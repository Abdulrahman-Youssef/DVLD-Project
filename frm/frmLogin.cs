﻿using System;
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
            string UserName = "", Passowrd = "";
            if (clsGlobal.GetSavedUser(ref UserName, ref Passowrd ))
            {
                txtbUserName.Text = UserName;
                txtbPassword.Text = Passowrd;

            }


        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // just to time cut
            //txtbUserName.Text = "user4"; 
            //txtbPassword.Text = "123";

            clsGlobal.User = clsUsers.LoginSearch(txtbUserName.Text.ToString(), txtbPassword.Text.ToString());

            if (clsGlobal.User != null)
            {
                if (cbRemember.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtbUserName.Text, txtbPassword.Text);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }


                if (!clsGlobal.User.Active)
                {
                    MessageBox.Show("ur account not active conntact rhe admin ");
                    return;
                }


                frmMianScreen frmMianscreen= new frmMianScreen(this);
                this.Hide();
                frmMianscreen.ShowDialog();
                    
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
