namespace Full_Real_Project.frm
{
    partial class frmReplacedForDamagedOrLost
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
            this.ctrlLicenseInfo1 = new Full_Real_Project.ctrl.ctrlLicenseInfo();
            this.ctrlFullApplicationInfo1 = new Full_Real_Project.ctrl.ctrlFullApplicationInfo();
            this.btnSeacrh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(6, 71);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(719, 310);
            this.ctrlLicenseInfo1.TabIndex = 7;
            // 
            // ctrlFullApplicationInfo1
            // 
            this.ctrlFullApplicationInfo1.ApplicationFees = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrlFullApplicationInfo1.LDLA = -1;
            this.ctrlFullApplicationInfo1.Location = new System.Drawing.Point(6, 384);
            this.ctrlFullApplicationInfo1.Name = "ctrlFullApplicationInfo1";
            this.ctrlFullApplicationInfo1.Size = new System.Drawing.Size(719, 165);
            this.ctrlFullApplicationInfo1.TabIndex = 6;
            // 
            // btnSeacrh
            // 
            this.btnSeacrh.Location = new System.Drawing.Point(457, 24);
            this.btnSeacrh.Name = "btnSeacrh";
            this.btnSeacrh.Size = new System.Drawing.Size(75, 23);
            this.btnSeacrh.TabIndex = 5;
            this.btnSeacrh.Text = "Search";
            this.btnSeacrh.UseVisualStyleBackColor = true;
            this.btnSeacrh.Click += new System.EventHandler(this.btnSeacrh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLost);
            this.groupBox1.Controls.Add(this.rbDamaged);
            this.groupBox1.Location = new System.Drawing.Point(558, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 70);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repalced For";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(24, 45);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(45, 17);
            this.rbLost.TabIndex = 1;
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Location = new System.Drawing.Point(24, 18);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(74, 17);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged ";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(650, 556);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 31);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(552, 556);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmReplacedForDamagedOrLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 591);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.ctrlFullApplicationInfo1);
            this.Controls.Add(this.btnSeacrh);
            this.Controls.Add(this.textBox1);
            this.Name = "frmReplacedForDamagedOrLost";
            this.Text = "frmReplacedForDamagedOrLost";
            this.Load += new System.EventHandler(this.frmReplacedForDamagedOrLost_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrl.ctrlLicenseInfo ctrlLicenseInfo1;
        private ctrl.ctrlFullApplicationInfo ctrlFullApplicationInfo1;
        private System.Windows.Forms.Button btnSeacrh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnCancel;
    }
}