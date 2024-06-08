using System;
using System.Data.SqlClient;
using System.Drawing;
using Full_Real_Project_Buisness_layer_;
using System.Windows.Forms;
using Full_Real_Project.Properties;
using System.Data;
namespace Full_Real_Project
{

    public partial class frmManagePeoPle : Form

    {
        
        public frmManagePeoPle()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.ManagePPLImage;
            foreach (DataRow row in clsCountry.GetAllContries().Rows)
            {

                comboBox1.Items.Add(row["CountryName"].ToString()); 
            }

            dataGridView1.DataSource = clsContact.GetAllContacts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
