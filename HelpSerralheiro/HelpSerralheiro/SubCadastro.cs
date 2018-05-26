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
    public partial class SubCadastro : Form
    {
        public SubCadastro()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarUsuario cad = new ConsultarUsuario();
            cad.Show();
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultaFuncionario cons = new ConsultaFuncionario();
            cons.Show();
        }

        private void SubCadastro_Load(object sender, EventArgs e)
        {
            if (ClassInfo.TipoUsuario == "Administrador")
            {
                btnUsuario.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lbldata.Text = DateTime.Now.ToLongDateString();
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
