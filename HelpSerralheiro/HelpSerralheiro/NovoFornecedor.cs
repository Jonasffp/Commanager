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
    public partial class NovoFornecedor : Form
    {
        public NovoFornecedor()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            SubFornecedores sub = new SubFornecedores();
            sub.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String nomeFornecedor = txtNomeFornecedor.Text;
            String seguimentoFornecedor = cbSegmentoFornecedor.Text;
            String apelidoFornecedor = txtApelido.Text;
            String nomeruaFornecedor = txtNomeRuaFornecedor.Text;
            String bairroFornecedor = txtBairroFornecedor.Text;
            String cidadeFornecedor = txtCidadeFornecedor.Text;
            String ufFornecedor = txtufFornecedor.Text;
            String cepFornecedor = txtCEPFornecedor.Text;
            String telefoneFornecedor = txtTelefoneFornecedor.Text;
            String telefone2Fornecedor = txtTelefone2Fornecedor.Text;
            String celularFornecedor = txtCelularFornecedor.Text;
            String celular2Fornecedor = txtCelular2Fornecedor.Text;
            String complementoFornecedor = txtComplementoFornecedor.Text;
            String emailFornecedor = txtEmailFornecedor.Text;
            String nomerepresentanteFornecedor = txtNomeRepresentanteFornecedor.Text;
            String cnpjFornecedor = txtCNPJFornecedor.Text;
            String numieFornecedor = txtNumIEFornecedor.Text;
            String obsFornecedor = txtOBSFornecedor.Text;
            String emailrepresentanteFornecedor = txtEmailRepresentante.Text;
            String data = dateTimePicker1.Text;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO fornecedor (dataCadastro, segmento, nomeCompleto, nomeFantasia, email, rua, bairro, cidade, UF, CEP, telefone, telefone_2, celular, celular_2, complemento, nomeRepresentante, emailRepresentante, CNPJ, IE, observacoes)" + "VALUES('" + data + "', '" + seguimentoFornecedor +"', '" + nomeFornecedor + "', '" + apelidoFornecedor + "', '" + emailFornecedor + "', '" + nomeruaFornecedor + "', '" + bairroFornecedor + "', '" + cidadeFornecedor + "', '" + ufFornecedor + "', '" + cepFornecedor + "', '" + telefoneFornecedor + "', '" + telefone2Fornecedor + "', '" + celularFornecedor + "', '" + celular2Fornecedor + "', '" + complementoFornecedor + "', '" + nomerepresentanteFornecedor + "', '" + emailrepresentanteFornecedor + "', '" + cnpjFornecedor + "', '" + numieFornecedor + "', '" + obsFornecedor + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                this.Close();
                SubFornecedores sub = new SubFornecedores();
                sub.Show();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();

        }
    }
}