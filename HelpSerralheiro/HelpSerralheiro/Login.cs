using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HelpSerralheiro
{
    public partial class Login : Form
    {
        public string usuarioentrou;

        public Login()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text;
            string senha = txtSenha.Text;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            MySqlCommand Query = new MySqlCommand();
            conex.Open();
            Query.Connection = conex;
            Query.CommandText = "SELECT usuario, senha FROM Usuarios WHERE usuario = @nome AND senha = @senha";
            Query.Parameters.AddWithValue("@nome", nome);
            Query.Parameters.AddWithValue("@senha", senha);
            bool Verifica = Query.ExecuteReader().HasRows;

            //MySqlConnection conex2 = new MySqlConnection(Config);
          // // conex2.Open();

            //MySqlCommand Query2 = new MySqlCommand("SELECT * FROM usuario WHERE nome LIKE '%" + nome + "%';", conex2);

            //MySqlDataReader leitor = Query2.ExecuteReader();

          // leitor.Read(); //lê a primeira row da pesquisa
           // ClassInfo.TipoUsuario = leitor["tipo"].ToString();
                


            MySqlConnection conex2 = new MySqlConnection(Config);
            conex2.Open();
            MySqlCommand Query2 = new MySqlCommand("SELECT * FROM usuario WHERE usuario=" + nome + "';", conex2);

                try

                {
                MySqlDataReader leitor = Query2.ExecuteReader();

                    leitor.Read(); //lê a primeira row da pesquisa
                    ClassInfo.TipoUsuario = leitor["tipo"].ToString();
                }

                 catch (Exception ex)
                                {
                                    ex.Message.ToString();
                                }

                finally{conex.Close();}

            if (Verifica == true)
            {
                ClassInfo.Usuarioentrou = nome;

                Menu menu = new Menu();
                menu.Show();
                Close();
            }
            else{
                MessageBox.Show("Nome ou Senha Incorretos!");
            }
            conex.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCadastro cad = new FrmCadastro();
            cad.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            EsqueceSenha esq = new EsqueceSenha();
            esq.Show();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }
    }
}
