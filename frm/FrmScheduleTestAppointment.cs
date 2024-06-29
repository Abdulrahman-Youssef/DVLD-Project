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
    public partial class FrmScheduleTestAppointment : Form
    {
        DataTable dgvDataSourec;
        public int LocalDrivingLicenseApplicationID;
        public int TestTypeID;
        void Refreshdgv()
        {
            dgvDataSourec = clsTestAppointments.GetTestAppointmentsByLDLAIDAndTEStTypeID(LocalDrivingLicenseApplicationID , TestTypeID);
            dgvTestAppointments.DataSource = dgvDataSourec;
        }

        bool CheckIfHeHadPassedTheTest()
        {
            List<int> LTestAppointMent = new List<int>(); 
            bool Passed; 
            
            if(dgvDataSourec.Rows.Count >0)
            {
                foreach(DataRow row  in dgvDataSourec.Rows)
                {
                    LTestAppointMent.Add((int)row[0]);
                }
            DataTable TestResult = clsTest.GetTestsResultsByTestAppointmentIDs(LTestAppointMent);
            foreach(DataRow row in  TestResult.Rows)
            {
                if ((bool)row[0])
                {
                    return true;
                }
            }
            }

            return false;
        }

        public FrmScheduleTestAppointment(int LocalDrivingLicenseApplicationID , string Tiltle  , int TestTypeID)
        {
            InitializeComponent();
            ctrlApplicationInfo1.loadApplicationInfo(LocalDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            lblTitle.Text = Tiltle ;
            this.TestTypeID = TestTypeID;
            Refreshdgv();
        }
        private void FrmScheduleTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPutTestAppointment_Click(object sender, EventArgs e)
        {
            
            if(!CheckIfHeHadPassedTheTest())
            {
             bool Found = true; 
             foreach(DataRow row in dgvDataSourec.Rows)
             {
                if (!(bool)row["IsLocked"])
                {
                    Found = false; 
                    break;
                }
             }
                if (Found)
                {
                    frmAddedTestAppointment frm = new frmAddedTestAppointment(LocalDrivingLicenseApplicationID);
                    frm.ShowDialog();
                    Refreshdgv();
                }
                else
                {
                    MessageBox.Show("You Already Have Actice Appointment");
                }
            }


        }

        private void takeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(bool)dgvTestAppointments.CurrentRow.Cells["IsLocked"].Value)
            {
               frmTakeTask frm = new frmTakeTask(LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
                Refreshdgv();
            }
            else
            {
                MessageBox.Show("appointMentIsLocked");
                Refreshdgv();
            }
        }
    }
}
