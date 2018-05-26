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
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
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
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lbldata.Text = DateTime.Now.ToLongDateString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Close();
            SubClientes sub = new SubClientes();
            sub.Show();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCadastro cad = new FrmCadastro();
            cad.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            this.Close();
            SubProdutos prod = new SubProdutos();
            prod.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            this.Close();
            SubFornecedores forn = new SubFornecedores();
            forn.Show();
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            this.Close();
            SubOrcamento orc = new SubOrcamento();
            orc.Show();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            SubAgenda sub = new SubAgenda();
            sub.Show();
            this.Close();
        }
    }
}
