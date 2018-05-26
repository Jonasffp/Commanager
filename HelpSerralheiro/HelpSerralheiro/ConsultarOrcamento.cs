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
    public partial class ConsultarOrcamento : Form
    {
        public ConsultarOrcamento()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubOrcamento sub = new SubOrcamento();
            sub.Show();
            this.Close();
        }

        private void ConsultarOrcamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM orcamentos;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable orcamentos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(orcamentos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvOrcamento.DataSource = orcamentos;

            if (ClassInfo.TipoUsuario == "Vendedor")
            {
                btnAlterarRegistro.Enabled = false;
                btnExcluirRegistro.Enabled = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtCliente.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM orcamentos WHERE Cliente LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable orcamento = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(orcamento);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvOrcamento.DataSource = orcamento;
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvOrcamento.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdVendaGlobal = Convert.ToInt32(dgvOrcamento.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarOrcamento al = new AlterarOrcamento();
                al.Show();

            }
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvOrcamento.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Orcamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int orcamentoId = Convert.ToInt32(dgvOrcamento.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM orcamentos WHERE Id=" + orcamentoId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro de orçamento excluido com sucesso! " + orcamentoId);
                    btnPesquisar.PerformClick();

                }
                catch (Exception ex)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!"+ ex);

                }


            }
        }
    }
}
