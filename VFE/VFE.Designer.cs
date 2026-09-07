namespace VFE
{
    partial class IOTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_plainText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_encryptedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_CookbookFilePath = new System.Windows.Forms.TextBox();
            this.bn_makeFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bn_makeVecFile = new System.Windows.Forms.Button();
            this.tb_vecFilePath = new System.Windows.Forms.TextBox();
            this.tabC_Main = new System.Windows.Forms.TabControl();
            this.tabP_4Enc = new System.Windows.Forms.TabPage();
            this.lb_dec_time = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lb_enc_time = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_dec_speed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_enc_Speed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bn_5enc_decScan = new System.Windows.Forms.Button();
            this.bn_5enc_encScan = new System.Windows.Forms.Button();
            this.progressBar_4enc_decBar = new System.Windows.Forms.ProgressBar();
            this.progressBar_4enc_encBar = new System.Windows.Forms.ProgressBar();
            this.tb_4enc_outputFile_dec = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bn_4enc_FindFile = new System.Windows.Forms.Button();
            this.tb_4enc_inputFile = new System.Windows.Forms.TextBox();
            this.tb_4enc_outputFile_enc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabP_1Enc = new System.Windows.Forms.TabPage();
            this.bn_5enc_Dec_streams = new System.Windows.Forms.Button();
            this.bn_5enc_encDec_streams = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_enc1_encryptedTextRaw = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.bn_findFile_codebook = new System.Windows.Forms.Button();
            this.bn_findfile_vec = new System.Windows.Forms.Button();
            this.tabC_Main.SuspendLayout();
            this.tabP_4Enc.SuspendLayout();
            this.tabP_1Enc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_plainText
            // 
            this.tb_plainText.Location = new System.Drawing.Point(18, 42);
            this.tb_plainText.Multiline = true;
            this.tb_plainText.Name = "tb_plainText";
            this.tb_plainText.Size = new System.Drawing.Size(199, 242);
            this.tb_plainText.TabIndex = 1;
            this.tb_plainText.Text = "abc \r\nHellow World : )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(293, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Encrypted Text";
            // 
            // tb_encryptedText
            // 
            this.tb_encryptedText.Font = new System.Drawing.Font("Microsoft Tai Le", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_encryptedText.Location = new System.Drawing.Point(296, 42);
            this.tb_encryptedText.Multiline = true;
            this.tb_encryptedText.Name = "tb_encryptedText";
            this.tb_encryptedText.Size = new System.Drawing.Size(240, 242);
            this.tb_encryptedText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plain Text";
            // 
            // tb_RanFilePath
            // 
            this.tb_CookbookFilePath.Location = new System.Drawing.Point(202, 17);
            this.tb_CookbookFilePath.Name = "tb_RanFilePath";
            this.tb_CookbookFilePath.Size = new System.Drawing.Size(451, 22);
            this.tb_CookbookFilePath.TabIndex = 6;
            this.tb_CookbookFilePath.Text = "////////Desktop\\VFE\\codebook.iotp";
            this.tb_CookbookFilePath.TextChanged += new System.EventHandler(this.tb_CodebookFilePath_TextChanged);
            // 
            // bn_makeFile
            // 
            this.bn_makeFile.Location = new System.Drawing.Point(315, 45);
            this.bn_makeFile.Name = "bn_makeFile";
            this.bn_makeFile.Size = new System.Drawing.Size(99, 23);
            this.bn_makeFile.TabIndex = 7;
            this.bn_makeFile.Text = "Make File";
            this.bn_makeFile.UseVisualStyleBackColor = true;
            this.bn_makeFile.Click += new System.EventHandler(this.bn_makeCookbookFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(65, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codebook File Path";
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(542, 42);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(199, 242);
            this.tb_output.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(539, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Output Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(54, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vector Feild File Path";
            // 
            // bn_makeVecFile
            // 
            this.bn_makeVecFile.Location = new System.Drawing.Point(315, 102);
            this.bn_makeVecFile.Name = "bn_makeVecFile";
            this.bn_makeVecFile.Size = new System.Drawing.Size(99, 23);
            this.bn_makeVecFile.TabIndex = 13;
            this.bn_makeVecFile.Text = "Make File";
            this.bn_makeVecFile.UseVisualStyleBackColor = true;
            this.bn_makeVecFile.Click += new System.EventHandler(this.bn_makeVecFile_Click);
            // 
            // tb_vecFilePath
            // 
            this.tb_vecFilePath.Location = new System.Drawing.Point(202, 74);
            this.tb_vecFilePath.Name = "tb_vecFilePath";
            this.tb_vecFilePath.Size = new System.Drawing.Size(451, 22);
            this.tb_vecFilePath.TabIndex = 12;
            this.tb_vecFilePath.Text = "/////////\\Desktop\\VFE\\vector.iotp";
            this.tb_vecFilePath.TextChanged += new System.EventHandler(this.tb_vecFilePath_TextChanged);
            // 
            // tabC_Main
            // 
            this.tabC_Main.Controls.Add(this.tabP_4Enc);
            this.tabC_Main.Controls.Add(this.tabP_1Enc);
            this.tabC_Main.Location = new System.Drawing.Point(12, 12);
            this.tabC_Main.Name = "tabC_Main";
            this.tabC_Main.SelectedIndex = 0;
            this.tabC_Main.Size = new System.Drawing.Size(765, 360);
            this.tabC_Main.TabIndex = 15;
            // 
            // tabP_4Enc
            // 
            this.tabP_4Enc.Controls.Add(this.lb_dec_time);
            this.tabP_4Enc.Controls.Add(this.label16);
            this.tabP_4Enc.Controls.Add(this.lb_enc_time);
            this.tabP_4Enc.Controls.Add(this.label11);
            this.tabP_4Enc.Controls.Add(this.lb_dec_speed);
            this.tabP_4Enc.Controls.Add(this.label12);
            this.tabP_4Enc.Controls.Add(this.lb_enc_Speed);
            this.tabP_4Enc.Controls.Add(this.label10);
            this.tabP_4Enc.Controls.Add(this.bn_5enc_decScan);
            this.tabP_4Enc.Controls.Add(this.bn_5enc_encScan);
            this.tabP_4Enc.Controls.Add(this.progressBar_4enc_decBar);
            this.tabP_4Enc.Controls.Add(this.progressBar_4enc_encBar);
            this.tabP_4Enc.Controls.Add(this.tb_4enc_outputFile_dec);
            this.tabP_4Enc.Controls.Add(this.label15);
            this.tabP_4Enc.Controls.Add(this.bn_4enc_FindFile);
            this.tabP_4Enc.Controls.Add(this.tb_4enc_inputFile);
            this.tabP_4Enc.Controls.Add(this.tb_4enc_outputFile_enc);
            this.tabP_4Enc.Controls.Add(this.label17);
            this.tabP_4Enc.Controls.Add(this.label18);
            this.tabP_4Enc.Location = new System.Drawing.Point(4, 25);
            this.tabP_4Enc.Name = "tabP_4Enc";
            this.tabP_4Enc.Size = new System.Drawing.Size(757, 331);
            this.tabP_4Enc.TabIndex = 3;
            this.tabP_4Enc.Text = "tabP_4Enc";
            this.tabP_4Enc.UseVisualStyleBackColor = true;
            // 
            // lb_dec_time
            // 
            this.lb_dec_time.AutoSize = true;
            this.lb_dec_time.Location = new System.Drawing.Point(668, 156);
            this.lb_dec_time.Name = "lb_dec_time";
            this.lb_dec_time.Size = new System.Drawing.Size(27, 17);
            this.lb_dec_time.TabIndex = 48;
            this.lb_dec_time.Text = "0 s";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Gainsboro;
            this.label16.Location = new System.Drawing.Point(618, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "Time:";
            // 
            // lb_enc_time
            // 
            this.lb_enc_time.AutoSize = true;
            this.lb_enc_time.Location = new System.Drawing.Point(668, 37);
            this.lb_enc_time.Name = "lb_enc_time";
            this.lb_enc_time.Size = new System.Drawing.Size(27, 17);
            this.lb_enc_time.TabIndex = 46;
            this.lb_enc_time.Text = "0 s";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(618, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 45;
            this.label11.Text = "Time:";
            // 
            // lb_dec_speed
            // 
            this.lb_dec_speed.AutoSize = true;
            this.lb_dec_speed.Location = new System.Drawing.Point(668, 129);
            this.lb_dec_speed.Name = "lb_dec_speed";
            this.lb_dec_speed.Size = new System.Drawing.Size(43, 17);
            this.lb_dec_speed.TabIndex = 44;
            this.lb_dec_speed.Text = "0 bps";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(608, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 43;
            this.label12.Text = "Speed:";
            // 
            // lb_enc_Speed
            // 
            this.lb_enc_Speed.AutoSize = true;
            this.lb_enc_Speed.Location = new System.Drawing.Point(668, 10);
            this.lb_enc_Speed.Name = "lb_enc_Speed";
            this.lb_enc_Speed.Size = new System.Drawing.Size(43, 17);
            this.lb_enc_Speed.TabIndex = 42;
            this.lb_enc_Speed.Text = "0 bps";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(608, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Speed:";
            // 
            // bn_5enc_decScan
            // 
            this.bn_5enc_decScan.Location = new System.Drawing.Point(130, 184);
            this.bn_5enc_decScan.Name = "bn_5enc_decScan";
            this.bn_5enc_decScan.Size = new System.Drawing.Size(92, 33);
            this.bn_5enc_decScan.TabIndex = 40;
            this.bn_5enc_decScan.Text = "Decrypt";
            this.bn_5enc_decScan.UseVisualStyleBackColor = true;
            this.bn_5enc_decScan.Click += new System.EventHandler(this.bn_5enc_decScan_Click);
            // 
            // bn_5enc_encScan
            // 
            this.bn_5enc_encScan.Location = new System.Drawing.Point(130, 65);
            this.bn_5enc_encScan.Name = "bn_5enc_encScan";
            this.bn_5enc_encScan.Size = new System.Drawing.Size(92, 33);
            this.bn_5enc_encScan.TabIndex = 39;
            this.bn_5enc_encScan.Text = "Encrypt";
            this.bn_5enc_encScan.UseVisualStyleBackColor = true;
            this.bn_5enc_encScan.Click += new System.EventHandler(this.bn_5enc_encScan_Click);
            // 
            // progressBar_4enc_decBar
            // 
            this.progressBar_4enc_decBar.Location = new System.Drawing.Point(121, 130);
            this.progressBar_4enc_decBar.Name = "progressBar_4enc_decBar";
            this.progressBar_4enc_decBar.Size = new System.Drawing.Size(481, 23);
            this.progressBar_4enc_decBar.TabIndex = 38;
            // 
            // progressBar_4enc_encBar
            // 
            this.progressBar_4enc_encBar.Location = new System.Drawing.Point(109, 11);
            this.progressBar_4enc_encBar.Name = "progressBar_4enc_encBar";
            this.progressBar_4enc_encBar.Size = new System.Drawing.Size(493, 23);
            this.progressBar_4enc_encBar.TabIndex = 37;
            // 
            // tb_4enc_outputFile_dec
            // 
            this.tb_4enc_outputFile_dec.Location = new System.Drawing.Point(10, 253);
            this.tb_4enc_outputFile_dec.Name = "tb_4enc_outputFile_dec";
            this.tb_4enc_outputFile_dec.Size = new System.Drawing.Size(592, 22);
            this.tb_4enc_outputFile_dec.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Gainsboro;
            this.label15.Location = new System.Drawing.Point(7, 233);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "Output Text File";
            // 
            // bn_4enc_FindFile
            // 
            this.bn_4enc_FindFile.Location = new System.Drawing.Point(10, 65);
            this.bn_4enc_FindFile.Name = "bn_4enc_FindFile";
            this.bn_4enc_FindFile.Size = new System.Drawing.Size(93, 29);
            this.bn_4enc_FindFile.TabIndex = 30;
            this.bn_4enc_FindFile.Text = "Input File";
            this.bn_4enc_FindFile.UseVisualStyleBackColor = true;
            this.bn_4enc_FindFile.Click += new System.EventHandler(this.bn_4enc_FindFile_Click);
            // 
            // tb_4enc_inputFile
            // 
            this.tb_4enc_inputFile.Location = new System.Drawing.Point(10, 37);
            this.tb_4enc_inputFile.Name = "tb_4enc_inputFile";
            this.tb_4enc_inputFile.Size = new System.Drawing.Size(592, 22);
            this.tb_4enc_inputFile.TabIndex = 23;
            // 
            // tb_4enc_outputFile_enc
            // 
            this.tb_4enc_outputFile_enc.Location = new System.Drawing.Point(10, 156);
            this.tb_4enc_outputFile_enc.Name = "tb_4enc_outputFile_enc";
            this.tb_4enc_outputFile_enc.Size = new System.Drawing.Size(592, 22);
            this.tb_4enc_outputFile_enc.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Gainsboro;
            this.label17.Location = new System.Drawing.Point(7, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 17);
            this.label17.TabIndex = 26;
            this.label17.Text = "Plain Text File";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Gainsboro;
            this.label18.Location = new System.Drawing.Point(7, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 17);
            this.label18.TabIndex = 27;
            this.label18.Text = "Output Text File";
            // 
            // tabP_1Enc
            // 
            this.tabP_1Enc.Controls.Add(this.bn_5enc_Dec_streams);
            this.tabP_1Enc.Controls.Add(this.bn_5enc_encDec_streams);
            this.tabP_1Enc.Controls.Add(this.label14);
            this.tabP_1Enc.Controls.Add(this.tb_enc1_encryptedTextRaw);
            this.tabP_1Enc.Controls.Add(this.tb_plainText);
            this.tabP_1Enc.Controls.Add(this.label1);
            this.tabP_1Enc.Controls.Add(this.tb_encryptedText);
            this.tabP_1Enc.Controls.Add(this.tb_output);
            this.tabP_1Enc.Controls.Add(this.label2);
            this.tabP_1Enc.Controls.Add(this.label4);
            this.tabP_1Enc.Location = new System.Drawing.Point(4, 25);
            this.tabP_1Enc.Name = "tabP_1Enc";
            this.tabP_1Enc.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_1Enc.Size = new System.Drawing.Size(757, 331);
            this.tabP_1Enc.TabIndex = 0;
            this.tabP_1Enc.Text = "tabP_1Enc";
            this.tabP_1Enc.UseVisualStyleBackColor = true;
            // 
            // bn_5enc_Dec_streams
            // 
            this.bn_5enc_Dec_streams.Location = new System.Drawing.Point(296, 290);
            this.bn_5enc_Dec_streams.Name = "bn_5enc_Dec_streams";
            this.bn_5enc_Dec_streams.Size = new System.Drawing.Size(94, 33);
            this.bn_5enc_Dec_streams.TabIndex = 25;
            this.bn_5enc_Dec_streams.Text = "Decrypt";
            this.bn_5enc_Dec_streams.UseVisualStyleBackColor = true;
            this.bn_5enc_Dec_streams.Click += new System.EventHandler(this.bn_5enc_Dec_streams_Click);
            // 
            // bn_5enc_encDec_streams
            // 
            this.bn_5enc_encDec_streams.Location = new System.Drawing.Point(18, 290);
            this.bn_5enc_encDec_streams.Name = "bn_5enc_encDec_streams";
            this.bn_5enc_encDec_streams.Size = new System.Drawing.Size(94, 33);
            this.bn_5enc_encDec_streams.TabIndex = 24;
            this.bn_5enc_encDec_streams.Text = "Enc + Dec";
            this.bn_5enc_encDec_streams.UseVisualStyleBackColor = true;
            this.bn_5enc_encDec_streams.Click += new System.EventHandler(this.bn_5enc_encDec_streams_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Gainsboro;
            this.label14.Location = new System.Drawing.Point(230, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 21;
            this.label14.Text = "EncRaw";
            // 
            // tb_enc1_encryptedTextRaw
            // 
            this.tb_enc1_encryptedTextRaw.Font = new System.Drawing.Font("Microsoft Tai Le", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_enc1_encryptedTextRaw.Location = new System.Drawing.Point(233, 42);
            this.tb_enc1_encryptedTextRaw.Multiline = true;
            this.tb_enc1_encryptedTextRaw.Name = "tb_enc1_encryptedTextRaw";
            this.tb_enc1_encryptedTextRaw.Size = new System.Drawing.Size(45, 242);
            this.tb_enc1_encryptedTextRaw.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.bn_findfile_vec);
            this.panel1.Controls.Add(this.bn_findFile_codebook);
            this.panel1.Controls.Add(this.tb_CookbookFilePath);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bn_makeFile);
            this.panel1.Controls.Add(this.bn_makeVecFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_vecFilePath);
            this.panel1.Location = new System.Drawing.Point(47, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 130);
            this.panel1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(47, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Encryption Material";
            // 
            // bn_findFile_codebook
            // 
            this.bn_findFile_codebook.Location = new System.Drawing.Point(202, 45);
            this.bn_findFile_codebook.Name = "bn_findFile_codebook";
            this.bn_findFile_codebook.Size = new System.Drawing.Size(99, 23);
            this.bn_findFile_codebook.TabIndex = 15;
            this.bn_findFile_codebook.Text = "Find File";
            this.bn_findFile_codebook.UseVisualStyleBackColor = true;
            this.bn_findFile_codebook.Click += new System.EventHandler(this.bn_findfile_codebook_Click);
            // 
            // bn_findfile_vec
            // 
            this.bn_findfile_vec.Location = new System.Drawing.Point(202, 102);
            this.bn_findfile_vec.Name = "bn_findfile_vec";
            this.bn_findfile_vec.Size = new System.Drawing.Size(99, 23);
            this.bn_findfile_vec.TabIndex = 16;
            this.bn_findfile_vec.Text = "Find File";
            this.bn_findfile_vec.UseVisualStyleBackColor = true;
            this.bn_findfile_vec.Click += new System.EventHandler(this.bn_findfile_vec_Click);
            // 
            // IOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(791, 545);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabC_Main);
            this.Controls.Add(this.panel1);
            this.Name = "IOTP";
            this.Text = "Vector Field Encryption";
            this.tabC_Main.ResumeLayout(false);
            this.tabP_4Enc.ResumeLayout(false);
            this.tabP_4Enc.PerformLayout();
            this.tabP_1Enc.ResumeLayout(false);
            this.tabP_1Enc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_plainText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_encryptedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_CookbookFilePath;
        private System.Windows.Forms.Button bn_makeFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bn_makeVecFile;
        private System.Windows.Forms.TextBox tb_vecFilePath;
        private System.Windows.Forms.TabControl tabC_Main;
        private System.Windows.Forms.TabPage tabP_1Enc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_enc1_encryptedTextRaw;
        private System.Windows.Forms.TabPage tabP_4Enc;
        private System.Windows.Forms.Button bn_4enc_FindFile;
        private System.Windows.Forms.TextBox tb_4enc_inputFile;
        private System.Windows.Forms.TextBox tb_4enc_outputFile_enc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_4enc_outputFile_dec;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar progressBar_4enc_encBar;
        private System.Windows.Forms.ProgressBar progressBar_4enc_decBar;
        private System.Windows.Forms.Button bn_5enc_decScan;
        private System.Windows.Forms.Button bn_5enc_encScan;
        private System.Windows.Forms.Button bn_5enc_encDec_streams;
        private System.Windows.Forms.Label lb_dec_speed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_enc_Speed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lb_dec_time;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lb_enc_time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bn_5enc_Dec_streams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bn_findFile_codebook;
        private System.Windows.Forms.Button bn_findfile_vec;
    }
}

