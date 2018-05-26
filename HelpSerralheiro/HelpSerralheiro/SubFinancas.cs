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
    public partial class SubFinancas : Form
    {
        public SubFinancas()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btDespesas_Click(object sender, EventArgs e)
        {
            ConsultaDespesas cons = new ConsultaDespesas();
            cons.Show();
            this.Close();
        }

        private void btDespesasFuncionarios_Click(object sender, EventArgs e)
        {
            ConsultaFinancasFuncionario cons = new ConsultaFinancasFuncionario();
            cons.Show();
            this.Show();
        }

        private void btFinancasVendas_Click(object sender, EventArgs e)
        {
            ConsultaFinancasVenda cons = new ConsultaFinancasVenda();
            cons.Show();
            this.Close();
        }

        private void btFinancasGeral_Click(object sender, EventArgs e)
        {
            ConsultaFinancasGeral cons = new ConsultaFinancasGeral();
            cons.Show();
            this.Close();
        }
    }
}
