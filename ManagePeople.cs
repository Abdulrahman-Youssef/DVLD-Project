using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
            pictureBox1.Image = Image.FromFile(@"C:\Users\Abdelrahman\OneDrive\Pictures\DVDL Project\ManagePPLImage.png");


            listView1.Items.Add(); 
            
        }

     
    }
}
