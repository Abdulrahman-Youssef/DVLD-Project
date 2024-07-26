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
        DataTable poepleDataSource = clsContact.FiltertedTable(); 


        private string[] filterbylist = {"None" , "PersonID" , "NationalNo" , "FirstName" , "SecondName" , "ThirdName" ,
        "LastName" , "NationalityCountryID" , "Gendor" , "Phone" , "Email"};

        // this function will be fiered OnChange for the ComboBox
        private void viladationTotxtBoxOnComboBoxChange() 
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (maskedTextBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                poepleDataSource.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "PersonID") 
                //in this case we deal with integer not string.

                poepleDataSource.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, maskedTextBox1.Text.Trim());
            else
                    poepleDataSource.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, maskedTextBox1.Text.Trim());



            }
            public frmManagePeoPle()
            {
              InitializeComponent();
            }

        private void Refreshdgv()
        {
            poepleDataSource = clsContact.FiltertedTable();
            //must
            dgvPeople.DataSource = poepleDataSource;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //1
            dgvPeople.DataSource = poepleDataSource;
            cbFilter.DataSource = filterbylist;

            if(dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;

            }







          
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viladationTotxtBoxOnComboBoxChange();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string columnName = cbFilter.Text;
            string filtertext = maskedTextBox1.Text;

            
            poepleDataSource.DefaultView.RowFilter = string.Format("{1} like '%{0}%'" , filtertext , columnName );
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }



        private void addedNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditePeople frm = new frmAddEditePeople(-1);
            frm.ShowDialog();
            Refreshdgv();
        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Console.WriteLine((string)dgvPeople.CurrentRow.Cells[0].Value);
            frmAddEditePeople frm= new frmAddEditePeople(Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value));
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
            frmShowPersonDetails frm = new frmShowPersonDetails(Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value));
            frm.Show();
            Refreshdgv();
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditePeople frm = new frmAddEditePeople(-1);
            frm.ShowDialog();
            Refreshdgv();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine($"{cbFilter.Text} = PersonID " + (cbFilter.Text == "PersonID").ToString());
            if (cbFilter.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}





//1 i was trying the way but it dosent work try to make it work later
//DataColumn dc= new DataColumn();
//dc.ColumnName = dt.Columns["ID"].ToString();
//dataGridView1.Columns.Add();
//foreach (DataRow row in dt.Rows )
//{
//    dataGridView1.Rows.Add(row[1])  ;
//    dataGridView1.Rows.Add(row[2])  ;

//}