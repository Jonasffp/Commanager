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
        int ValorItens, ValorFrete, Desconto, IdProd;

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
            MySqlConnection conex2 = new MySqlConnection(Config);
            conex2.Open();


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
                ValorItens = 0;
                ValorFrete = 0; 
                Desconto = 0;
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtClienteOrcamento.Text = leitor["Cliente"].ToString();
                txtVendedor.Text = leitor["Vendedor"].ToString();
                //txtValorItensOrcamento.Text = leitor["ValorItens"].ToString();
                //txtFreteOrcamento.Text = leitor["ValorFrete"].ToString();
                //txtTotalOrcamento.Text = leitor["ValorTotal"].ToString();
                txtDescontoOrcamento.Text = leitor["Desconto"].ToString();

                MySqlCommand Query4 = new MySqlCommand("SELECT Nome FROM funcionario;", conex2);
                //define o tipo do comando
                Query4.CommandType = CommandType.Text;
                Query4.ExecuteNonQuery();

                MySqlDataReader leitor4 = Query4.ExecuteReader();

                for (int i = 0; leitor4.Read() != false; i++)
                {
                    string ig = leitor4["Nome"].ToString();
                    txtVendedor.Items.Add(ig);
                }
                conex2.Close();
                for (int i = 0; i < dgvOrcamento.Rows.Count - 1; i++)
                {

                    ValorItens += Convert.ToInt32(dgvOrcamento.Rows[i].Cells[7].Value);

                    ValorFrete += Convert.ToInt32(dgvOrcamento.Rows[i].Cells[9].Value);
                }

                txtValorItensOrcamento.Text = Convert.ToString(ValorItens);
                txtFreteOrcamento.Text = Convert.ToString(ValorFrete);
                
                Desconto = Convert.ToInt32(txtDescontoOrcamento.Text);
                txtTotalOrcamento.Text = Convert.ToString((ValorFrete + ValorItens) - Desconto);

                dgvOrcamento.Columns[0].Visible = false;
                dgvOrcamento.Columns[8].Visible = false;
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
            String vendedor = txtVendedor.Text.Trim();
            int desconto = Convert.ToInt32(txtDescontoOrcamento.Text.Trim());
            int valorItens = Convert.ToInt32(txtValorItensOrcamento.Text.Trim());
            int frete = Convert.ToInt32(txtFreteOrcamento.Text.Trim());
            int valorTotal = Convert.ToInt32(txtTotalOrcamento.Text.Trim());

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
                try
                {
                    // pega o valor do id na ccoluna selecionada
                    IdProd = Convert.ToInt32(dgvOrcamento.CurrentRow.Cells[0].Value);
                }
                catch
                {
                    MessageBox.Show("Por favor clique sobre o produto que deseja excluir!");
                    return;
                }
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
                    MessageBox.Show("Registro excluido com sucesso! ");

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

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produtosorcamentos WHERE IdOrcamento=" + ClassInfo.IdVendaGlobal + ";", conex);
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

                ValorItens += Convert.ToInt32(dgvOrcamento.Rows[i].Cells[7].Value);

                ValorFrete += Convert.ToInt32(dgvOrcamento.Rows[i].Cells[9].Value);
            }
            dgvOrcamento.Columns[0].Visible = false;
            dgvOrcamento.Columns[8].Visible = false;


            txtValorItensOrcamento.Text = Convert.ToString(ValorItens);
            txtFreteOrcamento.Text = Convert.ToString(ValorFrete);



            Desconto = Convert.ToInt32(txtDescontoOrcamento.Text);
            txtTotalOrcamento.Text = Convert.ToString((ValorFrete + ValorItens) - Desconto);
        }

        private void txtDescontoOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDescontoOrcamento.Text != "")
            {
                Desconto = Convert.ToInt32(txtDescontoOrcamento.Text);
                ValorFrete = Convert.ToInt32(txtFreteOrcamento.Text);
                ValorItens = Convert.ToInt32(txtValorItensOrcamento.Text);
                txtTotalOrcamento.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
        }

        private void txtFreteOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFreteOrcamento.Text != "" )
            {
                if (txtDescontoOrcamento.Text != "")
	                {
                         Desconto = Convert.ToInt32(txtDescontoOrcamento.Text);
	                }
                ValorFrete = Convert.ToInt32(txtFreteOrcamento.Text);
                ValorItens = Convert.ToInt32(txtValorItensOrcamento.Text);
                txtTotalOrcamento.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
            }
        }

        private void txtVendedor_Click(object sender, EventArgs e)
        {
            txtVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 || !char.IsLetter(e.KeyChar))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

    }
}
