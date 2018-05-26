using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;
using MySql.Data.MySqlClient;

namespace HelpSerralheiro
{
    public partial class EsqueceSenha : Form
    {
        public EsqueceSenha()
        {
            InitializeComponent();
        }

        String senha = null;
        String nome = null;
        String usuario = null;



        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM usuarios WHERE email = '" + email + "';", conex);

            try
            {
                MySqlDataReader leitor = Query.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read(); //lê a primeira row da pesquisa
                    senha = leitor["senha"].ToString();
                    nome = leitor["nome"].ToString();
                    usuario = leitor["usuario"].ToString();

                    MessageBox.Show("Olá "+ nome + ", a cópia da sua senha foi enviada para o seu email, por favor verifique-o");
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("developoficial@gmail.com");
                    mail.To.Add(email); // para
                    mail.Subject = "Email de recuperação de senha"; // assunto
                    mail.Body = "Olá Sr.(a) " + nome + ", sua senha, para o usuário " + usuario + " é " +senha ; // mensagem

                    using (var smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.EnableSsl = true; // GMail requer SSL
                        smtp.Port = 587;       // porta para SSL
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                        smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                        // seu usuário e senha para autenticação
                        smtp.Credentials = new NetworkCredential("developoficial@gmail.com", "develop2017");

                        // envia o e-mail
                        smtp.Send(mail);
                        txtEmail.Clear();
                        this.Close();
                        Login log = new Login();
                        log.Show();
                    }

                }else{
                    MessageBox.Show("Erro ao enviar por email, email inválido!");
                    MessageBox.Show("Verifique sua conexão e tente novamente, se o erro persistir entre em contato com o suporte.");
                    txtEmail.Clear();
                }
            }
  



            finally { conex.Close(); }



        }

    }
    }


