namespace Full_Real_Project.frm
{
    partial class frmAddedTestAppointment
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlAddAppointment1 = new Full_Real_Project.ctrl.ctrlAddAppointment();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(450, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlAddAppointment1
            // 
            this.ctrlAddAppointment1.AppointmentDate = new System.DateTime(((long)(0)));
            this.ctrlAddAppointment1.Location = new System.Drawing.Point(42, 27);
            this.ctrlAddAppointment1.Name = "ctrlAddAppointment1";
            this.ctrlAddAppointment1.Size = new System.Drawing.Size(403, 329);
            this.ctrlAddAppointment1.TabIndex = 0;
            this.ctrlAddAppointment1.TestType = null;
            this.ctrlAddAppointment1.TotalPaidFees = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmAddedTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlAddAppointment1);
            this.Name = "frmAddedTestAppointment";
            this.Text = "frmAddedTestAppointment";
            this.Load += new System.EventHandler(this.frmAddedTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrl.ctrlAddAppointment ctrlAddAppointment1;
        private System.Windows.Forms.Button btnSave;
    }
}