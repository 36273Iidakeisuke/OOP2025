namespace UnitConverter {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label4 = new System.Windows.Forms.Label();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudAnswer = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btCalc = new System.Windows.Forms.Button();
            this.nudAmari = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(79, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "距離変換アプリ";
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(142, 85);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(100, 28);
            this.tbNum1.TabIndex = 1;
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(142, 195);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(100, 28);
            this.tbNum2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(54, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "変換前";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(54, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "変換後";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(145, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "変換";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttun1_Click);
            // 
            // nudNum1
            // 
            this.nudNum1.Font = new System.Drawing.Font("Palace Script MT", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNum1.Location = new System.Drawing.Point(38, 236);
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(120, 96);
            this.nudNum1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(164, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 43);
            this.label7.TabIndex = 3;
            this.label7.Text = "÷";
            // 
            // nudNum2
            // 
            this.nudNum2.Font = new System.Drawing.Font("Palace Script MT", 72F, System.Drawing.FontStyle.Italic);
            this.nudNum2.Location = new System.Drawing.Point(226, 381);
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(120, 96);
            this.nudNum2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(352, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 43);
            this.label8.TabIndex = 3;
            this.label8.Text = "=";
            // 
            // nudAnswer
            // 
            this.nudAnswer.Font = new System.Drawing.Font("Palace Script MT", 72F, System.Drawing.FontStyle.Italic);
            this.nudAnswer.Location = new System.Drawing.Point(404, 236);
            this.nudAnswer.Name = "nudAnswer";
            this.nudAnswer.Size = new System.Drawing.Size(120, 96);
            this.nudAnswer.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.Font = new System.Drawing.Font("UD デジタル 教科書体 N", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(522, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 43);
            this.label9.TabIndex = 3;
            this.label9.Text = "あまり";
            // 
            // btCalc
            // 
            this.btCalc.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btCalc.Location = new System.Drawing.Point(373, 503);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(88, 45);
            this.btCalc.TabIndex = 7;
            this.btCalc.Text = "計算";
            this.btCalc.UseVisualStyleBackColor = true;
            this.btCalc.Click += new System.EventHandler(this.btCalc_Click);
            // 
            // nudAmari
            // 
            this.nudAmari.Font = new System.Drawing.Font("Palace Script MT", 72F, System.Drawing.FontStyle.Italic);
            this.nudAmari.Location = new System.Drawing.Point(658, 381);
            this.nudAmari.Name = "nudAmari";
            this.nudAmari.Size = new System.Drawing.Size(120, 96);
            this.nudAmari.TabIndex = 6;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(912, 579);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.nudAmari);
            this.Controls.Add(this.nudAnswer);
            this.Controls.Add(this.nudNum2);
            this.Controls.Add(this.nudNum1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChange1;
        private System.Windows.Forms.TextBox tbChange2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudAnswer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.NumericUpDown nudAmari;
    }
}

