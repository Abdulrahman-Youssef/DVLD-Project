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
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
               if (clsLicense.IsLicensefromClass3(int.Parse(textBox2.Text)))
               {
                    if (clsLicense.GetLicenseClassByLicenseID(int.Parse(textBox2.Text)).IsActive)
                    {
                        ctrlLicenseInfo1.LoadInfo(int.Parse(textBox2.Text));
                        ctrlApplicationRenewLicense1.LoadInfo(int.Parse(textBox2.Text));
                        if (DateTime.Now > ctrlLicenseInfo1.ExpirationDate) 
                        {
                            btnRenew.Enabled = true;
                        }
                    }
                    else
                    {

                    }

                }
            }
            if(DateTime.Now > ctrlLicenseInfo1.ExpirationDate) 
            {
                

            }
            else
            {
                MessageBox.Show("this License is already vaild ");
                btnRenew.Enabled = false;
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            
            if (DateTime.Now > ctrlLicenseInfo1.ExpirationDate)
            {
                clsApplication application = new clsApplication(); 
                clsLicense license = clsLicense.GetLicenseClassByLicenseID(ctrlApplicationRenewLicense1.LicenseID);
                clsApplication fulledapplication2 = clsApplication.GetApplicationByApplicatoinID(license.ApplicationID);

                application.ApplicationDate = DateTime.Now;
                application.PaidFees = clsApplicationTypes.GetApplicationTypesByApplicationType(2).ApplicationFees;
                application.ApplicationStatus = 3;
                application.ApplicantPersonID = fulledapplication2.ApplicantPersonID;
                application.ApplicationTypeID = 2;
                application.CreatedByUserID = clsGlobal.User.UserID;
                application.LastStatusDate = DateTime.Now;
               if (application.AddedNewApplication())
                {
                    MessageBox.Show("appolication Added"+ application.ApplicantPersonID) ;
                   if (clsLicense.UpdatedIsActiveByLincenseID(license.LicenseID, false))
                    {
                        MessageBox.Show("License Updated successfuly" + license.LicenseID);
                        if (license.AddedNewLicense())
                        {
                            MessageBox.Show("Added New Licnse and the license new ID is : " + license.LicenseID);
                            ctrlApplicationRenewLicense1.loadRenewApplcationInfoAfterAdded(application.ApplicationID, license.LicenseID);
                        }
                        else
                        {
                            MessageBox.Show("License Not Added");
                        }
                    }
                    else
                    {
                        MessageBox.Show("license Not Updated" + license.LicenseID);
                    }
                }
                else
                {
                    MessageBox.Show("Applcation Not Added");
                }



            }
            else
            {
                MessageBox.Show("this License is already vaild ");
                btnRenew.Enabled = false;
            }
        }

        private void ctrlApplicationRenewLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
