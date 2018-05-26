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
    public partial class ConsultaVenda : Form
    {
        public ConsultaVenda()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubVendas sub = new SubVendas();
            sub.Show();
            this.Close();
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvVendas.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int vendaId = Convert.ToInt32(dgvVendas.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM vendas WHERE Id=" + vendaId + ";", conex);
                    Query.ExecuteNonQuery();
                    MySqlCommand Query2 = new MySqlCommand("DELETE FROM produtosvendas WHERE IdVenda=" + vendaId + ";", conex);
                    Query2.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + vendaId);
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtCliente.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas WHERE Comprador LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable vendas = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(vendas);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvVendas.DataSource = vendas;
            dgvVendas.Columns[14].Visible = false;
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvVendas.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdVendaGlobal = Convert.ToInt32(dgvVendas.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarVenda al = new AlterarVenda();
                al.Show();

            }
        }

        private void ConsultaVenda_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable vendas = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(vendas);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvVendas.DataSource = vendas;
            dgvVendas.Columns[14].Visible = false;

            if (ClassInfo.TipoUsuario == "Vendedor")
            {
                btnAlterarRegistro.Enabled = false;
                btnExcluirRegistro.Enabled = false;
            }
        }
    }
}
