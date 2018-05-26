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
    public partial class SubAgenda : Form
    {
        public SubAgenda()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnNovoAgendamento_Click(object sender, EventArgs e)
        {
            NovoAgendamento nv = new NovoAgendamento();
            nv.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultaAgendamento cons = new ConsultaAgendamento();
            cons.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
