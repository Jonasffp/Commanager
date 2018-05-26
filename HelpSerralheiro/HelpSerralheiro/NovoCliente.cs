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

        private void button1_Click(object sender, EventArgs e)
        {
            String nome, sexo, cpf, rg, dataNascimento, rua, bairro, cidade, cep, uf, complemento, email, telefone, celular, observacoes;

            nome = txtNome.Text.Trim();
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

            MessageBox.Show("" + nome + cpf + rg + dataNascimento + rua + bairro + cidade + cep + uf + complemento + email + telefone + celular + observacoes);
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO cliente (nome, rg, cpf, dataNasc, celular, telefone, email, cep, uf, cidade, rua, bairro, complemento, observacoes)" + "VALUES('" + nome + "', '" + rg + "', '" + cpf + "', '" + dataNascimento + "', '" + celular + "', '" + telefone + "', '" + email "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();

        }
        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtDataNascimento.Text = Convert.ToString(DateTime.Now);
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtCEP.Clear();
            txtUF.Clear();
            txtComplemento.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtObservacoes.Clear();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
    
