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

namespace Full_Real_Project
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }

        clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications_View; 
        

        private void _Fillctrl()
        {
            lblDLApplicationID.Text = LocalDrivingLicenseApplications_View.LocalDrivingLicenseApplicationsID.ToString();
            lblAppliedFor.Text = LocalDrivingLicenseApplications_View.ClassName_View.ToString() ;
            lblPassedTest.Text = LocalDrivingLicenseApplications_View.PassedTestCount_View.ToString() ;
           
        }
        public void LoadLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
           this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
           this.LocalDrivingLicenseApplications_View = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByLDLAID_View(LocalDrivingLicenseApplicationID);
            _Fillctrl();
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
