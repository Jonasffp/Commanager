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
    public partial class ConsultaClientesVenda : Form
    {
        public ConsultaClientesVenda()
        {
            InitializeComponent();
        }

        private void ConsultaClientesVenda_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM cliente ;", conex);
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string nome = txtPesquisaProduto.Text;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count <= 0) { MessageBox.Show("Não há registro selecionado"); return; }
            else
            {
                ClassInfo.IdClienteGlobal = Convert.ToString(dgvClientes.CurrentRow.Cells[0].Value);
            }

            var form = Application.OpenForms["NovaVenda"] as NovaVenda;
            var form2 = Application.OpenForms["AlterarVenda"] as AlterarVenda;
            if (form != null)//se encontrou o form principal aberto
            {
                form.btnOculto_Click(this, new EventArgs());
            }
            if (form2 != null)//se encontrou o form principal aberto
            {
                form2.btnOculto_Click(this, new EventArgs());
            }
            this.Close();

        }
    }
}
