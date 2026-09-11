namespace VFE
{
    public partial class  Support
    {

        public delegate void Crypter(System.IO.Stream dataIN, System.IO.Stream dataOut, CubeData cube, System.Action cleanUP);

        static System.Security.Cryptography.RandomNumberGenerator R = System.Security.Cryptography.RandomNumberGenerator.Create();
        static byte[] TempRanArray = new byte[1024];
        static ushort index;

        static Support()
        {
            LoadRan();
        }

        static void LoadRan()
        {
            System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(TempRanArray);
            index = (ushort)(TempRanArray.Length - 1);
        }

        static byte NextRan()
        {
            return NextRan(0);
        }

        static byte NextRan(byte min)
        {
            byte output = TempRanArray[index--];

            if (index == 0)
                LoadRan();

            if (output < min)
                output = NextRan(min);

            return output;
        }

        static public byte Ran
        {
            get
            {
                return NextRan(0);
            }
        }

        static public Vector RanVector
        {
            get
            {
                return new Vector(Ran, Ran, Ran);
            }
        }

        static public byte Ran_notZero
        {
            get
            {
                return NextRan(1);
            }
        }

        static public byte Ran_get(byte min, byte max)
        {
                int big = max;
                byte output;
                while (true)
                {
                   output=NextRan(min);
                    if (output <= big)
                        return output;
                }
            
        }
        static public byte Ran_notSmall
        {
            get
            {
                return NextRan(10);
            }
        }

        static public void FillArrayRandom(in byte[] array)
        {
            System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(array);
        }

        static public void MakeRandomFile(string pathIN)
        {
            Support.MakeRandomFile(pathIN, 256 * 256 * 256);
        }

        static public void MakeRandomFile(string pathIN, int size)
        {
            var f = System.IO.File.Create(pathIN);
            byte[] empty = new byte[size];

            Support.FillArrayRandom(empty);
            f.Write(empty, 0, size);
            f.Close();
        }

        static public void MakeRandomFile_big(string pathIN, ulong size)
        {
            var f = System.IO.File.Create(pathIN);
            ulong tempSize = size;
            int useSize;
            while (size > 0)
            {
                if (tempSize > int.MaxValue)
                    useSize = int.MaxValue;
                else
                    useSize = (int)size;

                size -= tempSize;

                byte[] empty = new byte[useSize];

                Support.FillArrayRandom(empty);
                f.Write(empty, 0, useSize);
            }
            f.Close();
        }

        public static System.IO.Stream GenerateStreamFromString(string s)
        {
            var stream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}