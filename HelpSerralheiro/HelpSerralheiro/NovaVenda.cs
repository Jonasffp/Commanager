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
        double ValorItens, ValorFrete, Desconto;
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (txtValorTotal.Text == "")
            {
                 MessageBox.Show("Erro ao concluir a venda!");
                 MessageBox.Show("É necessário escolher no mínimo um produto!");
            }    
            String dataVenda = txtDataVenda.Text.Trim();
            String horaVenda = txtHoraVenda.Text.Trim();
            String comprador = txtComprador.Text.Trim();
            String vendedor = txtVendedor.Text.Trim();
            String dataEntrega = txtDataEntrega.Text.Trim();
            String horaEntrega = txtHoraEntrega.Text.Trim();
            String observacoes = txtObservacoes.Text.Trim();
            double desconto = Convert.ToDouble(txtDescontos.Text.Trim());
            double valorItens = Convert.ToDouble(txtValorItens.Text.Trim());
            double frete = Convert.ToDouble(txtFrete.Text.Trim());
            double valorTotal = Convert.ToDouble(txtValorTotal.Text.Trim());

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            //MySqlCommand Query = new MySqlCommand("INSERT INTO vendas (IdComprador, IdVendedor, Comprador, Vendedor, DataVenda, HoraVenda, DataEntrega, HoraEntrega, Observacoes, ValorItens, Desconto, ValorFrete, ValorTotal)" + "VALUES('0', '0', '" + comprador + "', '" + vendedor + "', '" + dataVenda + "', '" + horaVenda + "', '" + dataEntrega + "', '" + horaEntrega + "', '" + observacoes + "', '" + valorItens + "', '" + desconto + "', '" + frete + "', '" + valorTotal + "');" + "SELECT LAST_INSERT_ID() INTO @IdVenda;", conex);
            //Query.ExecuteNonQuery();
           // var sql = "INSERT INTO vendas (IdComprador, IdVendedor, Comprador, Vendedor, DataVenda, HoraVenda, DataEntrega, HoraEntrega, Observacoes, ValorItens, Desconto, ValorFrete, ValorTotal)" + "VALUES('0', '0', '" + comprador + "', '" + vendedor + "', '" + dataVenda + "', '" + horaVenda + "', '" + dataEntrega + "', '" + horaEntrega + "', '" + observacoes + "', '" + valorItens + "', '" + desconto + "', '" + frete + "', '" + valorTotal + "');" + "SELECT LAST_INSERT_ID() INTO @IdVenda;"+"INSERT INTO produtosvendas (Id, IdVenda, Nome, UnidadeMedida, Marca, Categoria, Valor, ValorCusto, Frete, Observacoes) " +
             //                    "VALUES (@idProduto, @IdVenda, @Nome, @UnidadeMedida, @Marca, @Categoria, @Valor, @ValorCusto, @Frete, @Observacoes)";
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
                Query.CommandText = "INSERT INTO produtosvendas (Id, Nome, UnidadeMedida, Marca, Categoria, Valor, ValorCusto, Frete, Observacoes) VALUES (@idProduto, @Nome, @UnidadeMedida, @Marca, @Categoria, @Valor, @ValorCusto, @Frete, @Observacoes)";
                Query.ExecuteNonQuery();
            }
            //Fecho conexão
            conex.Close();
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
               
                   ValorFrete += Convert.ToDouble(dgvVenda.Rows[i].Cells[7].Value);
            }

        

            txtValorItens.Text = Convert.ToString(ValorItens);
            txtFrete.Text = Convert.ToString(ValorFrete);



            txtValorTotal.Text = Convert.ToString((ValorFrete + ValorItens)-Desconto);

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            SubVendas sb = new SubVendas();
            sb.Show();
            this.Close();
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
                int clienteId = Convert.ToInt32(dgvVenda.CurrentRow.Cells[0].Value);

                try
                {
                    //string de conexão mysql
                    string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
                    MySqlConnection conex = new MySqlConnection(Config);
                    conex.Open();

                    // executa a query de deletar com a variavel do id selecionado na datagrid
                    MySqlCommand Query = new MySqlCommand("DELETE FROM produtosvendastemporaria WHERE id=" + clienteId + ";", conex);
                    Query.ExecuteNonQuery();

                    //confirmação da exclusão
                    MessageBox.Show("Registro excluido com sucesso! " + clienteId);
                  
                    btnOculto_Click(this, new EventArgs());
                    

                }
                catch (Exception)
                {
                    //erro na exclusão aparecerá essa mensagem
                    MessageBox.Show("Erro ao excluir o registro!");

                }


            }
        }



    }
}
