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
    public partial class ConsultarClientes : Form
    {
        public ConsultarClientes()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            SubClientes sub = new SubClientes();
            sub.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtCliente.Text;

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM cliente WHERE nome LIKE '%" + nome + "%';", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvClientes.DataSource = clientes;
        }

        private void btnExcluirRegistro_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM cliente WHERE id=" + clienteId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + clienteId);
                    btnPesquisar.PerformClick();

                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }


            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                string nome = txtCliente.Text;

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();

                MySqlCommand Query = new MySqlCommand("SELECT * FROM cliente WHERE nome LIKE '%" + nome + "%';", conex);

                //define o tipo do comando
                Query.CommandType = CommandType.Text;
                //cria um dataadapter
                MySqlDataAdapter da = new MySqlDataAdapter(Query);

                //cria um objeto datatable
                DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(clientes);

                //atribui o datatable ao datagridview para exibir o resultado
                dgvClientes.DataSource = clientes;

            }
        }

        private void btnAlterarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja alterar o registro selecionado?", "Alterar - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                ClassInfo.IdClienteGlobal = Convert.ToString(dgvClientes.CurrentRow.Cells[0].Value);

                this.Close();
                AlterarCliente al = new AlterarCliente();
                al.Show();

            }
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM cliente;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvClientes.DataSource = clientes;

            if (ClassInfo.TipoUsuario == "Vendedor")
            {
                btnAlterarRegistro.Enabled = false;
                btnExcluirRegistro.Enabled = false;
            }
        }
    }
}
