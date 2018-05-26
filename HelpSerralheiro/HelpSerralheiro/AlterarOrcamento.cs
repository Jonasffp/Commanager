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
    public partial class AlterarOrcamento : Form
    {
        public AlterarOrcamento()
        {
            InitializeComponent();
        }
        double ValorItens, ValorFrete, Desconto;

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultarOrcamento cons = new ConsultarOrcamento();
            cons.Show();
        }

        private void AlterarOrcamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM orcamentos WHERE Id = '" + ClassInfo.IdVendaGlobal + "';", conex);

            MySqlCommand Query2 = new MySqlCommand("SELECT * FROM produtosorcamentos WHERE IdOrcamento='" + ClassInfo.IdVendaGlobal + "';", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query2);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvOrcamento.DataSource = produtos;
            try
            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtClienteOrcamento.Text = leitor["Cliente"].ToString();
                txtVendedorOrcamento.Text = leitor["Vendedor"].ToString();
                txtValorItensOrcamento.Text = leitor["ValorItens"].ToString();
                txtFreteOrcamento.Text = leitor["ValorFrete"].ToString();
                txtTotalOrcamento.Text = leitor["ValorTotal"].ToString();
                txtDescontoOrcamento.Text = leitor["Desconto"].ToString();
                


            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }


            finally { conex.Close(); }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            String comprador = txtClienteOrcamento.Text.Trim();
            String vendedor = txtVendedorOrcamento.Text.Trim();
            double desconto = Convert.ToDouble(txtDescontoOrcamento.Text.Trim());
            double valorItens = Convert.ToDouble(txtValorItensOrcamento.Text.Trim());
            double frete = Convert.ToDouble(txtFreteOrcamento.Text.Trim());
            double valorTotal = Convert.ToDouble(txtTotalOrcamento.Text.Trim());

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("UPDATE orcamentos SET Cliente='" + comprador + "', Vendedor='" + vendedor + "', Desconto=" + desconto + ", ValorItens=" + valorItens + ", ValorFrete=" + frete + ", ValorTotal=" + valorTotal + " WHERE Id=" + ClassInfo.IdVendaGlobal + ";", conex);
            Query.ExecuteNonQuery();
            Query.Connection = conex;
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Alterado com sucesso!");

                this.Close();
                ConsultarOrcamento sub = new ConsultarOrcamento();
                sub.Show();
            }

            else
            {
                MessageBox.Show("Erro ao alterar!");
            }
            conex.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlterarProdutoOrcamento al = new AlterarProdutoOrcamento();
            al.Show();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvOrcamento.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int IdProd = Convert.ToInt32(dgvOrcamento.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM produtosorcamentos WHERE id=" + IdProd + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + IdProd);

                    btnOculto_Click(this, new EventArgs());
                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }

            }
        }

        public void btnOculto_Click(object sender, EventArgs e)
        {
            ValorFrete = 0;
            ValorItens = 0;
            Desconto = 0;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produtosvendas WHERE IdVenda=" + ClassInfo.IdVendaGlobal + ";", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query);

            //cria um objeto datatable
            DataTable produto = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produto);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvOrcamento.DataSource = produto;

            for (int i = 0; i < dgvOrcamento.Rows.Count - 1; i++)
            {

                ValorItens += Convert.ToDouble(dgvOrcamento.Rows[i].Cells[7].Value);

                ValorFrete += Convert.ToDouble(dgvOrcamento.Rows[i].Cells[9].Value);
            }
            dgvOrcamento.Columns[0].Visible = false;
            dgvOrcamento.Columns[7].Visible = false;


            txtValorItensOrcamento.Text = Convert.ToString(ValorItens);
            txtFreteOrcamento.Text = Convert.ToString(ValorFrete);



            Desconto = Convert.ToInt32(txtDescontoOrcamento.Text);
            txtTotalOrcamento.Text = Convert.ToString((ValorFrete + ValorItens) - Desconto);
        }
    }
}
