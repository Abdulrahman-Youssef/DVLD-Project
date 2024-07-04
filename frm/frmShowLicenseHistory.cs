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
    public partial class frmShowLicenseHistory : Form
    {
        int DriverID;
        int PersonID;
        private void _Refresgdvs()
        {
            dgvInternationalLicenses.DataSource = clsInternationalDrivingLicense.GetInternationalLicenseByDriverID(DriverID);
            dgvLocalLicenses.DataSource = clsLicense.GetLicensesByDriverID(DriverID);
        }

        
        public frmShowLicenseHistory(int DriverID)
        {
            InitializeComponent();
            PersonID = clsDrivers.getDriverIDByDriverID(DriverID).PersonID;
            this.DriverID = DriverID;
            userInfoAndSreach1.LoadWithEnabledFilter(false ,PersonID);
            _Refresgdvs();
        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void userInfoAndSreach1_Load(object sender, EventArgs e)
        {

        }
    }
}
