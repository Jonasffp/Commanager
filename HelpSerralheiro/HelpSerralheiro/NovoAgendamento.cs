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
        int idVendedor;

        private void btnSair_Click(object sender, EventArgs e)
        {
            SubAgenda sub = new SubAgenda();
            sub.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis recebendo os valores dos campos
            String NomeLembrete = txtVendedor.Text;
            String Lembrete = txtLembrete.Text;
            String Importancia = null;
            string Data = Convert.ToDateTime(txtData.Text).ToString("yyyy/MM/dd");
            string Hora = txtHora.Text;
            String Obs = txtObs.Text;


            /*Laço de repetição para definir qual das opções a variavel vai 
            armazenar*/
            if (rbEu.Checked) { Importancia = rbEu.Text; }
            if (rbTodos.Checked) { Importancia = rbTodos.Text; }
            if (radioButton1.Checked) { Importancia = radioButton1.Text; }
            if (radioButton2.Checked) { Importancia = radioButton2.Text; }

            if (txtVendedor.Text == "" || txtLembrete.Text == "")
            {
                MessageBox.Show("Por favor, preencha adequadamente os campos referentes ao nome do funcionário a qual o alarme será atribuido e ao nome do alarme !");
            }
            else
            {

                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("INSERT INTO agenda (Lembrete, Nome, Importancia, Data, Hora, Observacoes)" + "VALUES('" + Lembrete + "', '" + NomeLembrete + "', '" + Importancia + "', '" + Data + "', '" + Hora + "', '" + Obs + "');", conex);
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

        private void NovoAgendamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query2 = new MySqlCommand("SELECT Nome FROM funcionario;", conex);
                //define o tipo do comando
                Query2.CommandType = CommandType.Text;
                Query2.ExecuteNonQuery();

                MySqlDataReader leitor2 = Query2.ExecuteReader();

                for (int i = 0; leitor2.Read() != false; i++)
                {
                    string ig = leitor2["Nome"].ToString();
                    txtVendedor.Items.Add(ig);
                }

                conex.Close();
                
            }
            
        }


    }
