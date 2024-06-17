using Full_Real_Project.frm;
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
    public partial class frmManageUsers : Form
    {
        DataTable dgvSource = clsUsers.FilteredTable();
        private void _RefershdgvUsers() 
        {
            dgvSource = clsUsers.FilteredTable();
        }
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = dgvSource;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddEditeUser frmAddEditeUser = new frmAddEditeUser();
            frmAddEditeUser.ShowDialog();
        }
    }
}
