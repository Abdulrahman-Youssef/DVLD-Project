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

namespace Full_Real_Project.ctrl
{


    public partial class ctrlFullApplicationInfo : UserControl
    {
        public int ApplicationTypeID;
        public int LDLA { get; set; } = -1;
        public decimal ApplicationFees { get; set; }
       
        clsLicense license;
        clsApplication application;
        clsLicenseClasses licenseClasses;
        clsContact person;
        clsApplicationTypes applicationTypes;
        clsInternationalDrivingLicense internationalDrivingLicense; 
        private void _FillClass(int LicenseID)
        {
            LDLA = LicenseID;
            license = clsLicense.GetLicenseByLicenseID(LicenseID);
            application = clsApplication.GetApplicationByApplicatoinID(license.ApplicationID);
            applicationTypes = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(this.ApplicationTypeID);
            licenseClasses = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(license.LicenseClass);
            person = clsContact.Find(application.ApplicantPersonID);
            internationalDrivingLicense = clsInternationalDrivingLicense.GetInternationalDrivingLicense(LicenseID);
            Console.WriteLine("step Here");
        }
        private void _Fillctrl()
        {
            lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
            lblissueDate.Text  =  license.IssueDate1.ToShortDateString();
            lblFees.Text = applicationTypes.ApplicationFees.ToString();
            lblLocalLicenseID.Text = license.LicenseID.ToString();
            lblExpirationDate.Text = license.ExpirationDate1.ToShortDateString();   
            lblCreatedBy.Text = license.CreatedByUserID.ToString();
            // check if the he had a driver IDL first 
            if (clsInternationalDrivingLicense.CheckOninternationalLicenseByLocalDrivingLicense(license.LicenseID))
            {
                lbliLApplication.Text  = internationalDrivingLicense.ApplicationID.ToString();  
                lblLocalLicenseID.Text = internationalDrivingLicense.InternationalLicenseID.ToString();

            }
            ApplicationFees = applicationTypes.ApplicationFees;
          
        }


        public void loadctrlInfo(int LicenseID ,int ApplicationTypeID)
        {
            this.ApplicationTypeID = ApplicationTypeID; 
            _FillClass(LicenseID);
            _Fillctrl();



        }

        public ctrlFullApplicationInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
