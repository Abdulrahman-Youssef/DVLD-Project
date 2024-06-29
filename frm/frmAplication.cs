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
        clsApplication Application = new clsApplication();
        clsLocalDrivingLicenseApplications localDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();

        public bool IsLicenseClassAleadyExist()
        {
            bool Found = true;
            //check first is this user has the same type of application and class or not 
            List<int> listApplicationIDs = new List<int>();
            List<int> listLicenseClassIDs = new List<int>();
            
            DataTable ApplicationIDs = clsApplication.GetApplicationIDsByPersonID(userInfoAndSreach1.PersonID);

            //dgv.DataSource = d;

            foreach (DataRow row in ApplicationIDs.Rows)
            {
                listApplicationIDs.Add(Convert.ToInt32(row["ApplicationID"].ToString()));
            }
            DataTable LicenseClassIDs = clsLocalDrivingLicenseApplications.LicenseClassIDsByApplicationIDs(listApplicationIDs);
            foreach (DataRow row in LicenseClassIDs.Rows)
            {
                listLicenseClassIDs.Add(Convert.ToInt32(row["LicenseClassID"].ToString()));

            }

            foreach (int licenseclassID in listLicenseClassIDs)
            {
                // جبت كل الابلكيش وبعد كدا جبت كل ليسنس كلاسس اللي الشخص دا عاملها وبعدين وقارنتها باللي عاوز يعملها (كوملبيتد و نيو)بس
                Console.WriteLine(comboBox1.SelectedIndex.ToString());
                if (licenseclassID == comboBox1.SelectedIndex + 1)
                {
                  return Found = false;
                }
                
            }
            return Found;
        
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

        private void _fillfrm()
        {
            DataTable dt =  clsLicenseClasses.getClassCoulmn("ClassName");
             
            lblUserName.Text = clsGlobal.User.UserName.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = "15";
            foreach(DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["ClassName"].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }   
        public frmAplication()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(clsContact.IsContactExist(userInfoAndSreach1.PersonID))
            {
                _enabled(0);
                tabControl1.SelectedIndex = 1;
                _fillfrm();
            }
            else
            {
                _enabled(-1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // put that in fucntion
          
            //untill here and the reslut of this funcion will be bool and the answer for the condition
            if (IsLicenseClassAleadyExist())
            {
            Application.ApplicationTypeID = 1;
            Application.ApplicantPersonID = userInfoAndSreach1.PersonID;
            Application.CreatedByUserID   = clsGlobal.User.UserID;
            Application.ApplicationStatus = 1; // New
            Application.ApplicationDate   = DateTime.Now;
            Application.LastStatusDate    = Application.ApplicationDate.AddHours(1);
            Application.PaidFees          = decimal.Parse(lblApplicationFees.Text.ToString());
            bool bolapp                   = Application.AddedNewApplication(); 
            //add to local license too
            localDrivingLicenseApplications.ApplicationID   = Application.ApplicationID;
            localDrivingLicenseApplications.LicenseClassID  = comboBox1.SelectedIndex +1;
            bool drivinglicense                             = localDrivingLicenseApplications.AddNewLocalDrivingLicenseApplications();
                if (drivinglicense && bolapp)
                {
                    MessageBox.Show("added");
                    lblDL.Text = Application.ApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("not added");
                }
            }
            else
            {
                MessageBox.Show("already have an application");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex.ToString());

          

        }
    }
}
