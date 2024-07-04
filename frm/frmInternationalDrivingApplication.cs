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
    public partial class frmInternationalDrivingApplication : Form
    {
     
        public frmInternationalDrivingApplication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (clsLicense.IsLicensefromClass3(int.Parse(textBox1.Text)))
                {
                    ctrlFullApplicationInfo1.loadctrlInfo(int.Parse(textBox1.Text), 6);
                    ctrlLicenseInfo1.LoadInfo(int.Parse(textBox1.Text));
                }
            }
        }

        private void frmInternationalDrivingApplication_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!clsInternationalDrivingLicense.CheckOninternationalLicenseByLocalDrivingLicense(ctrlFullApplicationInfo1.LDLA))
            {
                clsApplication application = new clsApplication();
                clsInternationalDrivingLicense internationalDrivingLicense = new clsInternationalDrivingLicense(); 
                application.ApplicationStatus = 3;
                application.ApplicationDate = DateTime.Now;
                application.LastStatusDate = DateTime.Now;
                application.PaidFees = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(6).ApplicationFees;
                application.ApplicantPersonID = clsApplication.GetApplicationByApplicatoinID(clsLicense.GetLicenseByLicenseID(ctrlFullApplicationInfo1.LDLA).ApplicationID).ApplicantPersonID;
                application.ApplicationTypeID = 6;
                application.CreatedByUserID = clsGlobal.User.UserID;
                if(application.AddedNewApplication())
                {
                    MessageBox.Show("Application Added successfully" +application.ApplicationID);
                }
                else
                {
                    MessageBox.Show("Application not add");
                }

                internationalDrivingLicense.ApplicationID = application.ApplicationID;
                internationalDrivingLicense.DriverID  = clsLicense.GetLicenseByLicenseID(ctrlFullApplicationInfo1.LDLA).DriverID;
                internationalDrivingLicense.IssuedUsingLocalLicenseID = ctrlFullApplicationInfo1.LDLA; 
                internationalDrivingLicense.IssueDate = DateTime.Now;
                internationalDrivingLicense.ExpirationDate = DateTime.Now.AddYears(10);
                internationalDrivingLicense.IsActive = true;
                internationalDrivingLicense.CreatedByUserID = clsGlobal.User.UserID; 
                if(internationalDrivingLicense.AddedNewInternationalDrivingLicense())
                {
                    MessageBox.Show("International License Added");

                }
                else
                {
                    MessageBox.Show("International Fiald");
                }



            }
            else
            {
                MessageBox.Show("Already have one");
                
            }
        }
    }
}
