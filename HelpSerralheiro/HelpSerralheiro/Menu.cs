using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace HelpSerralheiro
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            string usuarioentrou2 = ClassInfo.Usuarioentrou;
            string Config = "server=127.0.0.1;userid=root;database=login";
            string nomeuser;
            MySqlConnection conex = new MySqlConnection(Config);
            MySqlCommand Query = new MySqlCommand();
            conex.Open();
            Query.Connection = conex;
            Query.CommandText = "SELECT nome FROM usuarios WHERE usuario = @usuarioentrou";
            Query.Parameters.AddWithValue("@usuarioentrou", usuarioentrou2);
            Object retorno = Query.ExecuteScalar();
            nomeuser = Convert.ToString(retorno);
            label2.Text = (nomeuser);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
