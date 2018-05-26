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
    public partial class AlterarAgendamento : Form
    {
        public AlterarAgendamento()
        {
            InitializeComponent();
        }

        private void AlterarAgendamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM agenda WHERE id = '" + ClassInfo.IdAgendaGlobal + "';", conex);

            try

            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtVendedor.Text = leitor["Nome"].ToString();
                txtLembrete.Text = leitor["Lembrete"].ToString();
                txtData.Text = leitor["Data"].ToString();
                txtHora.Text = leitor["Hora"].ToString();
                txtObs.Text = leitor["Observacoes"].ToString();


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

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis recebendo os valores dos campos
            String NomeLembrete = txtVendedor.Text;
            String Lembrete = txtLembrete.Text;
            String Visibilidade = null;
            string Data = Convert.ToDateTime(txtData.Text).ToString("yyyy/MM/dd");
            string Hora = txtHora.Text;
            String Obs = txtObs.Text;

            /*Laço de repetição para definir qual das opções a variavel vai 
            armazenar*/
            if (rbEu.Checked) { Visibilidade = rbEu.Text; }
            if (rbTodos.Checked) { Visibilidade = rbTodos.Text; }

            if (txtVendedor.Text == "" || txtLembrete.Text == "")
            {
                MessageBox.Show("Por favor, preencha adequadamente os campos referentes ao nome do funcionário a qual o alarme será atribuido e ao nome do alarme !");
            }
            else
            {

                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("UPDATE agenda SET Lembrete='" + Lembrete + "', Nome='" + NomeLembrete + "', Visibilidade='" + Visibilidade + "', Data='" + Data + "', Hora='" + Hora + "', Observacoes='" + Obs + "' WHERE Id=" + ClassInfo.IdAgendaGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    this.Close();
                    ConsultaAgendamento sub = new ConsultaAgendamento();
                    sub.Show();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ConsultaAgendamento cons = new ConsultaAgendamento();
            cons.Show();
            this.Close();
        }
    }
}
