using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpSerralheiro
{
    public partial class SubProdutos : Form
    {
        public SubProdutos()
        {
            InitializeComponent();
        }

        private void SubProdutos_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new HelpSerralheiro.Menu();
            menu.Show();
        }
    }
}
