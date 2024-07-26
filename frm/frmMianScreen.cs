using Full_Real_Project.frm;
using Full_Real_Project_Buisness_layer_;
using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project
{
    public partial class frmMianScreen : Form
    {
        frmLogin frmlogin;

        public frmMianScreen(frmLogin frm)
        {
            InitializeComponent();
            this.frmlogin = frm;
        }

        private void accountSittingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peoopleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmManagePeoPle frmManagePple = new frmManagePeoPle();
            frmManagePple.Show();
        }

        private void frmMianScreen_Load(object sender, EventArgs e)
        {
            
            

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();

        }

       

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCurrentUser frm = new frmShowCurrentUser();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGlobal.User.UserID);
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.User = null; 
            this.Close();
            frmlogin.Show();
        }

        private void ManagePeopleApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplications frmManageApplications = new frmManageApplications();
            frmManageApplications.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestType frmTests = new frmManageTestType();
            frmTests.ShowDialog();
            
        }

        

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAplication frmAplication = new frmAplication(); 
            frmAplication.ShowDialog();
        }

        private void internatinalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalDrivinglicense frmManageInternational = new frmManageInternationalDrivinglicense();
            frmManageInternational.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicense frmLocalDrivinglicense = new frmManageLocalDrivingLicense();
            frmLocalDrivinglicense.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers frmDrivers = new frmDrivers();
            frmDrivers.ShowDialog();
        }

        private void internationalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingApplication International = new frmInternationalDrivingApplication();
            International.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense frmRenewDrivingLicense = new frmRenewDrivingLicense();
            frmRenewDrivingLicense.ShowDialog();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacedForDamagedOrLost frmReplacedForDamagedOrLost = new frmReplacedForDamagedOrLost();
            frmReplacedForDamagedOrLost.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmdetainLicense = new frmDetainLicense();
            frmdetainLicense.ShowDialog();
        }

        private void releceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.ShowDialog();

        }

        private void managerDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicense frmManage = new frmManageDetainedLicense();
            frmManage.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
