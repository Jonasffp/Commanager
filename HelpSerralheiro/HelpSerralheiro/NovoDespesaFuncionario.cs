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
    public partial class NovoDespesaFuncionario : Form
    {
        public NovoDespesaFuncionario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ConsultaFinancasFuncionario cons = new ConsultaFinancasFuncionario();
            cons.Show();
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtVendedor.Text;
            string salario = txtSalario.Text;
            string DataPagamento = Convert.ToDateTime(txtDataPagamento.Text).ToString("yyyy/MM/dd");
            string observacoes = txtObservacoes.Text;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO financasfuncionarios (Nome, ValorSalario, DataPagamento, Observacoes)" + "VALUES('" + nome + "', '" + salario + "', '" + DataPagamento + "', '" + observacoes + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                ConsultaFinancasFuncionario cons = new ConsultaFinancasFuncionario();
                cons.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();
        }

        private void NovoDespesaFuncionario_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query2 = new MySqlCommand("SELECT Nome FROM funcionario;", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            Query2.ExecuteNonQuery();

            MySqlDataReader leitor2 = Query2.ExecuteReader();

            for (int i = 0; leitor2.Read() != false; i++)
            {
                string ig = leitor2["Nome"].ToString();
                txtVendedor.Items.Add(ig);
            }

            conex.Close();
        }
    }
}
