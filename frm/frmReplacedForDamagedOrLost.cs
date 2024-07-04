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
    public partial class frmReplacedForDamagedOrLost : Form
    {
        private int Reason;
        public frmReplacedForDamagedOrLost()
        {
            InitializeComponent();
        }

        private void btnSeacrh_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                if (clsLicense.IsLicensefromClass3(int.Parse(textBox1.Text)))
                {
                    ctrlFullApplicationInfo1.loadctrlInfo(int.Parse(textBox1.Text), Reason);
                    ctrlLicenseInfo1.LoadInfo(int.Parse(textBox1.Text));
                    if (clsLicense.GetLicenseByLicenseID(int.Parse(textBox1.Text)).IsActive)
                    {
                        btnReplace.Enabled = true;
                    } 
                    else
                    {
                        btnReplace.Enabled=false;
                    }
                }
            }
        }

        private void frmReplacedForDamagedOrLost_Load(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                Reason = 4;
            }
            else
            {
                Reason = 3;
            }

        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                Reason = 4;
            }
            else
            {
                Reason = 3;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {



            


                clsApplication application = new clsApplication();
                clsLicense license = clsLicense.GetLicenseByLicenseID(ctrlLicenseInfo1.LicenseID);

                application.ApplicationStatus = 3;
                application.ApplicationDate = DateTime.Now;
                application.LastStatusDate = DateTime.Now;
                application.PaidFees = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(Reason).ApplicationFees;
                application.CreatedByUserID = clsGlobal.User.UserID;
                application.ApplicantPersonID = clsApplication.GetApplicationByApplicatoinID(license.ApplicationID).ApplicantPersonID;
                application.ApplicationTypeID = Reason;
                if (application.AddedNewApplication())
                {
                    MessageBox.Show("Application Add " + application.ApplicationID);
                    license.ApplicationID = application.ApplicationID;
                    if (clsLicense.UpdatedIsActiveByLincenseID(license.LicenseID, false))
                    {
                        MessageBox.Show("License Upataed " + license.LicenseID);

                        if (license.AddedNewLicense())
                        {
                            MessageBox.Show("Adden New License ID " + license.LicenseID);
                            btnReplace.Enabled = false;
                            btnSeacrh.Enabled = false;
                            textBox1.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("license Not Added ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("License Not Updated");
                    }


                }
                else
                {
                    MessageBox.Show("Appliacation Not Added");
                }

            

        }
    }
}
