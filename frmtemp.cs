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
    public partial class frmtemp : Form
    {
        public frmtemp()
        {
            InitializeComponent();
        }

        private void frmtemp_Load(object sender, EventArgs e)
        {
            List<int> listApplicationIDs = new List<int>();
            List<int> listLicenseClassIDs = new List<int>();

            DataTable ApplicationIDs = clsApplication.GetApplicationIDsByPersonID(1025);

            dgv.DataSource = ApplicationIDs;

            //foreach (DataRow row in ApplicationIDs.Rows)
            //{
            //    listApplicationIDs.Add(Convert.ToInt32(row["ApplicationID"].ToString()));
            //}
            //DataTable LicenseClassIDs = clsLocalDrivingLicenseApplications.LicenseClassIDsByApplicationIDs(listApplicationIDs);
            //foreach (DataRow row in LicenseClassIDs.Rows)
            //{
            //    listLicenseClassIDs.Add(Convert.ToInt32(row["LicenseClassID"].ToString()));
            //}


        }
    }
}
