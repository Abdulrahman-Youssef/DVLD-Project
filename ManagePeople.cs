using System;
using System.Data.SqlClient;
using System.Drawing;
using Full_Real_Project_Buisness_layer_;
using System.Windows.Forms;
using Full_Real_Project.Properties;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
namespace Full_Real_Project
{

    public partial class frmManagePeoPle : Form

    {
        private string[] filterbylist = {"None" , "PersonID" , "Nationality No" , "First Name" , "SeocondName" , "ThirdName" ,
        "LastName" , "Nationality" , "Gendor" , "Phone" , "Emial"};

        // this function will be fiered OnChange for the ComboBox
        private void viladationTotxtBoxOnComboBoxChange() {
            
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                case 2:
                    maskedTextBox1.Mask = null; 
                    break;
                case 1:
                    maskedTextBox1.Mask = "00000";
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    maskedTextBox1.Mask = "LLLLLLLLLLLLL"; 
                    break ;
                case 9:
                    maskedTextBox1.Mask = "(999) 000-0000";
                    break;
                // not validation for email until found a good one 
                case 10:
                    maskedTextBox1.Mask = null;
                    break;
            }
            
            



        }
        public frmManagePeoPle()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            //1
            dgvPeople.DataSource = clsContact.FiltertedTable();
            comboBox1.DataSource = filterbylist;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viladationTotxtBoxOnComboBoxChange();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //dgvPeople.d
        }
    }
}

// to full the toll boxw with the countries
//foreach (DataRow row in clsCountry.GetAllContries().Rows)
//{

//    comboBox1.Items.Add(row["CountryName"].ToString());
//}



//1 i was trying the way but it dosent work try to make it work 
//DataColumn dc= new DataColumn();
//dc.ColumnName = dt.Columns["ID"].ToString();
//dataGridView1.Columns.Add();
//foreach (DataRow row in dt.Rows )
//{
//    dataGridView1.Rows.Add(row[1])  ;
//    dataGridView1.Rows.Add(row[2])  ;

//}