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

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("UPDATE cliente set nome, rg, cpf, dataNasc, celular, telefone, email, cep, uf, cidade, rua, numeroRua, bairro, complemento, observacoes" + "VALUES('" + nome + "', '" + rg + "', '" + cpf + "', '" + dataNascimento + "', '" + celular + "', '" + telefone + "', '" + email + "', '" + cep + "', '" + uf + "', '" + cidade + "', '" + rua + "', '" + numerorua + "', '" + bairro + "', '" + complemento + "', '" + observacoes + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                txtNome.Clear(); txtCPF.Clear(); txtRG.Clear(); txtDataNascimento.Text = Convert.ToString(DateTime.Now); txtRua.Clear(); txtBairro.Clear(); txtCidade.Clear(); txtCEP.Clear(); txtUF.Clear(); txtComplemento.Clear();txtEmail.Clear();txtTelefone.Clear(); txtCelular.Clear(); txtObservacoes.Clear();
                SubClientes sub = new SubClientes();
                sub.Show();
            }
            
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();
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
                    txtNome.Text = leitor["nome"].ToString();
                    txtRG.Text = leitor["rg"].ToString();
                    txtCPF.Text = leitor["cpf"].ToString();
                    txtDataNascimento.Text = leitor["dataNasc"].ToString();
                    txtCelular.Text = leitor["celular"].ToString();
                    txtTelefone.Text = leitor["telefone"].ToString();
                    txtEmail.Text = leitor["email"].ToString();
                    txtCEP.Text = leitor["cep"].ToString();
                    txtUF.Text = leitor["uf"].ToString();
                    txtCidade.Text = leitor["cidade"].ToString();
                    txtRua.Text = leitor["rua"].ToString();
                    txtnumeroRua.Text = leitor["numeroRua"].ToString();
                    txtBairro.Text = leitor["bairro"].ToString();
                    txtComplemento.Text = leitor["complemento"].ToString();
                    txtObservacoes.Text = leitor["observacoes"].ToString();

                }

                 catch (Exception ex)
                                {
                                    ex.Message.ToString();
                                }

                finally{conex.Close();}

            }
        }
    }

