using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Full_Real_Project_Buisness_layer_;

namespace Full_Real_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userId = clsUsers.LoginSearch(txtbUserName.Text, txtbPassword.Text);

            if (userId != -1)
            {
                frmManagePeoPle frmManageppl = new frmManagePeoPle();
                frmManageppl.Show();
                //this.Close();
                 
               
            }
            else
            {
                errorProvider1.SetError(txtbPassword, "User Name or Password are wrong");
                errorProvider1.SetError(txtbUserName, "User Name or Password are wrong");
            }
         

        }

        private void txtbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace( txtbUserName.Text))
            {
                e.Cancel = true;
                txtbUserName.Focus();
                errorProvider1.SetError(txtbUserName, "u have to write the user name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbUserName, "");
            }


        }

        private void txtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace( txtbPassword.Text))
            {
                e.Cancel = true;
                txtbPassword.Focus();
                errorProvider1.SetError(txtbPassword, "u have to write the user name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbPassword, "");
            }
        }
    }
}
