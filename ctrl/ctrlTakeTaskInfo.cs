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
    public partial class ctrlTakeTaskInfo : UserControl
    {
        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication_View ;
        public clsApplication LDLA; 
        public clsTestType TestType ;
        public int LDRAID { get; set; }
        // LocalDrivingLicenseApplication
        public void LoadInfo(int LocalDrivingLicenseApplicationID)
        {
            LocalDrivingLicenseApplication_View = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByLDLAID_View(LocalDrivingLicenseApplicationID);
            TestType = clsTestType.GetTestTypesByTestTypesID(LocalDrivingLicenseApplication_View.PassedTestCount_View +1);
            
            LDRAID = LocalDrivingLicenseApplicationID;

            lblClass.Text = LocalDrivingLicenseApplication_View.ClassName_View;
            lblName.Text = LocalDrivingLicenseApplication_View.FullName_View;
            lblDate.Text = LocalDrivingLicenseApplication_View.ApplicationDate_View.ToShortDateString();
            lblLDLApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = TestType.TestTypeFees.ToString();


        }
        public ctrlTakeTaskInfo()
        {
            InitializeComponent();
        }

        private void ctrlTakeTaskInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
