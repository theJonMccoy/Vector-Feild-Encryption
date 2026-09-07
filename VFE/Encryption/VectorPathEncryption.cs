using System;

namespace VFE
{
    static public class VectorPathEncryption
    {
        static public byte[] Encrypt(byte[] input, CubeData cube)
        {
            System.IO.MemoryStream streamIN = new System.IO.MemoryStream(input);
            System.IO.MemoryStream streamOut = new System.IO.MemoryStream();
            try
            {
                Encrypt(streamIN, streamOut, cube, null);

                return streamOut.ToArray();
            }
            finally
            {
                streamIN.Dispose();
                streamOut.Dispose();
            }
        }

        static public void Encrypt(System.IO.Stream dataIN, System.IO.Stream dataOut, CubeData cube, Action cleanUP)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(dataIN);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(dataOut);

            Run_Streams(br, bw, cube, cleanUP);
        }

        static public byte[] DecryptRaw(byte[] input, CubeData cube)
        {
            System.IO.MemoryStream streamIN = new System.IO.MemoryStream(input);
            System.IO.MemoryStream streamOut = new System.IO.MemoryStream();
            try
            {

                Decrypt(streamIN, streamOut, cube, null);

                return streamOut.ToArray();
            }
            finally
            {
                streamIN.Dispose();
                streamOut.Dispose();
            }
        }

        static public void Decrypt(System.IO.Stream dataIN, System.IO.Stream dataOut, CubeData cube, Action cleanUP)
        {
            System.IO.BinaryReader br = new System.IO.BinaryReader(dataIN);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(dataOut);

            UnRun_Stream(br, bw, cube, cleanUP);
        }

        static void Mixer(byte[] dataIN)
        {
            // this is a weak input text mixxer
            // this is just a place holder
            for (int i = 0; i < dataIN.Length; i++)
            {
                dataIN[i] ^= (byte)(55);
            }
        }

        static void Run_Streams(System.IO.BinaryReader br, System.IO.BinaryWriter bw, CubeData cubeIN, Action cleanUP)
        {
            try
            {
                Support.Vector lastVector = new Support.Vector(1, 1, 1);
                Support.Vector initVector = new Support.Vector { x = 0, y = 0, z = 0 };
                byte offSet = 0;
                byte messageUID;
                byte inByte;

                // IV select a random location
                {
                    byte paddingSize = Support.Ran_notSmall;
                    byte lastPad = 0;
                    for (int i = 0; i <= paddingSize; i++)
                    {
                        if (i == paddingSize)
                            inByte = lastPad;
                        else
                        {
                            do
                            {
                                inByte = Support.Ran;
                            } while (inByte == lastPad);
                            lastPad = inByte;
                        }

                        PutChar(inByte, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    }
                }

                // select a random init vector
                // select a random offSet
                {
                    Support.Vector v = new Support.Vector { x = Support.Ran, y = Support.Ran, z = Support.Ran };
                    PutChar(v.x, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    PutChar(v.y, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    PutChar(v.z, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    initVector ^= v;

                    byte new_offSet = Support.Ran;
                    PutChar(new_offSet, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    offSet ^= new_offSet;
                }

                // use a random message ID
                {
                    messageUID = Support.Ran_notSmall;
                    PutChar(messageUID, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                  
                   
                    for (int i = 0; i < messageUID; i++)
                    {
                        initVector ^= cubeIN.Location_Vector(initVector, offSet);
                        offSet ^= cubeIN.Location_Data_mix(initVector, offSet);
                    }
                }

                try
                {
                    // Procress each byte until exception at the end
                    while (true)
                    {
                        inByte = br.ReadByte();
                        PutChar(inByte, bw, cubeIN, ref initVector, ref lastVector, ref offSet);
                    }
                }
                catch (System.IO.EndOfStreamException)
                {
                    // this is expected
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Encryption Stream Error #g4w45gh4", "Encryption Stream Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                //   throw new Exception("Decryption Stream Error #oi8ghd8");
            }
            finally
            {
                if (cleanUP != null)
                    cleanUP();
            }
        }

        static void UnRun_Stream(System.IO.BinaryReader br, System.IO.BinaryWriter bw, CubeData cubeIN, Action cleanUP)
        {
            try
            {
                Support.Vector initVector = new Support.Vector { x = 0, y = 0, z = 0 };
                Support.Vector lastVector = new Support.Vector(1, 1, 1);
                byte offSet = 0;
                byte messageUID;
                byte outByte;

                // IV select a random location
                {
                    bool paddingActive = true;
                    byte lastPad = 0;
                    while (paddingActive)
                    {
                        outByte = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);

                        if (outByte == lastPad)
                            paddingActive = false;
                        else
                            lastPad = outByte;
                    }
                }

                // select a random init vector
                // select a random offSet
                {
                    byte temp_x = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                    byte temp_y = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                    byte temp_z = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                    initVector ^= new Support.Vector(temp_x, temp_y, temp_z);
              
                    byte tempOffSet = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                    offSet ^= tempOffSet;
                }

                // use a random message ID
                {
                    messageUID = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                    for (int i = 0; i < messageUID; i++)
                    {
                        initVector ^= cubeIN.Location_Vector(initVector, offSet);
                        offSet ^= cubeIN.Location_Data_mix(initVector, offSet);
                    }
                }

                try
                {
                    // Procress each byte until exception at the end
                    while (true)
                    {
                        outByte = PullChar(br, cubeIN, ref initVector, ref lastVector, ref offSet);
                        bw.Write(outByte);
                    }
                }
                catch { }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Decryption Stream Error #oi8ghd8", "Decryption Stream Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
             //   throw new Exception("Decryption Stream Error #oi8ghd8");
            }
            finally
            {
                if (cleanUP != null)
                    cleanUP();
            }
        }

        static void PutChar(byte inByte, System.IO.BinaryWriter bw, CubeData cubeIN, ref Support.Vector initVector, ref Support.Vector lastVector, ref byte offSet)
        {
            byte outIndex;
            inByte ^= offSet;

            do
            {
                outIndex = cubeIN.ScanPath(inByte, initVector, ref lastVector);
                bw.Write(outIndex);

                //      lastVector ^= initVector;
                initVector ^= cubeIN.Location_Vector(lastVector, offSet)^ initVector;
                offSet ^= cubeIN.Location_Data_mix(lastVector, offSet);
            } while (outIndex == 0);

            lastVector = initVector ^ inByte;
        }

        static byte PullChar(System.IO.BinaryReader br, CubeData cubeIN, ref Support.Vector initVector, ref Support.Vector lastVector, ref byte offSet)
        {
            byte inByte;
            byte outByte;
            byte temp_offSet = offSet;

            do
            {
                    inByte = br.ReadByte();
               
                outByte = cubeIN.ScanPathFollow(inByte, initVector, ref lastVector);

                //        lastVector ^= initVector;
                initVector ^= cubeIN.Location_Vector(lastVector, offSet)^ initVector;
                offSet ^= cubeIN.Location_Data_mix(lastVector, offSet);
            } while (inByte == 0);

            lastVector = initVector ^ outByte;
            outByte ^= temp_offSet;

            return outByte;
        }
    }
}