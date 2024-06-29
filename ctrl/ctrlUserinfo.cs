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
    public partial class ctrlUserinfo : UserControl
    {

        public void LoadTheCurrentUser()
        {
            lblUserID.Text = clsGlobal.User.UserID.ToString();
            lblUserName.Text = clsGlobal.User.UserName.ToString();
            if (clsGlobal.User.Active == false)
            {
                lblIsActive.Text = "0";
            }
            else
            {
                lblIsActive.Text = "1";
            }

            personInfoCard1.LoadPersonInfo(clsGlobal.User.PersonID);
        }

        public ctrlUserinfo()
        {
            InitializeComponent();
        }

        private void ctrlUserinfo_Load(object sender, EventArgs e)
        {
           
        }
    }
}
