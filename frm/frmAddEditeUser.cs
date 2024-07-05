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
namespace Full_Real_Project.frm
{
    public partial class frmAddEditeUser : Form
    {
        clsUsers user; 
        enum enMode { AddedNew, Updated };
        enMode mode;
        public void _AbleTheLogin(int OFFON) 
        {
            if (OFFON == 1)
            {
                lblUserID.Enabled = true;
                txtbPassword.Enabled = true;
                txtbConfiremPassword.Enabled = true;
                txtbUserName.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                cbActive.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                lblUserID.Enabled = false;
                txtbPassword.Enabled = false;
                txtbConfiremPassword.Enabled = false;
                txtbUserName.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                cbActive.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        public void enabledFiltercb(bool OFFON)
        {
            userInfoAndSreach1.LoadWithEnabledFilter(OFFON , user.UserID);
        }
        public void LoadPersonInfo()
        {
            userInfoAndSreach1.LoadUserInfo(user.PersonID);
        }
        public frmAddEditeUser(int UserID)
        {
            InitializeComponent();

            if (UserID == -1)
            {
                user = new clsUsers();
                mode = enMode.AddedNew;
                _FillForm();

            }
            else
            {
                user = clsUsers.FindUserByUesrID(UserID);
                mode = enMode.Updated;
                _FillForm();
                userInfoAndSreach1.PersonID = UserID;
            }
        }     

        private void _FillForm()
        {
            if(mode == enMode.AddedNew)
            {

                lblTitle.Text = "Added New User";
                txtbUserName.Text = user.UserName;
                txtbPassword.Text = user.Password;
                txtbConfiremPassword.Text = user.Password;
                cbActive.Checked = user.Active;
            
            }
            else if(mode == enMode.Updated)
            {
                lblTitle.Text = "Update";
                txtbUserName.Text = user.UserName;
                txtbPassword.Text = user.Password;
                txtbConfiremPassword.Text = user.Password;
                cbActive.Checked = user.Active;
                //
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // check on the personID in Users and if u do find it that means u cant go and if u do find it u have to check he is one of the people
            if (clsContact.IsContactExist(userInfoAndSreach1.PersonID) && !clsUsers.IsUserExistByPersonID(userInfoAndSreach1.PersonID))
            {
             _AbleTheLogin(1);
             tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("the User is Already Exist OR not one of the Poeple");
                _AbleTheLogin(-1);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            if(txtbUserName.Text == "")
            {
                errorProvider1.SetError(txtbUserName, "the UesrName cant be empty");
            }
            else if(txtbPassword.Text == "")
            {
                errorProvider1.SetError(txtbPassword, "Password cant be empty");
            }
            else if (txtbConfiremPassword.Text == "")
            {
                errorProvider1.SetError(txtbConfiremPassword, "ConfirmedPassword cant be empty");
            }
            else if(txtbPassword.Text != txtbConfiremPassword.Text)
            {
                errorProvider1.SetError(txtbConfiremPassword, "ConfiremPassword have to much Password");
                errorProvider1.SetError(txtbPassword, "Password has to much Confimred Password");
            }
            else if(txtbUserName.Text != "" && txtbPassword.Text != ""  && txtbConfiremPassword.Text != "" && txtbConfiremPassword.Text == txtbPassword.Text)
            {
                if(mode == enMode.AddedNew)
                {
                 clsUsers users = new clsUsers();
                 users.Password = txtbPassword.Text;
                 users.Active   = cbActive.Checked;
                 users.PersonID = userInfoAndSreach1.PersonID; 
                 users.Save();
                 lblUserID.Text = users.UserID.ToString();
                 lblTitle.Text = "Update";
                }
                else
                {
                    user.UserName = txtbUserName.Text;
                    user.Password = txtbPassword.Text;
                    user.Active = cbActive.Checked;
                    user.Save();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditeUser_Load(object sender, EventArgs e)
        {

        }
    }
}
