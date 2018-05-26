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
    public partial class SubFornecedores : Form
    {
        public SubFornecedores()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new HelpSerralheiro.Menu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            NovoFornecedor nv = new NovoFornecedor();
            nv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultaFornecedor cons = new ConsultaFornecedor();
            cons.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lbldata.Text = DateTime.Now.ToLongDateString();
        }
    }
}
