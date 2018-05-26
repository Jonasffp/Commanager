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
    public partial class NovoProduto : Form
    {
        public NovoProduto()
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

            if (txtNome.TextLength<1 || txtValorCusto.TextLength < 1 || txtValorFrete.TextLength < 1 || txtValorVenda.TextLength < 1)
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
                MySqlCommand Query = new MySqlCommand("INSERT INTO produto (Nome, Unidade, Marca, Categoria, Fornecedor, ValorCusto, ValorVenda, ValorFrete, Observacoes)" + "VALUES('" + nome + "', '" + unidade + "', '" + marca + "', '" + categoria + "', '" + fornecedor + "',  @valorCusto , @valorVenda , @valorFrete,'" + observacoes + "');", conex);
                Query.Parameters.AddWithValue("@valorCusto", valorCusto);
                Query.Parameters.AddWithValue("@valorVenda", valorVenda);
                Query.Parameters.AddWithValue("@valorFrete", valorFrete);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                    this.Close();
                    SubProdutos sub = new SubProdutos();
                    sub.Show();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!");
                }
                conex.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            SubProdutos sub = new SubProdutos();
            sub.Show();
        }

        private void NovoProduto_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query2 = new MySqlCommand("SELECT NomeFantasia FROM fornecedor;", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            Query2.ExecuteNonQuery();
            
            MySqlDataReader leitor = Query2.ExecuteReader();

            for (int i = 0; leitor.Read() != false; i++)
            {
                string ig = leitor["NomeFantasia"].ToString();
                txtFornecedor.Items.Add(ig);
            }

            conex.Close();
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

        private void textBox1_KeyPress(object sender,
                System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        
    }
    }
    }

