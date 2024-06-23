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
    public partial class frmManageTestType : Form
    {
        private void _Refersh()
        {
            dgvTests.DataSource = clsTestType.GetAllTest();
        }
        public frmManageTestType()
        {
            InitializeComponent();
            _Refersh();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {

        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditeTestTypes frmEditeTest = new frmEditeTestTypes(int.Parse(dgvTests.CurrentRow.Cells[0].Value.ToString()));
            frmEditeTest.ShowDialog();
            _Refersh();
        }
    }
}
