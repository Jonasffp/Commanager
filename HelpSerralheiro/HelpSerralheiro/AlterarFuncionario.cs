﻿using System;
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
    public partial class AlterarFuncionario : Form
    {
        public AlterarFuncionario()
        {
            InitializeComponent();
        }

        private void AlterarFuncionario_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM funcionario WHERE id = '" + ClassInfo.IdFuncionarioGlobal + "';", conex);

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
                txtnumeroRua.Text = leitor["NumeroRua"].ToString();
                txtBairro.Text = leitor["Bairro"].ToString();
                txtComplemento.Text = leitor["Complemento"].ToString();

            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultaFuncionario cons = new ConsultaFuncionario();
            cons.Show();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String nome, numerorua, cpf, rg, dataNascimento, rua, bairro, cidade, cep, uf, complemento, email, telefone, celular;

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

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("UPDATE funcionario SET Nome='" + nome + "', RG='" + rg + "', CPF='" + cpf + "', DataNascimento='" + dataNascimento + "', Celular='" + celular + "', Telefone='" + telefone + "', Email='" + email + "', CEP='" + cep + "', UF='" + uf + "', Cidade='" + cidade + "', Rua='" + rua + "', NumeroRua='" + numerorua + "', Bairro='" + bairro + "', Complemento='" + complemento + "' WHERE Id=" + ClassInfo.IdFuncionarioGlobal + ";", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Alterado com sucesso!");
                txtNome.Clear(); txtCPF.Clear(); txtRG.Clear(); txtDataNascimento.Text = Convert.ToString(DateTime.Now); txtRua.Clear(); txtBairro.Clear(); txtCidade.Clear(); txtCEP.Clear(); txtUF.Clear(); txtComplemento.Clear(); txtEmail.Clear(); txtTelefone.Clear(); txtCelular.Clear();
                ConsultaFuncionario sub = new ConsultaFuncionario();
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
}
