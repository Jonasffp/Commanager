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
    public partial class AlterarDespesaFuncionario : Form
    {
        public AlterarDespesaFuncionario()
        {
            InitializeComponent();
        }

        private void AlterarDespesaFuncionario_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM financasfuncionarios WHERE id = '" + ClassInfo.IdDespesaGlobal + "';", conex);

            try

            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtVendedor.Text = leitor["Nome"].ToString();
                txtDataPagamento.Text = leitor["DataPagamento"].ToString();
                txtSalario.Text = leitor["ValorSalario"].ToString();
                txtObservacoes.Text = leitor["Observacoes"].ToString();

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

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }
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
            MySqlCommand Query = new MySqlCommand("UPDATE financasfuncionarios SET Nome='" + nome + "', ValorSalario='" + salario + "', DataPagamento='" + DataPagamento + "', Observacoes='" + observacoes + "' WHERE Id=" + ClassInfo.IdDespesaGlobal + ";", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Alterado com sucesso!");

                ConsultaFinancasFuncionario sub = new ConsultaFinancasFuncionario();
                sub.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Erro ao alterar!");
            }
            conex.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ConsultaFinancasFuncionario cons = new ConsultaFinancasFuncionario();
            cons.Show();
            this.Close();
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
