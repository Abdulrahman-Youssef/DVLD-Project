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
            dgvUsers.DataSource = dgvSource;
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
            frmAddEditeUser frmAddEditeUser = new frmAddEditeUser(-1);
            frmAddEditeUser.ShowDialog();
            _RefershdgvUsers(); 
        }

      

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddEditeUser frmAddEditeUser = new frmAddEditeUser(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value));
            clsUsers.DeleteUserByUserID(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value));
            _RefershdgvUsers();
        }

        private void cmsEdite_Click(object sender, EventArgs e)
        {
            frmAddEditeUser frmaddEditeUser = new frmAddEditeUser(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value));
            frmaddEditeUser._AbleTheLogin(1);
            frmaddEditeUser.enabledFiltercb(false);
            frmaddEditeUser.LoadPersonInfo();
            frmaddEditeUser.ShowDialog();
            _RefershdgvUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frmChangeUserPassword = new frmChangeUserPassword(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value));
            frmChangeUserPassword.ShowDialog();
        }
    }
}
