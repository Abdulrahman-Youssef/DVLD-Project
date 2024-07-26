namespace Full_Real_Project_DataAccess_layer_
{
    partial class frmDetainLicense
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ctrlDetianApplicationInfo1 = new Full_Real_Project.ctrl.ctrlDetianApplicationInfo();
            this.ctrlLicenseInfo1 = new Full_Real_Project.ctrl.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(455, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Location = new System.Drawing.Point(651, 481);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(95, 25);
            this.btnDetain.TabIndex = 1;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ctrlDetianApplicationInfo1
            // 
            this.ctrlDetianApplicationInfo1.Finefees = 0;
            this.ctrlDetianApplicationInfo1.Location = new System.Drawing.Point(44, 352);
            this.ctrlDetianApplicationInfo1.Name = "ctrlDetianApplicationInfo1";
            this.ctrlDetianApplicationInfo1.Size = new System.Drawing.Size(668, 123);
            this.ctrlDetianApplicationInfo1.TabIndex = 5;
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.ExpirationDate = new System.DateTime(((long)(0)));
            this.ctrlLicenseInfo1.LicenseID = 0;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(5, 39);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(747, 307);
            this.ctrlLicenseInfo1.TabIndex = 4;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 507);
            this.Controls.Add(this.ctrlDetianApplicationInfo1);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmDetainLicense";
            this.Text = "frmDetainLicense";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.TextBox textBox1;
        private Full_Real_Project.ctrl.ctrlLicenseInfo ctrlLicenseInfo1;
        private Full_Real_Project.ctrl.ctrlDetianApplicationInfo ctrlDetianApplicationInfo1;
    }
}