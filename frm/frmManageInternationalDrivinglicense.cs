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
    public partial class frmManageInternationalDrivinglicense : Form
    {
        private void _Refreshdgv()
        {
            dgvIDL.DataSource = clsInternationalDrivingLicense.GetAllInternationalDrivingLicense();
        }
        public frmManageInternationalDrivinglicense()
        {
            InitializeComponent();
            _Refreshdgv();
        }

        private void frmManageInternationalDrivinglicense_Load(object sender, EventArgs e)
        {

        }

        private void btnAddedNewIDL_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingApplication frmInternationalDriving = new frmInternationalDrivingApplication();
            frmInternationalDriving.ShowDialog();
            _Refreshdgv();
        }
    }
}
