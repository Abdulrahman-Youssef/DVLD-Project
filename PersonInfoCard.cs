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

namespace Full_Real_Project
{
    public partial class PersonInfoCard : UserControl
    {
        clsContact Person;
        public PersonInfoCard(int personID)
        {
            InitializeComponent();
            if (clsContact.IsContactExist(personID))
            {
                Person = clsContact.Find(personID);
            }
            else
            {
                MessageBox.Show("this PersonID is not exist");

            }
        }

        private void PersonInfoCard_Load(object sender, EventArgs e)
        {
            lblpersonID.Text = Person.Id.ToString();
            lblNationalNo.Text = Person.NationalNo;
            lblName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblEmails.Text = Person.Email;
            lblCountry.Text = clsCountry.Find(Person.NationalityCountryID).CountryName;
            lblAddress.Text = Person.Address;
            if (Person.Gendor == 0)
                lblGendor.Text = "Male";
            lblGendor.Text = "Female";


        }
    }
}
