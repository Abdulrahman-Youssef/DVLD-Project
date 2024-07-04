using Full_Real_Project_Buisness_layer_;
using Full_Real_Project_DataAccess_layer_;
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
    public partial class frmManageDetainedLicense : Form
    {
        void refreshdgv()
        {
            dgvDetainedLicense.DataSource = clsDetainLicense.GetAllDetainedLicenses();
        }
        public frmManageDetainedLicense()
        {
            InitializeComponent();
            refreshdgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            refreshdgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            refreshdgv();
        }

        private void frmManageDetainedLicense_Load(object sender, EventArgs e)
        {
            
        }
    }
}
