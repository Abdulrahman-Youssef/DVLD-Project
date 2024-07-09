using Full_Real_Project_Buisness_layer_;
using System;
using System.Windows.Forms;

namespace Full_Real_Project
{
    public partial class ctrlApplicationInfo : UserControl
    {
        clsApplication application;
        clsApplicationTypes applicationTypes;
        clsContact Person;
        clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications;
        public int ApplicationID { get; set; }

        private void _Fillctrl()
        {
            lblApplicant.Text = Person.FullName.ToString();
            lblApplicationID.Text = application.ApplicationID.ToString();
            lblCreatedBy.Text = clsGlobal.User.UserName.ToString();
            lblDate.Text = application.ApplicationDate.ToShortDateString();
            lblDateStatus.Text = application.LastStatusDate.ToShortDateString();
            lblFees.Text = application.PaidFees.ToString();
            lblStatus.Text = application.ApplicationStatus == clsApplication.enApplicationStatus.New ? "new" : (int)clsApplication.enApplicationStatus.Cancelled == 2 ? "Cancel" : (int)clsApplication.enApplicationStatus.Completed == 3 ? "Compeleted" : "ccompeleted";
            lblType.Text = applicationTypes.ApplicationTypeTitel.ToString();


        }
        public void loadApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseApplicationID);
            application = clsApplication.GetApplicationByApplicatoinID(LocalDrivingLicenseApplications.ApplicationID);
            applicationTypes = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(application.ApplicationTypeID);
            Person = clsContact.Find(application.ApplicantPersonID);


            _Fillctrl();
        }
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
