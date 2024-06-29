namespace Full_Real_Project.frm
{
    partial class frmInternationalDrivingApplication
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSeacrh = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlLicenseInfo1 = new Full_Real_Project.ctrl.ctrlLicenseInfo();
            this.ctrlFullApplicationInfo1 = new Full_Real_Project.ctrl.ctrlFullApplicationInfo();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnSeacrh
            // 
            this.btnSeacrh.Location = new System.Drawing.Point(453, 44);
            this.btnSeacrh.Name = "btnSeacrh";
            this.btnSeacrh.Size = new System.Drawing.Size(75, 23);
            this.btnSeacrh.TabIndex = 1;
            this.btnSeacrh.Text = "Search";
            this.btnSeacrh.UseVisualStyleBackColor = true;
            this.btnSeacrh.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(713, 566);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 23);
            this.btnIssue.TabIndex = 4;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(38, 82);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(719, 307);
            this.ctrlLicenseInfo1.TabIndex = 3;
            // 
            // ctrlFullApplicationInfo1
            // 
            this.ctrlFullApplicationInfo1.Location = new System.Drawing.Point(38, 395);
            this.ctrlFullApplicationInfo1.Name = "ctrlFullApplicationInfo1";
            this.ctrlFullApplicationInfo1.Size = new System.Drawing.Size(719, 165);
            this.ctrlFullApplicationInfo1.TabIndex = 2;
            // 
            // frmInternationalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.ctrlFullApplicationInfo1);
            this.Controls.Add(this.btnSeacrh);
            this.Controls.Add(this.textBox1);
            this.Name = "frmInternationalDrivingApplication";
            this.Text = "frmInternationalDrivingApplication";
            this.Load += new System.EventHandler(this.frmInternationalDrivingApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSeacrh;
        private ctrl.ctrlFullApplicationInfo ctrlFullApplicationInfo1;
        private ctrl.ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.Button btnIssue;
    }
}