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
    public partial class frmDrivers : Form
    {
      private void RefresDrivers()
      {
          dgvDrivers.DataSource = clsDrivers.GetDrivers_View();
      }


        public frmDrivers()
        {
            InitializeComponent();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            RefresDrivers();

            if(dgvDrivers.Columns.Count > 0)
            {
                Console.WriteLine(dgvDrivers.Columns.Count);

                dgvDrivers.Columns[0].Width = 70;

                dgvDrivers.Columns[1].Width = 70;
                
                dgvDrivers.Columns[2].Width = 70;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 220;

                dgvDrivers.Columns[4].Width = 140;

                dgvDrivers.Columns[5].Width = 100;
                dgvDrivers.Columns[5].HeaderText = "Lisences";


            }
            






        }

        private void showDriverHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(Convert.ToInt32(dgvDrivers.CurrentRow.Cells[0].Value));
            frmShowLicenseHistory.ShowDialog();
        }
    }
}
