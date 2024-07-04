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
    
    public partial class frmEditeApplicationFees : Form
    {
        public clsApplicationTypes applicationTypes;
        private void _Fillfrm()
        {
            txtbFees.Text = applicationTypes.ApplicationFees.ToString();
            txtbTitel.Text = applicationTypes.ApplicationTypeTitel.ToString();
            lblID.Text = applicationTypes.ApplicationTypesID.ToString();

        }
        public frmEditeApplicationFees(int ApplicationTypeID)
        {
            InitializeComponent();
            applicationTypes = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(ApplicationTypeID);
            _Fillfrm();
        }

        private void frmEditeApplicationFees_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtbTitel.Text == "")
            {
                errorProvider1.SetError(txtbTitel, "cant be empty");
            }
            else if(txtbFees.Text =="")
            {
                errorProvider1.SetError(txtbFees, "cant be empty");
            }
            else
            {
                clsApplicationTypes.UpdateFeesByApplicationIDAndApplicationTypeTitle(applicationTypes.ApplicationTypesID , decimal.Parse(txtbFees.Text.ToString()) , txtbTitel.Text);
                MessageBox.Show("Updated Successfuly");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
