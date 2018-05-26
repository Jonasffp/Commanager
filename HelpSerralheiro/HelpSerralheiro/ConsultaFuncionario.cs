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
    public partial class ConsultaFuncionario : Form
    {
        public ConsultaFuncionario()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            SubCadastro sub = new SubCadastro();
            sub.Show();
        }

        private void ConsultaFuncionario_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM funcionario;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable funcionario = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(funcionario);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvFuncionarios.DataSource = funcionario;
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdFuncionarioGlobal = Convert.ToInt32(dgvFuncionarios.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarFuncionario al = new AlterarFuncionario();
                al.Show();
            }
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int funcionarioId = Convert.ToInt32(dgvFuncionarios.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM funcionario WHERE id=" + funcionarioId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + funcionarioId);
                    btnPesquisar.PerformClick();

                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }


            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.Close();
            NovoFuncionario novo = new NovoFuncionario();
            novo.Show();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtFuncionario.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM funcionario WHERE nome LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable funcionario = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(funcionario);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvFuncionarios.DataSource = funcionario;
        }

    }
}
