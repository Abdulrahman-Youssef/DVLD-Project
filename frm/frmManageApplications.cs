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
    public partial class frmManageApplications : Form
    {
        DataTable dgvSource; 
        private void _Refresh()
        {
            dgvSource= clsApplicationTypes.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = dgvSource;
        }
        public frmManageApplications()
        {            
           InitializeComponent();
           _Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            if(dgvApplicationTypes.Columns.Count > 0)
            {
                dgvApplicationTypes.Columns[0].Width = 160;
                dgvApplicationTypes.Columns[1].Width = 220;
                dgvApplicationTypes.Columns[2].Width = 220;
            }



        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditeApplicationFees frmEditeApplicationFees = new frmEditeApplicationFees(Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value));
            frmEditeApplicationFees.ShowDialog();
            _Refresh();
        }



    }
}
