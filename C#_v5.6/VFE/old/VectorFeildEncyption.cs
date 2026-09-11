//using System;

//namespace VFE
//{
//    static public class VectorFeildEncyption
//    {
//        static public byte[] Encrypt(byte[] input, CubeData cube)
//        {
//            System.IO.MemoryStream streamIN = new System.IO.MemoryStream(input);
//            System.IO.MemoryStream streamOut = new System.IO.MemoryStream();
//            try
//            {
//                Encrypt(streamIN, streamOut, cube, null);

//                return streamOut.ToArray();
//            }
//            finally
//            {
//                streamIN.Dispose();
//                streamOut.Dispose();
//            }
//        }

//        static public void Encrypt(System.IO.Stream dataIN, System.IO.Stream dataOut, CubeData cube, Action cleanUP)
//        {
//            System.IO.BinaryReader br = new System.IO.BinaryReader(dataIN);
//            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(dataOut);

//            Run_Streams(br, bw, cube, cleanUP);
//        }

//        static public byte[] DecryptRaw(byte[] input, CubeData cube)
//        {
//            System.IO.MemoryStream streamIN = new System.IO.MemoryStream(input);
//            System.IO.MemoryStream streamOut = new System.IO.MemoryStream();
//            try
//            {

//                Decrypt(streamIN, streamOut, cube, null);

//                return streamOut.ToArray();
//            }
//            finally
//            {
//                streamIN.Dispose();
//                streamOut.Dispose();
//            }
//        }

//        static public void Decrypt(System.IO.Stream dataIN, System.IO.Stream dataOut, CubeData cube, Action cleanUP)
//        {
//            System.IO.BinaryReader br = new System.IO.BinaryReader(dataIN);
//            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(dataOut);

//            UnRun_Stream(br, bw, cube, cleanUP);
//        }

//        static void Mixer(byte[] dataIN)
//        {
//            // this is a weak input text mixxer
//            // this is just a place holder
//            for (int i = 0; i < dataIN.Length; i++)
//            {
//                dataIN[i] ^= (byte)(55);
//            }
//        }

//        static void Run_Streams(System.IO.BinaryReader br, System.IO.BinaryWriter bw, CubeData myCube, Action cleanUP)
//        {
//            try
//            {
//                Support.Vector initVector = new Support.Vector { x = 0, y = 0, z = 0 };
//                byte offSet = 0;
//                byte messageUID;

//                Support.Vector tempTarget;
//                byte typeByte;

//                byte paddingSize = Support.Ran_get(2, 5);

//                byte lastPad = 0;

//                for (int i = 0; i <= paddingSize; i++)
//                {
//                    if (i >= paddingSize)
//                        typeByte = lastPad;
//                    else
//                    {
//                        do
//                        {
//                            typeByte = Support.Ran;
//                        } while (typeByte == lastPad);
//                    }

//                    lastPad = typeByte;

//                    typeByte ^= offSet;

//                    tempTarget = myCube.LookJump(typeByte, initVector);
//                    //tempTarget = myCube.Look(typeByte, initVector);

//                    bw.Write(tempTarget.ToBytes());

//                    initVector += myCube.myVectorFeild[initVector.x, initVector.y, initVector.z] ^ offSet;
//                    offSet += myCube.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }

//                Support.Vector v = new Support.Vector { x = Support.Ran, y = Support.Ran, z = Support.Ran };
//                bw.Write(v.ToBytes());
//                initVector ^= v;

//                byte new_offSet = Support.Ran;
//                offSet += new_offSet;
//                messageUID = Support.Ran_notSmall;
//                var r = new Support.Vector() { x = new_offSet, y = messageUID, z = Support.Ran };
//                bw.Write(r.ToBytes());

//                for (int i = 0; i < messageUID; i++)
//                {
//                    initVector += myCube.myVectorFeild[initVector.x, initVector.y, initVector.z] ^ offSet;
//                    offSet += myCube.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }

//                while (br.BaseStream.Length > br.BaseStream.Position)
//                {
//                    typeByte = br.ReadByte();
//                    typeByte ^= offSet;

//                    tempTarget = myCube.LookJump(typeByte, initVector);
//                    //tempTarget = myCube.Look(typeByte, initVector);

//                    bw.Write(tempTarget.ToBytes());
//                    initVector += myCube.myVectorFeild[initVector.x, initVector.y, initVector.z] ^ offSet;
//                    offSet += myCube.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }
//            }
//            finally
//            {
//                if (cleanUP != null)
//                    cleanUP();
//            }
//        }

//        static void UnRun_Stream(System.IO.BinaryReader br, System.IO.BinaryWriter bw, CubeData cubeIN, Action cleanUP)
//        {
//            try
//            {
//                Support.Vector initVector = new Support.Vector { x = 0, y = 0, z = 0 };
//                byte offSet = 0;
//                byte messageUID;
//                byte typeByte;

//                bool paddingActive = true;

//                byte lastPad = 0;
//                Support.Vector jumpVector;

//                while (paddingActive)
//                {
//                    jumpVector = CubeData.ReadVector(br);
//                    typeByte = cubeIN.Location_Jump(initVector,ref jumpVector);
//                    //typeByte = cubeIN.Location(v + initVector);
//                    typeByte ^= offSet;

//                    if (typeByte == lastPad)
//                    {
//                        paddingActive = false;
//                    }
//                    else
//                        lastPad = typeByte;


//                    initVector += cubeIN.myVectorFeild[jumpVector.x, jumpVector.y, jumpVector.z] ^ offSet;
//                    offSet += cubeIN.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }

//                initVector ^= CubeData.ReadVector(br);

//                Support.Vector v2 = CubeData.ReadVector(br);

//                offSet += v2.x;
//                messageUID = v2.y;

//                for (int i = 0; i < messageUID; i++)
//                {
//                    initVector += cubeIN.myVectorFeild[initVector.x, initVector.y, initVector.z] ^ offSet;
//                    offSet += cubeIN.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }

            
//                while (br.BaseStream.Length > br.BaseStream.Position)
//                {
//                    jumpVector = CubeData.ReadVector(br);
//                    typeByte = cubeIN.Location_Jump(initVector,ref jumpVector);
//                    //typeByte = cubeIN.Location(tempTarget + initVector);
//                    typeByte ^= offSet;

//                    bw.Write(typeByte);
//                    initVector += cubeIN.myVectorFeild[jumpVector.x, jumpVector.y, jumpVector.z] ^ offSet;
//                    offSet += cubeIN.myMatrix[initVector.z ^ offSet, initVector.y, initVector.x];
//                }
//            }
//            finally
//            {
//                if (cleanUP != null)
//                    cleanUP();
//            }
//        }
//    }
//}