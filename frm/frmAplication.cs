using Full_Real_Project_Buisness_layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project.frm
{
    public partial class frmAplication : Form
    {
        enum enMode { AddedNew = 1, Updated = 2 }
        enMode Mode = enMode.AddedNew;
        //clsApplication Application = new clsApplication();
        int localDrivingLicenseApplicationID; 
        clsLocalDrivingLicenseApplications localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();

        public frmAplication()
        {
            InitializeComponent();
            Mode = enMode.AddedNew;
        }
        public frmAplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            localDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            Mode = enMode.Updated; 



        }

        private void _FillCoboBox()
        {
            DataTable dt = clsLicenseClasses.getClassCoulmn("ClassName");
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["ClassName"].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        private void _enabled(int OnOff)
        {
            if(OnOff == -1)
            {
                label1.Enabled =false;
                label2.Enabled =false;
                label3.Enabled =false;
                label4.Enabled =false;
                label6.Enabled =false;
                lblApplicationDate.Enabled =false;
                lblApplicationFees.Enabled =false;
                lblDL.Enabled =false;
                lblUserName.Enabled =false;
                comboBox1.Enabled =false;
                btnSave.Enabled =false;
            }
            else
            {
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label6.Enabled = true;
                lblApplicationDate.Enabled = true;
                lblApplicationFees.Enabled = true;
                lblDL.Enabled = true;
                lblUserName.Enabled = true;
                comboBox1.Enabled =true;
                btnSave.Enabled=true;
            }
        } 

        private void _ResetDefualtValues()
        {
            if (Mode == enMode.AddedNew)
            {
                lblTitle.Text = "Added New Local Driving License Application";
                localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
                comboBox1.SelectedIndex = 2;
                lblUserName.Text = clsGlobal.User.UserName.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypesByApplicationTypeID((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                _FillCoboBox();
                lblUserName.Text = clsGlobal.User.UserName;
            }
            else
            {
                lblTitle.Text = "Update LocalDriving License Application";

            }

        }   

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(clsContact.IsContactExist(userInfoAndSreach1.PersonID))
            {
                _enabled(0);
                tabControl1.SelectedIndex = 1;
                
            }
            else
            {
                _enabled(-1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //new
            if (clsApplication.GetActiveApplicationIDForLicenseClass(userInfoAndSreach1.PersonID, (int)clsApplication.enApplicationType.NewDrivingLicense, comboBox1.SelectedIndex + 1))
            {
                MessageBox.Show("you have already Active LocalDrivingLicense with the same License type in this person chose another Lincense type");
                return;
            }

            if(clsLicense.GetActiveLicenseIDByPersonID(userInfoAndSreach1.PersonID , comboBox1.SelectedIndex +1))
            {
                MessageBox.Show("This perosn have a Lincense already from this type chose another one ");
                return; 
            }

            localDrivingLicenseApplications.ApplicationTypeID = 1;
            localDrivingLicenseApplications.ApplicantPersonID = userInfoAndSreach1.PersonID;
            localDrivingLicenseApplications.CreatedByUserID = clsGlobal.User.UserID;
            localDrivingLicenseApplications.ApplicationStatus = clsApplication.enApplicationStatus.New; // New
            localDrivingLicenseApplications.ApplicationDate = DateTime.Now;
            localDrivingLicenseApplications.LastStatusDate = DateTime.Now.AddDays(30);
            localDrivingLicenseApplications.PaidFees = decimal.Parse(lblApplicationFees.Text.ToString());
            //localDrivingLicenseApplications.ApplicationID = Application.ApplicationID;
            localDrivingLicenseApplications.LicenseClassID = comboBox1.SelectedIndex + 1;

            if (localDrivingLicenseApplications.save())
            {
                MessageBox.Show("LocalDriving license Application Added successfully ");
                lblDL.Text = localDrivingLicenseApplications.ApplicationID.ToString();
                Mode = enMode.Updated;
                lblTitle.Text = "Update local Driving License"; 
            }
            else
            {
                MessageBox.Show("Local Driving License Application Not Added");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex.ToString());

          

        }

        private void _LoadData()
        {
            localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(this.localDrivingLicenseApplicationID);
            if(localDrivingLicenseApplications == null)
            {
                MessageBox.Show("this LocalDrivingLicenseApplication Not exist");
                return;
            }


            lblApplicationDate.Text = localDrivingLicenseApplications.ApplicationDate.ToShortDateString();
            lblDL.Text = localDrivingLicenseApplications.ApplicationID.ToString();
            lblUserName.Text = clsUsers.FindUserByUesrID(localDrivingLicenseApplications.CreatedByUserID).ToString();
            userInfoAndSreach1.LoadWithEnabledFilter(false, localDrivingLicenseApplications.ApplicantPersonID);
            comboBox1.SelectedIndex = comboBox1.FindString(localDrivingLicenseApplications.LicenseClasseInfo.ClassName);
            lblApplicationFees.Text = localDrivingLicenseApplications.PaidFees.ToString();

        }

        private void frmAplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (Mode == frmAplication.enMode.Updated)
            _LoadData();




        }
    }
}
