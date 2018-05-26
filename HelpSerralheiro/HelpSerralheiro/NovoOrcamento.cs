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
    public partial class NovoOrcamento : Form
    {
        public NovoOrcamento()
        {
            InitializeComponent();
        }
        double ValorFrete, ValorItens, Desconto;
        private void txtDescontoOrcamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtFreteOrcamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtDescontoOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDescontos.Text != "")
            {
                Desconto = Convert.ToInt32(txtDescontos.Text);
                ValorFrete = Convert.ToInt32(txtFrete.Text);
                ValorItens = Convert.ToInt32(txtValorItens.Text);
                txtValorTotal.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
        }

        private void txtFreteOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFrete.TextLength > 0)
            {
                Desconto = Convert.ToInt32(txtDescontos.Text);
                ValorFrete = Convert.ToInt32(txtFrete.Text);
                ValorItens = Convert.ToInt32(txtValorItens.Text);
                txtValorTotal.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
            else
            {
                MessageBox.Show("É necessário que todos os campos referentes a valores estejam preenchidos, para que o calculo possa ser feito !");
            }
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
                    MySqlCommand Query = new MySqlCommand("DELETE FROM produtosvendastemporaria WHERE id=" + IdProd + ";", conex);
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

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produtosvendastemporaria;", conex);
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

                ValorItens += Convert.ToDouble(dgvOrcamento.Rows[i].Cells[6].Value);

                ValorFrete += Convert.ToDouble(dgvOrcamento.Rows[i].Cells[8].Value);
            }
            dgvOrcamento.Columns[0].Visible = false;
            dgvOrcamento.Columns[7].Visible = false;


            txtValorItens.Text = Convert.ToString(ValorItens);
            txtFrete.Text = Convert.ToString(ValorFrete);



            Desconto = Convert.ToInt32(txtDescontos.Text);
            txtValorTotal.Text = Convert.ToString((ValorFrete + ValorItens) - Desconto);
            conex.Close();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
            SubOrcamento sub = new SubOrcamento();
            sub.Show();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (txtValorTotal.Text == "")
            {
                MessageBox.Show("Erro ao concluir a venda!");
                MessageBox.Show("É necessário escolher no mínimo um produto!");
            }



            String comprador = txtComprador.Text.Trim();
            String vendedor = txtVendedor.Text.Trim();



            double desconto = Convert.ToDouble(txtDescontos.Text.Trim());
            double valorItens = Convert.ToDouble(txtValorItens.Text.Trim());
            double frete = Convert.ToDouble(txtFrete.Text.Trim());
            double valorTotal = Convert.ToDouble(txtValorTotal.Text.Trim());



            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query1 = new MySqlCommand("INSERT INTO orcamentos (Cliente, Vendedor, ValorItens, Desconto, ValorFrete, ValorTotal)" + "VALUES('" + comprador + "', '" + vendedor + "', '" + valorItens + "', '" + desconto + "', '" + frete + "', '" + valorTotal + "');", conex);
            Query1.ExecuteNonQuery();
            int idOrcamento = Convert.ToInt32(Query1.LastInsertedId);

            //instância do comando onde passo
            //o sql e a conexão como parâmetro
            //abro a conexão
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = conex;

            //percorro o DataGridView
            for (int i = 0; i < dgvOrcamento.Rows.Count - 1; i++)
            {
                Query.Parameters.Clear();
                //crio os parâmetro do comando
                //e passo as linhas do dgvClientes para eles
                //onde a célula indica a coluna do dgv
                Query.Parameters.AddWithValue("@idProduto",
                    dgvOrcamento.Rows[i].Cells[1].Value);
                Query.Parameters.AddWithValue("@Nome",
                    dgvOrcamento.Rows[i].Cells[2].Value);
                Query.Parameters.AddWithValue("@UnidadeMedida",
                    dgvOrcamento.Rows[i].Cells[3].Value);
                Query.Parameters.AddWithValue("@Marca",
                    dgvOrcamento.Rows[i].Cells[4].Value);
                Query.Parameters.AddWithValue("@Categoria",
                    dgvOrcamento.Rows[i].Cells[5].Value);
                Query.Parameters.AddWithValue("@Valor",
                    dgvOrcamento.Rows[i].Cells[6].Value);
                Query.Parameters.AddWithValue("@ValorCusto",
                    dgvOrcamento.Rows[i].Cells[7].Value);
                Query.Parameters.AddWithValue("@Frete",
                    dgvOrcamento.Rows[i].Cells[8].Value);
                Query.Parameters.AddWithValue("@Observacoes",
                    dgvOrcamento.Rows[i].Cells[9].Value);
                //executo o comando
                Query.CommandText = "INSERT INTO produtosorcamentos (IdProduto, IdOrcamento, Nome, UnidadeMedida, Marca, Categoria, Valor, ValorCusto, Frete, Observacoes) VALUES (@idProduto,'" + idOrcamento + "', @Nome, @UnidadeMedida, @Marca, @Categoria, @Valor, @ValorCusto, @Frete, @Observacoes)";
                Query.ExecuteNonQuery();
            }
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Orçamento finalizado com sucesso!");



                MySqlCommand Query2 = new MySqlCommand("TRUNCATE TABLE produtosvendastemporaria ;", conex);
                //define o tipo do comando
                Query2.CommandType = CommandType.Text;
                Query2.ExecuteNonQuery();

                //Fecho conexão
                conex.Close();

                SubOrcamento sb = new SubOrcamento();
                sb.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao finalizar orçamento!");
            }

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            ConsultaProdutosOrcamento cons = new ConsultaProdutosOrcamento();
            cons.Show();
        }

        private void NovoOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("TRUNCATE TABLE produtosvendastemporaria ;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            Query.ExecuteNonQuery();
            conex.Close();
        }

        private void NovoOrcamento_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            MySqlConnection conex2 = new MySqlConnection(Config);
            conex.Open();
            conex2.Open();

            MySqlCommand Query = new MySqlCommand("TRUNCATE TABLE produtosvendastemporaria ;", conex);
            //define o tipo do comando
            Query.CommandType = CommandType.Text;
            Query.ExecuteNonQuery();

            MySqlCommand Query2 = new MySqlCommand("SELECT Nome FROM funcionario;", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            Query2.ExecuteNonQuery();
            
            MySqlDataReader leitor = Query2.ExecuteReader();

            for (int i = 0; leitor.Read() != false; i++)
            {
                string ig = leitor["Nome"].ToString();
                txtVendedor.Items.Add(ig);
            }

            MySqlCommand Query3 = new MySqlCommand("SELECT * FROM produtosvendastemporaria ;", conex2);
            //define o tipo do comando
            Query3.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query3);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvOrcamento.DataSource = produtos;

            conex.Close();
            conex2.Close();
        }
        }
    }

