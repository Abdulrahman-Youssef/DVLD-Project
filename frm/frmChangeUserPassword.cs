using Full_Real_Project_Buisness_layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project.frm
{
    public partial class frmChangeUserPassword : Form
    {
        int UserID;
        clsUsers User;
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctrlUserinfo1_Load(object sender, EventArgs e)
        {
            ctrlUserinfo1.LoadTheCurrentUser(this.UserID);
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            User = clsUsers.FindUserByUesrID(this.UserID);
            if (User != null)
            {
                if ((txtbCurrentPassword.Text != User.Password))
                {
                    errorProvider1.SetError(txtbConfiremNewPassword, "the current password is wrong");
                }
                else if (txtbConfiremNewPassword.Text == "")
                {
                    errorProvider1.SetError(txtbConfiremNewPassword, "confirmed password cant me empty");
                }
                else if (txtbCurrentPassword.Text == "")
                {
                    errorProvider1.SetError(txtbCurrentPassword, "current password Cant be empty");
                }
                else if (txtbNewPassword.Text == "")
                {
                    errorProvider1.SetError(txtbNewPassword, "new password cant be empty");
                }
                else if (txtbNewPassword.Text != txtbConfiremNewPassword.Text)
                {
                    errorProvider1.SetError(txtbNewPassword, "the password dosen't much the Confirmed password");
                    errorProvider1.SetError(txtbConfiremNewPassword, "the password dosen't much the Confirmed password");
                }
                else
                {
                    if (clsUsers.UpdatePasswordByUserID(UserID, txtbNewPassword.Text))
                    {
                        MessageBox.Show("Password has been Changed successfuly ");
                    }
                }
            }
        }
    }
}
