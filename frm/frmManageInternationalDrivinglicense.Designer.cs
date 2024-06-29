namespace Full_Real_Project.frm
{
    partial class frmManageInternationalDrivinglicense
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
            this.dgvIDL = new System.Windows.Forms.DataGridView();
            this.btnAddedNewIDL = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIDL
            // 
            this.dgvIDL.AllowUserToAddRows = false;
            this.dgvIDL.AllowUserToDeleteRows = false;
            this.dgvIDL.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvIDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIDL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvIDL.Location = new System.Drawing.Point(0, 215);
            this.dgvIDL.Name = "dgvIDL";
            this.dgvIDL.ReadOnly = true;
            this.dgvIDL.Size = new System.Drawing.Size(800, 235);
            this.dgvIDL.TabIndex = 0;
            // 
            // btnAddedNewIDL
            // 
            this.btnAddedNewIDL.Location = new System.Drawing.Point(678, 171);
            this.btnAddedNewIDL.Name = "btnAddedNewIDL";
            this.btnAddedNewIDL.Size = new System.Drawing.Size(110, 38);
            this.btnAddedNewIDL.TabIndex = 1;
            this.btnAddedNewIDL.Text = "Added New IDL";
            this.btnAddedNewIDL.UseVisualStyleBackColor = true;
            this.btnAddedNewIDL.Click += new System.EventHandler(this.btnAddedNewIDL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(249, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 128);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "International Driving License";
            // 
            // frmManageInternationalDrivinglicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddedNewIDL);
            this.Controls.Add(this.dgvIDL);
            this.Name = "frmManageInternationalDrivinglicense";
            this.Text = "frmManageInternationalDrivinglicense";
            this.Load += new System.EventHandler(this.frmManageInternationalDrivinglicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIDL;
        private System.Windows.Forms.Button btnAddedNewIDL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}