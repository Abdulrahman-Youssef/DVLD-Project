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
    public partial class ClintInfo : UserControl
    {

        public event Action<int> OnCalculationComplete;
        // Create a protected method to raise the event with a parameter
        protected virtual void CalculationComplete(int PersonID)
        {
           
        }
        public ClintInfo()
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
