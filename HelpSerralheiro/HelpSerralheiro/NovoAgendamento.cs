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
            String Visibilidade = null;
            String Importancia = null;
            String Data = txtData.Text;
            String Hora = txtHora.Text;
            String Obs = txtObs.Text;

            /*Laço de repetição para definir qual das opções a variavel vai 
            armazenar*/
            if (rbEu.Checked) { Visibilidade = rbEu.Text; }
            if (rbTodos.Checked) { Visibilidade = rbTodos.Text; }
            if (rbPoucoImportante.Checked) { Importancia = rbPoucoImportante.Text; }
            if (rbNormal.Checked) { Importancia = rbNormal.Text; }
            if (rbImportante.Checked) { Importancia = rbImportante.Text; }
            if (rbMuitoImportante.Checked) { Importancia = rbMuitoImportante.Text; }

            MessageBox.Show(NomeLembrete + "\n" + Visibilidade + "\n" + Importancia+ "\n" + Data + "\n" + Hora + "\n" + Obs) ;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO agenda (Nome, Visibilidade, Importancia, Data, Hora, Observacoes)" + "VALUES('" + NomeLembrete + "', '" + Visibilidade + "', '" + Importancia + "', '" + Data + "', '" + Hora + "', '" + Obs + "');", conex);
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
    }
}
