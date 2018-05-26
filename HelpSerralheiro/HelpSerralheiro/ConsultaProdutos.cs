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
    public partial class ConsultaProdutos : Form
    {
        public ConsultaProdutos()
        {
            InitializeComponent();
        }

        private void ConsultaProdutos_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produto;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvProdutos.DataSource = produtos;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtPesquisaProduto.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produto WHERE nome LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvProdutos.DataSource = produtos;
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdProdutoGlobal = Convert.ToInt32(dgvProdutos.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarProduto al = new AlterarProduto();
                al.Show();

            }
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int produtoId = Convert.ToInt32(dgvProdutos.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM produto WHERE id=" + produtoId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + produtoId);
                    txtPesquisaProduto.Clear();
                    btnPesquisar.PerformClick();

                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }


            }
        }

        private void txtPesquisaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                string nome = txtPesquisaProduto.Text;

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();

                MySqlCommand Query = new MySqlCommand("SELECT * FROM produto WHERE nome LIKE '%" + nome + "%';", conex);
                //define o tipo do comando
                Query.CommandType = CommandType.Text;
                //cria um dataadapter
                MySqlDataAdapter da = new MySqlDataAdapter(Query);

                //cria um objeto datatable
                DataTable produtos = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(produtos);

                //atribui o datatable ao datagridview para exibir o resultado
                dgvProdutos.DataSource = produtos;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubProdutos sub = new SubProdutos();
            sub.Show();
            this.Close();
        }
    }
}
