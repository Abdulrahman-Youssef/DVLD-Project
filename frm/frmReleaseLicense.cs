using Full_Real_Project_Buisness_layer_;
using System;
using System.Windows.Forms;

namespace Full_Real_Project.frm
{
    public partial class frmReleaseLicense : Form
    {
        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        private void ctrlLicenseInfo1_Load(object sender, EventArgs e)
        {


        }

        private void ctrlApplicationInfoReleaseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.ApplicationStatus = 3;
            application.ApplicantPersonID = clsApplication.GetApplicationByApplicatoinID(clsLicense.GetLicenseByLicenseID(ctrlLicenseInfo1.LicenseID).ApplicationID).ApplicantPersonID; ;
            application.PaidFees = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(clsApplication.GetApplicationByApplicatoinID(clsLicense.GetLicenseByLicenseID(ctrlLicenseInfo1.LicenseID).ApplicationID).ApplicationTypeID).ApplicationFees;
            application.ApplicationDate = DateTime.Now;
            application.CreatedByUserID = clsGlobal.User.UserID;
            application.LastStatusDate = DateTime.Now;
            application.ApplicationTypeID = 5;
            if (application.AddedNewApplication())
            { 
                if (clsDetainLicense.UpdateIsReleasedByLicenseID(ctrlLicenseInfo1.LicenseID, true, DateTime.Now, clsGlobal.User.UserID, application.ApplicationID))
                {
                    MessageBox.Show("License Released");
                    btnRelease.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Released Filed");
                }
            }
            else
            {
                MessageBox.Show("Application Not Added");
            }




        }

        private void btnSreach_Click(object sender, EventArgs e)
        {
            if (!clsDetainLicense.CheckIfLicenseIsReleased(int.Parse(textBox1.Text)))
            {
                ctrlLicenseInfo1.LoadInfo(int.Parse(textBox1.Text));
                ctrlApplicationInfoReleaseInfo1.LoadCtrlinfo(int.Parse(textBox1.Text));
                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chose Detaind license");
                ctrlLicenseInfo1.LoadInfo(int.Parse(textBox1.Text));
                btnRelease.Enabled = false;

            }
        }
    }
}
