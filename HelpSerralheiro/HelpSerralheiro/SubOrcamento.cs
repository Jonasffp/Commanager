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
    public partial class SubOrcamento : Form
    {
        public SubOrcamento()
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
            NovoOrcamento novo = new NovoOrcamento();
            novo.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarOrcamento cons = new ConsultarOrcamento();
            cons.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lbldata.Text = DateTime.Now.ToLongDateString();
        }
    }
}
