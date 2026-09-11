using System;

namespace VFE
{
    public static class ThreadWrapper
    {
        public static int progress = 0;
        public static double speed = 0;
        public static TimeSpan time = TimeSpan.Zero;
        
        public static void RunThread_encrypt(System.IO.FileInfo filePathIN, System.IO.FileInfo filePathOUT, VFE.CubeData cubeIN, System.Windows.Forms.Timer Tic, VFE.Support.Crypter encryptionType)
        {
            progress = 0;
            System.Threading.ThreadStart TS = new System.Threading.ThreadStart(() =>
            {
                Enc(filePathIN, filePathOUT, cubeIN, Tic,encryptionType);
            });

            System.Threading.Thread T = new System.Threading.Thread(TS);
            T.IsBackground = true;
            T.Start();
        }

        public static void RunThread_decrypt(System.IO.FileInfo filePathIN, System.IO.FileInfo filePathOUT, VFE.CubeData cubeIN, System.Windows.Forms.Timer Tic, VFE.Support.Crypter decryptionType)
        {
            progress = 0;
            System.Threading.ThreadStart TS = new System.Threading.ThreadStart(() =>
            {
                Dec(filePathIN, filePathOUT, cubeIN, Tic,decryptionType);
            });

            System.Threading.Thread T = new System.Threading.Thread(TS);
            T.IsBackground = true;
            T.Start();
        }

        static void Enc(System.IO.FileInfo filePathIN, System.IO.FileInfo filePathOUT, VFE.CubeData cubeIN, System.Windows.Forms.Timer Tic, VFE.Support.Crypter encryptionType)
        {
            System.IO.FileStream fileStreamIN = new System.IO.FileStream(filePathIN.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream fileStreamOUT = new System.IO.FileStream(filePathOUT.FullName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            DateTime LastUpdate=DateTime.Now;
            long PrevBytes=0;
            DateTime startTime = DateTime.Now;
            Tic.Tick += (object sender2, System.EventArgs e2) =>
            {
                if (progress != 100)
                {
                    try { 
                    // progress
                    progress = (int)(fileStreamIN.Position * 100.0 / fileStreamIN.Length);

                    //Speed
               //     var msElapsed = DateTime.Now - LastUpdate;

                    int curBytes = (int)(fileStreamIN.Position - PrevBytes);
                    PrevBytes = (int)fileStreamIN.Position;

                        speed = curBytes;// ((double)curBytes) / msElapsed.TotalSeconds;

                    time = DateTime.Now - startTime;
                    }
                    catch
                    {
                        progress = 100;
                    }
                }
            };

            Action cleanUP = () =>
            {
                progress = 100;
                System.Threading.Thread.Sleep(5);

                fileStreamIN.Close();
                fileStreamIN.Dispose();
                fileStreamOUT.Close();
                fileStreamOUT.Dispose();
            };

            encryptionType(fileStreamIN, fileStreamOUT, cubeIN, cleanUP);
        }

        static void Dec(System.IO.FileInfo filePathIN, System.IO.FileInfo filePathOUT, VFE.CubeData cubeIN, System.Windows.Forms.Timer Tic, VFE.Support.Crypter decryptionType)
        {
            System.IO.FileStream fileStreamIN = new System.IO.FileStream(filePathIN.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream fileStreamOUT = new System.IO.FileStream(filePathOUT.FullName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            DateTime LastUpdate = DateTime.Now;
            long PrevBytes = 9;
            DateTime startTime = DateTime.Now;

            Tic.Tick += (object sender2, System.EventArgs e2) =>
            {
                if (progress != 100)
                {
                    try
                    {
                        // progress
                        progress = (int)(fileStreamIN.Position * 100.0 / fileStreamIN.Length);

                        //Speed
                    //    var msElapsed = DateTime.Now - LastUpdate;

                        int curBytes = (int)(fileStreamIN.Position - PrevBytes);
                        PrevBytes = (int)fileStreamIN.Position;

                        speed = curBytes;// ((double)curBytes) / msElapsed.TotalSeconds;

                        time = DateTime.Now - startTime;
                    }
                    catch 
                    {
                        progress = 100;
                    }
                    }
            };

            Action cleanUP = () =>
            {
                progress = 100;
                System.Threading.Thread.Sleep(5);

                fileStreamIN.Close();
                fileStreamIN.Dispose();
                fileStreamOUT.Close();
                fileStreamOUT.Dispose();
            };

            decryptionType(fileStreamIN, fileStreamOUT, cubeIN, cleanUP);
        }
    }
}