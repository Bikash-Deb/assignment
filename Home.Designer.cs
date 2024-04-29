namespace Amar_Cash
{
    partial class Home
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
            this.checkbalancebtn = new System.Windows.Forms.Button();
            this.cashoutbtn = new System.Windows.Forms.Button();
            this.transferbtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.balancelbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkbalancebtn
            // 
            this.checkbalancebtn.Location = new System.Drawing.Point(94, 66);
            this.checkbalancebtn.Name = "checkbalancebtn";
            this.checkbalancebtn.Size = new System.Drawing.Size(122, 65);
            this.checkbalancebtn.TabIndex = 0;
            this.checkbalancebtn.Text = "Check Balance";
            this.checkbalancebtn.UseVisualStyleBackColor = true;
            this.checkbalancebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cashoutbtn
            // 
            this.cashoutbtn.Location = new System.Drawing.Point(94, 245);
            this.cashoutbtn.Name = "cashoutbtn";
            this.cashoutbtn.Size = new System.Drawing.Size(100, 52);
            this.cashoutbtn.TabIndex = 1;
            this.cashoutbtn.Text = "Cash Out";
            this.cashoutbtn.UseVisualStyleBackColor = true;
            this.cashoutbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // transferbtn
            // 
            this.transferbtn.Location = new System.Drawing.Point(94, 153);
            this.transferbtn.Name = "transferbtn";
            this.transferbtn.Size = new System.Drawing.Size(91, 56);
            this.transferbtn.TabIndex = 2;
            this.transferbtn.Text = "Transfer Money";
            this.transferbtn.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(94, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "Pay Bill";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // balancelbl
            // 
            this.balancelbl.AutoSize = true;
            this.balancelbl.Location = new System.Drawing.Point(287, 80);
            this.balancelbl.Name = "balancelbl";
            this.balancelbl.Size = new System.Drawing.Size(67, 20);
            this.balancelbl.TabIndex = 4;
            this.balancelbl.Text = "Balance";
            this.balancelbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "History";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.balancelbl);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.transferbtn);
            this.Controls.Add(this.cashoutbtn);
            this.Controls.Add(this.checkbalancebtn);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkbalancebtn;
        private System.Windows.Forms.Button cashoutbtn;
        private System.Windows.Forms.Button transferbtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label balancelbl;
        private System.Windows.Forms.Button button1;
    }
}