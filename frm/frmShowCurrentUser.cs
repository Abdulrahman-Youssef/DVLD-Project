﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project.frm
{
    public partial class frmShowCurrentUser : Form
    {
        public frmShowCurrentUser()
        {
            InitializeComponent();
        }

        private void frmShowCurrentUser_Load(object sender, EventArgs e)
        {
            ctrlUserinfo1.LoadTheCurrentUser();
        }
    }
}