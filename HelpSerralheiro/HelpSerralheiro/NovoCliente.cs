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
    public partial class NovoCliente : Form
    {
        public NovoCliente()
        {
            InitializeComponent();
        }
        int cont;
        private void button1_Click(object sender, EventArgs e)
        {
            String nome,numerorua, cpf, rg, dataNascimento, rua, bairro, cidade, cep, uf, complemento, email, telefone, celular, observacoes;

            nome = txtNome.Text.Trim();
            numerorua = txtnumeroRua.Text.Trim();
            cpf = txtCPF.Text.Trim();
            rg = txtRG.Text.Trim();
            dataNascimento = txtDataNascimento.Text.Trim();
            rua = txtRua.Text.Trim();
            bairro = txtBairro.Text.Trim();
            cidade = txtCidade.Text.Trim();
            cep = txtCEP.Text.Trim();
            uf = txtUF.Text.Trim();
            complemento = txtComplemento.Text.Trim();
            email = txtEmail.Text.Trim();
            telefone = txtTelefone.Text.Trim();
            celular = txtCelular.Text.Trim();
            observacoes = txtObservacoes.Text.Trim();


            if (txtNome.TextLength < 1 || txtEmail.TextLength < 1)
            {
                MessageBox.Show("Por favor, preencha adequadamente os campos referentes ao nome e email !");
            }
            else
            {


                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("INSERT INTO cliente (Nome, RG, CPF, DataNascimento, Celular, Telefone, Email, CEP, UF, Cidade, Rua, Numero, Bairro, Complemento, Observacoes)" + "VALUES('" + nome + "', '" + rg + "', '" + cpf + "', '" + dataNascimento + "', '" + celular + "', '" + telefone + "', '" + email + "', '" + cep + "', '" + uf + "', '" + cidade + "', '" + rua + "', '" + numerorua + "', '" + bairro + "', '" + complemento + "', '" + observacoes + "');", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                    txtNome.Clear(); txtCPF.Clear(); txtRG.Clear(); txtDataNascimento.Text = Convert.ToString(DateTime.Now); txtRua.Clear(); txtBairro.Clear(); txtCidade.Clear(); txtCEP.Clear(); txtUF.Clear(); txtComplemento.Clear(); txtEmail.Clear(); txtTelefone.Clear(); txtCelular.Clear(); txtObservacoes.Clear();
                    this.Close();
                    SubClientes sub = new SubClientes();
                    sub.Show();
                }

                else
                {
                    MessageBox.Show("Erro ao cadastrar!");
                }
                conex.Close();
            }
        }
        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            SubClientes sub = new SubClientes();
            sub.Show();
        }

        private void txtCEP_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            cont++;                    
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            if (e.KeyChar == 08)
            {
                cont--;
            }


            if (e.KeyChar == 13)
            {
               
            string Config = "server=127.0.0.1;userid=root;database=cep";
            string cep = txtCEP.Text.Trim();
            string UF = txtUF.Text.Trim();
                

        MySqlConnection conex = new MySqlConnection(Config);
        conex.Open();
        MySqlCommand Query = new MySqlCommand("SELECT * FROM "+UF+" WHERE cep = '"+cep+"';", conex);

                try

                {
                MySqlDataReader leitor = Query.ExecuteReader();
                if(leitor.HasRows)
                {
                    txtRua.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();

                    leitor.Read(); //lê a primeira row da pesquisa
                    txtRua.Text = leitor["logradouro"].ToString();
                    txtBairro.Text = leitor["bairro"].ToString();
                    txtCidade.Text = leitor["cidade"].ToString();

                }

                }

                 catch (Exception ex)
                                {
                                    ex.Message.ToString();
                                }

                finally{conex.Close();}

            }



            
        }

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Back)
            {
                txtRua.Clear();
                txtBairro.Clear();
                txtCidade.Clear();

            }
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            if ((txtCEP.TextLength == 9) && (txtUF.TextLength == 2))
            {
                string Config = "server=127.0.0.1;userid=root;database=cep";
                string cep = txtCEP.Text.Trim();
                string UF = txtUF.Text.Trim();


                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("SELECT * FROM " + UF + " WHERE cep = '" + cep + "';", conex);

                try
                {
                    MySqlDataReader leitor = Query.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        txtRua.Clear();
                        txtBairro.Clear();
                        txtCidade.Clear();

                        leitor.Read(); //lê a primeira row da pesquisa
                        txtRua.Text = leitor["logradouro"].ToString();
                        txtBairro.Text = leitor["bairro"].ToString();
                        txtCidade.Text = leitor["cidade"].ToString();

                    }

                }

                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

                finally { conex.Close(); }
            }
            else
            {
                MessageBox.Show("Campos de Cep ou UF estão incompletos");
            }
        }

        private void txtRG_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        


    }
}
    
