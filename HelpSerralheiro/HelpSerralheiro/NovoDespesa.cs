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
    public partial class NovoDespesa : Form
    {
        public NovoDespesa()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            ConsultaDespesas cons = new ConsultaDespesas();
            cons.Show();
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nomeDespesa = txtDespesa.Text;
            string dataVencimento = Convert.ToDateTime(txtDataVencimento.Text).ToString("yyyy/MM/dd");
            decimal valorDespesa = Convert.ToDecimal(txtValorDespesa.Text);
            string observacoes = txtObservacoes.Text;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO despesas (DataVencimento, NomeDespesa, Observacoes, Valor)" + "VALUES('" + dataVencimento + "', '" + nomeDespesa + "', '" + observacoes + "', '" + valorDespesa + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                txtDespesa.Clear(); txtObservacoes.Clear(); txtValorDespesa.Clear();
                ConsultaDespesas despesas = new ConsultaDespesas();
                despesas.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtDespesa.Clear(); txtObservacoes.Clear(); txtValorDespesa.Clear(); txtDataVencimento.Text = Convert.ToString(DateTime.Now);
        }

        private void txtValorDespesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
    }
}
