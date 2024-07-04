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
    public partial class ctrlApplicationRenewLicense : UserControl
    {
        public int LicenseID { get; set; }
        public string Notes {  get; set; }  
        clsLicense license;
        clsApplication application;
        clsApplicationTypes applicationTypes;
        clsLicenseClasses licenseClasses;
        clsContact person;

        public DateTime ExpirationDate { get; set; }


        private bool _fillClass(int LicenseID)
        {
            license = clsLicense.GetLicenseByLicenseID(LicenseID);
            if (license == null)
            {
                return false;
            }
            application = clsApplication.GetApplicationByApplicatoinID(license.ApplicationID);
            applicationTypes = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(2); 
            licenseClasses = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(license.LicenseClass);
            person = clsContact.Find(application.ApplicantPersonID);

            Console.WriteLine("setp Her");
            return true;
        }

        private void _FillCtrl()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblissueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = applicationTypes.ApplicationFees.ToString();
            lblLicenseFees.Text = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(license.LicenseClass).ClassFees.ToString();
            //lblTotalFees.Text = (int.Parse(lblFees.Text) + int.Parse(lblLicenseFees.Text)).ToString(); this won't work cuz the 
            lblTotalFees.Text = (decimal.Parse(lblFees.Text) + decimal.Parse(lblLicenseFees.Text)).ToString();
            lblOldLicenseID.Text = license.LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.User.UserName;
            LicenseID = license.LicenseID;


        }


        public bool LoadInfo(int LinceseID)
        {
            if (_fillClass(LinceseID))
            {
                _FillCtrl();
                return true;
            }
            else
            {
               return false;
            }
        }
     
        
        public void loadRenewApplcationInfoAfterAdded(int ApplicationID , int NewLicenseID)
        {
            lbliLApplication.Text = ApplicationID.ToString();
            lblRLicenseID.Text = NewLicenseID.ToString();
        }
        
        public ctrlApplicationRenewLicense()
        {
            InitializeComponent();
        }

        private void ctrlRenewLicense_Load(object sender, EventArgs e)
        {

        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
           Notes = tbNote.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
