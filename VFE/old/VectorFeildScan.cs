//using System;

//namespace VFE
//{
//    static public class VectorFeildScan
//    {
//        static public VFE.Support.Vector[] ScanDataPath(string textIN, VFE.CubeData myCube)
//        {
//            return ScanDataPath(System.Text.Encoding.ASCII.GetBytes(textIN), myCube);
//        }

//        static public VFE.Support.Vector[] ScanDataPath(byte[] textIN, VFE.CubeData myCube)
//        {
//            Support.Vector indexLocation = new Support.Vector(0, 0, 0);
//            Support.Vector offSetLocation = new Support.Vector(0, 0, 0);
//            Support.Vector indexLocationTemp = new Support.Vector(0, 0, 0);

//            Support.Vector[] outData = new Support.Vector[2];
//            Support.Vector jumpLocation;
//            Support.Vector jumpOffSetLocation;
//            bool found = false;
//            ushort index;
        
            
//            for (int i_offset = 0; i_offset < 255 * 255 * 255 && found==false; i_offset++)
//            {
//                offSetLocation.z++;
//                indexLocation = new Support.Vector(0, 0, 0);

//                for (int i = 0;  i< 255 * 255 * 255 && found == false; i++)
//                {
//                    byte target = (byte)(textIN[0]);

//                    indexLocation++;
//                        indexLocation += myCube.Look(target, indexLocation);
                   
//                    jumpOffSetLocation = offSetLocation;
//                    jumpLocation = indexLocation;

//                    index = 1;
//                    while (true)
//                    {
//                        if (textIN.Length == index)
//                        {
//                            found = true;
//                            break;
//                        }

//                        if (myCube.CheckAtLocation(jumpLocation + jumpOffSetLocation, (byte)(textIN[index])))
//                        {
//                            index++;
//                            jumpLocation = myCube.GetVectorAtLocation(jumpLocation+ jumpOffSetLocation);
//                        }
//                        else
//                            break;
//                    }
//                }
//            }

//            if (found)
//            {
//                outData[0] = indexLocation;
//                outData[1] = offSetLocation;
//            }
//            else
//            {
//                outData[0] = new Support.Vector();
//                outData[1] = new Support.Vector();
//            }
//            return outData;
//        }

//        static public VFE.Support.Vector[] FindDataPath(string textIN, VFE.CubeData myCube)
//        {
//            return FindDataPath(System.Text.Encoding.ASCII.GetBytes(textIN), myCube);
//        }

//        static public VFE.Support.Vector[] FindDataPath(byte[] textIN, VFE.CubeData myCube)
//        {
//            VFE.Support.Vector[] outData = new Support.Vector[textIN.Length];
//            Support.Vector indexLocation = new Support.Vector(0, 0, 0);
//            Support.Vector indexLocationTemp = new Support.Vector(0, 0, 0);

//            ushort index = 0;
//            foreach (byte b in textIN)
//            {
//                indexLocationTemp = myCube.Look(b, indexLocation);
//                outData[index++] = indexLocationTemp;
//                indexLocation += indexLocationTemp;
//            }

//            return outData;
//        }

//        static public byte[] RunDataPath(string textIN, VFE.CubeData myCube)
//        {
//            var inputTextRaw = Convert.FromBase64String(textIN);
//            return RunDataPath(inputTextRaw, myCube);
//        }

//        static public byte[] RunDataPath(byte[] textIN, VFE.CubeData myCube)
//        {
//            Support.Vector[] vectors = CubeData.ConvertToVector(textIN);

//            return RunDataPath(vectors, myCube);
//        }

//        static public byte[] RunDataPath(Support.Vector[] vectorsIN, VFE.CubeData myCube)
//        {
//            Support.Vector indexLocation = new Support.Vector(0, 0, 0);
//            byte[] outData = new byte[vectorsIN.Length];

//            ushort index = 0;
//            foreach (Support.Vector v in vectorsIN)
//            {
//                indexLocation = myCube.GetVectorAtLocation(v);
//                myCube.GetAtLocation(indexLocation);
//                outData[index++] = myCube.GetAtLocation(indexLocation);
//            }

//            return outData;
//        }

//        static public byte[] PullDataPath(string textIN, VFE.CubeData myCube)
//        {
//            var inputTextRaw = Convert.FromBase64String(textIN);
//            return PullDataPath(inputTextRaw, myCube);
//        }

//        static public byte[] PullDataPath(byte[] textIN, VFE.CubeData myCube)
//        {
//            Support.Vector[] vectors = CubeData.ConvertToVector(textIN);
//            return PullDataPath(vectors, myCube);
//        }

//        static public byte[] PullDataPath(Support.Vector[] vectorsIN, VFE.CubeData myCube)
//        {
//            int messageSize = vectorsIN.Length;
//            Support.Vector indexLocation = new Support.Vector();
//            byte[] outData = new byte[messageSize];

//            ushort index = 0;
//            for (int i = 0; i < messageSize; i++)
//            {
//                indexLocation += vectorsIN[i];

//                outData[index++] = myCube.GetAtLocation(indexLocation);
//            }

//            return outData;
//        }
//    }
//}