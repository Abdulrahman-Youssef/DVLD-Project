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
        private void _AbleTheLogin(int OFFON) 
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
            }
        }
        public frmAddEditeUser()
        {
            InitializeComponent();
        }     
        private void btnNext_Click(object sender, EventArgs e)
        {
            // check on the personID in Users and if u do find it that means u cant go and if u do find it u have to check he is one of the people
            if (clsContact.IsContactExist(userInfoAndSreach1.PersonID) && clsUsers.IsUserExistByPersonID(userInfoAndSreach1.PersonID))
            {
             _AbleTheLogin(1);
             tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("the User is Already Exist OR not one of the Poeple");
            }

        }

       
    }
}
