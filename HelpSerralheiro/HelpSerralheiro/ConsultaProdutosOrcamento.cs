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
    public partial class ConsultaProdutosOrcamento : Form
    {
        public ConsultaProdutosOrcamento()
        {
            InitializeComponent();
        }

        private void ConsultaProdutosOrcamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produto ;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvProdutosVenda.DataSource = produtos;
            dgvProdutosVenda.Columns[6].Visible = false;

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
            dgvProdutosVenda.DataSource = produtos;
            dgvProdutosVenda.Columns[6].Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProdutosVenda.SelectedRows.Count <= 0) { MessageBox.Show("Não há registro selecionado"); return; }
            else
            {
                ClassInfo.IdProdutoGlobal = Convert.ToInt32(dgvProdutosVenda.CurrentRow.Cells[0].Value);
                int id = Convert.ToInt32(dgvProdutosVenda.CurrentRow.Cells[0].Value);
                string nome = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[1].Value);
                string unidade = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[2].Value);
                string marca = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[3].Value);
                string categoria = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[4].Value);
                string fornecedor = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[5].Value);
                int valorCusto = Convert.ToInt32(dgvProdutosVenda.CurrentRow.Cells[6].Value);
                int valorVenda = Convert.ToInt32(dgvProdutosVenda.CurrentRow.Cells[7].Value);
                int frete = Convert.ToInt32(dgvProdutosVenda.CurrentRow.Cells[8].Value);
                string observacoes = Convert.ToString(dgvProdutosVenda.CurrentRow.Cells[9].Value);

                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();

                MySqlCommand Query = new MySqlCommand("INSERT INTO produtosvendastemporaria (idProduto,Nome,UnidadeMedida,Marca,Categoria,Valor,ValorCusto,Frete,Observacoes)" + "VALUES('" + id + "', '" + nome + "', '" + unidade + "', '" + marca + "', '" + categoria + "', '" + valorVenda + "', '" + valorCusto + "', '" + frete + "', '" + observacoes + "');", conex);
                //define o tipo do comando
                Query.CommandType = CommandType.Text;
                Query.ExecuteNonQuery();

                var form = Application.OpenForms["NovoOrcamento"] as NovoOrcamento;
                if (form != null)//se encontrou o form principal aberto
                {
                    form.btnOculto_Click(this, new EventArgs());
                }

                this.Close();

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
