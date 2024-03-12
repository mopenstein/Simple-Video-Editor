namespace Simple_Video_Editor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmrPosEdit = new System.Windows.Forms.Timer(this.components);
            this.tmrScroll = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSplitsRestore = new System.Windows.Forms.Button();
            this.btnJumpTime = new System.Windows.Forms.Button();
            this.chkSplitForceMP4 = new System.Windows.Forms.CheckBox();
            this.btnSplitUpdateTime = new System.Windows.Forms.Button();
            this.btnSplitAutoScan = new System.Windows.Forms.Button();
            this.btnSplitListClear = new System.Windows.Forms.Button();
            this.btnSplitListRemove = new System.Windows.Forms.Button();
            this.btnSplitQueue = new System.Windows.Forms.Button();
            this.lstSplit = new System.Windows.Forms.ListBox();
            this.scrollBarMilli = new System.Windows.Forms.HScrollBar();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnGoEnd = new System.Windows.Forms.Button();
            this.btnGoStart = new System.Windows.Forms.Button();
            this.btnSeekEnd = new System.Windows.Forms.Button();
            this.btnSeekBegin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPos = new System.Windows.Forms.TextBox();
            this.btnEndPos = new System.Windows.Forms.Button();
            this.btnStartPos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndPos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartPos = new System.Windows.Forms.TextBox();
            this.picFrame = new System.Windows.Forms.PictureBox();
            this.scrollBar = new System.Windows.Forms.HScrollBar();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.chkAutoSetStart = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkAudio = new System.Windows.Forms.CheckBox();
            this.btnJoinBatch = new System.Windows.Forms.Button();
            this.chkXFade = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numJoinHeight = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numJoinWidth = new System.Windows.Forms.NumericUpDown();
            this.btnJoinMoveDown = new System.Windows.Forms.Button();
            this.btnJoinMoveUp = new System.Windows.Forms.Button();
            this.btnJoinClear = new System.Windows.Forms.Button();
            this.btnJoinRemove = new System.Windows.Forms.Button();
            this.lblJoinerFileCount = new System.Windows.Forms.Label();
            this.chkJoinEncode = new System.Windows.Forms.CheckBox();
            this.btnJoinMerge = new System.Windows.Forms.Button();
            this.btnJoinAdd = new System.Windows.Forms.Button();
            this.lstJoin = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnResizeAutoCrop = new System.Windows.Forms.Button();
            this.picResizeFrame = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numCropVideoTop = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numCropVideoLeft = new System.Windows.Forms.NumericUpDown();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnResizeVideo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numResizeVideoHeight = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numResizeVideoWidth = new System.Windows.Forms.NumericUpDown();
            this.txtResizeVideoFile = new System.Windows.Forms.TextBox();
            this.btnResizeVideoFile = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkAudioTrim = new System.Windows.Forms.CheckBox();
            this.btnAudioComine = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAudioAudio = new System.Windows.Forms.TextBox();
            this.btnAudioAudio = new System.Windows.Forms.Button();
            this.txtAudioVideo = new System.Windows.Forms.TextBox();
            this.btnAudioVideo = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAudioMagicListClear = new System.Windows.Forms.Button();
            this.btnAudioMagicListRemove = new System.Windows.Forms.Button();
            this.lstAudioMagic = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExtractAudioVideo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAudioMagicUseFilter = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.btnAudioBoost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExtractAudio = new System.Windows.Forms.Button();
            this.chkAudioMagicGenerateFilter = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.btnColorTest = new System.Windows.Forms.Button();
            this.picColorNew = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numGamma = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numSaturation = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numBright = new System.Windows.Forms.NumericUpDown();
            this.picColorOrig = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numContrast = new System.Windows.Forms.NumericUpDown();
            this.txtColorFile = new System.Windows.Forms.TextBox();
            this.picColorOpen = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lstCustom = new System.Windows.Forms.ListBox();
            this.txtCustomFilter = new System.Windows.Forms.TextBox();
            this.btnCustomSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomFile = new System.Windows.Forms.TextBox();
            this.btnCustomOpen = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.picResizeFrameTemp = new System.Windows.Forms.PictureBox();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.picStatusB = new System.Windows.Forms.PictureBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.txtVLog = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward10SecsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward1SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward10SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward1SecToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.back10SecsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.back1SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.back10SecsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.back01SecsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.beginningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setStartPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setEndPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToSplitQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJoinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJoinWidth)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResizeFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCropVideoTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCropVideoLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResizeVideoHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResizeVideoWidth)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColorNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResizeFrameTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Video Files|*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp4;*.mov;*.mkv;*.flv;*.webm;*" +
    ".WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP4;*.MOV;*.MKV;*.FLV;*.WEBM";
            this.openFileDialog1.Tag = "Video Files|*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp4;*.mov;*.mkv;*.flv;*.WMV;*." +
    "AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP4;*.MOV;*.MKV;*.FLV";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Video Files|*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp4;*.mov;*.mkv;*.flv;*.webm;*" +
    ".WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP4;*.MOV;*.MKV;*.FLV;*.WEBM";
            // 
            // tmrPosEdit
            // 
            this.tmrPosEdit.Interval = 750;
            this.tmrPosEdit.Tick += new System.EventHandler(this.tmrPosEdit_Tick);
            // 
            // tmrScroll
            // 
            this.tmrScroll.Interval = 500;
            this.tmrScroll.Tick += new System.EventHandler(this.tmrScroll_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(498, 325);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSplitsRestore);
            this.tabPage1.Controls.Add(this.btnJumpTime);
            this.tabPage1.Controls.Add(this.chkSplitForceMP4);
            this.tabPage1.Controls.Add(this.btnSplitUpdateTime);
            this.tabPage1.Controls.Add(this.btnSplitAutoScan);
            this.tabPage1.Controls.Add(this.btnSplitListClear);
            this.tabPage1.Controls.Add(this.btnSplitListRemove);
            this.tabPage1.Controls.Add(this.btnSplitQueue);
            this.tabPage1.Controls.Add(this.lstSplit);
            this.tabPage1.Controls.Add(this.scrollBarMilli);
            this.tabPage1.Controls.Add(this.btnExec);
            this.tabPage1.Controls.Add(this.btnGoEnd);
            this.tabPage1.Controls.Add(this.btnGoStart);
            this.tabPage1.Controls.Add(this.btnSeekEnd);
            this.tabPage1.Controls.Add(this.btnSeekBegin);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCurrentPos);
            this.tabPage1.Controls.Add(this.btnEndPos);
            this.tabPage1.Controls.Add(this.btnStartPos);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtEndPos);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtStartPos);
            this.tabPage1.Controls.Add(this.picFrame);
            this.tabPage1.Controls.Add(this.scrollBar);
            this.tabPage1.Controls.Add(this.txtFile);
            this.tabPage1.Controls.Add(this.btnLoadFile);
            this.tabPage1.Controls.Add(this.chkAutoSetStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(490, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Splitter";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnSplitsRestore
            // 
            this.btnSplitsRestore.Location = new System.Drawing.Point(464, 186);
            this.btnSplitsRestore.Name = "btnSplitsRestore";
            this.btnSplitsRestore.Size = new System.Drawing.Size(20, 21);
            this.btnSplitsRestore.TabIndex = 46;
            this.btnSplitsRestore.Text = "r";
            this.btnSplitsRestore.UseVisualStyleBackColor = true;
            this.btnSplitsRestore.Click += new System.EventHandler(this.btnSplitsRestore_Click);
            // 
            // btnJumpTime
            // 
            this.btnJumpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpTime.Location = new System.Drawing.Point(157, 219);
            this.btnJumpTime.Name = "btnJumpTime";
            this.btnJumpTime.Size = new System.Drawing.Size(29, 23);
            this.btnJumpTime.TabIndex = 45;
            this.btnJumpTime.Text = "*";
            this.btnJumpTime.UseVisualStyleBackColor = true;
            this.btnJumpTime.Click += new System.EventHandler(this.btnJumpTime_Click);
            // 
            // chkSplitForceMP4
            // 
            this.chkSplitForceMP4.AutoSize = true;
            this.chkSplitForceMP4.Checked = true;
            this.chkSplitForceMP4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSplitForceMP4.Location = new System.Drawing.Point(303, 190);
            this.chkSplitForceMP4.Name = "chkSplitForceMP4";
            this.chkSplitForceMP4.Size = new System.Drawing.Size(96, 17);
            this.chkSplitForceMP4.TabIndex = 44;
            this.chkSplitForceMP4.Text = "Force MP4 Ext";
            this.chkSplitForceMP4.UseVisualStyleBackColor = true;
            this.chkSplitForceMP4.CheckedChanged += new System.EventHandler(this.chkSplitForceMP4_CheckedChanged);
            // 
            // btnSplitUpdateTime
            // 
            this.btnSplitUpdateTime.Location = new System.Drawing.Point(464, 141);
            this.btnSplitUpdateTime.Name = "btnSplitUpdateTime";
            this.btnSplitUpdateTime.Size = new System.Drawing.Size(20, 21);
            this.btnSplitUpdateTime.TabIndex = 43;
            this.btnSplitUpdateTime.Text = "^";
            this.btnSplitUpdateTime.UseVisualStyleBackColor = true;
            this.btnSplitUpdateTime.Click += new System.EventHandler(this.btnSplitUpdateTime_Click);
            // 
            // btnSplitAutoScan
            // 
            this.btnSplitAutoScan.Location = new System.Drawing.Point(409, 7);
            this.btnSplitAutoScan.Name = "btnSplitAutoScan";
            this.btnSplitAutoScan.Size = new System.Drawing.Size(75, 23);
            this.btnSplitAutoScan.TabIndex = 42;
            this.btnSplitAutoScan.Text = "Auto Scan";
            this.btnSplitAutoScan.UseVisualStyleBackColor = true;
            this.btnSplitAutoScan.Click += new System.EventHandler(this.btnSplitAutoScan_Click);
            // 
            // btnSplitListClear
            // 
            this.btnSplitListClear.Location = new System.Drawing.Point(464, 162);
            this.btnSplitListClear.Name = "btnSplitListClear";
            this.btnSplitListClear.Size = new System.Drawing.Size(20, 21);
            this.btnSplitListClear.TabIndex = 40;
            this.btnSplitListClear.Text = "*";
            this.btnSplitListClear.UseVisualStyleBackColor = true;
            this.btnSplitListClear.Click += new System.EventHandler(this.btnSplitListClear_Click);
            // 
            // btnSplitListRemove
            // 
            this.btnSplitListRemove.Location = new System.Drawing.Point(464, 120);
            this.btnSplitListRemove.Name = "btnSplitListRemove";
            this.btnSplitListRemove.Size = new System.Drawing.Size(20, 21);
            this.btnSplitListRemove.TabIndex = 39;
            this.btnSplitListRemove.Text = "x";
            this.btnSplitListRemove.UseVisualStyleBackColor = true;
            this.btnSplitListRemove.Click += new System.EventHandler(this.btnSplitListRemove_Click);
            // 
            // btnSplitQueue
            // 
            this.btnSplitQueue.Location = new System.Drawing.Point(310, 82);
            this.btnSplitQueue.Name = "btnSplitQueue";
            this.btnSplitQueue.Size = new System.Drawing.Size(174, 23);
            this.btnSplitQueue.TabIndex = 38;
            this.btnSplitQueue.Text = "Add to Split Queue (Ctrl+Insert)";
            this.btnSplitQueue.UseVisualStyleBackColor = true;
            this.btnSplitQueue.Click += new System.EventHandler(this.btnSplitQueue_Click);
            // 
            // lstSplit
            // 
            this.lstSplit.FormattingEnabled = true;
            this.lstSplit.Location = new System.Drawing.Point(310, 124);
            this.lstSplit.Name = "lstSplit";
            this.lstSplit.Size = new System.Drawing.Size(148, 56);
            this.lstSplit.TabIndex = 37;
            this.lstSplit.SelectedIndexChanged += new System.EventHandler(this.lstSplit_SelectedIndexChanged);
            this.lstSplit.SizeChanged += new System.EventHandler(this.lstSplit_SizeChanged);
            this.lstSplit.DoubleClick += new System.EventHandler(this.lstSplit_DoubleClick);
            // 
            // scrollBarMilli
            // 
            this.scrollBarMilli.Location = new System.Drawing.Point(6, 278);
            this.scrollBarMilli.Maximum = 108;
            this.scrollBarMilli.Name = "scrollBarMilli";
            this.scrollBarMilli.Size = new System.Drawing.Size(478, 17);
            this.scrollBarMilli.TabIndex = 36;
            this.scrollBarMilli.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBarMilli_Scroll);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(401, 186);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(57, 23);
            this.btnExec.TabIndex = 35;
            this.btnExec.Text = "Split it!";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnGoEnd
            // 
            this.btnGoEnd.Location = new System.Drawing.Point(470, 59);
            this.btnGoEnd.Name = "btnGoEnd";
            this.btnGoEnd.Size = new System.Drawing.Size(14, 19);
            this.btnGoEnd.TabIndex = 34;
            this.btnGoEnd.Text = "*";
            this.btnGoEnd.UseVisualStyleBackColor = true;
            this.btnGoEnd.Click += new System.EventHandler(this.btnGoEnd_Click);
            // 
            // btnGoStart
            // 
            this.btnGoStart.Location = new System.Drawing.Point(470, 34);
            this.btnGoStart.Name = "btnGoStart";
            this.btnGoStart.Size = new System.Drawing.Size(14, 19);
            this.btnGoStart.TabIndex = 33;
            this.btnGoStart.Text = "*";
            this.btnGoStart.UseVisualStyleBackColor = true;
            this.btnGoStart.Click += new System.EventHandler(this.btnGoStart_Click);
            // 
            // btnSeekEnd
            // 
            this.btnSeekEnd.Location = new System.Drawing.Point(470, 242);
            this.btnSeekEnd.Name = "btnSeekEnd";
            this.btnSeekEnd.Size = new System.Drawing.Size(15, 33);
            this.btnSeekEnd.TabIndex = 32;
            this.btnSeekEnd.Text = ">";
            this.btnSeekEnd.UseVisualStyleBackColor = true;
            this.btnSeekEnd.Click += new System.EventHandler(this.btnSeekEnd_Click);
            // 
            // btnSeekBegin
            // 
            this.btnSeekBegin.Location = new System.Drawing.Point(8, 241);
            this.btnSeekBegin.Name = "btnSeekBegin";
            this.btnSeekBegin.Size = new System.Drawing.Size(15, 33);
            this.btnSeekBegin.TabIndex = 31;
            this.btnSeekBegin.Text = "<";
            this.btnSeekBegin.UseVisualStyleBackColor = true;
            this.btnSeekBegin.Click += new System.EventHandler(this.btnSeekBegin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Position: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtCurrentPos
            // 
            this.txtCurrentPos.BackColor = System.Drawing.SystemColors.Window;
            this.txtCurrentPos.Location = new System.Drawing.Point(51, 219);
            this.txtCurrentPos.Name = "txtCurrentPos";
            this.txtCurrentPos.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPos.TabIndex = 29;
            this.txtCurrentPos.Text = "00:00:00.0";
            this.txtCurrentPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentPos.TextChanged += new System.EventHandler(this.txtCurrentPos_TextChanged_1);
            // 
            // btnEndPos
            // 
            this.btnEndPos.Location = new System.Drawing.Point(333, 219);
            this.btnEndPos.Name = "btnEndPos";
            this.btnEndPos.Size = new System.Drawing.Size(134, 23);
            this.btnEndPos.TabIndex = 28;
            this.btnEndPos.Text = "Set End Pos (Ctrl+Minus)";
            this.btnEndPos.UseVisualStyleBackColor = true;
            this.btnEndPos.Click += new System.EventHandler(this.btnEndPos_Click);
            // 
            // btnStartPos
            // 
            this.btnStartPos.Location = new System.Drawing.Point(193, 219);
            this.btnStartPos.Name = "btnStartPos";
            this.btnStartPos.Size = new System.Drawing.Size(134, 23);
            this.btnStartPos.TabIndex = 27;
            this.btnStartPos.Text = "Set Start Pos (Ctrl+Plus)";
            this.btnStartPos.UseVisualStyleBackColor = true;
            this.btnStartPos.Click += new System.EventHandler(this.btnStartPos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "End Position: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEndPos
            // 
            this.txtEndPos.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndPos.Location = new System.Drawing.Point(388, 59);
            this.txtEndPos.Name = "txtEndPos";
            this.txtEndPos.Size = new System.Drawing.Size(79, 20);
            this.txtEndPos.TabIndex = 25;
            this.txtEndPos.Tag = "0.0";
            this.txtEndPos.Text = "00:00:00.0";
            this.txtEndPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEndPos.TextChanged += new System.EventHandler(this.txtEndPos_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Start Position: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtStartPos
            // 
            this.txtStartPos.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartPos.Location = new System.Drawing.Point(388, 33);
            this.txtStartPos.Name = "txtStartPos";
            this.txtStartPos.Size = new System.Drawing.Size(79, 20);
            this.txtStartPos.TabIndex = 23;
            this.txtStartPos.Tag = "0.0";
            this.txtStartPos.Text = "00:00:00.0";
            this.txtStartPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartPos.TextChanged += new System.EventHandler(this.txtStartPos_TextChanged);
            // 
            // picFrame
            // 
            this.picFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFrame.Location = new System.Drawing.Point(6, 29);
            this.picFrame.Name = "picFrame";
            this.picFrame.Size = new System.Drawing.Size(295, 180);
            this.picFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFrame.TabIndex = 21;
            this.picFrame.TabStop = false;
            this.picFrame.Click += new System.EventHandler(this.picFrame_Click);
            this.picFrame.DragDrop += new System.Windows.Forms.DragEventHandler(this.picFrame_DragDrop);
            // 
            // scrollBar
            // 
            this.scrollBar.Location = new System.Drawing.Point(23, 242);
            this.scrollBar.Maximum = 1382;
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(444, 31);
            this.scrollBar.TabIndex = 20;
            this.scrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBar_Scroll);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtFile.Location = new System.Drawing.Point(51, 7);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(352, 20);
            this.txtFile.TabIndex = 19;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(6, 6);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(38, 20);
            this.btnLoadFile.TabIndex = 18;
            this.btnLoadFile.Text = "...";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // chkAutoSetStart
            // 
            this.chkAutoSetStart.AutoSize = true;
            this.chkAutoSetStart.Checked = true;
            this.chkAutoSetStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSetStart.Location = new System.Drawing.Point(313, 107);
            this.chkAutoSetStart.Name = "chkAutoSetStart";
            this.chkAutoSetStart.Size = new System.Drawing.Size(178, 17);
            this.chkAutoSetStart.TabIndex = 41;
            this.chkAutoSetStart.Text = "Automatically Set Next Start Pos";
            this.chkAutoSetStart.UseVisualStyleBackColor = true;
            this.chkAutoSetStart.CheckedChanged += new System.EventHandler(this.chkAutoSetStart_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkAudio);
            this.tabPage2.Controls.Add(this.btnJoinBatch);
            this.tabPage2.Controls.Add(this.chkXFade);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.numJoinHeight);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.numJoinWidth);
            this.tabPage2.Controls.Add(this.btnJoinMoveDown);
            this.tabPage2.Controls.Add(this.btnJoinMoveUp);
            this.tabPage2.Controls.Add(this.btnJoinClear);
            this.tabPage2.Controls.Add(this.btnJoinRemove);
            this.tabPage2.Controls.Add(this.lblJoinerFileCount);
            this.tabPage2.Controls.Add(this.chkJoinEncode);
            this.tabPage2.Controls.Add(this.btnJoinMerge);
            this.tabPage2.Controls.Add(this.btnJoinAdd);
            this.tabPage2.Controls.Add(this.lstJoin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Joiner";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkAudio
            // 
            this.chkAudio.AutoSize = true;
            this.chkAudio.Checked = true;
            this.chkAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAudio.Location = new System.Drawing.Point(409, 124);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(53, 17);
            this.chkAudio.TabIndex = 47;
            this.chkAudio.Text = "Audio";
            this.chkAudio.UseVisualStyleBackColor = true;
            // 
            // btnJoinBatch
            // 
            this.btnJoinBatch.Location = new System.Drawing.Point(409, 34);
            this.btnJoinBatch.Name = "btnJoinBatch";
            this.btnJoinBatch.Size = new System.Drawing.Size(75, 23);
            this.btnJoinBatch.TabIndex = 46;
            this.btnJoinBatch.Text = "Batch XML";
            this.btnJoinBatch.UseVisualStyleBackColor = true;
            this.btnJoinBatch.Click += new System.EventHandler(this.btnJoinBatch_Click);
            // 
            // chkXFade
            // 
            this.chkXFade.AutoSize = true;
            this.chkXFade.Location = new System.Drawing.Point(409, 145);
            this.chkXFade.Name = "chkXFade";
            this.chkXFade.Size = new System.Drawing.Size(73, 17);
            this.chkXFade.TabIndex = 45;
            this.chkXFade.Text = "Crossfade";
            this.chkXFade.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(407, 232);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Height:";
            // 
            // numJoinHeight
            // 
            this.numJoinHeight.Enabled = false;
            this.numJoinHeight.Location = new System.Drawing.Point(410, 248);
            this.numJoinHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numJoinHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJoinHeight.Name = "numJoinHeight";
            this.numJoinHeight.Size = new System.Drawing.Size(74, 20);
            this.numJoinHeight.TabIndex = 43;
            this.numJoinHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numJoinHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(407, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Width:";
            // 
            // numJoinWidth
            // 
            this.numJoinWidth.Enabled = false;
            this.numJoinWidth.Location = new System.Drawing.Point(409, 204);
            this.numJoinWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numJoinWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJoinWidth.Name = "numJoinWidth";
            this.numJoinWidth.Size = new System.Drawing.Size(76, 20);
            this.numJoinWidth.TabIndex = 41;
            this.numJoinWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numJoinWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // btnJoinMoveDown
            // 
            this.btnJoinMoveDown.Location = new System.Drawing.Point(168, 7);
            this.btnJoinMoveDown.Name = "btnJoinMoveDown";
            this.btnJoinMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnJoinMoveDown.TabIndex = 8;
            this.btnJoinMoveDown.Text = "Move Down";
            this.btnJoinMoveDown.UseVisualStyleBackColor = true;
            this.btnJoinMoveDown.Click += new System.EventHandler(this.btnJoinMoveDown_Click);
            // 
            // btnJoinMoveUp
            // 
            this.btnJoinMoveUp.Location = new System.Drawing.Point(87, 7);
            this.btnJoinMoveUp.Name = "btnJoinMoveUp";
            this.btnJoinMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnJoinMoveUp.TabIndex = 7;
            this.btnJoinMoveUp.Text = "Move Up";
            this.btnJoinMoveUp.UseVisualStyleBackColor = true;
            this.btnJoinMoveUp.Click += new System.EventHandler(this.btnJoinMoveUp_Click);
            // 
            // btnJoinClear
            // 
            this.btnJoinClear.Location = new System.Drawing.Point(329, 7);
            this.btnJoinClear.Name = "btnJoinClear";
            this.btnJoinClear.Size = new System.Drawing.Size(75, 23);
            this.btnJoinClear.TabIndex = 6;
            this.btnJoinClear.Text = "Clear";
            this.btnJoinClear.UseVisualStyleBackColor = true;
            this.btnJoinClear.Click += new System.EventHandler(this.btnJoinClear_Click);
            // 
            // btnJoinRemove
            // 
            this.btnJoinRemove.Location = new System.Drawing.Point(249, 7);
            this.btnJoinRemove.Name = "btnJoinRemove";
            this.btnJoinRemove.Size = new System.Drawing.Size(75, 23);
            this.btnJoinRemove.TabIndex = 5;
            this.btnJoinRemove.Text = "Remove";
            this.btnJoinRemove.UseVisualStyleBackColor = true;
            this.btnJoinRemove.Click += new System.EventHandler(this.btnJoinRemove_Click);
            // 
            // lblJoinerFileCount
            // 
            this.lblJoinerFileCount.AutoSize = true;
            this.lblJoinerFileCount.Location = new System.Drawing.Point(436, 12);
            this.lblJoinerFileCount.Name = "lblJoinerFileCount";
            this.lblJoinerFileCount.Size = new System.Drawing.Size(40, 13);
            this.lblJoinerFileCount.TabIndex = 4;
            this.lblJoinerFileCount.Text = "0 file(s)";
            // 
            // chkJoinEncode
            // 
            this.chkJoinEncode.AutoSize = true;
            this.chkJoinEncode.Location = new System.Drawing.Point(409, 168);
            this.chkJoinEncode.Name = "chkJoinEncode";
            this.chkJoinEncode.Size = new System.Drawing.Size(79, 17);
            this.chkJoinEncode.TabIndex = 3;
            this.chkJoinEncode.Text = "Re-encode";
            this.chkJoinEncode.UseVisualStyleBackColor = true;
            this.chkJoinEncode.CheckedChanged += new System.EventHandler(this.chkJoinEncode_CheckedChanged);
            // 
            // btnJoinMerge
            // 
            this.btnJoinMerge.Location = new System.Drawing.Point(409, 271);
            this.btnJoinMerge.Name = "btnJoinMerge";
            this.btnJoinMerge.Size = new System.Drawing.Size(75, 23);
            this.btnJoinMerge.TabIndex = 2;
            this.btnJoinMerge.Text = "Merge!";
            this.btnJoinMerge.UseVisualStyleBackColor = true;
            this.btnJoinMerge.Click += new System.EventHandler(this.btnJoinMerge_Click);
            // 
            // btnJoinAdd
            // 
            this.btnJoinAdd.Location = new System.Drawing.Point(6, 7);
            this.btnJoinAdd.Name = "btnJoinAdd";
            this.btnJoinAdd.Size = new System.Drawing.Size(75, 23);
            this.btnJoinAdd.TabIndex = 1;
            this.btnJoinAdd.Text = "Add Video";
            this.btnJoinAdd.UseVisualStyleBackColor = true;
            this.btnJoinAdd.Click += new System.EventHandler(this.btnJoinAdd_Click);
            // 
            // lstJoin
            // 
            this.lstJoin.FormattingEnabled = true;
            this.lstJoin.HorizontalScrollbar = true;
            this.lstJoin.Location = new System.Drawing.Point(4, 34);
            this.lstJoin.Name = "lstJoin";
            this.lstJoin.ScrollAlwaysVisible = true;
            this.lstJoin.Size = new System.Drawing.Size(400, 264);
            this.lstJoin.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnResizeAutoCrop);
            this.tabPage5.Controls.Add(this.picResizeFrame);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.numCropVideoTop);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.numCropVideoLeft);
            this.tabPage5.Controls.Add(this.btnCrop);
            this.tabPage5.Controls.Add(this.btnResizeVideo);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.numResizeVideoHeight);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.numResizeVideoWidth);
            this.tabPage5.Controls.Add(this.txtResizeVideoFile);
            this.tabPage5.Controls.Add(this.btnResizeVideoFile);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(490, 299);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Resize";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnResizeAutoCrop
            // 
            this.btnResizeAutoCrop.Location = new System.Drawing.Point(178, 263);
            this.btnResizeAutoCrop.Name = "btnResizeAutoCrop";
            this.btnResizeAutoCrop.Size = new System.Drawing.Size(75, 23);
            this.btnResizeAutoCrop.TabIndex = 48;
            this.btnResizeAutoCrop.Text = "Auto Crop";
            this.btnResizeAutoCrop.UseVisualStyleBackColor = true;
            this.btnResizeAutoCrop.Click += new System.EventHandler(this.btnResizeAutoCrop_Click);
            // 
            // picResizeFrame
            // 
            this.picResizeFrame.Location = new System.Drawing.Point(178, 53);
            this.picResizeFrame.Name = "picResizeFrame";
            this.picResizeFrame.Size = new System.Drawing.Size(295, 204);
            this.picResizeFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResizeFrame.TabIndex = 47;
            this.picResizeFrame.TabStop = false;
            this.picResizeFrame.Click += new System.EventHandler(this.picResizeFrame_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Top:";
            // 
            // numCropVideoTop
            // 
            this.numCropVideoTop.Location = new System.Drawing.Point(94, 205);
            this.numCropVideoTop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCropVideoTop.Name = "numCropVideoTop";
            this.numCropVideoTop.Size = new System.Drawing.Size(67, 20);
            this.numCropVideoTop.TabIndex = 45;
            this.numCropVideoTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCropVideoTop.ValueChanged += new System.EventHandler(this.numCropVideoTop_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Left:";
            // 
            // numCropVideoLeft
            // 
            this.numCropVideoLeft.Location = new System.Drawing.Point(94, 179);
            this.numCropVideoLeft.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCropVideoLeft.Name = "numCropVideoLeft";
            this.numCropVideoLeft.Size = new System.Drawing.Size(67, 20);
            this.numCropVideoLeft.TabIndex = 43;
            this.numCropVideoLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCropVideoLeft.ValueChanged += new System.EventHandler(this.numCropVideoLeft_ValueChanged);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(55, 231);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(106, 56);
            this.btnCrop.TabIndex = 42;
            this.btnCrop.Text = "Crop!";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnResizeVideo
            // 
            this.btnResizeVideo.Location = new System.Drawing.Point(51, 112);
            this.btnResizeVideo.Name = "btnResizeVideo";
            this.btnResizeVideo.Size = new System.Drawing.Size(110, 56);
            this.btnResizeVideo.TabIndex = 41;
            this.btnResizeVideo.Text = "Resize!";
            this.btnResizeVideo.UseVisualStyleBackColor = true;
            this.btnResizeVideo.Click += new System.EventHandler(this.btnResizeVideo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Height:";
            // 
            // numResizeVideoHeight
            // 
            this.numResizeVideoHeight.Location = new System.Drawing.Point(94, 79);
            this.numResizeVideoHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numResizeVideoHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numResizeVideoHeight.Name = "numResizeVideoHeight";
            this.numResizeVideoHeight.Size = new System.Drawing.Size(67, 20);
            this.numResizeVideoHeight.TabIndex = 39;
            this.numResizeVideoHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numResizeVideoHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numResizeVideoHeight.ValueChanged += new System.EventHandler(this.numResizeVideoHeight_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Width:";
            // 
            // numResizeVideoWidth
            // 
            this.numResizeVideoWidth.Location = new System.Drawing.Point(94, 53);
            this.numResizeVideoWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numResizeVideoWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numResizeVideoWidth.Name = "numResizeVideoWidth";
            this.numResizeVideoWidth.Size = new System.Drawing.Size(67, 20);
            this.numResizeVideoWidth.TabIndex = 37;
            this.numResizeVideoWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numResizeVideoWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.numResizeVideoWidth.ValueChanged += new System.EventHandler(this.numResizeVideoWidth_ValueChanged);
            // 
            // txtResizeVideoFile
            // 
            this.txtResizeVideoFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtResizeVideoFile.Location = new System.Drawing.Point(51, 15);
            this.txtResizeVideoFile.Name = "txtResizeVideoFile";
            this.txtResizeVideoFile.ReadOnly = true;
            this.txtResizeVideoFile.Size = new System.Drawing.Size(434, 20);
            this.txtResizeVideoFile.TabIndex = 21;
            // 
            // btnResizeVideoFile
            // 
            this.btnResizeVideoFile.Location = new System.Drawing.Point(6, 15);
            this.btnResizeVideoFile.Name = "btnResizeVideoFile";
            this.btnResizeVideoFile.Size = new System.Drawing.Size(38, 20);
            this.btnResizeVideoFile.TabIndex = 20;
            this.btnResizeVideoFile.Text = "...";
            this.btnResizeVideoFile.UseVisualStyleBackColor = true;
            this.btnResizeVideoFile.Click += new System.EventHandler(this.btnResizeVideoFile_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkAudioTrim);
            this.tabPage3.Controls.Add(this.btnAudioComine);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txtAudioAudio);
            this.tabPage3.Controls.Add(this.btnAudioAudio);
            this.tabPage3.Controls.Add(this.txtAudioVideo);
            this.tabPage3.Controls.Add(this.btnAudioVideo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(490, 299);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Add Audio";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkAudioTrim
            // 
            this.chkAudioTrim.AutoSize = true;
            this.chkAudioTrim.Checked = true;
            this.chkAudioTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAudioTrim.Location = new System.Drawing.Point(68, 85);
            this.chkAudioTrim.Name = "chkAudioTrim";
            this.chkAudioTrim.Size = new System.Drawing.Size(148, 17);
            this.chkAudioTrim.TabIndex = 27;
            this.chkAudioTrim.Text = "Trim audio to video length";
            this.chkAudioTrim.UseVisualStyleBackColor = true;
            // 
            // btnAudioComine
            // 
            this.btnAudioComine.Location = new System.Drawing.Point(68, 122);
            this.btnAudioComine.Name = "btnAudioComine";
            this.btnAudioComine.Size = new System.Drawing.Size(373, 140);
            this.btnAudioComine.TabIndex = 26;
            this.btnAudioComine.Text = "Combine!";
            this.btnAudioComine.UseVisualStyleBackColor = true;
            this.btnAudioComine.Click += new System.EventHandler(this.btnAudioComine_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Audio File: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Video File: ";
            // 
            // txtAudioAudio
            // 
            this.txtAudioAudio.BackColor = System.Drawing.SystemColors.Window;
            this.txtAudioAudio.Location = new System.Drawing.Point(68, 58);
            this.txtAudioAudio.Name = "txtAudioAudio";
            this.txtAudioAudio.ReadOnly = true;
            this.txtAudioAudio.Size = new System.Drawing.Size(373, 20);
            this.txtAudioAudio.TabIndex = 23;
            // 
            // btnAudioAudio
            // 
            this.btnAudioAudio.Location = new System.Drawing.Point(447, 59);
            this.btnAudioAudio.Name = "btnAudioAudio";
            this.btnAudioAudio.Size = new System.Drawing.Size(38, 19);
            this.btnAudioAudio.TabIndex = 22;
            this.btnAudioAudio.Text = "...";
            this.btnAudioAudio.UseVisualStyleBackColor = true;
            this.btnAudioAudio.Click += new System.EventHandler(this.btnAudioAudio_Click);
            // 
            // txtAudioVideo
            // 
            this.txtAudioVideo.BackColor = System.Drawing.SystemColors.Window;
            this.txtAudioVideo.Location = new System.Drawing.Point(68, 27);
            this.txtAudioVideo.Name = "txtAudioVideo";
            this.txtAudioVideo.ReadOnly = true;
            this.txtAudioVideo.Size = new System.Drawing.Size(373, 20);
            this.txtAudioVideo.TabIndex = 21;
            // 
            // btnAudioVideo
            // 
            this.btnAudioVideo.Location = new System.Drawing.Point(447, 26);
            this.btnAudioVideo.Name = "btnAudioVideo";
            this.btnAudioVideo.Size = new System.Drawing.Size(38, 20);
            this.btnAudioVideo.TabIndex = 20;
            this.btnAudioVideo.Text = "...";
            this.btnAudioVideo.UseVisualStyleBackColor = true;
            this.btnAudioVideo.Click += new System.EventHandler(this.btnAudioVideo_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAudioMagicListClear);
            this.tabPage4.Controls.Add(this.btnAudioMagicListRemove);
            this.tabPage4.Controls.Add(this.lstAudioMagic);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.btnExtractAudioVideo);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.chkAudioMagicGenerateFilter);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(490, 299);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Audio Magic";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // btnAudioMagicListClear
            // 
            this.btnAudioMagicListClear.Location = new System.Drawing.Point(434, 104);
            this.btnAudioMagicListClear.Name = "btnAudioMagicListClear";
            this.btnAudioMagicListClear.Size = new System.Drawing.Size(20, 21);
            this.btnAudioMagicListClear.TabIndex = 43;
            this.btnAudioMagicListClear.Text = "*";
            this.btnAudioMagicListClear.UseVisualStyleBackColor = true;
            this.btnAudioMagicListClear.Click += new System.EventHandler(this.btnAudioMagicListClear_Click);
            // 
            // btnAudioMagicListRemove
            // 
            this.btnAudioMagicListRemove.Location = new System.Drawing.Point(434, 77);
            this.btnAudioMagicListRemove.Name = "btnAudioMagicListRemove";
            this.btnAudioMagicListRemove.Size = new System.Drawing.Size(20, 21);
            this.btnAudioMagicListRemove.TabIndex = 42;
            this.btnAudioMagicListRemove.Text = "x";
            this.btnAudioMagicListRemove.UseVisualStyleBackColor = true;
            this.btnAudioMagicListRemove.Click += new System.EventHandler(this.btnAudioMagicListRemove_Click);
            // 
            // lstAudioMagic
            // 
            this.lstAudioMagic.FormattingEnabled = true;
            this.lstAudioMagic.HorizontalScrollbar = true;
            this.lstAudioMagic.Location = new System.Drawing.Point(29, 30);
            this.lstAudioMagic.Name = "lstAudioMagic";
            this.lstAudioMagic.ScrollAlwaysVisible = true;
            this.lstAudioMagic.Size = new System.Drawing.Size(398, 95);
            this.lstAudioMagic.TabIndex = 41;
            this.lstAudioMagic.SelectedIndexChanged += new System.EventHandler(this.lstAudioMagic_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Video File(s): ";
            // 
            // btnExtractAudioVideo
            // 
            this.btnExtractAudioVideo.Location = new System.Drawing.Point(433, 30);
            this.btnExtractAudioVideo.Name = "btnExtractAudioVideo";
            this.btnExtractAudioVideo.Size = new System.Drawing.Size(21, 20);
            this.btnExtractAudioVideo.TabIndex = 36;
            this.btnExtractAudioVideo.Text = "+";
            this.btnExtractAudioVideo.UseVisualStyleBackColor = true;
            this.btnExtractAudioVideo.Click += new System.EventHandler(this.btnExtractAudioVideo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAudioMagicUseFilter);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numVolume);
            this.groupBox2.Controls.Add(this.btnAudioBoost);
            this.groupBox2.Location = new System.Drawing.Point(29, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 118);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adjust Volume";
            // 
            // chkAudioMagicUseFilter
            // 
            this.chkAudioMagicUseFilter.AutoSize = true;
            this.chkAudioMagicUseFilter.Location = new System.Drawing.Point(12, 45);
            this.chkAudioMagicUseFilter.Name = "chkAudioMagicUseFilter";
            this.chkAudioMagicUseFilter.Size = new System.Drawing.Size(123, 17);
            this.chkAudioMagicUseFilter.TabIndex = 37;
            this.chkAudioMagicUseFilter.Text = "Use Generated Filter";
            this.chkAudioMagicUseFilter.UseVisualStyleBackColor = true;
            this.chkAudioMagicUseFilter.CheckedChanged += new System.EventHandler(this.chkAudioMagicUseFilter_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Volume Level:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // numVolume
            // 
            this.numVolume.DecimalPlaces = 1;
            this.numVolume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numVolume.Location = new System.Drawing.Point(89, 21);
            this.numVolume.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(120, 20);
            this.numVolume.TabIndex = 35;
            // 
            // btnAudioBoost
            // 
            this.btnAudioBoost.Location = new System.Drawing.Point(12, 68);
            this.btnAudioBoost.Name = "btnAudioBoost";
            this.btnAudioBoost.Size = new System.Drawing.Size(197, 42);
            this.btnAudioBoost.TabIndex = 34;
            this.btnAudioBoost.Text = "Adjust Audio!";
            this.btnAudioBoost.UseVisualStyleBackColor = true;
            this.btnAudioBoost.Click += new System.EventHandler(this.btnAudioBoost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExtractAudio);
            this.groupBox1.Location = new System.Drawing.Point(254, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 117);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extract Audio";
            // 
            // btnExtractAudio
            // 
            this.btnExtractAudio.Location = new System.Drawing.Point(8, 21);
            this.btnExtractAudio.Name = "btnExtractAudio";
            this.btnExtractAudio.Size = new System.Drawing.Size(197, 82);
            this.btnExtractAudio.TabIndex = 34;
            this.btnExtractAudio.Text = "Extract!";
            this.btnExtractAudio.UseVisualStyleBackColor = true;
            this.btnExtractAudio.Click += new System.EventHandler(this.btnExtractAudio_Click);
            // 
            // chkAudioMagicGenerateFilter
            // 
            this.chkAudioMagicGenerateFilter.AutoSize = true;
            this.chkAudioMagicGenerateFilter.Location = new System.Drawing.Point(319, 14);
            this.chkAudioMagicGenerateFilter.Name = "chkAudioMagicGenerateFilter";
            this.chkAudioMagicGenerateFilter.Size = new System.Drawing.Size(95, 17);
            this.chkAudioMagicGenerateFilter.TabIndex = 44;
            this.chkAudioMagicGenerateFilter.Text = "Generate Filter";
            this.chkAudioMagicGenerateFilter.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label20);
            this.tabPage7.Controls.Add(this.btnColorTest);
            this.tabPage7.Controls.Add(this.picColorNew);
            this.tabPage7.Controls.Add(this.label19);
            this.tabPage7.Controls.Add(this.numGamma);
            this.tabPage7.Controls.Add(this.label18);
            this.tabPage7.Controls.Add(this.numSaturation);
            this.tabPage7.Controls.Add(this.label17);
            this.tabPage7.Controls.Add(this.numBright);
            this.tabPage7.Controls.Add(this.picColorOrig);
            this.tabPage7.Controls.Add(this.label16);
            this.tabPage7.Controls.Add(this.numContrast);
            this.tabPage7.Controls.Add(this.txtColorFile);
            this.tabPage7.Controls.Add(this.picColorOpen);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(490, 299);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Color";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(177, 273);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(153, 13);
            this.label20.TabIndex = 61;
            this.label20.Text = "Hover mouse over to compare!";
            // 
            // btnColorTest
            // 
            this.btnColorTest.Location = new System.Drawing.Point(8, 181);
            this.btnColorTest.Name = "btnColorTest";
            this.btnColorTest.Size = new System.Drawing.Size(131, 33);
            this.btnColorTest.TabIndex = 60;
            this.btnColorTest.Text = "Test";
            this.btnColorTest.UseVisualStyleBackColor = true;
            this.btnColorTest.Click += new System.EventHandler(this.btnColorTest_Click);
            // 
            // picColorNew
            // 
            this.picColorNew.BackColor = System.Drawing.Color.DimGray;
            this.picColorNew.Location = new System.Drawing.Point(177, 62);
            this.picColorNew.Name = "picColorNew";
            this.picColorNew.Size = new System.Drawing.Size(295, 204);
            this.picColorNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picColorNew.TabIndex = 59;
            this.picColorNew.TabStop = false;
            this.picColorNew.Visible = false;
            this.picColorNew.Click += new System.EventHandler(this.picColorNew_Click);
            this.picColorNew.MouseLeave += new System.EventHandler(this.picColorNew_MouseLeave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 141);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 58;
            this.label19.Text = "Gamma";
            // 
            // numGamma
            // 
            this.numGamma.DecimalPlaces = 2;
            this.numGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numGamma.Location = new System.Drawing.Point(64, 139);
            this.numGamma.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            this.numGamma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numGamma.Name = "numGamma";
            this.numGamma.Size = new System.Drawing.Size(60, 20);
            this.numGamma.TabIndex = 57;
            this.numGamma.Tag = "1";
            this.numGamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 56;
            this.label18.Text = "Saturation:";
            // 
            // numSaturation
            // 
            this.numSaturation.DecimalPlaces = 2;
            this.numSaturation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSaturation.Location = new System.Drawing.Point(63, 113);
            this.numSaturation.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            65536});
            this.numSaturation.Name = "numSaturation";
            this.numSaturation.Size = new System.Drawing.Size(61, 20);
            this.numSaturation.TabIndex = 55;
            this.numSaturation.Tag = "1";
            this.numSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSaturation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 54;
            this.label17.Text = "Brightness:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // numBright
            // 
            this.numBright.DecimalPlaces = 2;
            this.numBright.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBright.Location = new System.Drawing.Point(64, 86);
            this.numBright.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numBright.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numBright.Name = "numBright";
            this.numBright.Size = new System.Drawing.Size(60, 20);
            this.numBright.TabIndex = 53;
            this.numBright.Tag = "0";
            this.numBright.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // picColorOrig
            // 
            this.picColorOrig.BackColor = System.Drawing.Color.Black;
            this.picColorOrig.Location = new System.Drawing.Point(177, 62);
            this.picColorOrig.Name = "picColorOrig";
            this.picColorOrig.Size = new System.Drawing.Size(295, 204);
            this.picColorOrig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picColorOrig.TabIndex = 52;
            this.picColorOrig.TabStop = false;
            this.picColorOrig.Click += new System.EventHandler(this.picColorOrig_Click);
            this.picColorOrig.MouseEnter += new System.EventHandler(this.picColorOrig_MouseEnter);
            this.picColorOrig.MouseLeave += new System.EventHandler(this.picColorOrig_MouseLeave);
            this.picColorOrig.MouseHover += new System.EventHandler(this.picColorOrig_MouseHover);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Contrast:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // numContrast
            // 
            this.numContrast.DecimalPlaces = 2;
            this.numContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numContrast.Location = new System.Drawing.Point(64, 60);
            this.numContrast.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.numContrast.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numContrast.Name = "numContrast";
            this.numContrast.Size = new System.Drawing.Size(60, 20);
            this.numContrast.TabIndex = 50;
            this.numContrast.Tag = "1";
            this.numContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numContrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numContrast.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // txtColorFile
            // 
            this.txtColorFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtColorFile.Location = new System.Drawing.Point(50, 24);
            this.txtColorFile.Name = "txtColorFile";
            this.txtColorFile.ReadOnly = true;
            this.txtColorFile.Size = new System.Drawing.Size(434, 20);
            this.txtColorFile.TabIndex = 49;
            this.txtColorFile.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // picColorOpen
            // 
            this.picColorOpen.Location = new System.Drawing.Point(5, 24);
            this.picColorOpen.Name = "picColorOpen";
            this.picColorOpen.Size = new System.Drawing.Size(38, 20);
            this.picColorOpen.TabIndex = 48;
            this.picColorOpen.Text = "...";
            this.picColorOpen.UseVisualStyleBackColor = true;
            this.picColorOpen.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button1);
            this.tabPage6.Controls.Add(this.lstCustom);
            this.tabPage6.Controls.Add(this.txtCustomFilter);
            this.tabPage6.Controls.Add(this.btnCustomSave);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.txtCustomFile);
            this.tabPage6.Controls.Add(this.btnCustomOpen);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(490, 299);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Custom";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstCustom
            // 
            this.lstCustom.FormattingEnabled = true;
            this.lstCustom.Items.AddRange(new object[] {
            "Offset Audio|-i \"%IN%\" -itsoffset 3.84 -i \"%IN%\" -map 0:v -map 1:a -c copy \"%OUT%" +
                "\""});
            this.lstCustom.Location = new System.Drawing.Point(68, 161);
            this.lstCustom.Name = "lstCustom";
            this.lstCustom.Size = new System.Drawing.Size(210, 134);
            this.lstCustom.TabIndex = 44;
            this.lstCustom.SelectedIndexChanged += new System.EventHandler(this.lstCustom_SelectedIndexChanged);
            this.lstCustom.DoubleClick += new System.EventHandler(this.lstCustom_DoubleClick);
            // 
            // txtCustomFilter
            // 
            this.txtCustomFilter.Location = new System.Drawing.Point(68, 58);
            this.txtCustomFilter.Multiline = true;
            this.txtCustomFilter.Name = "txtCustomFilter";
            this.txtCustomFilter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCustomFilter.Size = new System.Drawing.Size(373, 96);
            this.txtCustomFilter.TabIndex = 43;
            this.txtCustomFilter.Text = "-i \"%IN%\" -itsoffset 3.84 -i \"%IN%\" -map 0:v -map 1:a -c copy \"%OUT%\"";
            this.txtCustomFilter.TextChanged += new System.EventHandler(this.txtCustomFilter_TextChanged);
            // 
            // btnCustomSave
            // 
            this.btnCustomSave.Location = new System.Drawing.Point(284, 160);
            this.btnCustomSave.Name = "btnCustomSave";
            this.btnCustomSave.Size = new System.Drawing.Size(157, 135);
            this.btnCustomSave.TabIndex = 42;
            this.btnCustomSave.Text = "Customize!";
            this.btnCustomSave.UseVisualStyleBackColor = true;
            this.btnCustomSave.Click += new System.EventHandler(this.btnCustomSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Filter: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Video File: ";
            // 
            // txtCustomFile
            // 
            this.txtCustomFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomFile.Location = new System.Drawing.Point(68, 29);
            this.txtCustomFile.Name = "txtCustomFile";
            this.txtCustomFile.ReadOnly = true;
            this.txtCustomFile.Size = new System.Drawing.Size(373, 20);
            this.txtCustomFile.TabIndex = 26;
            // 
            // btnCustomOpen
            // 
            this.btnCustomOpen.Location = new System.Drawing.Point(447, 28);
            this.btnCustomOpen.Name = "btnCustomOpen";
            this.btnCustomOpen.Size = new System.Drawing.Size(38, 20);
            this.btnCustomOpen.TabIndex = 25;
            this.btnCustomOpen.Text = "...";
            this.btnCustomOpen.UseVisualStyleBackColor = true;
            this.btnCustomOpen.Click += new System.EventHandler(this.btnCustomOpen_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.button2);
            this.tabPage8.Controls.Add(this.label23);
            this.tabPage8.Controls.Add(this.numericUpDown1);
            this.tabPage8.Controls.Add(this.label24);
            this.tabPage8.Controls.Add(this.numericUpDown2);
            this.tabPage8.Controls.Add(this.label25);
            this.tabPage8.Controls.Add(this.numericUpDown3);
            this.tabPage8.Controls.Add(this.label26);
            this.tabPage8.Controls.Add(this.numericUpDown4);
            this.tabPage8.Controls.Add(this.label21);
            this.tabPage8.Controls.Add(this.textBox1);
            this.tabPage8.Controls.Add(this.label22);
            this.tabPage8.Controls.Add(this.textBox2);
            this.tabPage8.Controls.Add(this.pictureBox1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(490, 299);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Delogo";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 33);
            this.button2.TabIndex = 73;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(355, 114);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 72;
            this.label23.Text = "Top:";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(397, 112);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown1.TabIndex = 71;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(355, 88);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 70;
            this.label24.Text = "Left:";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(397, 86);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown2.TabIndex = 69;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(355, 166);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 68;
            this.label25.Text = "Height:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(397, 164);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown3.TabIndex = 67;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(355, 140);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 13);
            this.label26.TabIndex = 66;
            this.label26.Text = "Width:";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(397, 138);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown4.TabIndex = 65;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown4.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(316, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "End Position: ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(397, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 63;
            this.textBox1.Tag = "0.0";
            this.textBox1.Text = "00:00:00.0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(316, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 13);
            this.label22.TabIndex = 62;
            this.label22.Text = "Start Position: ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(397, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(79, 20);
            this.textBox2.TabIndex = 61;
            this.textBox2.Tag = "0.0";
            this.textBox2.Text = "00:00:00.0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(8, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 358);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(494, 149);
            this.txtLog.TabIndex = 23;
            this.txtLog.Text = "ctrl+left arrow = +10 seconds\r\nalt+left arrow = +1 seconds\r\nctr+shiftl+left arrow" +
    " = +10 microseconds\r\nalt+shiftl+left arrow = +1 microseconds";
            this.txtLog.WordWrap = false;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // tmrProcess
            // 
            this.tmrProcess.Interval = 500;
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Red;
            this.picStatus.Location = new System.Drawing.Point(474, 513);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(18, 20);
            this.picStatus.TabIndex = 24;
            this.picStatus.TabStop = false;
            // 
            // picResizeFrameTemp
            // 
            this.picResizeFrameTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picResizeFrameTemp.Location = new System.Drawing.Point(544, 358);
            this.picResizeFrameTemp.Name = "picResizeFrameTemp";
            this.picResizeFrameTemp.Size = new System.Drawing.Size(295, 180);
            this.picResizeFrameTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResizeFrameTemp.TabIndex = 48;
            this.picResizeFrameTemp.TabStop = false;
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(77, 511);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(390, 23);
            this.pbar.TabIndex = 49;
            // 
            // picStatusB
            // 
            this.picStatusB.BackColor = System.Drawing.Color.Red;
            this.picStatusB.Location = new System.Drawing.Point(492, 513);
            this.picStatusB.Name = "picStatusB";
            this.picStatusB.Size = new System.Drawing.Size(18, 20);
            this.picStatusB.TabIndex = 50;
            this.picStatusB.TabStop = false;
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(16, 515);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(65, 17);
            this.chkVerbose.TabIndex = 51;
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // txtVLog
            // 
            this.txtVLog.Location = new System.Drawing.Point(16, 540);
            this.txtVLog.Multiline = true;
            this.txtVLog.Name = "txtVLog";
            this.txtVLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVLog.Size = new System.Drawing.Size(494, 149);
            this.txtVLog.TabIndex = 52;
            this.txtVLog.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seekToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // seekToolStripMenuItem
            // 
            this.seekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forward10SecsToolStripMenuItem,
            this.forward1SecToolStripMenuItem,
            this.forward10SecToolStripMenuItem,
            this.forward1SecToolStripMenuItem1,
            this.toolStripSeparator1,
            this.back10SecsToolStripMenuItem,
            this.back1SecToolStripMenuItem,
            this.back10SecsToolStripMenuItem1,
            this.back01SecsToolStripMenuItem,
            this.toolStripSeparator2,
            this.beginningToolStripMenuItem,
            this.endToolStripMenuItem,
            this.toolStripSeparator3,
            this.setStartPosToolStripMenuItem,
            this.setEndPosToolStripMenuItem,
            this.addToSplitQToolStripMenuItem});
            this.seekToolStripMenuItem.Name = "seekToolStripMenuItem";
            this.seekToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.seekToolStripMenuItem.Text = "Splitter";
            this.seekToolStripMenuItem.Click += new System.EventHandler(this.seekToolStripMenuItem_Click);
            // 
            // forward10SecsToolStripMenuItem
            // 
            this.forward10SecsToolStripMenuItem.Name = "forward10SecsToolStripMenuItem";
            this.forward10SecsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forward10SecsToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.forward10SecsToolStripMenuItem.Text = "Forward 10 Secs";
            this.forward10SecsToolStripMenuItem.Click += new System.EventHandler(this.forward10SecsToolStripMenuItem_Click);
            // 
            // forward1SecToolStripMenuItem
            // 
            this.forward1SecToolStripMenuItem.Name = "forward1SecToolStripMenuItem";
            this.forward1SecToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.forward1SecToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.forward1SecToolStripMenuItem.Text = "Forward 1 Sec";
            this.forward1SecToolStripMenuItem.Click += new System.EventHandler(this.forward1SecToolStripMenuItem_Click);
            // 
            // forward10SecToolStripMenuItem
            // 
            this.forward10SecToolStripMenuItem.Name = "forward10SecToolStripMenuItem";
            this.forward10SecToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.forward10SecToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.forward10SecToolStripMenuItem.Text = "Forward .10 Secs";
            this.forward10SecToolStripMenuItem.Click += new System.EventHandler(this.forward10SecToolStripMenuItem_Click);
            // 
            // forward1SecToolStripMenuItem1
            // 
            this.forward1SecToolStripMenuItem1.Name = "forward1SecToolStripMenuItem1";
            this.forward1SecToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Right)));
            this.forward1SecToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.forward1SecToolStripMenuItem1.Text = "Forward .01 Sec";
            this.forward1SecToolStripMenuItem1.Click += new System.EventHandler(this.forward1SecToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(252, 6);
            // 
            // back10SecsToolStripMenuItem
            // 
            this.back10SecsToolStripMenuItem.Name = "back10SecsToolStripMenuItem";
            this.back10SecsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.back10SecsToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.back10SecsToolStripMenuItem.Text = "Back 10 Secs";
            this.back10SecsToolStripMenuItem.Click += new System.EventHandler(this.back10SecsToolStripMenuItem_Click);
            // 
            // back1SecToolStripMenuItem
            // 
            this.back1SecToolStripMenuItem.Name = "back1SecToolStripMenuItem";
            this.back1SecToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.back1SecToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.back1SecToolStripMenuItem.Text = "Back 1 Sec";
            this.back1SecToolStripMenuItem.Click += new System.EventHandler(this.back1SecToolStripMenuItem_Click);
            // 
            // back10SecsToolStripMenuItem1
            // 
            this.back10SecsToolStripMenuItem1.Name = "back10SecsToolStripMenuItem1";
            this.back10SecsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Left)));
            this.back10SecsToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.back10SecsToolStripMenuItem1.Text = "Back .10 Secs";
            this.back10SecsToolStripMenuItem1.Click += new System.EventHandler(this.back10SecsToolStripMenuItem1_Click);
            // 
            // back01SecsToolStripMenuItem
            // 
            this.back01SecsToolStripMenuItem.Name = "back01SecsToolStripMenuItem";
            this.back01SecsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Left)));
            this.back01SecsToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.back01SecsToolStripMenuItem.Text = "Back .01 Sec";
            this.back01SecsToolStripMenuItem.Click += new System.EventHandler(this.back01SecsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(252, 6);
            // 
            // beginningToolStripMenuItem
            // 
            this.beginningToolStripMenuItem.Name = "beginningToolStripMenuItem";
            this.beginningToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.beginningToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.beginningToolStripMenuItem.Text = "Beginning";
            this.beginningToolStripMenuItem.Click += new System.EventHandler(this.beginningToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.endToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.endToolStripMenuItem.Text = "End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // setStartPosToolStripMenuItem
            // 
            this.setStartPosToolStripMenuItem.Name = "setStartPosToolStripMenuItem";
            this.setStartPosToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Plus(+)";
            this.setStartPosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.setStartPosToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.setStartPosToolStripMenuItem.Text = "Set Start Pos";
            this.setStartPosToolStripMenuItem.Click += new System.EventHandler(this.setStartPosToolStripMenuItem_Click);
            // 
            // setEndPosToolStripMenuItem
            // 
            this.setEndPosToolStripMenuItem.Name = "setEndPosToolStripMenuItem";
            this.setEndPosToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Minus(-)";
            this.setEndPosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.setEndPosToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.setEndPosToolStripMenuItem.Text = "Set End Pos";
            this.setEndPosToolStripMenuItem.Click += new System.EventHandler(this.setEndPosToolStripMenuItem_Click);
            // 
            // addToSplitQToolStripMenuItem
            // 
            this.addToSplitQToolStripMenuItem.Name = "addToSplitQToolStripMenuItem";
            this.addToSplitQToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Insert";
            this.addToSplitQToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.addToSplitQToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.addToSplitQToolStripMenuItem.Text = "Add to Split Q";
            this.addToSplitQToolStripMenuItem.Click += new System.EventHandler(this.addToSplitQToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 734);
            this.Controls.Add(this.txtVLog);
            this.Controls.Add(this.picStatusB);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.picResizeFrameTemp);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FFMpeg Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJoinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJoinWidth)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResizeFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCropVideoTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCropVideoLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResizeVideoHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResizeVideoWidth)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColorNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResizeFrameTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer tmrPosEdit;
        private System.Windows.Forms.Timer tmrScroll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button btnGoEnd;
        private System.Windows.Forms.Button btnGoStart;
        private System.Windows.Forms.Button btnSeekEnd;
        private System.Windows.Forms.Button btnSeekBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPos;
        private System.Windows.Forms.Button btnEndPos;
        private System.Windows.Forms.Button btnStartPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartPos;
        private System.Windows.Forms.PictureBox picFrame;
        private System.Windows.Forms.HScrollBar scrollBar;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstJoin;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnJoinMerge;
        private System.Windows.Forms.Button btnJoinAdd;
        private System.Windows.Forms.HScrollBar scrollBarMilli;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAudioComine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAudioAudio;
        private System.Windows.Forms.Button btnAudioAudio;
        private System.Windows.Forms.TextBox txtAudioVideo;
        private System.Windows.Forms.Button btnAudioVideo;
        private System.Windows.Forms.CheckBox chkAudioTrim;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkJoinEncode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numVolume;
        private System.Windows.Forms.Button btnAudioBoost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExtractAudio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExtractAudioVideo;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnResizeVideo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numResizeVideoHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numResizeVideoWidth;
        private System.Windows.Forms.TextBox txtResizeVideoFile;
        private System.Windows.Forms.Button btnResizeVideoFile;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomFile;
        private System.Windows.Forms.Button btnCustomOpen;
        private System.Windows.Forms.Button btnCustomSave;
        private System.Windows.Forms.TextBox txtCustomFilter;
        private System.Windows.Forms.ListBox lstCustom;
        private System.Windows.Forms.Button btnSplitQueue;
        private System.Windows.Forms.ListBox lstSplit;
        private System.Windows.Forms.Button btnSplitListClear;
        private System.Windows.Forms.Button btnSplitListRemove;
        private System.Windows.Forms.CheckBox chkAutoSetStart;
        private System.Windows.Forms.Button btnAudioMagicListClear;
        private System.Windows.Forms.Button btnAudioMagicListRemove;
        private System.Windows.Forms.ListBox lstAudioMagic;
        private System.Windows.Forms.Timer tmrProcess;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numCropVideoTop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numCropVideoLeft;
        private System.Windows.Forms.PictureBox picResizeFrame;
        private System.Windows.Forms.PictureBox picResizeFrameTemp;
        private System.Windows.Forms.Button btnResizeAutoCrop;
        private System.Windows.Forms.Button btnSplitAutoScan;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.CheckBox chkAudioMagicUseFilter;
        private System.Windows.Forms.CheckBox chkAudioMagicGenerateFilter;
        private System.Windows.Forms.Label lblJoinerFileCount;
        private System.Windows.Forms.Button btnJoinClear;
        private System.Windows.Forms.Button btnJoinRemove;
        private System.Windows.Forms.Button btnJoinMoveDown;
        private System.Windows.Forms.Button btnJoinMoveUp;
        private System.Windows.Forms.PictureBox picStatusB;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numJoinHeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numJoinWidth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkXFade;
        private System.Windows.Forms.Button btnJoinBatch;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PictureBox picColorOrig;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.TextBox txtColorFile;
        private System.Windows.Forms.Button picColorOpen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numBright;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numGamma;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numSaturation;
        private System.Windows.Forms.PictureBox picColorNew;
        private System.Windows.Forms.Button btnColorTest;
        private System.Windows.Forms.TextBox txtVLog;
        private System.Windows.Forms.Button btnSplitUpdateTime;
        private System.Windows.Forms.CheckBox chkSplitForceMP4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnJumpTime;
        private System.Windows.Forms.Button btnSplitsRestore;
        private System.Windows.Forms.CheckBox chkAudio;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward10SecsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward1SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward10SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward1SecToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem back10SecsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem back1SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem back10SecsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem back01SecsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem beginningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setStartPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setEndPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToSplitQToolStripMenuItem;
    }
}

