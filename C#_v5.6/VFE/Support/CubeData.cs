using System;

namespace VFE
{
    #region CubeData
    public class CubeData
    {
        #region vars
        Support.Vector[,,] myVectorFeild;
        byte[,,] myMatrix;
        #endregion ---vars---

        public Support.Vector GetVectorAtLocation(Support.Vector vectorIN)
        {
            return myVectorFeild[vectorIN.x, vectorIN.y, vectorIN.z];
        }

        public void LoadFile(string ranFilePathIN, string vectorFilePathIN)
        {
            try
            {
                SanityCheckFiles(ranFilePathIN, vectorFilePathIN);

                System.IO.FileInfo file = new System.IO.FileInfo(ranFilePathIN);
                byte[] array = System.IO.File.ReadAllBytes(ranFilePathIN);
                myMatrix = ConvertMatrix(array, 256, 256, 256);

                byte[] vectorFeildIN = System.IO.File.ReadAllBytes(vectorFilePathIN);
                myVectorFeild = ConvertVectorFeild(vectorFeildIN, 256, 256, 256);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error #7s8g", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        void SanityCheckFiles(string ranFilePathIN, string vectorFilePathIN)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(ranFilePathIN);

            if (!file.Directory.Exists)
                System.IO.Directory.CreateDirectory(file.Directory.FullName);

            if (!file.Exists)
            {
                Support.MakeRandomFile(ranFilePathIN, 16777216);
                Support.MakeRandomFile(vectorFilePathIN, 16777216 * 3);
            }
        }

        static byte[,,] ConvertMatrix(byte[] flat, int x, int y, int z)
        {
            if (flat.Length != x * y * z)
            {
                throw new ArgumentException("Invalid length");
            }
            byte[,,] ret = new byte[x, y, z];

            Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(byte));
            return ret;
        }

        static Support.Vector[,,] ConvertVectorFeild(byte[] flat, int x, int y, int z)
        {
            if (flat.Length != x * y * z * 3)
            {
                throw new ArgumentException("Invalid length");
            }
            Support.Vector[,,] ret = new Support.Vector[x, y, z];

            ulong index = 0;
            for (int i = 0; i < x; i++)
            {
                for (int i2 = 0; i2 < y; i2++)
                {
                    for (int i3 = 0; i3 < z; i3++)
                    {
                        ret[i, i2, i3] = new Support.Vector() { x = flat[index], y = flat[index + 1], z = flat[index + 2] };
                        index += 3;
                    }
                }
                ///Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * 12);
            }
            return ret;
        }

        public static byte[] ConvertFromVector(Support.Vector[] flat)
        {
            byte[] ret = new byte[flat.Length * 3];

            for (int i = 0; i < flat.Length; i++)
            {
                int at = i * 3;
                ret[at] = flat[i].x;
                ret[at + 1] = flat[i].y;
                ret[at + 2] = flat[i].z;
            }
            return ret;
        }

        public static Support.Vector[] ConvertToVector(byte[] flat)
        {
            Support.Vector[] ret = new Support.Vector[flat.Length / 3];

            for (int i = 0; i < flat.Length; i += 3)
            {
                int at = i / 3;
                ret[at] = new Support.Vector { x = flat[i], y = flat[i + 1], z = flat[i + 2] };
            }

            return ret;
        }

        public static Support.Vector ReadVector(System.IO.BinaryReader br)
        {
            return new Support.Vector { x = br.ReadByte(), y = br.ReadByte(), z = br.ReadByte() };
        }

        public Support.Vector Location_Vector(ushort x, ushort y, ushort z)
        {
            return myVectorFeild[x, y, z];
        }

        public Support.Vector Location_Vector(Support.Vector v)
        {
            return myVectorFeild[v.x, v.y, v.z];
        }
        public Support.Vector Location_Vector(Support.Vector v, byte offset)
        {
            return myVectorFeild[v.x, v.y, v.z] ^ offset;
        }

        public byte Location(ushort x, ushort y, ushort z)
        {
            return myMatrix[x, y, z];
        }

        public byte Location_Data(Support.Vector v)
        {
            return myMatrix[v.x, v.y, v.z];
        }
        public byte Location_Data_mix(Support.Vector v, byte offset)
        {
            return myMatrix[v.z ^ offset, v.y, v.x];
        }
        public bool Location_Data_Check(Support.Vector v, byte dataToCheck)
        {
            return dataToCheck == myMatrix[v.x, v.y, v.z];
        }

        public bool Location_Data_Check2(byte dataToCheck, Support.Vector lastVector, Support.Vector onVector)
        {
            Support.Vector v = Location_Vector(lastVector) ^ onVector;

            return dataToCheck == myMatrix[v.x, v.y, v.z];
        }
        public byte Location_Jump(Support.Vector initVector, ref Support.Vector jumpvector)
        {
            jumpvector = initVector ^ Location_Vector(initVector + jumpvector);
            return Location_Data(jumpvector);
        }

        public Support.Vector Look(byte dataIN, Support.Vector onVector)
        {
            Support.Vector diffVector = Support.RanVector;
            bool snap = false;
            while (true)
            {

                if (dataIN == Location_Data(onVector + diffVector))
                {
                    return diffVector;
                }
                else
                {
                    diffVector.x++;
                    if (diffVector.x == 0)
                    {
                        diffVector.y++;
                        if (diffVector.y == 0)
                        {
                            diffVector.z++;
                            if (diffVector.z == 0)
                            {
                                if (snap)
                                    throw new Exception("no found - snap #v97gssa");
                                else
                                {
                                    diffVector.x = 0;
                                    diffVector.y = 0;
                                    diffVector.z = 0;
                                    snap = true;
                                }
                            }
                        }
                    }
                }
            }

            return diffVector;
        }

        public Support.Vector LookJump(byte dataIN, Support.Vector onVector)
        {
            Support.Vector diffVector = Support.RanVector;
            bool snap = false;
            while (true)
            {
                if (dataIN == Location_Data(onVector ^ Location_Vector(onVector + diffVector)))
                {

                    return diffVector;
                }
                else
                {
                    diffVector.x++;
                    if (diffVector.x == 0)
                    {
                        diffVector.y++;
                        if (diffVector.y == 0)
                        {
                            diffVector.z++;
                            if (diffVector.z == 0)
                            {
                                if (snap)
                                    throw new Exception("no found - snap #v97gssa");
                                else
                                {
                                    diffVector.x = 0;
                                    diffVector.y = 0;
                                    diffVector.z = 0;
                                    snap = true;
                                }
                            }
                        }
                    }
                }
            }

            return diffVector;
        }

        public byte ScanPath(byte dataIN, Support.Vector onVector, ref Support.Vector lastVector)
        {
            byte index = 1;

            while (index != 0)
            {
                lastVector = myVectorFeild[lastVector.x, lastVector.y, lastVector.z] ^ onVector;
                //    lastVector = Location_Vector(lastVector) ^ onVector;

                //      if (Location_Data_Check(lastVector, dataIN))
                //        if ((dataIN ^ index) == myMatrix[lastVector.x, lastVector.y, lastVector.z])
                if (dataIN == myMatrix[lastVector.x, lastVector.y, lastVector.z])
                {
                    return index;
                }
                else
                {
                    index++;
                }
            }

            return index;
        }

        public byte ScanPathFollow(byte dataIN, Support.Vector onVector, ref Support.Vector tempVector)
        {
            if (dataIN == 0)
                dataIN = 255;

            //     byte index = dataIN;

            //  Support.Vector tempVector= lastVector;
            while (dataIN-- != 0)
            {
                //    tempVector = Location_Vector(tempVector) ^ onVector;
                tempVector = myVectorFeild[tempVector.x, tempVector.y, tempVector.z] ^ onVector;
            }
            //     lastVector = tempVector;

            return myMatrix[tempVector.x, tempVector.y, tempVector.z];
            //     return (byte)(myMatrix[tempVector.x, tempVector.y, tempVector.z] ^ index);
            //     return Location_Data(tempVector);
        }

        public byte GetAtLocation(Support.Vector onVector)
        {
            return Location_Data(onVector);
        }

        public bool CheckAtLocation(Support.Vector onVector, byte dataIN)
        {
            return Location_Data(onVector) == dataIN;
        }
    }
    #endregion ---CubeData---
}