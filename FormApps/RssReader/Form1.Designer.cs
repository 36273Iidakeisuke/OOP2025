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
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.BackColor = Color.White;
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.ForeColor = Color.Black;
            cbUrl.Location = new Point(207, 12);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(654, 33);
            cbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = Color.White;
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.ForeColor = Color.Black;
            btRssGet.Location = new Point(879, 12);
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
            lbTitles.Location = new Point(12, 127);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(482, 613);
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
            webView21.Location = new Point(547, 127);
            webView21.Name = "webView21";
            webView21.Size = new Size(571, 613);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            webView21.SourceChanged += webView21_SourceChanged;
            // 
            // btBack
            // 
            btBack.BackColor = Color.White;
            btBack.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBack.ForeColor = Color.Black;
            btBack.Location = new Point(12, 12);
            btBack.Name = "btBack";
            btBack.Size = new Size(75, 34);
            btBack.TabIndex = 4;
            btBack.Text = "左";
            btBack.UseVisualStyleBackColor = false;
            btBack.Click += btBack_Click;
            // 
            // btforward
            // 
            btforward.BackColor = Color.White;
            btforward.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btforward.ForeColor = SystemColors.WindowText;
            btforward.Location = new Point(117, 12);
            btforward.Name = "btforward";
            btforward.Size = new Size(75, 33);
            btforward.TabIndex = 5;
            btforward.Text = "右";
            btforward.UseVisualStyleBackColor = false;
            btforward.Click += btforward_Click;
            // 
            // btfavorite
            // 
            btfavorite.BackColor = Color.White;
            btfavorite.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btfavorite.ForeColor = Color.Black;
            btfavorite.Location = new Point(717, 70);
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
            btdelete.Location = new Point(879, 70);
            btdelete.Name = "btdelete";
            btdelete.Size = new Size(136, 33);
            btdelete.TabIndex = 8;
            btdelete.Text = "お気に入り削除";
            btdelete.UseVisualStyleBackColor = false;
            btdelete.Click += btdelete_Click;
            // 
            // tbFavorite
            // 
            tbFavorite.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbFavorite.Location = new Point(207, 70);
            tbFavorite.Name = "tbFavorite";
            tbFavorite.Size = new Size(454, 33);
            tbFavorite.TabIndex = 9;
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
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
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
    }
}
