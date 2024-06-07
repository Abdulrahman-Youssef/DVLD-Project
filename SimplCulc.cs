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
    public partial class SimplCulc : UserControl
    {

        public event Action<int> OnCalculationComplete;
        // Create a protected method to raise the event with a parameter
        protected virtual void CalculationComplete(int PersonID)
        {
            Action<int> handler = OnCalculationComplete;

            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }
        public SimplCulc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           int Result = Convert.ToInt32(textBox1.Text) + Convert.ToInt32 (textBox2.Text);
            label1.Text = Result.ToString(); 
            if (OnCalculationComplete != null)
                // Raise the event with a parameter
                CalculationComplete(Result);
        }
    }
}
