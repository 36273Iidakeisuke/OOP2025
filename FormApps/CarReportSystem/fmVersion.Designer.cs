namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btOK = new Button();
            label1 = new Label();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // btOK
            // 
            btOK.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btOK.Location = new Point(264, 152);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 32);
            btOK.TabIndex = 0;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Yellow;
            label1.Font = new Font("ＭＳ Ｐ明朝", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(49, 46);
            label1.Name = "label1";
            label1.Size = new Size(248, 21);
            label1.TabIndex = 1;
            label1.Text = "試乗レポート管理システム";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(271, 92);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(68, 21);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver.0.0.1";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(358, 208);
            ControlBox = false;
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btOK);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmVersion";
            ShowInTaskbar = false;
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOK;
        private Label label1;
        private Label lbVersion;
    }
}