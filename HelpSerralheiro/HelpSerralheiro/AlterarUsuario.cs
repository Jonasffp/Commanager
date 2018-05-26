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
    public partial class AlterarUsuario : Form
    {
        public AlterarUsuario()
        {
            InitializeComponent();
        }

        private void AlterarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultarUsuario cons = new ConsultarUsuario();
            cons.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
