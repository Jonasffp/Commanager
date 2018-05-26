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
        int idVendedor;
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
                txtObs.Text = leitor["Observacoes"].ToString();
                txtVendedor.Text = leitor["Nome"].ToString();
                txtLembrete.Text = leitor["Lembrete"].ToString();
                txtVendedor.Text = leitor["Vendedor"].ToString();
                txtData.Text = leitor["Data"].ToString();
                txtHora.Text = leitor["Hora"].ToString();
                
                
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }

            conex.Open();
            MySqlCommand Query3 = new MySqlCommand("SELECT Nome FROM funcionario;", conex);
            //define o tipo do comando
            Query3.CommandType = CommandType.Text;
            Query3.ExecuteNonQuery();

            MySqlDataReader leitor3 = Query3.ExecuteReader();

            for (int i = 0; leitor3.Read() != false; i++)
            {
                string ig = leitor3["Nome"].ToString();
                txtVendedor.Items.Add(ig);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis recebendo os valores dos campos
            String NomeLembrete = txtVendedor.Text;
            String Lembrete = txtLembrete.Text;
            String Importancia = null;
            String vendedor = txtVendedor.Text.Trim();
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
                MySqlCommand Query = new MySqlCommand("UPDATE agenda SET Lembrete='" + Lembrete + "', Nome='" + NomeLembrete + "', Importancia='" + Importancia + "', Data='" + Data + "', Hora='" + Hora + "', Observacoes='" + Obs + "' WHERE Id=" + ClassInfo.IdAgendaGlobal + ";", conex);
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

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 || !char.IsLetter(e.KeyChar))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtVendedor_Click(object sender, EventArgs e)
        {
            txtVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            idVendedor = (txtVendedor.SelectedIndex) + 1;
        }
    }
}
