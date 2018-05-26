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
                string valorCusto = (txtValorCusto.Text.Replace(",","."));
                string valorVenda = (txtValorVenda.Text.Replace(",", "."));
                string valorFrete = (txtValorFrete.Text.Replace(",", "."));


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



            MySqlConnection conex2 = new MySqlConnection(Config);
            conex2.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM produto WHERE id = '" + ClassInfo.IdProdutoGlobal + "';", conex2);

            try

            {
                MySqlDataReader leitor2 = Query.ExecuteReader();

                leitor2.Read(); //lê a primeira row da pesquisa
                txtNome.Text = leitor2["Nome"].ToString();
                txtUnidade.Text = leitor2["Unidade"].ToString();
                txtMarca.Text = leitor2["Marca"].ToString();
                txtCategoria.Text = leitor2["Categoria"].ToString();
                txtFornecedor.Text = leitor2["Fornecedor"].ToString();
                txtObservacoes.Text = leitor2["Observacoes"].ToString();
                txtValorCusto.Text = leitor2["ValorCusto"].ToString();
                txtValorVenda.Text = leitor2["ValorVenda"].ToString();
                txtValorFrete.Text = leitor2["ValorFrete"].ToString();
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
        int virgula = 1, i = 2;        
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

            if (virgula == 1 && i==0 && e.KeyChar == 08)
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
        int virgula2 = 1, i2 = 2;
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
        int virgula3 = 1, i3 = 2;
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
    }
}
