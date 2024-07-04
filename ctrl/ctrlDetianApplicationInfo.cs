using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project.ctrl
{
    public partial class ctrlDetianApplicationInfo : UserControl
    {
        public int Finefees { get; set; }

        public void Loadctrl(int LincenseID)
        {
            lblCreatedBy.Text = clsGlobal.User.UserName;
            lblDetianedDate .Text = DateTime.Now.ToShortDateString();
            lblLicenseID .Text = LincenseID.ToString();

        }

        public void loadDetainedID(int DetianeID)
        {
            lblDetainedID.Text = DetianeID.ToString();
        }





        public ctrlDetianApplicationInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtbFineFees_TextChanged(object sender, EventArgs e)
        {
            Finefees = int.Parse(txtbFineFees.Text);
        }
    }
}
