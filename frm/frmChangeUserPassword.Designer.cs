namespace Full_Real_Project.frm
{
    partial class frmChangeUserPassword
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
            this.txtbCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtbNewPassword = new System.Windows.Forms.TextBox();
            this.txtbConfiremNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctrlUserinfo1 = new Full_Real_Project.ctrlUserinfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbCurrentPassword
            // 
            this.txtbCurrentPassword.Location = new System.Drawing.Point(155, 392);
            this.txtbCurrentPassword.Name = "txtbCurrentPassword";
            this.txtbCurrentPassword.Size = new System.Drawing.Size(100, 20);
            this.txtbCurrentPassword.TabIndex = 1;
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.Location = new System.Drawing.Point(155, 436);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtbNewPassword.TabIndex = 2;
            this.txtbNewPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtbConfiremNewPassword
            // 
            this.txtbConfiremNewPassword.Location = new System.Drawing.Point(155, 480);
            this.txtbConfiremNewPassword.Name = "txtbConfiremNewPassword";
            this.txtbConfiremNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtbConfiremNewPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirem New Password";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(795, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 37);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(678, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 37);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // ctrlUserinfo1
            // 
            this.ctrlUserinfo1.Location = new System.Drawing.Point(1, 3);
            this.ctrlUserinfo1.Name = "ctrlUserinfo1";
            this.ctrlUserinfo1.Size = new System.Drawing.Size(894, 383);
            this.ctrlUserinfo1.TabIndex = 0;
            this.ctrlUserinfo1.Load += new System.EventHandler(this.ctrlUserinfo1_Load);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangeCurrentUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 546);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbConfiremNewPassword);
            this.Controls.Add(this.txtbNewPassword);
            this.Controls.Add(this.txtbCurrentPassword);
            this.Controls.Add(this.ctrlUserinfo1);
            this.Name = "frmChangeCurrentUserPassword";
            this.Text = "frmChangeCurrentUserPassword";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbCurrentPassword;
        private System.Windows.Forms.TextBox txtbNewPassword;
        private System.Windows.Forms.TextBox txtbConfiremNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ctrlUserinfo ctrlUserinfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}