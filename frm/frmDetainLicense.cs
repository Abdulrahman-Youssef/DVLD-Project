using Full_Real_Project;
using Full_Real_Project.ctrl;
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

namespace Full_Real_Project_DataAccess_layer_
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {

        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (clsLicense.GetLicenseByLicenseID(int.Parse(textBox1.Text)) != null)
                {
                    ctrlDetianApplicationInfo1.Loadctrl(int.Parse(textBox1.Text));
                    ctrlLicenseInfo1.LoadInfo(int.Parse(textBox1.Text));
                  
                    if (clsDetainLicense.CheckIfLicenseIsReleased(int.Parse(textBox1.Text)))
                    {
                        btnDetain.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("license is already");
                        btnDetain.Enabled = false;
                    }
                   
                }
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(ctrlDetianApplicationInfo1.Finefees != 0)
            {
                clsDetainLicense detainLicense = new clsDetainLicense();
                detainLicense.DetainDate = DateTime.Now;
                detainLicense.CreatedByUserID = clsGlobal.User.UserID;
                detainLicense.FineFees = ctrlDetianApplicationInfo1.Finefees;
                detainLicense.LicenseID = ctrlLicenseInfo1.LicenseID;
                detainLicense.IsReleased = false;
               
                if (detainLicense.AddedNewDetianLicense())
                {
                    MessageBox.Show("License Detained");
                    clsApplication application = new clsApplication();
                    //detain dosent need application
                    //application.ApplicationStatus = 3; 
                    //application.ApplicationDate = DateTime.Now;
                    //application.ApplicantPersonID = clsApplication.GetApplicationByApplicatoinID(clsLicense.GetLicenseClassByLicenseID(ctrlLicenseInfo1.LicenseID).ApplicationID).ApplicantPersonID);
                    //application.ApplicationTypeID = 5;
                    ctrlDetianApplicationInfo1.Loadctrl(int.Parse(textBox1.Text));
                    btnDetain.Enabled = false; 

                }
                else
                {
                    MessageBox.Show("License didnt detained");
                }
            }
        }
    }
}
