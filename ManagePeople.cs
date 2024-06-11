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
        DataTable poepleDataSource = clsContact.FiltertedTable(); 


        private string[] filterbylist = {"None" , "PersonID" , "NationalNo" , "FirstName" , "SeocondName" , "ThirdName" ,
        "LastName" , "NationalityCountryID" , "Gendor" , "Phone" , "Email"};

        // this function will be fiered OnChange for the ComboBox
        private void viladationTotxtBoxOnComboBoxChange() {
            
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    maskedTextBox1.Visible = false;
                    break;
                case 2:
                    maskedTextBox1.Visible = true;
                    maskedTextBox1.Mask = null; 
                    break;
                case 1:
                    maskedTextBox1.Visible = true;
                    maskedTextBox1.Mask = "00000";
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    maskedTextBox1.Visible = true;
                    maskedTextBox1.Mask = "LLLLLLL";
                    
                    break ;
                case 9:
                    maskedTextBox1.Visible = true;
                    maskedTextBox1.Mask = "0000000";
                    break;
                // not validation for email until found a good one 
                case 10:
                    maskedTextBox1.Visible = true;
                    maskedTextBox1.Mask = null;
                    break;
            }
            
        }
        public frmManagePeoPle()
        {
            InitializeComponent();
        }

        private void Refreshdgv()
        {
            poepleDataSource = clsContact.FiltertedTable();
            dgvPeople.DataSource = poepleDataSource;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //1
            dgvPeople.DataSource = poepleDataSource;
            comboBox1.DataSource = filterbylist;
           // he only load when he show dialog but not loading if didnt get closed 
            //Refreshdgv(); 
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viladationTotxtBoxOnComboBoxChange();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string columnName = comboBox1.Text;
            string filtertext = maskedTextBox1.Text;          
            poepleDataSource.DefaultView.RowFilter = string.Format("{1} like '%{0}%'" , filtertext , columnName );
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddEdite frm = new AddEdite(-1);
            frm.ShowDialog();
            Refreshdgv();
        }



        private void addedNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEdite frm = new AddEdite(-1);
            frm.ShowDialog();
            Refreshdgv();
        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Console.WriteLine((string)dgvPeople.CurrentRow.Cells[0].Value);
            AddEdite frm= new AddEdite(Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            Refreshdgv();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("delete","are u sure u want to Delete this contact",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               clsContact.deletContact(Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value));
                Refreshdgv();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}





//1 i was trying the way but it dosent work try to make it work 
//DataColumn dc= new DataColumn();
//dc.ColumnName = dt.Columns["ID"].ToString();
//dataGridView1.Columns.Add();
//foreach (DataRow row in dt.Rows )
//{
//    dataGridView1.Rows.Add(row[1])  ;
//    dataGridView1.Rows.Add(row[2])  ;

//}