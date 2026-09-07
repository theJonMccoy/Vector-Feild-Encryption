//using System;
//using System.Windows.Forms;

//namespace VFE
//{
//    public partial class IOTP : Form
//    {
//        CubeData myCubeData;
//        //  Cube myCube;

//        public IOTP()
//        {
//            InitializeComponent();
//            Inti();
//        }

//        void Inti()
//        {
//            tb_vecFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\IOTP\\ran.iotp";
//            tb_RanFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\IOTP\\vec.iotp";

//            myCubeData = new CubeData();
//            myCubeData.LoadFile(tb_RanFilePath.Text, tb_vecFilePath.Text);

//            LoadUserSetting();
//            //     myCube = new Cube(myCubeData);
//        }
//        void LoadUserSetting()
//        {
//            try
//            {
//                object s = Properties.Settings.Default["enc_FileSet"];
//                if (s != string.Empty)
//                    Set4EncFile(s.ToString());

//            }
//            catch { }
//        }
//        private void bn_makeVecFile_Click(object sender, EventArgs e)
//        {
//            Support.MakeRandomFile_big(tb_vecFilePath.Text, (ulong)(16777216 * 3));
//        }
//        private void bn_makeFile_Click(object sender, EventArgs e)
//        {
//            Support.MakeRandomFile(tb_RanFilePath.Text, 16777216);
//        }

//        private void bn_init_Click(object sender, EventArgs e)
//        {
//        }



//        private void bn_enc2_encryptDecrypt_Click(object sender, EventArgs e)
//        {
//            string inputText = tb_Enc2_plainText.Text;
//            string outputText = string.Empty;
//            string outputTextRaw = string.Empty;
//            try
//            {
//                var v = VFE.VectorFeildScan.FindDataPath(inputText, myCubeData);
//                byte[] a = CubeData.ConvertFromVector(v);
//                outputTextRaw = Convert.ToBase64String(a);
//                outputText = string.Join(System.Environment.NewLine, v);
//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//                outputText = "ERROR #dufgvf";
//            }
//            finally
//            {
//                tb_enc2_Encrypted.Text = outputText;
//                tb_enc2_encryptedTextRaw.Text = outputTextRaw;
//            }


//            // decrypt
//            string cypherText = tb_enc2_encryptedTextRaw.Text;

//            string outputText2 = string.Empty;
//            try
//            {
//                byte[] outputData = VFE.VectorFeildScan.PullDataPath(cypherText, myCubeData);
//                outputText2 = System.Text.Encoding.ASCII.GetString(outputData);
//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//                outputText2 = "ERROR #sahdjvf";
//            }
//            finally
//            {
//                tb_enc2_outputText.Text = outputText2;
//            }
//        }

//        private void bn_4enc_FindFile_Click(object sender, EventArgs e)
//        {
//            var fileContent = string.Empty;
//            var filePath = string.Empty;

//            using (OpenFileDialog openFileDialog = new OpenFileDialog())
//            {
//                if (tb_4enc_inputFile.Text != string.Empty)
//                {
//                    openFileDialog.InitialDirectory = new System.IO.DirectoryInfo(tb_4enc_inputFile.Text).FullName;
//                }
//                else
//                    openFileDialog.InitialDirectory = "c:\\";
//                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
//                openFileDialog.FilterIndex = 2;
//                openFileDialog.RestoreDirectory = true;

//                if (openFileDialog.ShowDialog() == DialogResult.OK)
//                {
//                    //Get the path of specified file
//                    Set4EncFile(openFileDialog.FileName);
//                    Properties.Settings.Default["enc_FileSet"] = openFileDialog.FileName;
//                    Properties.Settings.Default.Save(); // Saves settings in application configuration file
//                }
//            }
//        }

//        void Set4EncFile(string inputFile)
//        {
//            tb_4enc_inputFile.Text = inputFile;


//            tb_4enc_outputFile_enc.Text = inputFile + "_enc";

//            inputFile = inputFile.Substring(0, inputFile.Length - 4) + "_dec" + inputFile.Substring(inputFile.Length - 4);
//            tb_4enc_outputFile_dec.Text = inputFile;
//        }

//        private void bn_4enc_decryptFile_Click(object sender, EventArgs e)
//        {
//            //progressBar_4enc_decBar.Value = 0;

//            //System.Windows.Forms.Timer Tic = new Timer();
//            //EventHandler E = (object sender2, System.EventArgs e2) =>
//            //{
//            //    progressBar_4enc_decBar.Value = VFE.ThreadWrapper.progress;
//            //    if (VFE.ThreadWrapper.progress == 100)
//            //    {
//            //        Tic.Stop();
//            //        progressBar_4enc_decBar.Value = VFE.ThreadWrapper.progress;
//            //    }
//            //};
//            //Tic.Tick += E;

//            //System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);
//            //System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_dec.Text);

//            //VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorFeildEncyption.Decrypt);
//            //VFE.ThreadWrapper.RunThread_decrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
//            //Tic.Start();
//        }

//        private void bn_4enc_enc_Click(object sender, EventArgs e)
//        {
//            //progressBar_4enc_encBar.Value = 0;

//            //System.Windows.Forms.Timer Tic = new Timer();
//            //EventHandler E = (object sender2, System.EventArgs e2) =>
//            //{
//            //    progressBar_4enc_encBar.Value = VFE.ThreadWrapper.progress;
//            //    if (VFE.ThreadWrapper.progress == 100)
//            //    {
//            //        Tic.Stop();
//            //        progressBar_4enc_encBar.Value = VFE.ThreadWrapper.progress;
//            //    }
//            //};
//            //Tic.Tick += E;

//            //System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_inputFile.Text);
//            //System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);

//            //VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorFeildEncyption.Encrypt);
//            //VFE.ThreadWrapper.RunThread_encrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
//            //Tic.Start();
//        }

//        private void bn_1enc_encDec_streams_Click(object sender, EventArgs e)
//        {
//            //string inputText = tb_plainText.Text;
//            //string outputText = string.Empty;
//            //string outputTextRaw = string.Empty;
//            //try
//            //{
//            //    System.IO.MemoryStream ms_input = new System.IO.MemoryStream();
//            //    System.IO.StreamWriter Sw = new System.IO.StreamWriter(ms_input);
//            //    Sw.Write(inputText);
//            //    Sw.Flush();
//            //    ms_input.Position = 0;

//            //    System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

//            //    VectorFeildEncyption.Encrypt(ms_input, ms_output, myCubeData, null);

//            //    byte[] outData = ms_output.ToArray(); // CubeData.ConvertFromVector(outputEncrypted)
//            //    outputText = Convert.ToBase64String(outData);
//            //    outputTextRaw = string.Join(System.Environment.NewLine, CubeData.ConvertToVector(outData));


//            //    ms_input.Dispose();
//            //    ms_output.Dispose();

//            //}
//            //catch (System.Exception ex)
//            //{
//            //    throw ex;
//            //    outputText = "ERROR #dufgvf";
//            //}
//            //finally
//            //{
//            //    tb_encryptedText.Text = outputText;
//            //    tb_enc1_encryptedTextRaw.Text = outputTextRaw;
//            //}

//            //string inputText2 = tb_encryptedText.Text;
//            //string outputText2 = string.Empty;
//            //try
//            //{
//            //    byte[] dataIN = Convert.FromBase64String(inputText2);

//            //    System.IO.MemoryStream ms_inpt = new System.IO.MemoryStream(dataIN);

//            //    System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

//            //    VectorFeildEncyption.Decrypt(ms_inpt, ms_output, myCubeData, null);

//            //    System.IO.StreamReader reader = new System.IO.StreamReader(ms_output);
//            //    ms_output.Flush();
//            //    ms_output.Position = 0;
//            //    outputText2 = reader.ReadToEnd();

//            //    ms_inpt.Dispose();
//            //    ms_output.Dispose();
//            //}
//            //catch (System.Exception ex)
//            //{
//            //    throw ex;
//            //    outputText2 = "ERROR #dufgvf";
//            //}
//            //finally
//            //{
//            //    tb_output.Text = outputText2;
//            //}
//        }

//        private void bn_4enc_decFile2_Click(object sender, EventArgs e)
//        {
//            //progressBar_4enc_decBar.Value = 0;
//            //this.Update();

//            ////            string cypherText = tb_enc3_encryptedTextRaw.Text;
//            //byte[] inputData = System.IO.File.ReadAllBytes(tb_4enc_outputFile_enc.Text);

//            //byte[] output;
//            //try
//            //{
//            //    output = VFE.VectorFeildEncyption.DecryptRaw(inputData, myCubeData);
//            //    System.IO.File.WriteAllBytes(tb_4enc_outputFile_dec.Text, output);
//            //}
//            //catch (System.Exception ex)
//            //{
//            //    throw ex;
//            //    ///    outputText2 = "ERROR #sahdjvf";
//            //}
//            //finally
//            //{
//            //    //     tb_enc3_outputText.Text = outputText2;
//            //}

//            //progressBar_4enc_decBar.Value = 100;
//            //this.Update();

//        }

//        private void bn_4enc_encFile2_Click(object sender, EventArgs e)
//        {
//            //progressBar_4enc_encBar.Value = 0;
//            //this.Update();

//            //byte[] dataIN = System.IO.File.ReadAllBytes(tb_4enc_inputFile.Text);
//            //byte[] outputEncrypted = VFE.VectorFeildEncyption.Encrypt(dataIN, myCubeData);

//            //System.IO.File.WriteAllBytes(tb_4enc_outputFile_enc.Text, outputEncrypted);


//            /////       outputTextRaw = string.Join(System.Environment.NewLine, outputEncrypted);

//            ////    VFE.ThreadEncrypt.RunThread_encrypt(tb_4enc_inputFile.Text, tb_4enc_outputFile_enc.Text, myCubeData);
//            //progressBar_4enc_encBar.Value = 100;
//            //this.Update();

//        }

//        private void bn_5enc_encScan_Click(object sender, EventArgs e)
//        {
//            progressBar_4enc_encBar.Value = 0;
//            lb_enc_Speed.Text = "0";
//            lb_enc_time.Text = "0";

//            System.Windows.Forms.Timer Tic = new Timer();
//            EventHandler E = (object sender2, System.EventArgs e2) =>
//            {
//                progressBar_4enc_encBar.Value = VFE.ThreadWrapper.progress;
//                lb_enc_Speed.Text = VFE.ThreadWrapper.speed.ToString();
//                lb_enc_time.Text = VFE.ThreadWrapper.time.ToString(@"hh\:mm\:ss\.ff");
//                if (VFE.ThreadWrapper.progress == 100)
//                {
//                    Tic.Stop();
//                    progressBar_4enc_encBar.Value = 100;
//                }
//            };
//            Tic.Tick += E;

//            System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_inputFile.Text);
//            System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);


//            VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorPathEncryption.Encrypt);
//            VFE.ThreadWrapper.RunThread_encrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
//            Tic.Start();
//        }

//        private void bn_5enc_decScan_Click(object sender, EventArgs e)
//        {
//            progressBar_4enc_decBar.Value = 0;
//            lb_dec_speed.Text = "0";
//            lb_dec_time.Text = "0";

//            System.Windows.Forms.Timer Tic = new Timer();
//            EventHandler E = (object sender2, System.EventArgs e2) =>
//            {
//                progressBar_4enc_decBar.Value = VFE.ThreadWrapper.progress;
//                lb_dec_speed.Text = VFE.ThreadWrapper.speed.ToString();
//                lb_dec_time.Text = VFE.ThreadWrapper.time.ToString(@"hh\:mm\:ss\.ff");
//                if (VFE.ThreadWrapper.progress == 100)
//                {
//                    Tic.Stop();
//                    progressBar_4enc_decBar.Value = 100;
//                }
//            };
//            Tic.Tick += E;

//            System.IO.FileInfo fileIN = new System.IO.FileInfo(tb_4enc_outputFile_enc.Text);
//            System.IO.FileInfo fileOUT = new System.IO.FileInfo(tb_4enc_outputFile_dec.Text);

//            VFE.Support.Crypter crypter = new Support.Crypter(VFE.VectorPathEncryption.Decrypt);
//            VFE.ThreadWrapper.RunThread_decrypt(fileIN, fileOUT, myCubeData, Tic, crypter);
//            Tic.Start();
//        }

//        private void bn_5enc_encDec_streams_Click(object sender, EventArgs e)
//        {
//            string inputText = tb_plainText.Text;
//            string outputText = string.Empty;
//            string outputTextRaw = string.Empty;
//            try
//            {
//                System.IO.MemoryStream ms_input = new System.IO.MemoryStream();
//                System.IO.StreamWriter Sw = new System.IO.StreamWriter(ms_input);
//                Sw.Write(inputText);
//                Sw.Flush();
//                ms_input.Position = 0;

//                System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

//                VectorPathEncryption.Encrypt(ms_input, ms_output, myCubeData, null);

//                byte[] outData = ms_output.ToArray(); // CubeData.ConvertFromVector(outputEncrypted)
//                outputText = Convert.ToBase64String(outData);
//                outputTextRaw = string.Join(System.Environment.NewLine, outData);


//                ms_input.Dispose();
//                ms_output.Dispose();

//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//                outputText = "ERROR #dufgvf";
//            }
//            finally
//            {
//                tb_encryptedText.Text = outputText;
//                tb_enc1_encryptedTextRaw.Text = outputTextRaw;
//            }

//            string inputText2 = tb_encryptedText.Text;
//            string outputText2 = string.Empty;
//            try
//            {
//                byte[] dataIN = Convert.FromBase64String(inputText2);

//                System.IO.MemoryStream ms_inpt = new System.IO.MemoryStream(dataIN);

//                System.IO.MemoryStream ms_output = new System.IO.MemoryStream();

//                VectorPathEncryption.Decrypt(ms_inpt, ms_output, myCubeData, null);

//                System.IO.StreamReader reader = new System.IO.StreamReader(ms_output);
//                ms_output.Flush();
//                ms_output.Position = 0;
//                outputText2 = reader.ReadToEnd();

//                ms_inpt.Dispose();
//                ms_output.Dispose();
//            }
//            //catch (System.Exception ex)
//            //{
//            //    throw ex;
//            //    outputText2 = "ERROR #dufgvf";
//            //}
//            finally
//            {
//                tb_output.Text = outputText2;
//            }
//        }
//    }
//}