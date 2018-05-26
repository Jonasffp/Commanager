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
    public partial class NovoAgendamento : Form
    {
        public NovoAgendamento()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            SubAgenda sub = new SubAgenda();
            sub.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis recebendo os valores dos campos
            String NomeLembrete = cbNomeLembrete.Text;
            String Lembrete = txtLembrete.Text;
            String Visibilidade = null;
            string Data = Convert.ToDateTime(txtData.Text).ToString("yyyy/MM/dd");
            string Hora = txtHora.Text;
            String Obs = txtObs.Text;

            /*Laço de repetição para definir qual das opções a variavel vai 
            armazenar*/
            if (rbEu.Checked) { Visibilidade = rbEu.Text; }
            if (rbTodos.Checked) { Visibilidade = rbTodos.Text; }


            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO agenda (Lembrete, Nome, Visibilidade, Data, Hora, Observacoes)" + "VALUES('"+ Lembrete + "', '" + NomeLembrete + "', '" + Visibilidade + "', '" + Data + "', '" + Hora + "', '" + Obs + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                this.Close();
                SubAgenda sub = new SubAgenda();
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
