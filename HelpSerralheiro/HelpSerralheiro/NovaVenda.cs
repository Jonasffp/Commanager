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
    public partial class NovaVenda : Form
    {
        public NovaVenda()
        {
            InitializeComponent();
            
        }
        double ValorItens, ValorFrete, Desconto,ValorLucro,ValorCusto;
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (txtValorTotal.Text == "")
            {
                 MessageBox.Show("Erro ao concluir a venda!");
                 MessageBox.Show("É necessário escolher no mínimo um produto!");
            }    

            String dataVenda = Convert.ToDateTime(txtDataVenda.Text).ToString("yyyy/MM/dd");
            String horaVenda = txtHoraVenda.Text.Trim();
            String comprador = txtComprador.Text.Trim();
            String vendedor = txtVendedor.Text.Trim();
            String dataEntrega = txtDataEntrega.Text.Trim();
            String horaEntrega = txtHoraEntrega.Text.Trim();
            String observacoes = txtObservacoes.Text.Trim();
            int idComprador = Convert.ToInt32(txtIdComprador.Text.Trim());
            


                double desconto = Convert.ToDouble(txtDescontos.Text.Trim());
                double valorItens = Convert.ToDouble(txtValorItens.Text.Trim());
                double frete = Convert.ToDouble(txtFrete.Text.Trim());
                double valorTotal = Convert.ToDouble(txtValorTotal.Text.Trim());


            
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query1 = new MySqlCommand("INSERT INTO vendas (IdComprador, IdVendedor, Comprador, Vendedor, DataVenda, HoraVenda, DataEntrega, HoraEntrega, Observacoes, ValorItens, Desconto, ValorFrete, ValorTotal, ValorLucro)" + "VALUES('"+idComprador+"', '0', '" + comprador + "', '" + vendedor + "', '" + dataVenda + "', '" + horaVenda + "', '" + dataEntrega + "', '" + horaEntrega + "', '" + observacoes + "', '" + valorItens + "', '" + desconto + "', '" + frete + "', '" + valorTotal + "', '"+ValorLucro+"');", conex);
            Query1.ExecuteNonQuery();
            int idVenda = Convert.ToInt32(Query1.LastInsertedId);

            //instância do comando onde passo
            //o sql e a conexão como parâmetro
            //abro a conexão
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = conex;
            
            //percorro o DataGridView
            for (int i = 0; i < dgvVenda.Rows.Count - 1; i++)
            {
                Query.Parameters.Clear();
                //crio os parâmetro do comando
                //e passo as linhas do dgvClientes para eles
                //onde a célula indica a coluna do dgv
                Query.Parameters.AddWithValue("@idProduto",
                    dgvVenda.Rows[i].Cells[1].Value);
                Query.Parameters.AddWithValue("@Nome",
                    dgvVenda.Rows[i].Cells[2].Value);
                Query.Parameters.AddWithValue("@UnidadeMedida",
                    dgvVenda.Rows[i].Cells[3].Value);
                Query.Parameters.AddWithValue("@Marca",
                    dgvVenda.Rows[i].Cells[4].Value);
                Query.Parameters.AddWithValue("@Categoria",
                    dgvVenda.Rows[i].Cells[5].Value);
                Query.Parameters.AddWithValue("@Valor",
                    dgvVenda.Rows[i].Cells[6].Value);
                Query.Parameters.AddWithValue("@ValorCusto",
                    dgvVenda.Rows[i].Cells[7].Value);
                Query.Parameters.AddWithValue("@Frete",
                    dgvVenda.Rows[i].Cells[8].Value);
                Query.Parameters.AddWithValue("@Observacoes",
                    dgvVenda.Rows[i].Cells[9].Value);
                //executo o comando
                Query.CommandText = "INSERT INTO produtosvendas (IdProduto, IdVenda, Nome, UnidadeMedida, Marca, Categoria, Valor, ValorCusto, Frete, Observacoes) VALUES (@idProduto,'"+idVenda+"', @Nome, @UnidadeMedida, @Marca, @Categoria, @Valor, @ValorCusto, @Frete, @Observacoes)";
                Query.ExecuteNonQuery();
            }
            if (conex.State == ConnectionState.Open)
            {
                MessageBox.Show("Venda finalizada com sucesso!");



                MySqlCommand Query2 = new MySqlCommand("TRUNCATE TABLE produtosvendastemporaria ;", conex);
                //define o tipo do comando
                Query2.CommandType = CommandType.Text;
                Query2.ExecuteNonQuery();

                //Fecho conexão
                conex.Close();

                SubVendas sb = new SubVendas();
                sb.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao finalizar a venda!");
            }

            }

            
        

        private void btIncluirProduto_Click(object sender, EventArgs e)
        {
            ConsultaProdutosVenda cs = new ConsultaProdutosVenda();
            cs.Show();
        }

        private void txtValorItens_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtDescontos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        public void btnOculto_Click(object sender, EventArgs e)
        {
            ValorFrete = 0;
            ValorItens = 0;
            Desconto = 0;
            ValorLucro = 0;
            ValorCusto = 0;
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
            dgvVenda.DataSource = produto;

            for (int i = 0; i < dgvVenda.Rows.Count - 1; i++)
            {
               
                   ValorItens += Convert.ToDouble(dgvVenda.Rows[i].Cells[6].Value);
                   ValorCusto += Convert.ToDouble(dgvVenda.Rows[i].Cells[7].Value);
                   ValorFrete += Convert.ToDouble(dgvVenda.Rows[i].Cells[8].Value);

            }
            dgvVenda.Columns[0].Visible = false;
            dgvVenda.Columns[7].Visible = false;


            txtValorItens.Text = Convert.ToString(ValorItens);
            txtFrete.Text = Convert.ToString(ValorFrete);



            Desconto = Convert.ToInt32(txtDescontos.Text);
            ValorLucro = ValorItens - ValorCusto;
            txtValorTotal.Text = Convert.ToString((ValorFrete + ValorItens)-Desconto);

            if (ClassInfo.IdClienteGlobal !="0")
            {
                txtIdComprador.Text = ClassInfo.IdClienteGlobal;
                MySqlCommand Query2 = new MySqlCommand("SELECT Nome FROM cliente WHERE Id=" + ClassInfo.IdClienteGlobal + " ;", conex);
                //define o tipo do comando
                Query2.CommandType = CommandType.Text;
                Query2.ExecuteNonQuery();
                try

                {
                    MySqlDataReader leitor = Query2.ExecuteReader();

                    leitor.Read(); //lê a primeira row da pesquisa
                    txtIdComprador.Text = ClassInfo.IdClienteGlobal;
                    txtComprador.Text = leitor["Nome"].ToString();


                }

                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

                finally { conex.Close(); }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            SubVendas sb = new SubVendas();
            sb.Show();
            this.Close();
        }

        private void NovaVenda_Load(object sender, EventArgs e)
        {
            ClassInfo.IdClienteGlobal = "0";
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

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

            conex.Close();
        }

        private void NovaVenda_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btExcluirProduto_Click(object sender, EventArgs e)
        {
            if (dgvVenda.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado");
                return;

            }
            if (MessageBox.Show("Deseja excluir o registro selecionado?", "Excluir - Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // pega o valor do id na ccoluna selecionada
                int IdProd = Convert.ToInt32(dgvVenda.CurrentRow.Cells[0].Value);

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

        private void btAddCliente_Click(object sender, EventArgs e)
        {
            ConsultaClientesVenda cons = new ConsultaClientesVenda();
            cons.Show();
        }

        private void txtDescontos_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDescontos.Text != "")
            {
                Desconto = Convert.ToInt32(txtDescontos.Text);
                ValorFrete = Convert.ToInt32(txtFrete.Text);
                ValorItens = Convert.ToInt32(txtValorItens.Text);
                txtValorTotal.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
        }

        private void txtFrete_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFrete.Text != "")
            {
                Desconto = Convert.ToInt32(txtDescontos.Text);
                ValorFrete = Convert.ToInt32(txtFrete.Text);
                ValorItens = Convert.ToInt32(txtValorItens.Text);
                txtValorTotal.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
        }




    }
}
