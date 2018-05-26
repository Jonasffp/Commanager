using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace HelpSerralheiro
{
    public partial class AlterarDespesa : Form
    {
        public AlterarDespesa()
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

            if (txtDespesa.TextLength < 1 || txtValorDespesa.TextLength < 1)
            {
                MessageBox.Show("Por favor, preencha adequadamente o campo referente ao nome do funcionário e do lembrete !");
            }
            else
            {
                string nomeDespesa = txtDespesa.Text;
                string dataVencimento = Convert.ToDateTime(txtDataVencimento.Text).ToString("yyyy/MM/dd");
                string valorDespesa = txtValorDespesa.Text.Replace(',', '.');
                string observacoes = txtObservacoes.Text;
                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("UPDATE despesas SET NomeDespesa='" + nomeDespesa + "', DataVencimento='" + dataVencimento + "', Valor='" + valorDespesa + "', Observacoes='" + observacoes + "' WHERE Id =" + ClassInfo.IdDespesaGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    ConsultaDespesas cons = new ConsultaDespesas();
                    cons.Show();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
                MessageBox.Show("" + valorDespesa);
            }
        }

        private void AlterarDespesa_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM despesas WHERE id = '" + ClassInfo.IdDespesaGlobal + "';", conex);

            try

            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtDespesa.Text = leitor["NomeDespesa"].ToString();
                txtDataVencimento.Text = leitor["DataVencimento"].ToString();
                txtValorDespesa.Text = leitor["Valor"].ToString();
                txtObservacoes.Text = leitor["Observacoes"].ToString();
               

            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }
        }
        int virgula = 1, i = 2;
        private void txtValorDespesa_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
