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
    public partial class SubVendas : Form
    {
        public SubVendas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NovaVenda nv = new NovaVenda();
            nv.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultaVenda cons = new ConsultaVenda();
            cons.Show();
            this.Close();
        }
    }
}
