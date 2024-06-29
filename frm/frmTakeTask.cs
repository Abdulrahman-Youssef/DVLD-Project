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
    public partial class frmTakeTask : Form
    {
        clsTestAppointments TestAppointment;
        public frmTakeTask(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            ctrlTakeTaskInfo1.LoadInfo(LocalDrivingLicenseApplicationID);
            rbPass.Checked = true;
            TestAppointment = clsTestAppointments.GetTestAppointmentByLDLAID(LocalDrivingLicenseApplicationID);
        }

        private void frmTakeTask_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure u want to save u cant Change it after Save" , "Take Taask", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsTest test = new clsTest();
                test.Notes = tbNote.Text;
                if(rbPass.Checked )
                {
                 test.TestResult = true;

                }
                else
                {
                    test.TestResult = false;
                }
                test.CreatedByUserID = clsGlobal.User.UserID;
                test.TestAppointmentID = TestAppointment.TestAppointmentID;
                if (test.AddedNewTest())
                {
                    MessageBox.Show("Test Taked");
                    if(clsTestAppointments.UpdateIsLockedByTestAppointmentID(TestAppointment.TestAppointmentID , true))
                    {
                        MessageBox.Show("Update IsLock i TestAppointment " + test.TestAppointmentID);                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("IsLock Not Updated");
                    }
                }
                else
                {
                    MessageBox.Show("not Added");
                }
            }
        }
    }
}
