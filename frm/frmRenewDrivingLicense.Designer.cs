namespace Full_Real_Project.frm
{
    partial class frmRenewDrivingLicense
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
            this.btnRenew = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlApplicationRenewLicense1 = new Full_Real_Project.ctrl.ctrlApplicationRenewLicense();
            this.ctrlLicenseInfo1 = new Full_Real_Project.ctrl.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Location = new System.Drawing.Point(609, 659);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 25);
            this.btnRenew.TabIndex = 8;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(150, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 20);
            this.textBox2.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(414, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlApplicationRenewLicense1
            // 
            this.ctrlApplicationRenewLicense1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlApplicationRenewLicense1.LicenseID = 0;
            this.ctrlApplicationRenewLicense1.Location = new System.Drawing.Point(6, 359);
            this.ctrlApplicationRenewLicense1.Name = "ctrlApplicationRenewLicense1";
            this.ctrlApplicationRenewLicense1.Notes = null;
            this.ctrlApplicationRenewLicense1.Size = new System.Drawing.Size(676, 295);
            this.ctrlApplicationRenewLicense1.TabIndex = 11;
            this.ctrlApplicationRenewLicense1.Load += new System.EventHandler(this.ctrlApplicationRenewLicense1_Load);
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlLicenseInfo1.LicenseID = 0;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(6, 46);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(676, 307);
            this.ctrlLicenseInfo1.TabIndex = 1;
            // 
            // frmRenewDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 685);
            this.Controls.Add(this.ctrlApplicationRenewLicense1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "frmRenewDrivingLicense";
            this.Text = "frmRenewDrivingLicense";
            this.Load += new System.EventHandler(this.frmRenewDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ctrl.ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSearch;
        private ctrl.ctrlApplicationRenewLicense ctrlApplicationRenewLicense1;
    }
}