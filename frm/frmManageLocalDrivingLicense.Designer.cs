namespace Full_Real_Project.frm
{
    partial class frmManageLocalDrivingLicense
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
            this.components = new System.ComponentModel.Container();
            this.dgvLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAppiontmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testVisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testStreatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLocalDrivingLicense
            // 
            this.dgvLocalDrivingLicense.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicense.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicense.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalDrivingLicense.Location = new System.Drawing.Point(12, 184);
            this.dgvLocalDrivingLicense.Name = "dgvLocalDrivingLicense";
            this.dgvLocalDrivingLicense.ReadOnly = true;
            this.dgvLocalDrivingLicense.Size = new System.Drawing.Size(776, 254);
            this.dgvLocalDrivingLicense.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAppiontmentToolStripMenuItem,
            this.issueLicenseToolStripMenuItem,
            this.cancelledToolStripMenuItem,
            this.showLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 124);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // setAppiontmentToolStripMenuItem
            // 
            this.setAppiontmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testVisionToolStripMenuItem,
            this.writeToolStripMenuItem,
            this.testStreatToolStripMenuItem});
            this.setAppiontmentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setAppiontmentToolStripMenuItem.Name = "setAppiontmentToolStripMenuItem";
            this.setAppiontmentToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.setAppiontmentToolStripMenuItem.Text = "scheduleTest";
            this.setAppiontmentToolStripMenuItem.Click += new System.EventHandler(this.setAppiontmentToolStripMenuItem_Click);
            // 
            // testVisionToolStripMenuItem
            // 
            this.testVisionToolStripMenuItem.Enabled = false;
            this.testVisionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testVisionToolStripMenuItem.Name = "testVisionToolStripMenuItem";
            this.testVisionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.testVisionToolStripMenuItem.Text = "schedule Test vision ";
            this.testVisionToolStripMenuItem.Click += new System.EventHandler(this.testVisionToolStripMenuItem_Click);
            // 
            // writeToolStripMenuItem
            // 
            this.writeToolStripMenuItem.Enabled = false;
            this.writeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.writeToolStripMenuItem.Text = "schedule Test Written ";
            this.writeToolStripMenuItem.Click += new System.EventHandler(this.writeToolStripMenuItem_Click);
            // 
            // testStreatToolStripMenuItem
            // 
            this.testStreatToolStripMenuItem.Enabled = false;
            this.testStreatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testStreatToolStripMenuItem.Name = "testStreatToolStripMenuItem";
            this.testStreatToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.testStreatToolStripMenuItem.Text = "schedule Test street";
            this.testStreatToolStripMenuItem.Click += new System.EventHandler(this.testStreatToolStripMenuItem_Click);
            // 
            // issueLicenseToolStripMenuItem
            // 
            this.issueLicenseToolStripMenuItem.Name = "issueLicenseToolStripMenuItem";
            this.issueLicenseToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.issueLicenseToolStripMenuItem.Text = "Issue License";
            this.issueLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueLicenseToolStripMenuItem_Click);
            // 
            // cancelledToolStripMenuItem
            // 
            this.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem";
            this.cancelledToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.cancelledToolStripMenuItem.Text = "Cancelled";
            this.cancelledToolStripMenuItem.Click += new System.EventHandler(this.cancelledToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(279, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.showLicenseToolStripMenuItem.Text = "show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(660, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add new LDLA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmManageLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocalDrivingLicense);
            this.Name = "frmManageLocalDrivingLicense";
            this.Text = "frmManageLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalDrivingLicense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setAppiontmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testVisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testStreatToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem issueLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}