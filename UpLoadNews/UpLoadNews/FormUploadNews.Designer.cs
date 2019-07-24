namespace UpLoadNews
{
    partial class FormUploadNews
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
            this.components = new System.ComponentModel.Container();
            this.cmbchannel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttextchannel = new System.Windows.Forms.TextBox();
            this.radunlisted = new System.Windows.Forms.RadioButton();
            this.radprivate = new System.Windows.Forms.RadioButton();
            this.rabpublic = new System.Windows.Forms.RadioButton();
            this.checkuploadvideo = new System.Windows.Forms.CheckBox();
            this.txtadddesc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtvideoupload = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtthoigiancho = new System.Windows.Forms.NumericUpDown();
            this.btnrender = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prs = new System.Windows.Forms.ToolStripProgressBar();
            this.lblxuly = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.bgwrender = new System.ComponentModel.BackgroundWorker();
            this.timerrender = new System.Windows.Forms.Timer(this.components);
            this.btninputfolder = new System.Windows.Forms.Button();
            this.txtfoldervideo = new System.Windows.Forms.TextBox();
            this.checkdelfolder = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsleep = new System.Windows.Forms.NumericUpDown();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.raduploadchome = new System.Windows.Forms.RadioButton();
            this.raduploadapi = new System.Windows.Forms.RadioButton();
            this.checkdefaulprofile = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.txttaikhoan = new System.Windows.Forms.TextBox();
            this.btnsavecfupload = new System.Windows.Forms.Button();
            this.checksetmotizeion = new System.Windows.Forms.CheckBox();
            this.checkrapidtags = new System.Windows.Forms.CheckBox();
            this.txtvideomax = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtdatenow = new System.Windows.Forms.TextBox();
            this.checkuploadfb = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtlinkpage = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideoupload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtthoigiancho)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsleep)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideomax)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbchannel
            // 
            this.cmbchannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbchannel.FormattingEnabled = true;
            this.cmbchannel.Location = new System.Drawing.Point(122, 23);
            this.cmbchannel.Name = "cmbchannel";
            this.cmbchannel.Size = new System.Drawing.Size(227, 21);
            this.cmbchannel.TabIndex = 302;
            this.cmbchannel.SelectedIndexChanged += new System.EventHandler(this.cmbchannel_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 303;
            this.label4.Text = "Channel :";
            // 
            // txttextchannel
            // 
            this.txttextchannel.Location = new System.Drawing.Point(543, 62);
            this.txttextchannel.Name = "txttextchannel";
            this.txttextchannel.Size = new System.Drawing.Size(170, 20);
            this.txttextchannel.TabIndex = 315;
            this.txttextchannel.Text = "textchannel2";
            // 
            // radunlisted
            // 
            this.radunlisted.AutoSize = true;
            this.radunlisted.Location = new System.Drawing.Point(288, 65);
            this.radunlisted.Name = "radunlisted";
            this.radunlisted.Size = new System.Drawing.Size(61, 17);
            this.radunlisted.TabIndex = 314;
            this.radunlisted.Text = "unlisted";
            this.radunlisted.UseVisualStyleBackColor = true;
            // 
            // radprivate
            // 
            this.radprivate.AutoSize = true;
            this.radprivate.Location = new System.Drawing.Point(224, 65);
            this.radprivate.Name = "radprivate";
            this.radprivate.Size = new System.Drawing.Size(57, 17);
            this.radprivate.TabIndex = 313;
            this.radprivate.Text = "private";
            this.radprivate.UseVisualStyleBackColor = true;
            // 
            // rabpublic
            // 
            this.rabpublic.AutoSize = true;
            this.rabpublic.Checked = true;
            this.rabpublic.Location = new System.Drawing.Point(165, 64);
            this.rabpublic.Name = "rabpublic";
            this.rabpublic.Size = new System.Drawing.Size(53, 17);
            this.rabpublic.TabIndex = 312;
            this.rabpublic.TabStop = true;
            this.rabpublic.Text = "public";
            this.rabpublic.UseVisualStyleBackColor = true;
            // 
            // checkuploadvideo
            // 
            this.checkuploadvideo.AutoSize = true;
            this.checkuploadvideo.Checked = true;
            this.checkuploadvideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkuploadvideo.Location = new System.Drawing.Point(72, 65);
            this.checkuploadvideo.Name = "checkuploadvideo";
            this.checkuploadvideo.Size = new System.Drawing.Size(87, 17);
            this.checkuploadvideo.TabIndex = 311;
            this.checkuploadvideo.Text = "upload video";
            this.checkuploadvideo.UseVisualStyleBackColor = true;
            // 
            // txtadddesc
            // 
            this.txtadddesc.Location = new System.Drawing.Point(543, 88);
            this.txtadddesc.Multiline = true;
            this.txtadddesc.Name = "txtadddesc";
            this.txtadddesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtadddesc.Size = new System.Drawing.Size(375, 66);
            this.txtadddesc.TabIndex = 316;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewList);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 258);
            this.groupBox2.TabIndex = 317;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewList.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.Size = new System.Drawing.Size(507, 239);
            this.dataGridViewList.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(624, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 323;
            this.label9.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 322;
            this.label8.Text = "Video upload :";
            // 
            // txtvideoupload
            // 
            this.txtvideoupload.Location = new System.Drawing.Point(555, 182);
            this.txtvideoupload.Name = "txtvideoupload";
            this.txtvideoupload.Size = new System.Drawing.Size(66, 20);
            this.txtvideoupload.TabIndex = 321;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(853, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 320;
            this.label6.Text = "ss";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 319;
            this.label5.Text = "Time loop :";
            // 
            // txtthoigiancho
            // 
            this.txtthoigiancho.Location = new System.Drawing.Point(781, 182);
            this.txtthoigiancho.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtthoigiancho.Name = "txtthoigiancho";
            this.txtthoigiancho.Size = new System.Drawing.Size(66, 20);
            this.txtthoigiancho.TabIndex = 318;
            this.txtthoigiancho.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // btnrender
            // 
            this.btnrender.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnrender.Location = new System.Drawing.Point(549, 298);
            this.btnrender.Name = "btnrender";
            this.btnrender.Size = new System.Drawing.Size(102, 48);
            this.btnrender.TabIndex = 324;
            this.btnrender.Text = "Begin upload";
            this.btnrender.UseVisualStyleBackColor = true;
            this.btnrender.Click += new System.EventHandler(this.btnrender_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prs,
            this.lblxuly,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(949, 36);
            this.statusStrip1.TabIndex = 325;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prs
            // 
            this.prs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prs.Name = "prs";
            this.prs.Size = new System.Drawing.Size(200, 30);
            // 
            // lblxuly
            // 
            this.lblxuly.Name = "lblxuly";
            this.lblxuly.Size = new System.Drawing.Size(0, 31);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 30);
            // 
            // bgwrender
            // 
            this.bgwrender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrender_DoWork);
            this.bgwrender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrender_RunWorkerCompleted);
            // 
            // timerrender
            // 
            this.timerrender.Tick += new System.EventHandler(this.timerrender_Tick);
            // 
            // btninputfolder
            // 
            this.btninputfolder.Location = new System.Drawing.Point(543, 18);
            this.btninputfolder.Name = "btninputfolder";
            this.btninputfolder.Size = new System.Drawing.Size(95, 23);
            this.btninputfolder.TabIndex = 326;
            this.btninputfolder.Text = "&Output Video";
            this.btninputfolder.UseVisualStyleBackColor = true;
            this.btninputfolder.Click += new System.EventHandler(this.btninputfolder_Click);
            // 
            // txtfoldervideo
            // 
            this.txtfoldervideo.Enabled = false;
            this.txtfoldervideo.Location = new System.Drawing.Point(644, 18);
            this.txtfoldervideo.Name = "txtfoldervideo";
            this.txtfoldervideo.Size = new System.Drawing.Size(274, 20);
            this.txtfoldervideo.TabIndex = 327;
            // 
            // checkdelfolder
            // 
            this.checkdelfolder.AutoSize = true;
            this.checkdelfolder.Checked = true;
            this.checkdelfolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkdelfolder.Location = new System.Drawing.Point(627, 160);
            this.checkdelfolder.Name = "checkdelfolder";
            this.checkdelfolder.Size = new System.Drawing.Size(86, 17);
            this.checkdelfolder.TabIndex = 328;
            this.checkdelfolder.Text = "Delete video";
            this.checkdelfolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 330;
            this.label2.Text = "Time sleep :";
            // 
            // txtsleep
            // 
            this.txtsleep.Location = new System.Drawing.Point(618, 208);
            this.txtsleep.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtsleep.Name = "txtsleep";
            this.txtsleep.Size = new System.Drawing.Size(66, 20);
            this.txtsleep.TabIndex = 329;
            this.txtsleep.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.raduploadchome);
            this.groupBox10.Controls.Add(this.raduploadapi);
            this.groupBox10.Location = new System.Drawing.Point(657, 302);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(264, 44);
            this.groupBox10.TabIndex = 332;
            this.groupBox10.TabStop = false;
            // 
            // raduploadchome
            // 
            this.raduploadchome.AutoSize = true;
            this.raduploadchome.Location = new System.Drawing.Point(101, 19);
            this.raduploadchome.Name = "raduploadchome";
            this.raduploadchome.Size = new System.Drawing.Size(149, 17);
            this.raduploadchome.TabIndex = 1;
            this.raduploadchome.Text = "Upload chome automation";
            this.raduploadchome.UseVisualStyleBackColor = true;
            // 
            // raduploadapi
            // 
            this.raduploadapi.AutoSize = true;
            this.raduploadapi.Checked = true;
            this.raduploadapi.Location = new System.Drawing.Point(6, 19);
            this.raduploadapi.Name = "raduploadapi";
            this.raduploadapi.Size = new System.Drawing.Size(93, 17);
            this.raduploadapi.TabIndex = 0;
            this.raduploadapi.TabStop = true;
            this.raduploadapi.Text = "Upload by API";
            this.raduploadapi.UseVisualStyleBackColor = true;
            // 
            // checkdefaulprofile
            // 
            this.checkdefaulprofile.AutoSize = true;
            this.checkdefaulprofile.Checked = true;
            this.checkdefaulprofile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkdefaulprofile.ForeColor = System.Drawing.Color.Blue;
            this.checkdefaulprofile.Location = new System.Drawing.Point(648, 352);
            this.checkdefaulprofile.Name = "checkdefaulprofile";
            this.checkdefaulprofile.Size = new System.Drawing.Size(128, 18);
            this.checkdefaulprofile.TabIndex = 337;
            this.checkdefaulprofile.Text = "Defaul Profile chome";
            this.checkdefaulprofile.UseCompatibleTextRendering = true;
            this.checkdefaulprofile.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(15, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 336;
            this.label12.Text = "Mật khẩu :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(12, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 335;
            this.label11.Text = "Tài khoản :";
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(90, 389);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(239, 20);
            this.txtmatkhau.TabIndex = 334;
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.Location = new System.Drawing.Point(90, 351);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(239, 20);
            this.txttaikhoan.TabIndex = 333;
            // 
            // btnsavecfupload
            // 
            this.btnsavecfupload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsavecfupload.ForeColor = System.Drawing.Color.Red;
            this.btnsavecfupload.Location = new System.Drawing.Point(813, 380);
            this.btnsavecfupload.Name = "btnsavecfupload";
            this.btnsavecfupload.Size = new System.Drawing.Size(108, 33);
            this.btnsavecfupload.TabIndex = 340;
            this.btnsavecfupload.Text = "Save cf upload";
            this.btnsavecfupload.UseVisualStyleBackColor = true;
            this.btnsavecfupload.Click += new System.EventHandler(this.btnsavecfupload_Click);
            // 
            // checksetmotizeion
            // 
            this.checksetmotizeion.AutoSize = true;
            this.checksetmotizeion.ForeColor = System.Drawing.Color.Blue;
            this.checksetmotizeion.Location = new System.Drawing.Point(719, 221);
            this.checksetmotizeion.Name = "checksetmotizeion";
            this.checksetmotizeion.Size = new System.Drawing.Size(90, 18);
            this.checksetmotizeion.TabIndex = 341;
            this.checksetmotizeion.Text = "set motizeion";
            this.checksetmotizeion.UseCompatibleTextRendering = true;
            this.checksetmotizeion.UseVisualStyleBackColor = true;
            // 
            // checkrapidtags
            // 
            this.checkrapidtags.AutoSize = true;
            this.checkrapidtags.Location = new System.Drawing.Point(549, 245);
            this.checkrapidtags.Name = "checkrapidtags";
            this.checkrapidtags.Size = new System.Drawing.Size(80, 17);
            this.checkrapidtags.TabIndex = 342;
            this.checkrapidtags.Text = "rapidtags.io";
            this.checkrapidtags.UseVisualStyleBackColor = true;
            // 
            // txtvideomax
            // 
            this.txtvideomax.Location = new System.Drawing.Point(637, 182);
            this.txtvideomax.Name = "txtvideomax";
            this.txtvideomax.Size = new System.Drawing.Size(66, 20);
            this.txtvideomax.TabIndex = 343;
            this.txtvideomax.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(717, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 346;
            this.label14.Text = "Date now :";
            // 
            // txtdatenow
            // 
            this.txtdatenow.Enabled = false;
            this.txtdatenow.Location = new System.Drawing.Point(777, 63);
            this.txtdatenow.Name = "txtdatenow";
            this.txtdatenow.Size = new System.Drawing.Size(141, 20);
            this.txtdatenow.TabIndex = 345;
            // 
            // checkuploadfb
            // 
            this.checkuploadfb.AutoSize = true;
            this.checkuploadfb.ForeColor = System.Drawing.Color.Blue;
            this.checkuploadfb.Location = new System.Drawing.Point(102, 417);
            this.checkuploadfb.Name = "checkuploadfb";
            this.checkuploadfb.Size = new System.Drawing.Size(153, 18);
            this.checkuploadfb.TabIndex = 357;
            this.checkuploadfb.Text = "set upload page facebook";
            this.checkuploadfb.UseCompatibleTextRendering = true;
            this.checkuploadfb.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 453);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 356;
            this.label17.Text = "Link page :";
            // 
            // txtlinkpage
            // 
            this.txtlinkpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtlinkpage.Location = new System.Drawing.Point(90, 448);
            this.txtlinkpage.Name = "txtlinkpage";
            this.txtlinkpage.Size = new System.Drawing.Size(435, 20);
            this.txtlinkpage.TabIndex = 355;
            // 
            // FormUploadNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 516);
            this.Controls.Add(this.checkuploadfb);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtlinkpage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtdatenow);
            this.Controls.Add(this.txtvideomax);
            this.Controls.Add(this.checkrapidtags);
            this.Controls.Add(this.checksetmotizeion);
            this.Controls.Add(this.btnsavecfupload);
            this.Controls.Add(this.checkdefaulprofile);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtmatkhau);
            this.Controls.Add(this.txttaikhoan);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsleep);
            this.Controls.Add(this.checkdelfolder);
            this.Controls.Add(this.btninputfolder);
            this.Controls.Add(this.txtfoldervideo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnrender);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtvideoupload);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtthoigiancho);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtadddesc);
            this.Controls.Add(this.txttextchannel);
            this.Controls.Add(this.radunlisted);
            this.Controls.Add(this.radprivate);
            this.Controls.Add(this.rabpublic);
            this.Controls.Add(this.checkuploadvideo);
            this.Controls.Add(this.cmbchannel);
            this.Controls.Add(this.label4);
            this.Name = "FormUploadNews";
            this.Text = "FormUploadNews";
            this.Load += new System.EventHandler(this.FormUploadNews_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideoupload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtthoigiancho)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsleep)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvideomax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbchannel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttextchannel;
        private System.Windows.Forms.RadioButton radunlisted;
        private System.Windows.Forms.RadioButton radprivate;
        private System.Windows.Forms.RadioButton rabpublic;
        private System.Windows.Forms.CheckBox checkuploadvideo;
        private System.Windows.Forms.TextBox txtadddesc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtvideoupload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtthoigiancho;
        private System.Windows.Forms.Button btnrender;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prs;
        private System.Windows.Forms.ToolStripStatusLabel lblxuly;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker bgwrender;
        private System.Windows.Forms.Timer timerrender;
        private System.Windows.Forms.Button btninputfolder;
        private System.Windows.Forms.TextBox txtfoldervideo;
        private System.Windows.Forms.CheckBox checkdelfolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtsleep;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton raduploadchome;
        private System.Windows.Forms.RadioButton raduploadapi;
        private System.Windows.Forms.CheckBox checkdefaulprofile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.TextBox txttaikhoan;
        private System.Windows.Forms.Button btnsavecfupload;
        private System.Windows.Forms.CheckBox checksetmotizeion;
        private System.Windows.Forms.CheckBox checkrapidtags;
        private System.Windows.Forms.NumericUpDown txtvideomax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtdatenow;
        private System.Windows.Forms.CheckBox checkuploadfb;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtlinkpage;
    }
}