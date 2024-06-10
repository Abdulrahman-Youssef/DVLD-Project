using System;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;
using System.Linq;
using System.Text;
using System.Drawing;
using Full_Real_Project_Buisness_layer_;
// to use the Resources
using Full_Real_Project.Properties;
using System.Data;
using System.Diagnostics.Contracts;





namespace ContactsDataAccessLayer
{
    // this class in future will be partial class for add and one for edit 
    public partial class AddandEditeFrm : Form
    {
        private clsContact _Contact;
        private enum Moods { AddedNew = 0, Edit = 1 };
        private Moods moods;
 
        public AddandEditeFrm(int ID)
        {
            InitializeComponent();
            _FillcbCountries();
            // replace with function
            if (ID == -1)
            {
                moods = Moods.AddedNew;
                lblTilte.Text = "Added New";
            }
            else
            {
                moods = Moods.Edit;
                lblTilte.Text = "Edit";
                _Contact = clsContact.Find(ID);
                setEditData();
            }


        }
        //check if the ID exsit or not (this step must came after check if the number is -1)
        // return the right contact null or empty for add and contianted for edit
        private clsContact _ExsitingID(int ID)
        {
            clsContact Contact = new clsContact();
            if (ID == -1)
            {
                return Contact;
            }
            if (clsContact.IsContactExist(ID))
            {
                return Contact = clsContact.Find(ID);
            }
            return null;

        }


        private void setEditData()
        {
            lblID.Text = _Contact.Id.ToString();
            txtbFirstName.Text = _Contact.FirstName;
            txtbLastName.Text = _Contact.LastName;
            txtbEmail.Text = _Contact.Email;
            txtbAddress.Text = _Contact.Address;
            txtbPhone.Text = _Contact.Phone;
            // cuz as u expext the cb starts the count from 0 and the dt base starts form 1 so we have to make this step to 
            // ensure that the number in range and in his right selection
            // it give the name of the country to the fisrt cb and the cb return it right by name
            cbCoutries.SelectedIndex =  cbCoutries.FindString(clsCountry.Find(_Contact.NationalityCountryID).CountryName); 
            dtpDateOfBirth.Value = _Contact.DateOfBirth;

            if (_Contact.ImagePath != null && _Contact.ImagePath != "" )
            {
                MessageBox.Show($"{_Contact.ImagePath}");
                pictureBox1.Load(_Contact.ImagePath);
            }
            else
            {
                if (_Contact.Id % 2 == 0)
                {
                    pictureBox1.Image = Resources.DefultGirlPhoto;
                }
                else
                {
                    pictureBox1.Image = Resources.DefultBoyPhoto;

                }
            }

        }

    
        private void _FillcbCountries()
        {

            DataTable dt = clsCountry.GetAllContries();
            foreach(DataRow c in dt.Rows)
            {
                cbCoutries.Items.Add(c["CountryName"]) ;
            }
            // put the country on the fisrt one as defult 
            cbCoutries.SelectedIndex = 0;
        }
     

        private void AddandEditeFrm_Load(object sender, EventArgs e)
        {
            
         
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (moods == Moods.Edit)
            {
                _Contact.FirstName = txtbFirstName.Text;
                _Contact.LastName = txtbLastName.Text;
                _Contact.Email = txtbEmail.Text;
                _Contact.Phone = txtbPhone.Text;
                _Contact.Address = txtbAddress.Text;
                _Contact.NationalityCountryID = clsCountry.Find(cbCoutries.Text).ID;
                _Contact.DateOfBirth = dtpDateOfBirth.Value;
            }
            else
            {
                _Contact = new clsContact(); 
                _Contact.FirstName = txtbFirstName.Text;
                _Contact.LastName = txtbLastName.Text;
                _Contact.Email = txtbEmail.Text;
                _Contact.Phone = txtbPhone.Text;
                _Contact.Address = txtbAddress.Text;
                _Contact.NationalityCountryID = clsCountry.Find(cbCoutries.Text).ID;
                _Contact.DateOfBirth = dtpDateOfBirth.Value;
            }
            if (pictureBox1.ImageLocation != null )
                _Contact.ImagePath = pictureBox1.ImageLocation;
            else
                _Contact.ImagePath = "";

           


            if (_Contact != null)
            {
                _Contact.Save();
                MessageBox.Show("recored Add successfully"); 
                
            }
            else
            {
                
                MessageBox.Show("recored did not Add"); 

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblRemovePhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pictureBox1.ImageLocation = null;
            llblRemovePhoto.Visible = false;
        }

        private void llblAddedPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image file|*.jpg;*.jpeg;*.png;*.gif;*.bmp ";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
