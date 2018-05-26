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
    public partial class AlterarProduto : Form
    {
        public AlterarProduto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string unidade = txtUnidade.Text.Trim();
            string marca = txtMarca.Text.Trim();
            string categoria = txtCategoria.Text.Trim();
            string fornecedor = txtFornecedor.Text.Trim();
            string observacoes = txtObservacoes.Text.Trim();

            if (txtNome.TextLength < 1 || txtValorCusto.TextLength < 1 || txtValorFrete.TextLength < 1 || txtValorVenda.TextLength < 1)
            {
                MessageBox.Show("Por favor, preencha adequadamente os campos referentes ao Nome do produto, Valor de custo, Valor de frete e Valor de venda !");
            }
            else
            {
                int valorCusto = Convert.ToInt16(txtValorCusto.Text);
                int valorVenda = Convert.ToInt16(txtValorVenda.Text);
                int valorFrete = Convert.ToInt16(txtValorFrete.Text);


                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("UPDATE produto SET Nome='" + nome + "', Unidade='" + unidade + "', Marca='" + marca + "', Categoria='" + categoria + "', Fornecedor='" + fornecedor + "', Observacoes='" + observacoes + "', ValorCusto='" + valorCusto + "', ValorVenda='" + valorVenda + "', ValorFrete='" + valorFrete + "' WHERE Id=" + ClassInfo.IdProdutoGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso!");

                    ConsultaProdutos cons = new ConsultaProdutos();
                    cons.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
            }
        }


        private void AlterarProduto_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM produto WHERE id = '" + ClassInfo.IdProdutoGlobal + "';", conex);

            try

            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtNome.Text = leitor["Nome"].ToString();
                txtUnidade.Text = leitor["Unidade"].ToString();
                txtMarca.Text = leitor["Marca"].ToString();
                txtCategoria.Text = leitor["Categoria"].ToString();
                txtFornecedor.Text = leitor["Fornecedor"].ToString();
                txtObservacoes.Text = leitor["Observacoes"].ToString();
                txtValorCusto.Text = leitor["ValorCusto"].ToString();
                txtValorVenda.Text = leitor["ValorVenda"].ToString();
                txtValorFrete.Text = leitor["ValorFrete"].ToString();
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }

        
    }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ConsultaProdutos cons = new ConsultaProdutos();
            cons.Show();
            this.Close();
        }

        private void txtValorFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }
            else { e.Handled = true; }
        }

        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }
            else { e.Handled = true; }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))

            {

                e.Handled = false;

            }
            else { e.Handled = true; }
        }
    }
}
