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
    public partial class AlterarCliente : Form
    {
        public AlterarCliente()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultarClientes cc = new ConsultarClientes();
            cc.Show();
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            String nome, numerorua, cpf, rg, dataNascimento, rua, bairro, cidade, cep, uf, complemento, email, telefone, celular, observacoes;

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
                MySqlCommand Query = new MySqlCommand("UPDATE cliente SET Nome='" + nome + "', RG='" + rg + "', CPF='" + cpf + "', DataNascimento='" + dataNascimento + "', Celular='" + celular + "', Telefone='" + telefone + "', Email='" + email + "', CEP='" + cep + "', UF='" + uf + "', Cidade='" + cidade + "', Rua='" + rua + "', Numero='" + numerorua + "', Bairro='" + bairro + "', Complemento='" + complemento + "', Observacoes='" + observacoes + "' WHERE Id=" + ClassInfo.IdClienteGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    txtNome.Clear(); txtCPF.Clear(); txtRG.Clear(); txtDataNascimento.Text = Convert.ToString(DateTime.Now); txtRua.Clear(); txtBairro.Clear(); txtCidade.Clear(); txtCEP.Clear(); txtUF.Clear(); txtComplemento.Clear(); txtEmail.Clear(); txtTelefone.Clear(); txtCelular.Clear(); txtObservacoes.Clear();
                    ConsultarClientes sub = new ConsultarClientes();
                    sub.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
            }

        }
        

        private void AlterarCliente_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM cliente WHERE id = '"+ClassInfo.IdClienteGlobal+"';", conex);

                try

                {
                MySqlDataReader leitor = Query.ExecuteReader();

                    leitor.Read(); //lê a primeira row da pesquisa
                    txtNome.Text = leitor["Nome"].ToString();
                    txtRG.Text = leitor["RG"].ToString();
                    txtCPF.Text = leitor["CPF"].ToString();
                    txtDataNascimento.Text = leitor["DataNascimento"].ToString();
                    txtCelular.Text = leitor["Celular"].ToString();
                    txtTelefone.Text = leitor["Telefone"].ToString();
                    txtEmail.Text = leitor["Email"].ToString();
                    txtCEP.Text = leitor["CEP"].ToString();
                    txtUF.Text = leitor["UF"].ToString();
                    txtCidade.Text = leitor["Cidade"].ToString();
                    txtRua.Text = leitor["Rua"].ToString();
                    txtnumeroRua.Text = leitor["Numero"].ToString();
                    txtBairro.Text = leitor["Bairro"].ToString();
                    txtComplemento.Text = leitor["Complemento"].ToString();
                    txtObservacoes.Text = leitor["Observacoes"].ToString();

                }

                 catch (Exception ex)
                                {
                                    ex.Message.ToString();
                                }

                finally{conex.Close();}

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

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == 13)
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
        }

        private void txtnumeroRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    }

