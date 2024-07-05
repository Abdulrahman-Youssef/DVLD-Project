using Full_Real_Project_Buisness_layer_;
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
        private clsUsers _User; 

        public void LoadTheCurrentUser(int UserID)
        {

            _User =  clsUsers.FindUserByUesrID(UserID);

            if (_User != null)
            {
            lblUserID.Text = UserID.ToString();
                lblUserName.Text = _User.UserName.ToString();
                if (_User.Active == false)
                {
                    lblIsActive.Text = "0";
                }
                else
                {
                    lblIsActive.Text = "1";
                }

                personInfoCard1.LoadPersonInfo(_User.PersonID);

            }
           

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
