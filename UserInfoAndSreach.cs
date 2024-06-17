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
    public partial class UserInfoAndSreach : UserControl
    {

        public int PersonID { get; set; }

        public UserInfoAndSreach()
        {
            InitializeComponent();
        }

        private void try21_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
                this.PersonID = int.Parse(textBox1.Text.Trim().ToString()); 
            }
            else
            {
                PersonID = -1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
              ctralPersonCard.LoadPersonInfo(int.Parse(textBox1.Text.ToString().Trim()));

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddEditePeople frmAddEditePeople = new frmAddEditePeople(-1);
            frmAddEditePeople.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UserInfoAndSreach_Load(object sender, EventArgs e)
        {
            cbFindby.SelectedIndex = 0;
        }
    }
}
