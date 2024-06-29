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
    public partial class frmManageLocalDrivingLicense : Form
    {
        private clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications;

        private void EnabledAllMenueToolStrip(bool enabled)
        {
            testVisionToolStripMenuItem.Enabled = enabled;
            writeToolStripMenuItem.Enabled = enabled;
            testStreatToolStripMenuItem.Enabled = enabled;
            issueLicenseToolStripMenuItem.Enabled = enabled;
            setAppiontmentToolStripMenuItem.Enabled = enabled;
            cancelledToolStripMenuItem.Enabled = enabled;
        }
        void refreshdgv()
        {
            dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications_view();
        }
        public frmManageLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            refreshdgv();


        }

        private void testVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Vision Test";

            FrmScheduleTestAppointment frmScheduleTestAppointment = new FrmScheduleTestAppointment(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value) ,title , 1);
            frmScheduleTestAppointment.ShowDialog();
            refreshdgv();
        }

        private void testStreatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmScheduleTestAppointment frmScheduleTestAppointment = new FrmScheduleTestAppointment(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value), "Street Test", 3);
            frmScheduleTestAppointment.ShowDialog();
            refreshdgv();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //???
            LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByLDLAID_View(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value));

            if ((string)dgvLocalDrivingLicense.CurrentRow.Cells["Status"].Value != "Completed" && (string)dgvLocalDrivingLicense.CurrentRow.Cells["Status"].Value != "Cancelled")
            {
                if (Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells["PassedTestCount"].Value) == 0)
                {
                    testStreatToolStripMenuItem.Enabled = false;
                    writeToolStripMenuItem.Enabled = false;
                    testVisionToolStripMenuItem.Enabled = true;
                    setAppiontmentToolStripMenuItem.Enabled = true;
                    cancelledToolStripMenuItem.Enabled = true;
                    issueLicenseToolStripMenuItem.Enabled = false;

                }
                else if (Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells["PassedTestCount"].Value) == 1)
                {
                    testStreatToolStripMenuItem.Enabled = false;
                    testVisionToolStripMenuItem.Enabled = false;
                    writeToolStripMenuItem.Enabled = true;
                    setAppiontmentToolStripMenuItem.Enabled = true;
                    cancelledToolStripMenuItem.Enabled = true;
                    issueLicenseToolStripMenuItem.Enabled = false;

                }
                else if (Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells["PassedTestCount"].Value) == 2)
                {
                    testVisionToolStripMenuItem.Enabled = false;
                    writeToolStripMenuItem.Enabled = false;
                    testStreatToolStripMenuItem.Enabled = true;
                    cancelledToolStripMenuItem.Enabled = true;
                    setAppiontmentToolStripMenuItem.Enabled = true;
                    issueLicenseToolStripMenuItem.Enabled = false;

                }
                else if (Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells["PassedTestCount"].Value) == 3)
                {
                    testVisionToolStripMenuItem.Enabled = false;
                    writeToolStripMenuItem.Enabled = false;
                    testStreatToolStripMenuItem.Enabled = false;
                    setAppiontmentToolStripMenuItem.Enabled = false;
                    issueLicenseToolStripMenuItem.Enabled = true;
                    cancelledToolStripMenuItem.Enabled = true;


                }

            }
            else
            {
                EnabledAllMenueToolStrip(false);                
            }
        }

      

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmScheduleTestAppointment frmScheduleTestAppointment = new FrmScheduleTestAppointment(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value), "Writen Test", 2);
            frmScheduleTestAppointment.ShowDialog();
            refreshdgv();
        }

        private void issueLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frmIssue = new frmIssueDrivingLicense(Convert.ToInt32(dgvLocalDrivingLicense.CurrentRow.Cells[0].Value));
            frmIssue.ShowDialog();

        }

        private void setAppiontmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsApplication.UpdateLocalDrivingLicenseIDStatusByApplicationID(LocalDrivingLicenseApplications.ApplicationID, 2))
            {
                MessageBox.Show("Application Updated seccessfuly number" + LocalDrivingLicenseApplications.ApplicationID);
            }
            else
            {
                MessageBox.Show("Application  Updated Fialled number" + LocalDrivingLicenseApplications.ApplicationID);
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAplication frmAplication = new frmAplication();
            frmAplication.ShowDialog();
        }
    }
}
