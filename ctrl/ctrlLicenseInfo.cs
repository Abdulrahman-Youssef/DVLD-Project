using Full_Real_Project.Properties;
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
    public partial class ctrlLicenseInfo : UserControl
    {
        clsLicense license;
        clsApplication application;
        clsLicenseClasses licenseClasses;
        clsContact person;

        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler SelectPerson;

        public int LicenseID { get; set; }
        public DateTime ExpirationDate { get; set; }
        private void _fillClass(int LicenseID)
        {
            this.LicenseID = LicenseID;
            license = clsLicense.GetLicenseByLicenseID(LicenseID);
            application = clsApplication.GetApplicationByApplicatoinID(license.ApplicationID);
            licenseClasses = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(license.LicenseClass);
            person = clsContact.Find(application.ApplicantPersonID);

            Console.WriteLine("setp Her");
        }

        private void _Fillctrl()
        {

            lblClass.Text = licenseClasses.ClassName;
            lblName.Text = person.FullName;
            lblLicenseID.Text  = license.LicenseID.ToString();
            lblNationalNo.Text = person.NationalNo;
            if (person.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pictureBox1.Image = Resources.user_icon_male_300x300_3;

            }
            else
            {
                lblGendor.Text = "Female";
                pictureBox1.Image = Resources.female_icon_27_2;
            }
            lblIssueDate.Text = license.IssueDate1.ToShortDateString();
            lblIssueReason .Text = license.IssueReason1.ToString();
            if(license.Notes != null && license.Notes !=  "")
            {
             lblNotes.Text = license.Notes.ToString();// handel null

            }
            else
            {
                lblNotes.Text = "Non";
            }
            if(license.IsActive)
            {
                lblIsActive.Text = "Yes";

            }
            else
            {
                lblIsActive.Text ="No";
            }

            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate1.ToShortDateString();
            lblIsDetained.Text = "No";
            ExpirationDate = license.ExpirationDate1;
            if (clsDetainLicense.CheckIfLicenseIsReleased(this.LicenseID))
            {
                lblIsDetained.Text = "No";
            }
            else
            {
                lblIsDetained.Text = "yes";
            }
        }


        public void LoadInfo(int LicenseID)
        {
            _fillClass(LicenseID);

            _Fillctrl();
            SelectPerson.Invoke(this, LicenseID);
        }



        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
