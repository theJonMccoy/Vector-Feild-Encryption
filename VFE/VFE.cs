using System;
using System.Windows.Forms;

namespace VFE
{
    public partial class IOTP : Form
    {
        CubeData myCubeData;
        //  Cube myCube;

        public IOTP()
        {
            InitializeComponent();
            Inti();
        }

        void Inti()
        {
            string file_codebook = Properties.Settings.Default["ENC_File_codebook"].ToString();
            string file_vec = Properties.Settings.Default["ENC_File_vec"].ToString();
            if (file_codebook == string.Empty)
                file_codebook = Application.StartupPath + "\\codebook.iotp";
            if (file_vec == string.Empty)
                file_vec = Application.StartupPath + "\\vec.iotp";

            tb_CookbookFilePath.Text = file_codebook;
            tb_vecFilePath.Text = file_vec;
           
            myCubeData = new CubeData();
            myCubeData.LoadFile(tb_CookbookFilePath.Text, tb_vecFilePath.Text);

            LoadUserSetting();
            //     myCube = new Cube(myCubeData);
        }
        void LoadUserSetting()
        {
            try
            {
                object s = Properties.Settings.Default["enc_FileSet"];
                if (s != string.Empty)
                    Set4EncFile(s.ToString());

            }
            catch { }
        }
        private void bn_makeVecFile_Click(object sender, EventArgs e)
        {
            var file = tb_CookbookFilePath.Text;
            file = openFile(file, "vector.iotp", false);
            if (file != string.Empty)
            {
                tb_vecFilePath.Text = file;
                Support.MakeRandomFile_big(tb_vecFilePath.Text, (ulong)(16777216 * 3));
                Inti();
            }
        }
        private void bn_makeCookbookFile_Click(object sender, EventArgs e)
        {
            var file = tb_CookbookFilePath.Text;
            file = openFile(file, "codebook.iotp", false);
            if (file != string.Empty)
            {
                tb_CookbookFilePath.Text = file;
                Support.MakeRandomFile_big(tb_CookbookFilePath.Text, 16777216);
                Inti();
            }
        }

        private void bn_4enc_FindFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            string file = Properties.Settings.Default["enc_FileSet"].ToString();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (file != string.Empty)
                {
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(file);
                }
                else
                    openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Set4EncFile(openFileDialog.FileName);
                    Properties.Settings.Default["enc_FileSet"] = openFileDialog.FileName;
                    Properties.Settings.Default.Save(); // Saves settings in application configuration file
                }
            }
        }

        void Set4EncFile(string inputFile)
        {
            tb_4enc_inputFile.Text = inputFile;


            tb_4enc_outputFile_enc.Text = inputFile + "_enc";

            inputFile = inputFile.Substring(0, inputFile.Length - 4) + "_dec" + inputFile.Substring(inputFile.Length - 4);
            tb_4enc_outputFile_dec.Text = inputFile;
        }

        private void bn_5enc_encScan_Click(object sender, EventArgs e)
        {
            progressBar_4enc_encBar.Value = 0;
            lb_enc_Speed.Text = "0";
            lb_enc_time.Text = "0";

            System.Windows.Forms.Timer Tic = new Timer();
            EventHandler E = (object sender2, System.EventArgs e2) =>
            {
                progressBar_4enc_encBar.Value = VFE.ThreadWrapper.progress;
                lb_enc_Speed.Text = VFE.ThreadWrapper.speed.ToString();
                lb_enc_time.Text = VFE.ThreadWrapper.time.ToString(@"hh\:mm\:ss\.ff");
                if (VFE.ThreadWrapper.progress == 100)
                {
                    Tic.Stop();
                    progressBar_4enc_encBar.Value = 100;
                }
            };
            Tic.Tick += E;

            System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_inputFile.Text);
            System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);


            VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorPathEncryption.Encrypt);
            VFE.ThreadWrapper.RunThread_encrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
            Tic.Start();
        }

        private void bn_5enc_decScan_Click(object sender, EventArgs e)
        {
            progressBar_4enc_decBar.Value = 0;
            lb_dec_speed.Text = "0";
            lb_dec_time.Text = "0";

            System.Windows.Forms.Timer Tic = new Timer();
            EventHandler E = (object sender2, System.EventArgs e2) =>
            {
                progressBar_4enc_decBar.Value = VFE.ThreadWrapper.progress;
                lb_dec_speed.Text = VFE.ThreadWrapper.speed.ToString();
                lb_dec_time.Text = VFE.ThreadWrapper.time.ToString(@"hh\:mm\:ss\.ff");
                if (VFE.ThreadWrapper.progress == 100)
                {
                    Tic.Stop();
                    progressBar_4enc_decBar.Value = 100;
                }
            };
            Tic.Tick += E;

            System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);
            System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_dec.Text);

            VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorPathEncryption.Decrypt);
            VFE.ThreadWrapper.RunThread_decrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
            Tic.Start();
        }

        private void bn_5enc_encDec_streams_Click(object sender, EventArgs e)
        {
            UI_Encrypt();
            UI_Decrypt();
        }

        private void bn_5enc_Dec_streams_Click(object sender, EventArgs e)
        {
            tb_output.Text = "Decrypting";
            this.Update();
            UI_Decrypt();

        }

        void UI_Encrypt()
        {
            string inputText = tb_plainText.Text;
            string outputText = string.Empty;
            string outputTextRaw = string.Empty;
            try
            {
                System.IO.MemoryStream ms_input = new System.IO.MemoryStream();
                System.IO.StreamWriter Sw = new System.IO.StreamWriter(ms_input);
                Sw.Write(inputText);
                Sw.Flush();
                ms_input.Position = 0;

                System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

                VectorPathEncryption.Encrypt(ms_input, ms_output, myCubeData, null);


                byte[] outData = ms_output.ToArray(); // CubeData.ConvertFromVector(outputEncrypted)
                outputText = Convert.ToBase64String(outData);
                outputTextRaw += string.Join(System.Environment.NewLine, outData);


                ms_input.Dispose();
                ms_output.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
                outputText = "ERROR #dufgvf";
            }
            finally
            {
                tb_encryptedText.Text = outputText;
                tb_enc1_encryptedTextRaw.Text = outputTextRaw;
            }
        }
        void UI_Decrypt()
        {
            string inputText2 = tb_encryptedText.Text;
            string outputText2 = string.Empty;
            try
            {
                byte[] dataIN = Convert.FromBase64String(inputText2);

                System.IO.MemoryStream ms_inpt = new System.IO.MemoryStream(dataIN);

                System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

                VectorPathEncryption.Decrypt(ms_inpt, ms_output, myCubeData, null);

                System.IO.StreamReader reader = new System.IO.StreamReader(ms_output);
                ms_output.Flush();
                ms_output.Position = 0;
                outputText2 = reader.ReadToEnd();

                ms_inpt.Dispose();
                ms_output.Dispose();
            }
            //catch (System.Exception ex)
            //{
            //    throw ex;
            //    outputText2 = "ERROR #dufgvf";
            //}
            finally
            {
                tb_output.Text = outputText2;
            }
        }

        private void tb_CodebookFilePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ENC_File_codebook"] = tb_CookbookFilePath.Text;
            Properties.Settings.Default.Save();
        }

        private void tb_vecFilePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ENC_File_vec"] = tb_vecFilePath.Text;
            Properties.Settings.Default.Save();
        }

        private void bn_findfile_codebook_Click(object sender, EventArgs e)
        {
            var file = tb_CookbookFilePath.Text;
            file = openFile(file, "codebook.iotp", true);
            if (file != string.Empty)
            {
                tb_CookbookFilePath.Text = file;
                Inti();
            }
        }

        private void bn_findfile_vec_Click(object sender, EventArgs e)
        {
            var file = tb_vecFilePath.Text;
            file = openFile(file, "vector.iotp", true);
            if (file != string.Empty)
            {
                tb_vecFilePath.Text = file;
                Inti();
            }
        }
        string openFile(string file, string defaultFileName, bool forceCheckFile)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open "+defaultFileName;
                if (file != string.Empty)
                {
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(file);
                }
                else
                    openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "iotp files (*.iotp)|*.iotp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;
                openFileDialog.FileName = defaultFileName;
                openFileDialog.CheckFileExists = forceCheckFile;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    //  Set4EncFile(openFileDialog.FileName);
                    return openFileDialog.FileName;
                    //     Properties.Settings.Default.Save(); // Saves settings in application configuration file
                }
                else
                return "";
            }
        }
    }
}