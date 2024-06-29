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
    public partial class frmIssueDrivingLicense : Form
    {
        int LocalDrivingLicenseID;
        public frmIssueDrivingLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            ctrlApplicationInfo1.loadApplicationInfo(LocalDrivingLicenseID);
            ctrlDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationID(LocalDrivingLicenseID);
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int PerosnID = clsApplication.GetApplicationByApplicatoinID(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseID).ApplicationID).ApplicantPersonID;
            //Check if the person is driver or not 
            //if(!clsDrivers.IsDriverExist(clsApplication.GetApplicationByApplicatoinID(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseID).ApplicationID).ApplicantPersonID))
            if (!clsGlobal.isDriverIsxist(LocalDrivingLicenseID))
            {

                MessageBox.Show("its new driver and will be add to drivers");

                clsLicense license = new clsLicense();
                clsDrivers driver = new clsDrivers();
                clsLocalDrivingLicenseApplications LDLAID = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseID);
                clsLicenseClasses licenseClasses = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(LDLAID.LicenseClassID);
                driver.UserID = clsGlobal.User.UserID;
                driver.PersonID = PerosnID;
               if(driver.AddedNewDriver())
                {
                    MessageBox.Show("Driver Added successfuly");
                    license.PaidFees = licenseClasses.ClassFees;
                    license.ApplicationID = LDLAID.ApplicationID;
                    license.CreatedByUserID = clsGlobal.User.UserID;
                    license.DriverID = driver.DriverID;
                    license.Notes = textBox1.Text;
                    license.IsActive = true;
                    license.LicenseClass = LDLAID.LicenseClassID;
                    if (license.AddedNewLicense())
                    {
                        MessageBox.Show("License added successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Liecnse Not Added");
                        license.PaidFees = licenseClasses.ClassFees;
                        license.ApplicationID = LDLAID.ApplicationID;
                        license.CreatedByUserID = clsGlobal.User.UserID;

                        license.DriverID = clsDrivers.getDriverIDByPersonID(PerosnID).DriverID;


                        license.Notes = textBox1.Text;
                        license.IsActive = true;
                        license.LicenseClass = LDLAID.LicenseClassID;
                        if (license.AddedNewLicense())
                        {
                            MessageBox.Show("License added successfuly");
                        }
                        else
                        {
                            MessageBox.Show("Liecnse Not Added");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Driver not Added");
                }
               
                if (clsApplication.UpdateLocalDrivingLicenseIDStatusByApplicationID(LDLAID.ApplicationID , 3)) 
                {
                    MessageBox.Show("Application updated successfuly");
                }
                else
                {
                    MessageBox.Show("Application not updated");
                }

            }
            else
            {

                MessageBox.Show("its alraedy a driver and jsut will add the license");
                clsLicense license = new clsLicense();
                clsDrivers driver = new clsDrivers();
                clsLocalDrivingLicenseApplications LDLAID = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseID);
                clsLicenseClasses licenseClasses = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(LDLAID.LicenseClassID);
                license.PaidFees = licenseClasses.ClassFees ;
                license.ApplicationID = LDLAID.ApplicationID;
                license.CreatedByUserID = clsGlobal.User.UserID;
                license.DriverID = clsDrivers.getDriverIDByPersonID(PerosnID).DriverID;
                license.Notes = textBox1.Text;
                license.IsActive = true;
                license.LicenseClass = LDLAID.LicenseClassID;
                
                if (license.AddedNewLicense())
                {
                    MessageBox.Show("License added successfuly");
                }
                else
                {
                    MessageBox.Show("Liecnse Not Added");
                }
                 if (clsApplication.UpdateLocalDrivingLicenseIDStatusByApplicationID(LDLAID.ApplicationID, 3))
                {
                    MessageBox.Show("Application updated successfuly");
                }
                else
                {
                    MessageBox.Show("Application not updated");
                }

            }

        }
    }
}
