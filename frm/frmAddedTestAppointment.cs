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
    public partial class frmAddedTestAppointment : Form
    {
        public clsLocalDrivingLicenseApplications localDrivingLicenseApplication;
        int LocalDLApplicationID;
        public frmAddedTestAppointment(int LocalDLApplication)
        {
            InitializeComponent();

            this.LocalDLApplicationID = LocalDLApplication;
            localDrivingLicenseApplication = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByLDLAID_View(LocalDLApplication);
            ctrlAddAppointment1.loadCtralInfo(localDrivingLicenseApplication);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsTestAppointments.GetTestAppointmentsByLDLAIDAndTEStTypeID(LocalDLApplicationID , localDrivingLicenseApplication.PassedTestCount_View+1).Rows.Count > 0)
            {
                clsApplication Application = new clsApplication();
                clsTestAppointments testAppointments = new clsTestAppointments();
                testAppointments.PaidFees = ctrlAddAppointment1.TotalPaidFees;
                testAppointments.LocalDrivingLicenseApplicationID = LocalDLApplicationID; 
                testAppointments.AppointmentDate = ctrlAddAppointment1.AppointmentDate;
                testAppointments.CreatedByUserID = clsGlobal.User.UserID;
                testAppointments.IsLocked = false;
                testAppointments.TestTypeID = localDrivingLicenseApplication.PassedTestCount_View + 1;
                //fill applicaiton
                Application.ApplicationDate = ctrlAddAppointment1.AppointmentDate;
                Application.CreatedByUserID = clsGlobal.User.UserID;
                Application.ApplicantPersonID = 
clsApplication.GetApplicationByApplicatoinID(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDLApplicationID).ApplicationID).ApplicantPersonID;
                Application.PaidFees = 5;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed; 
                Application.LastStatusDate = ctrlAddAppointment1.AppointmentDate;
                Application.ApplicationTypeID = 7;
               if( Application.Save())
               //if( Application.AddedNewApplication())
                {
                    MessageBox.Show("Application Added");
                    testAppointments.RetakeTestApplicationID = Application.ApplicationID;
                }
               else
                {
                    MessageBox.Show("Application not Added");
                    testAppointments.RetakeTestApplicationID = null;
                }
                if (testAppointments.AddNewTestAppointments())
                {
                    MessageBox.Show("TestAppointment Added");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("TestAppointMent Not Added");
                }
            }
            else
            {
                clsTestAppointments testAppointments = new clsTestAppointments();
                testAppointments.PaidFees = ctrlAddAppointment1.TotalPaidFees;
                testAppointments.LocalDrivingLicenseApplicationID = LocalDLApplicationID;
                testAppointments.AppointmentDate = ctrlAddAppointment1.AppointmentDate;
                testAppointments.CreatedByUserID = clsGlobal.User.UserID;
                testAppointments.IsLocked = false;
                testAppointments.TestTypeID = localDrivingLicenseApplication.PassedTestCount_View + 1;
                testAppointments.RetakeTestApplicationID = null; 
                if(testAppointments.AddNewTestAppointments() )
                {
                    MessageBox.Show("Only Test Appointment Added");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not Test Appointment Added");
                }
            }
        }

        private void frmAddedTestAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
