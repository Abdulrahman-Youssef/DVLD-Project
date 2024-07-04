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

namespace Full_Real_Project.ctrl
{
    public partial class ctrlApplicationInfoReleaseInfo : UserControl
    {
        public int LincenseID { get; set; }
        public int DetainedID { get; set; }

        clsDetainLicense DetainedLicense { get; set; }
        clsApplicationTypes applicationTypes { get; set; }
        private void FillCls()
        {
            
            DetainedLicense = clsDetainLicense.GetDetaindLicenseBylicenseID(this.LincenseID);
            applicationTypes = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(clsApplication.GetApplicationByApplicatoinID(clsLicense.GetLicenseByLicenseID(this.LincenseID).ApplicationID).ApplicationTypeID);
            this.DetainedID = DetainedLicense.DetainID;
        }

        private void Fillctrl ()
        {
            
            lblApplicationFees.Text = applicationTypes.ApplicationFees.ToString();
            lblCreateBy.Text = clsUsers.FindUserByUesrID( DetainedLicense.CreatedByUserID).UserName.ToString();
            lblDetainDate.Text = this.DetainedLicense.DetainDate.ToShortDateString();
            lblDetainID.Text = this.DetainedLicense.DetainID.ToString();
            lblFineFees.Text = this.DetainedLicense.FineFees.ToString();
            lblTotalFees.Text= (this.DetainedLicense.FineFees + this.applicationTypes.ApplicationFees).ToString();
            lblLicenseID.Text = this.LincenseID.ToString();
        }

        public void LoadCtrlinfo(int LincenseID)
        {
            this.LincenseID = LincenseID;  
            FillCls();
            Fillctrl();
        }

        public ctrlApplicationInfoReleaseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
