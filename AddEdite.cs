using Full_Real_Project_Buisness_layer_;
using System;
using System.Data;

using System.Windows.Forms;

namespace Full_Real_Project
{


    public partial class AddEdite : Form
    {
        enum enMode { AddedNew, Updated };
        enMode mode;
        private clsContact person;
        public AddEdite(int PersonID)
        {
            InitializeComponent();


            if (PersonID == -1)
            {
                person = new clsContact();
                mode = enMode.AddedNew;
                //lblFormTitle.Text = "Added New";
                FillForm();
            }
            else
            {
                person= clsContact.Find( PersonID);
                mode = enMode.Updated;
                //lblFormTitle.Text = "Update Contact";
                FillForm(); 
            }

         
        }
       
        private void FillForm() 
        {
             if(mode == enMode.Updated)
             {
                lblFormTitle.Text = "Update Person";
                lblPersonID.Text = person.Id.ToString();
                txtbNationalNo.Text =person.NationalNo;
                txtbFirstName.Text = person.FirstName;
                txtbSecondName.Text = person.SecondName;
                txtbThirdName.Text = person.ThirdName;
                txtbLastName.Text = person.LastName;
                txtbAdress.Text = person.Address;
                txtbPhone.Text = person.Phone;
                txtbEmail.Text = person.Email;
                dateTimePicker1.Value = person.DateOfBirth;
                if(person.Gendor == 0 )
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;
                }
                if (person.ImagePath != null && person.ImagePath != "")
                {
                    pictureBox1.Load(person.ImagePath);
                    llblRemovePicture.Visible = true;
                }
                else
                {

                    llblRemovePicture.Visible = false;
                }

                // give error and in loding not why ?????????????????????????????????????????????????????????????????????
                //cbCountries.SelectedIndex = 0;

            }
            else
            {
                lblFormTitle.Text = "Added New Person";
                llblRemovePicture.Visible = false;
            }
        }
            

       

      

      

      

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in clsCountry.GetAllContries().Rows)
            {
                cbCountries.Items.Add(row["CountryName"].ToString());
            }
             




            if (mode == enMode.Updated)
            {
                cbCountries.SelectedIndex = person.NationalityCountryID-1;
            }
            else
            {
                cbCountries.SelectedIndex=50;
                rbMale.Checked=true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            person.NationalNo = txtbNationalNo.Text;
            person.FirstName = txtbFirstName.Text;
            person.SecondName = txtbSecondName.Text;
            person.ThirdName = txtbThirdName.Text;
            person.LastName = txtbLastName.Text;
            person.Email = txtbEmail.Text;
            person.Phone = txtbPhone.Text;
            person.Address = txtbAdress.Text;
            if(rbMale.Enabled)
            {
                person.Gendor = 0; 
            }else
            {
                person.Gendor = 1;
            }
            person.DateOfBirth = dateTimePicker1.Value.Date;
            person.NationalityCountryID = cbCountries.SelectedIndex+1;
            if (pictureBox1.ImageLocation != null && pictureBox1.ImageLocation != "")
                person.ImagePath = pictureBox1.ImageLocation;
            else
                person.ImagePath =null;
          
            person.Save();

            //lblFormTitle.Text = "Update Person";
            mode = enMode.Updated;
            FillForm();

        }

        private void llblAddPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image file|*.jpg;*.jpeg;*.png;*.gif;*.bmp ";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                pictureBox1.Load(openFileDialog1.FileName);
                llblRemovePicture.Visible= true;
                
            }
        }

        private void llblRemovePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            person.ImagePath=null;
            pictureBox1.ImageLocation=null;
            llblRemovePicture.Visible = false;
        }
    }
}
