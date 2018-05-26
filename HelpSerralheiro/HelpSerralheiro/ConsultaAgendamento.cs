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
    public partial class ConsultaAgendamento : Form
    {
        public ConsultaAgendamento()
        {
            InitializeComponent();
        }

        private void ConsultaAgendamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM agenda;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable agenda = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(agenda);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvAgendamento.DataSource = agenda;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string dataInicial = Convert.ToDateTime(txtDataInicial.Text).ToString("yyyy/MM/dd");
            string dataFinal = Convert.ToDateTime(txtDataFinal.Text).ToString("yyyy/MM/dd");

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM agenda WHERE Data BETWEEN('"+dataInicial+"') AND('"+dataFinal+"'); ", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable agenda = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(agenda);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvAgendamento.DataSource = agenda;
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvAgendamento.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdAgendaGlobal = Convert.ToInt32(dgvAgendamento.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarAgendamento al = new AlterarAgendamento();
                al.Show();

            }
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvAgendamento.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int agendaId = Convert.ToInt32(dgvAgendamento.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM agenda WHERE id=" + agendaId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + agendaId);
                    btnPesquisar.PerformClick();
                    conex.Close();

                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }


            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubAgenda sub = new SubAgenda();
            sub.Show();
            this.Close();
        }
    }
}
