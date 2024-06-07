using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void simplCulc1_Load(object sender, EventArgs e)
        {

        }

        private void simplCulc1_Load_1(object sender, EventArgs e)
        {

        }

        private void simplCulc1_OnCalculationComplete(int obj)
        {

            MessageBox.Show("the number that send is : " + obj);


        }

  
    }
}
