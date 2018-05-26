using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HelpSerralheiro
{
    public partial class FrmCadastro : Form
    {
        string usuario, senha,senhatemp, confirmasenha, nome, rg, tipo, email,emailtemp,confirmaemail;
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            usuario = txtUsuario.Text;
            senhatemp = txtSenha.Text;
            confirmasenha = txtConfirmaSenha.Text;
            nome = txtNome.Text;
            rg = maskedTextBoxRG.Text;
            tipo = comboBox1.Text;
            emailtemp = txtEmail.Text;
            confirmaemail = txtConfirmaEmail.Text;

            if (txtUsuario.TextLength == 0 || txtSenha.TextLength == 0 || txtNome.TextLength == 0 || txtEmail.TextLength == 0 || txtConfirmaSenha.TextLength == 0 || txtConfirmaEmail.TextLength == 0)
            {
                MessageBox.Show("Todos os campos precisam estar preenchidos!");
                return;
            }

            if (senhatemp != confirmasenha)
            {
                MessageBox.Show("As senhas não são iguais!");
                return;
            }else{senha = senhatemp;}

            if (emailtemp != confirmaemail)
            {
                MessageBox.Show("Os emails não são iguais!");
                return;
            } else { email = emailtemp; }

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("INSERT INTO usuarios (usuario, senha, nome, rg, tipo, email)" + "VALUES('" + usuario + "', '" + senha + "', '" + nome + "', '" + rg + "', '" + tipo  + "', '" + email + "');", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                this.Close();
                Menu men = new Menu();
                men.Show();
            }
            else{
                MessageBox.Show("Erro ao cadastrar!");
            }
            conex.Close();

        }
         

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultarUsuario menu = new ConsultarUsuario();
            menu.Show();
        }
    }
}
