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
    public partial class frmMianScreen : Form
    {


        public frmMianScreen()
        {
            InitializeComponent();
        }

        private void accountSittingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peoopleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmManagePeoPle frmManagePple = new frmManagePeoPle();
            frmManagePple.Show();
        }

        private void frmMianScreen_Load(object sender, EventArgs e)
        {
            
            

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();

        }
    }
}
