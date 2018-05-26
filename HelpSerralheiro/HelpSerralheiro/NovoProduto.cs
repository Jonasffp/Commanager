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
            int valorCusto = Convert.ToInt32(txtValorCusto);
            int valorVenda = Convert.ToInt32(txtValorVenda.Text);
            int valorFrete = Convert.ToInt32(txtValorFrete.Text);

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO produto (Nome, Unidade, Marca, Categoria, Fornecedor, Valor de Custo, Valor de Venda, Frete, Observacoes)" + "VALUES('" + nome + "', '" + unidade + "', '" + marca + "', '" + categoria + "', '" + fornecedor + "', '" + valorCusto + "', '" + valorVenda + "', '" + valorFrete + "', '" + observacoes + "');", conex);
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            SubProdutos sub = new SubProdutos();
            sub.Show();
        }
    }
}
