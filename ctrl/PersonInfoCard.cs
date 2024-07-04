using Full_Real_Project.Properties;
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
using System.IO;
using Full_Real_Project.frm;

namespace Full_Real_Project
{
    public partial class PersonInfoCard : UserControl
    {//contact
        private clsContact _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        //contact
        public clsContact SelectedPersonInfo
        {
            get { return _Person; }
        }
        //constructer
        public PersonInfoCard()
        {
            InitializeComponent();            
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsContact.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        //public void LoadPersonInfo(string NationalNo)
        //{
        //    _Person = clsContact.Find(NationalNo);
        //    if (_Person == null)
        //    {
        //        ResetPersonInfo();
        //        MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    _FillPersonInfo();
        //}

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.DefultBoyPhoto;
            else
                pbPersonImage.Image = Resources.DefultGirlPhoto;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _FillPersonInfo()
        {
            llblEditPersonInfo.Enabled = true;
            _PersonID = _Person.Id;
            lblPersonID.Text = _Person.Id.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;

            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();




        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            //pbGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            //pbPersonImage.Image = Resources.Male_512;
            llblEditPersonInfo.Enabled = true; 
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditePeople frm = new frmAddEditePeople(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }

        private void try2_Load(object sender, EventArgs e)
        {
            //lblAddress.Text = "perosn"; 
        }

        private void llEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditePeople frmAddEditeUser = new frmAddEditePeople(PersonID);
            frmAddEditeUser.ShowDialog();
            LoadPersonInfo(PersonID);
        }
    }
}
