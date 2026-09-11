namespace VFE
{
public partial    class Support
    {
       #region vector
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1, Size = 6, CharSet = System.Runtime.InteropServices.CharSet.None)]
        public struct Vector
        {
            public byte x;
            public byte y;
            public byte z;

            public Vector(byte xIN, byte yIN, byte zIN)
            {
                x = xIN;
                y = yIN;
                z = zIN;
            }
            public static Vector operator +(Vector v1, Vector v2)
            {
                v1.x += v2.x;
                v1.y += v2.y;
                v1.z += v2.z;
                return v1;
            }
            public static Vector operator ^(Vector v1, Vector v2)
            {
                v1.x ^= v2.x;
                v1.y ^= v2.y;
                v1.z ^= v2.z;
                return v1;
            }
            public static Vector operator ^(Vector v1, byte offset)
            {
                v1.x ^= offset;
                v1.y ^= offset;
                v1.z ^= offset;
                return v1;
            }
            public static Vector operator ++(Vector v1)
            {
                v1.x++;
                if (v1.x == 0)
                {
                    v1.y++;
                    if (v1.y == 0)
                    {
                        v1.z++;
                        if (v1.z == 0)
                        {

                            v1.x = 0;
                            v1.y = 0;
                            v1.z = 0;

                        }
                    }
                }
                return v1;
            }
            public override string ToString()
            {
                return x.ToString() + ',' + y.ToString() + ',' + z.ToString();
            }
            public byte[] ToBytes()
            {
                byte[] b = new byte[3];
                b[0] = x;
                b[1] = y;
                b[2] = z;
                return b;
            }
        }
        #endregion


    }
}
