using Full_Real_Project_Buisness_layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project.ctrl
{
    public partial class ctrlAddAppointment : UserControl
    {
        //    public int LocalDrivingLicenseApplicationID;
        //    public int TestAppointmentID { get; set; }
        //    public int TestTypeID { get; set; }

        //    public int CreatedByUserID { get; set; }
        //    public int? RetakeTestApplicationID { get; set; } = null; 
        //    public bool IsLocked { get; set; }= false;
        public DateTime AppointmentDate { get; set; }
        public decimal TotalPaidFees { get; set; }

        public clsLocalDrivingLicenseApplications localDrivingLicenseApplication;

        
        public clsTestType TestType { get; set; }
        public ctrlAddAppointment()
        {
            InitializeComponent();
        }
        private void _Fillctrl()
        {
          
            lblLDLApplicationID.Text =  localDrivingLicenseApplication.LocalDrivingLicenseApplicationsID.ToString();
            lblClassName.Text = localDrivingLicenseApplication.ClassName_View.ToString();           
            lblName.Text = localDrivingLicenseApplication.FullName_View ;
            lblFees.Text = (Convert.ToInt32(TestType.TestTypeFees)).ToString();
            lblTotalFees.Text = (int.Parse(lblFees.Text)  + int.Parse(lblRatakeFees.Text)).ToString() ;
            TotalPaidFees = int.Parse(lblTotalFees.Text.ToString()) ;
            AppointmentDate = dateTimePicker1.Value; 
        
        }

      
        private void ctrlAddAppointment_Load(object sender, EventArgs e)
        {

        }

        public void loadCtralInfo(clsLocalDrivingLicenseApplications LocalDLApplication)
        {
            localDrivingLicenseApplication = LocalDLApplication;
            TestType = clsTestType.GetTestTypesByTestTypesID(localDrivingLicenseApplication.PassedTestCount_View+1);
            _Fillctrl();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(dateTimePicker1.Value.ToString());
            AppointmentDate = dateTimePicker1.Value;
        }
    }
}
