using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HelpSerralheiro
{
    public partial class ConsultaFinancasVenda : Form
    {
        public ConsultaFinancasVenda()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubFinancas sub = new SubFinancas();
            sub.Show();
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string dataInicial = Convert.ToDateTime(txtDataInicial.Text).ToString("yyyy/MM/dd");
            string dataFinal = Convert.ToDateTime(txtDataFinal.Text).ToString("yyyy/MM/dd");

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas WHERE DataVenda BETWEEN('" + dataInicial + "') AND('" + dataFinal + "'); ", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable vendas = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(vendas);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvVendas.DataSource = vendas;
        }

        private void ConsultaFinancasVenda_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable vendas = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(vendas);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvVendas.DataSource = vendas;
        }
    }
}
