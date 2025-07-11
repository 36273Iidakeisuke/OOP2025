namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dtpDate = new DateTimePicker();
            cbAuthor = new ComboBox();
            groupBox1 = new GroupBox();
            rbOther = new RadioButton();
            rb輸入車 = new RadioButton();
            rbスバル = new RadioButton();
            rbホンダ = new RadioButton();
            rb日産 = new RadioButton();
            rbトヨタ = new RadioButton();
            dgvRecord = new DataGridView();
            tbReport = new TextBox();
            cbCarName = new ComboBox();
            pbPicture = new PictureBox();
            btPicOpen = new Button();
            btPicDelete = new Button();
            btRecordAdd = new Button();
            btRecordModify = new Button();
            btRecodDelete = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            btNewRecord = new Button();
            ssMessageArea = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            ファイルFToolStripMenuItem = new ToolStripMenuItem();
            開くToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            色設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            cbColor = new ColorDialog();
            sfdReportFileSave = new SaveFileDialog();
            ofdReportFileOpen = new OpenFileDialog();
            Timer1 = new System.Windows.Forms.Timer(components);
            lbTimer = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ssMessageArea.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 66);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.Location = new Point(12, 138);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label3.Location = new Point(12, 198);
            label3.Name = "label3";
            label3.Size = new Size(72, 30);
            label3.TabIndex = 0;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label4.Location = new Point(12, 286);
            label4.Name = "label4";
            label4.Size = new Size(55, 30);
            label4.TabIndex = 0;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label5.Location = new Point(12, 339);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label6.Location = new Point(12, 450);
            label6.Name = "label6";
            label6.Size = new Size(55, 30);
            label6.TabIndex = 0;
            label6.Text = "一覧";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label7.Location = new Point(542, 65);
            label7.Name = "label7";
            label7.Size = new Size(55, 30);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Baskerville Old Face", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpDate.Location = new Point(137, 65);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(236, 31);
            dtpDate.TabIndex = 1;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(137, 135);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(236, 33);
            cbAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbOther);
            groupBox1.Controls.Add(rb輸入車);
            groupBox1.Controls.Add(rbスバル);
            groupBox1.Controls.Add(rbホンダ);
            groupBox1.Controls.Add(rb日産);
            groupBox1.Controls.Add(rbトヨタ);
            groupBox1.Location = new Point(137, 187);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(257, 80);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(183, 45);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(56, 19);
            rbOther.TabIndex = 5;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // rb輸入車
            // 
            rb輸入車.AutoSize = true;
            rb輸入車.Location = new Point(90, 45);
            rb輸入車.Name = "rb輸入車";
            rb輸入車.Size = new Size(61, 19);
            rb輸入車.TabIndex = 4;
            rb輸入車.TabStop = true;
            rb輸入車.Text = "輸入車";
            rb輸入車.UseVisualStyleBackColor = true;
            // 
            // rbスバル
            // 
            rbスバル.AutoSize = true;
            rbスバル.Location = new Point(2, 45);
            rbスバル.Name = "rbスバル";
            rbスバル.Size = new Size(54, 19);
            rbスバル.TabIndex = 3;
            rbスバル.TabStop = true;
            rbスバル.Text = "スバル";
            rbスバル.UseVisualStyleBackColor = true;
            // 
            // rbホンダ
            // 
            rbホンダ.AutoSize = true;
            rbホンダ.Location = new Point(183, 11);
            rbホンダ.Name = "rbホンダ";
            rbホンダ.Size = new Size(53, 19);
            rbホンダ.TabIndex = 2;
            rbホンダ.TabStop = true;
            rbホンダ.Text = "ホンダ";
            rbホンダ.UseVisualStyleBackColor = true;
            // 
            // rb日産
            // 
            rb日産.AutoSize = true;
            rb日産.Location = new Point(102, 11);
            rb日産.Name = "rb日産";
            rb日産.Size = new Size(49, 19);
            rb日産.TabIndex = 1;
            rb日産.TabStop = true;
            rb日産.Text = "日産";
            rb日産.UseVisualStyleBackColor = true;
            // 
            // rbトヨタ
            // 
            rbトヨタ.AutoSize = true;
            rbトヨタ.Location = new Point(6, 11);
            rbトヨタ.Name = "rbトヨタ";
            rbトヨタ.Size = new Size(50, 19);
            rbトヨタ.TabIndex = 0;
            rbトヨタ.TabStop = true;
            rbトヨタ.Text = "トヨタ";
            rbトヨタ.UseVisualStyleBackColor = true;
            // 
            // dgvRecord
            // 
            dgvRecord.AllowUserToAddRows = false;
            dgvRecord.AllowUserToDeleteRows = false;
            dgvRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvRecord.DefaultCellStyle = dataGridViewCellStyle1;
            dgvRecord.Location = new Point(137, 450);
            dgvRecord.MultiSelect = false;
            dgvRecord.Name = "dgvRecord";
            dgvRecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecord.Size = new Size(888, 134);
            dgvRecord.TabIndex = 4;
            dgvRecord.Click += dgvRecord_Click;
            // 
            // tbReport
            // 
            tbReport.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbReport.Location = new Point(137, 339);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(345, 93);
            tbReport.TabIndex = 5;
            // 
            // cbCarName
            // 
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(137, 286);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(265, 23);
            cbCarName.TabIndex = 6;
            // 
            // pbPicture
            // 
            pbPicture.BackColor = SystemColors.Info;
            pbPicture.Location = new Point(542, 149);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(483, 234);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 7;
            pbPicture.TabStop = false;
            // 
            // btPicOpen
            // 
            btPicOpen.Location = new Point(788, 96);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(75, 38);
            btPicOpen.TabIndex = 0;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += op1_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.Location = new Point(920, 96);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(75, 38);
            btPicDelete.TabIndex = 0;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += dt1_Click;
            // 
            // btRecordAdd
            // 
            btRecordAdd.Location = new Point(652, 399);
            btRecordAdd.Name = "btRecordAdd";
            btRecordAdd.Size = new Size(75, 43);
            btRecordAdd.TabIndex = 8;
            btRecordAdd.Text = "追加";
            btRecordAdd.UseVisualStyleBackColor = true;
            btRecordAdd.Click += buru_Click;
            // 
            // btRecordModify
            // 
            btRecordModify.Location = new Point(788, 399);
            btRecordModify.Name = "btRecordModify";
            btRecordModify.Size = new Size(75, 43);
            btRecordModify.TabIndex = 9;
            btRecordModify.Text = "修正";
            btRecordModify.UseVisualStyleBackColor = true;
            btRecordModify.Click += btRecordModify_Click;
            // 
            // btRecodDelete
            // 
            btRecodDelete.Location = new Point(920, 399);
            btRecodDelete.Name = "btRecodDelete";
            btRecodDelete.Size = new Size(75, 43);
            btRecodDelete.TabIndex = 10;
            btRecodDelete.Text = "削除";
            btRecodDelete.UseVisualStyleBackColor = true;
            btRecodDelete.Click += btRecodDelete_Click;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // btNewRecord
            // 
            btNewRecord.Location = new Point(402, 96);
            btNewRecord.Name = "btNewRecord";
            btNewRecord.Size = new Size(116, 83);
            btNewRecord.TabIndex = 11;
            btNewRecord.Text = "新規入力";
            btNewRecord.UseVisualStyleBackColor = true;
            btNewRecord.Click += btNewRecord_Click;
            // 
            // ssMessageArea
            // 
            ssMessageArea.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            ssMessageArea.Location = new Point(0, 596);
            ssMessageArea.Name = "ssMessageArea";
            ssMessageArea.Size = new Size(1037, 22);
            ssMessageArea.TabIndex = 12;
            ssMessageArea.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(118, 17);
            tsslbMessage.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルFToolStripMenuItem, ヘルプHToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1037, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            ファイルFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 開くToolStripMenuItem, toolStripSeparator1, 保存ToolStripMenuItem, toolStripSeparator2, 色設定ToolStripMenuItem, toolStripSeparator3, tsmiExit });
            ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            ファイルFToolStripMenuItem.Size = new Size(67, 20);
            ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(140, 22);
            開くToolStripMenuItem.Text = "開く...";
            開くToolStripMenuItem.Click += 開くToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(137, 6);
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(140, 22);
            保存ToolStripMenuItem.Text = "保存...";
            保存ToolStripMenuItem.Click += 保存ToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(137, 6);
            // 
            // 色設定ToolStripMenuItem
            // 
            色設定ToolStripMenuItem.Name = "色設定ToolStripMenuItem";
            色設定ToolStripMenuItem.Size = new Size(140, 22);
            色設定ToolStripMenuItem.Text = "色設定...";
            色設定ToolStripMenuItem.Click += 色設定ToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(137, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.ShortcutKeys = Keys.Alt | Keys.F4;
            tsmiExit.Size = new Size(140, 22);
            tsmiExit.Text = "終了";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiAbout });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(164, 22);
            tsmiAbout.Text = "このアプリについて...";
            tsmiAbout.Click += tsmiAbout_Click;
            // 
            // ofdReportFileOpen
            // 
            ofdReportFileOpen.FileName = "openFileDialog1";
            // 
            // Timer1
            // 
            Timer1.Interval = 1000;
            Timer1.Tick += Timer1_Tick;
            // 
            // lbTimer
            // 
            lbTimer.AutoSize = true;
            lbTimer.Location = new Point(987, 24);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(36, 15);
            lbTimer.TabIndex = 14;
            lbTimer.Text = "Timer";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.White;
            ClientSize = new Size(1037, 618);
            Controls.Add(lbTimer);
            Controls.Add(ssMessageArea);
            Controls.Add(menuStrip1);
            Controls.Add(btNewRecord);
            Controls.Add(btRecodDelete);
            Controls.Add(btRecordModify);
            Controls.Add(btRecordAdd);
            Controls.Add(btPicDelete);
            Controls.Add(btPicOpen);
            Controls.Add(pbPicture);
            Controls.Add(cbCarName);
            Controls.Add(tbReport);
            Controls.Add(dgvRecord);
            Controls.Add(groupBox1);
            Controls.Add(cbAuthor);
            Controls.Add(dtpDate);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "　";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ssMessageArea.ResumeLayout(false);
            ssMessageArea.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpDate;
        private ComboBox cbAuthor;
        private GroupBox groupBox1;
        private RadioButton rbOther;
        private RadioButton rb輸入車;
        private RadioButton rbスバル;
        private RadioButton rbホンダ;
        private RadioButton rb日産;
        private RadioButton rbトヨタ;
        private DataGridView dgvRecord;
        private TextBox tbReport;
        private ComboBox cbCarName;
        private PictureBox pbPicture;
        private Button btPicOpen;
        private Button btPicDelete;
        private Button btRecordAdd;
        private Button btRecordModify;
        private Button btRecodDelete;
        private OpenFileDialog ofdPicFileOpen;
        private Button btNewRecord;
        private StatusStrip ssMessageArea;
        private ToolStripStatusLabel tsslbMessage;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルFToolStripMenuItem;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 色設定ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmiExit;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private ToolStripMenuItem tsmiAbout;
        private ColorDialog cbColor;
        private SaveFileDialog sfdReportFileSave;
        private OpenFileDialog ofdReportFileOpen;
        private System.Windows.Forms.Timer Timer1;
        private Label lbTimer;
    }
}
