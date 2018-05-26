using System;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            NovoCliente nv = new NovoCliente();
            nv.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultarClientes cc = new ConsultarClientes();
            cc.Show();
        }
    }
}
