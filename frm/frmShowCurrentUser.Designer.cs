namespace Full_Real_Project.frm
{
    partial class frmShowCurrentUser
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
            this.ctrlUserinfo1 = new Full_Real_Project.ctrlUserinfo();
            this.SuspendLayout();
            // 
            // ctrlUserinfo1
            // 
            this.ctrlUserinfo1.Location = new System.Drawing.Point(10, 8);
            this.ctrlUserinfo1.Name = "ctrlUserinfo1";
            this.ctrlUserinfo1.Size = new System.Drawing.Size(939, 393);
            this.ctrlUserinfo1.TabIndex = 0;
            // 
            // frmShowCurrentUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 402);
            this.Controls.Add(this.ctrlUserinfo1);
            this.Name = "frmShowCurrentUser";
            this.Text = "frmShowCurrentUser";
            this.Load += new System.EventHandler(this.frmShowCurrentUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUserinfo ctrlUserinfo1;
    }
}