using Full_Real_Project_Buisness_layer_;
using System;
using System.Data;
using System.Windows.Forms;
// to copy file from place to place
using System.IO;
//for valadiating
using System.Text.RegularExpressions;
using System.Resources;
using Full_Real_Project.Properties;
namespace Full_Real_Project
{


    public partial class frmAddEditePeople : Form
    {
        enum enMode { AddedNew, Updated };
        enMode mode;
        private clsContact person;
        public frmAddEditePeople(int PersonID)
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
                if (person.ImagePath != null && person.ImagePath != "" && pictureBox1.Image == null)
                {
                    pictureBox1.ImageLocation =  person.ImagePath;

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
            
        // valiadaion for every text box ?
       private void _ValidateTextBoxes()
       {
            pictureBox1.Image = pictureBox1.Image;
            pictureBox1.ImageLocation = pictureBox1.ImageLocation
                ;
            pictureBox1.Location = pictureBox1.Location;


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
            if(rbMale.Checked)
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
            pictureBox1.Image = null;
            llblRemovePicture.Visible = false;
        }

        private void txtbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the character
            }
        }

        private void txtbEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtbEmail.Text, emailPattern))
            {
                e.Cancel = true; // Cancel the event and keep the focus on the text box
                //txtbEmail.BackColor = Color.LightCoral; // Optionally change the background color to indicate error
                MessageBox.Show("Please enter a valid email address.");
            }
            else
            {
                //txtbEmail.BackColor = SystemColors.Window; // Reset the background color if the input is valid
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (person.ImagePath !=null && person.ImagePath !="")
            {

            }
            else
            {
                if (rbMale.Checked)
                {
                    pictureBox1.Image = Resources.DefultBoyPhoto;
                }
                else
                {
                    pictureBox1.Image = Resources.DefultGirlPhoto;
                }
            }
        }

        
    }
}
