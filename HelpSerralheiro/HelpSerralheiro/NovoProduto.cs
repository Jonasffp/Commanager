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

                string valorCusto = (txtValorCusto.Text.Replace(",", "."));
                string valorVenda = (txtValorVenda.Text.Replace(",", "."));
                string valorFrete = (txtValorFrete.Text.Replace(",","."));

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
        int virgula = 0, i = 0;
        private void txtValorFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && virgula == 1 && i == 1)
            {
                i = 2;
                return;
            }
            if (char.IsDigit(e.KeyChar) && virgula == 1 && i == 0)
            {
                i = 1;
            }

            if (e.KeyChar == ',' && virgula != 1)
            {
                e.Handled = false;
                virgula = 1;
                return;
            }

            if (virgula == 1 && i == 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                virgula = 0;
                return;
            }



            if (char.IsDigit(e.KeyChar) && virgula == 1 && i == 2)
            {
                e.Handled = true;
                //SendKeys.SendWait("{BACKSPACE}");
            }

            if (virgula == 1 && i > 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                i = i - 1;
                return;
            }
        }
        int virgula2 = 0, i2 = 0;
        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && virgula2 == 1 && i2 == 1)
            {
                i2 = 2;
                return;
            }
            if (char.IsDigit(e.KeyChar) && virgula2 == 1 && i2 == 0)
            {
                i2 = 1;
            }

            if (e.KeyChar == ',' && virgula2 != 1)
            {
                e.Handled = false;
                virgula2 = 1;
                return;
            }

            if (virgula2 == 1 && i2 == 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                virgula2 = 0;
                return;
            }



            if (char.IsDigit(e.KeyChar) && virgula2 == 1 && i2 == 2)
            {
                e.Handled = true;
                //SendKeys.SendWait("{BACKSPACE}");
            }

            if (virgula2 == 1 && i2 > 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                i2 = i2 - 1;
                return;
            }
        }
        int virgula3 = 0, i3 = 0;
        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && virgula3 == 1 && i3 == 1)
            {
                i3 = 2;
                return;
            }
            if (char.IsDigit(e.KeyChar) && virgula3 == 1 && i3 == 0)
            {
                i3 = 1;
            }

            if (e.KeyChar == ',' && virgula3 != 1)
            {
                e.Handled = false;
                virgula3 = 1;
                return;
            }

            if (virgula3 == 1 && i3 == 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                virgula3 = 0;
                return;
            }



            if (char.IsDigit(e.KeyChar) && virgula3 == 1 && i3 == 2)
            {
                e.Handled = true;
                //SendKeys.SendWait("{BACKSPACE}");
            }

            if (virgula3 == 1 && i3 > 0 && e.KeyChar == 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = false;
                i3 = i3 - 1;
                return;
            }
        }

        private void textBox1_KeyPress(object sender,
                System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        
    }
    }
    }

