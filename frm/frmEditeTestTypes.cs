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
    public partial class frmEditeTestTypes : Form
    {
        clsTestType Test;

        private void _FillForm()
        {
            txtbTestTypeTitle.Text       = Test.TestTypeTitle;
            txtbTestTypeFees.Text        = Test.TestTypeFees.ToString();
            txtbTestTypeDescription.Text = Test.TestTypeDescription;
            lblTestTypeID.Text = Test.TestTypeID.ToString();

        }
        public frmEditeTestTypes(int TestTypeID)
        {
            InitializeComponent();

            Test = clsTestType.GetTestTypesByTestTypesID(TestTypeID);
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _FillForm();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsTestType.UpdateFeestitleDescrtionByTestTypeID(Test.TestTypeID, txtbTestTypeTitle.Text, txtbTestTypeDescription.Text, decimal.Parse(txtbTestTypeFees.Text)))
            {
                MessageBox.Show("Updated");

            }
            else
            {
                MessageBox.Show("Updated not ");

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
