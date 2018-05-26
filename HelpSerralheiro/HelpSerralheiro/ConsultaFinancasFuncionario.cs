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
    public partial class ConsultaFinancasFuncionario : Form
    {
        public ConsultaFinancasFuncionario()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubFinancas sub = new SubFinancas();
            sub.Show();
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvDespesas.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int despesaId = Convert.ToInt32(dgvDespesas.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM financasfuncionarios WHERE id=" + despesaId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + despesaId);
                    btnPesquisar.PerformClick();
                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvDespesas.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdDespesaGlobal = Convert.ToInt32(dgvDespesas.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarDespesaFuncionario al = new AlterarDespesaFuncionario();
                al.Show();

            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            NovoDespesaFuncionario novo = new NovoDespesaFuncionario();
            novo.Show();
            this.Close();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtDespesa.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM financasfuncionarios WHERE nome LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable despesa = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(despesa);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvDespesas.DataSource = despesa;
        }

        private void ConsultaFinancasFuncionario_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM financasfuncionarios ;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable despesa = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(despesa);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvDespesas.DataSource = despesa;

            foreach (DataGridViewColumn column in dgvDespesas.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
