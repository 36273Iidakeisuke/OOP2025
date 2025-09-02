namespace RssReader {
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
            cbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btBack = new Button();
            btforward = new Button();
            btfavorite = new Button();
            btdelete = new Button();
            tbFavorite = new TextBox();
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            tsmKeep = new ToolStripMenuItem();
            tsmEnd = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.BackColor = Color.White;
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.ForeColor = Color.Black;
            cbUrl.Location = new Point(207, 41);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(654, 33);
            cbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = Color.White;
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.ForeColor = Color.Black;
            btRssGet.Location = new Point(879, 41);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(92, 33);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = false;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbTitles.BackColor = Color.FromArgb(224, 224, 224);
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.ForeColor = Color.Black;
            lbTitles.FormattingEnabled = true;
            lbTitles.HorizontalScrollbar = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 148);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(482, 592);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.BackColor = Color.FromArgb(224, 224, 224);
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.ForeColor = Color.Black;
            webView21.Location = new Point(547, 150);
            webView21.Name = "webView21";
            webView21.Size = new Size(571, 590);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            webView21.SourceChanged += webView21_SourceChanged;
            // 
            // btBack
            // 
            btBack.BackColor = Color.White;
            btBack.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBack.ForeColor = Color.Black;
            btBack.Location = new Point(12, 41);
            btBack.Name = "btBack";
            btBack.Size = new Size(75, 34);
            btBack.TabIndex = 4;
            btBack.Text = "戻る";
            btBack.UseVisualStyleBackColor = false;
            btBack.Click += btBack_Click;
            // 
            // btforward
            // 
            btforward.BackColor = Color.White;
            btforward.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btforward.ForeColor = SystemColors.WindowText;
            btforward.Location = new Point(111, 41);
            btforward.Name = "btforward";
            btforward.Size = new Size(75, 33);
            btforward.TabIndex = 5;
            btforward.Text = "進む";
            btforward.UseVisualStyleBackColor = false;
            btforward.Click += btforward_Click;
            // 
            // btfavorite
            // 
            btfavorite.BackColor = Color.White;
            btfavorite.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btfavorite.ForeColor = Color.Black;
            btfavorite.Location = new Point(717, 99);
            btfavorite.Name = "btfavorite";
            btfavorite.Size = new Size(144, 33);
            btfavorite.TabIndex = 7;
            btfavorite.Text = "お気に入り登録";
            btfavorite.UseVisualStyleBackColor = false;
            btfavorite.Click += btfavorite_Click;
            // 
            // btdelete
            // 
            btdelete.BackColor = Color.White;
            btdelete.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btdelete.ForeColor = Color.Black;
            btdelete.Location = new Point(879, 99);
            btdelete.Name = "btdelete";
            btdelete.Size = new Size(136, 33);
            btdelete.TabIndex = 8;
            btdelete.Text = "お気に入り削除";
            btdelete.UseVisualStyleBackColor = false;
            btdelete.Click += btdelete_Click;
            // 
            // tbFavorite
            // 
            tbFavorite.BackColor = Color.White;
            tbFavorite.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbFavorite.Location = new Point(207, 99);
            tbFavorite.Name = "tbFavorite";
            tbFavorite.Size = new Size(454, 33);
            tbFavorite.TabIndex = 9;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, ヘルプHToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1153, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmKeep, tsmEnd });
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size = new Size(67, 20);
            ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // tsmKeep
            // 
            tsmKeep.Name = "tsmKeep";
            tsmKeep.ShortcutKeys = Keys.Control | Keys.S;
            tsmKeep.Size = new Size(180, 22);
            tsmKeep.Text = "保存...";
            tsmKeep.Click += tsmKeep_Click;
            // 
            // tsmEnd
            // 
            tsmEnd.Name = "tsmEnd";
            tsmEnd.ShortcutKeys = Keys.Alt | Keys.F4;
            tsmEnd.Size = new Size(180, 22);
            tsmEnd.Text = "終了...";
            tsmEnd.Click += tsmEnd_Click;
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            BackgroundImage = Properties.Resources.ダウンロード;
            ClientSize = new Size(1153, 756);
            Controls.Add(tbFavorite);
            Controls.Add(btdelete);
            Controls.Add(btfavorite);
            Controls.Add(btforward);
            Controls.Add(btBack);
            Controls.Add(webView21);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(cbUrl);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btBack;
        private Button btforward;
        private Button btfavorite;
        private Button btdelete;
        private TextBox tbFavorite;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private ToolStripMenuItem tsmKeep;
        private ToolStripMenuItem tsmEnd;
    }
}
