﻿using System;
using System.Windows.Forms;

namespace HelpSerralheiro
{
    public partial class SubClientes : Form
    {
        public SubClientes()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}