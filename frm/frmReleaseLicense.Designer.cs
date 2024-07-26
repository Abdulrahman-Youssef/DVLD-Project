namespace Full_Real_Project.frm
{
    partial class frmReleaseLicense
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
            this.btnSreach = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlApplicationInfoReleaseInfo1 = new Full_Real_Project.ctrl.ctrlApplicationInfoReleaseInfo();
            this.ctrlLicenseInfo1 = new Full_Real_Project.ctrl.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnSreach
            // 
            this.btnSreach.Location = new System.Drawing.Point(493, 13);
            this.btnSreach.Name = "btnSreach";
            this.btnSreach.Size = new System.Drawing.Size(75, 23);
            this.btnSreach.TabIndex = 3;
            this.btnSreach.Text = "Sreach";
            this.btnSreach.UseVisualStyleBackColor = true;
            this.btnSreach.Click += new System.EventHandler(this.btnSreach_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BackColor = System.Drawing.Color.Linen;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelease.Location = new System.Drawing.Point(678, 559);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 26);
            this.btnRelease.TabIndex = 4;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = false;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "License ID";
            // 
            // ctrlApplicationInfoReleaseInfo1
            // 
            this.ctrlApplicationInfoReleaseInfo1.DetainedID = 0;
            this.ctrlApplicationInfoReleaseInfo1.LincenseID = 0;
            this.ctrlApplicationInfoReleaseInfo1.Location = new System.Drawing.Point(21, 383);
            this.ctrlApplicationInfoReleaseInfo1.Name = "ctrlApplicationInfoReleaseInfo1";
            this.ctrlApplicationInfoReleaseInfo1.Size = new System.Drawing.Size(719, 171);
            this.ctrlApplicationInfoReleaseInfo1.TabIndex = 1;
            this.ctrlApplicationInfoReleaseInfo1.Load += new System.EventHandler(this.ctrlApplicationInfoReleaseInfo1_Load);
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlLicenseInfo1.LicenseID = 0;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(8, 44);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(745, 340);
            this.ctrlLicenseInfo1.TabIndex = 0;
            this.ctrlLicenseInfo1.Load += new System.EventHandler(this.ctrlLicenseInfo1_Load);
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(762, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnSreach);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ctrlApplicationInfoReleaseInfo1);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "frmReleaseLicense";
            this.Text = "frmReleaseLicense";
            this.Load += new System.EventHandler(this.frmReleaseLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrl.ctrlLicenseInfo ctrlLicenseInfo1;
        private ctrl.ctrlApplicationInfoReleaseInfo ctrlApplicationInfoReleaseInfo1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSreach;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label label1;
    }
}