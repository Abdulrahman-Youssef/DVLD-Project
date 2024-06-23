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
        public frmManageLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            dgvLocalDrivingLicense.DataSource = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications_view(); 
        }
    }
}
