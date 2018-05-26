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
    public partial class AlterarVenda : Form
    {
        public AlterarVenda()
        {
            InitializeComponent();
        }
        double ValorItens, ValorFrete, Desconto,ValorCusto,ValorLucro;
        int idVendedor, IdProd;
        
        private void AlterarVenda_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas WHERE Id = '" + ClassInfo.IdVendaGlobal + "';", conex);

            MySqlCommand Query2 = new MySqlCommand("SELECT * FROM produtosvendas WHERE IdVenda='" + ClassInfo.IdVendaGlobal + "';", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(Query2);

            //cria um objeto datatable
            DataTable produtos = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvVenda.DataSource = produtos;
            try
            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtDataVenda.Text = leitor["DataVenda"].ToString();
                txtHoraVenda.Text = leitor["HoraVenda"].ToString();
                txtComprador.Text = leitor["Comprador"].ToString();
                txtIdComprador.Text = leitor["IdComprador"].ToString();
                txtVendedor.Text = leitor["Vendedor"].ToString();
                string idVend = leitor["IdVendedor"].ToString();
                idVendedor = Convert.ToInt32(idVend);
                txtDataEntrega.Text = leitor["DataEntrega"].ToString();
                txtHoraEntrega.Text = leitor["HoraEntrega"].ToString();
                txtObservacoes.Text = leitor["Observacoes"].ToString();
                txtDescontos.Text = leitor["Desconto"].ToString();
                txtValorItens.Text = leitor["ValorItens"].ToString();
                txtFrete.Text = leitor["ValorFrete"].ToString();
                txtValorTotal.Text = leitor["ValorTotal"].ToString();

            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }


            finally { conex.Close(); }
            conex.Open();
            MySqlCommand Query3 = new MySqlCommand("SELECT Nome FROM funcionario;", conex);
            //define o tipo do comando
            Query3.CommandType = CommandType.Text;
            Query3.ExecuteNonQuery();

            MySqlDataReader leitor2 = Query3.ExecuteReader();

            for (int i = 0; leitor2.Read() != false; i++)
            {
                string ig = leitor2["Nome"].ToString();
                txtVendedor.Items.Add(ig);
            }

            conex.Close();
            

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultaVenda cons = new ConsultaVenda();
            cons.Show();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            String horaVenda = txtHoraVenda.Text.Trim();
            String comprador = txtComprador.Text.Trim();
            String vendedor = txtVendedor.Text.Trim();
            String dataEntrega = txtDataEntrega.Text.Trim();
            String horaEntrega = txtHoraEntrega.Text.Trim();
            String observacoes = txtObservacoes.Text.Trim();


            if (txtComprador.Text == "" || txtIdComprador.Text == "")
            {
                MessageBox.Show("Selecionar o comprador e o vendedor para maior segurança nas vendas!");
                return;
            }
            else
            {

                int idComprador = Convert.ToInt32(txtIdComprador.Text.Trim());
                double desconto = Convert.ToDouble(txtDescontos.Text.Trim());
                double valorItens = Convert.ToDouble(txtValorItens.Text.Trim());
                double frete = Convert.ToDouble(txtFrete.Text.Trim());
                double valorTotal = Convert.ToDouble(txtValorTotal.Text.Trim());
                String dataVenda = Convert.ToDateTime(txtDataVenda.Text).ToString("yyyy/MM/dd");


                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("UPDATE vendas SET DataVenda='" + dataVenda + "',IdComprador='" + idComprador + "', HoraVenda='" + horaVenda + "', Comprador='" + comprador + "',IdVendedor='" + idVendedor + "', Vendedor='" + vendedor + "', DataEntrega='" + dataEntrega + "', HoraEntrega='" + horaEntrega + "', Observacoes='" + observacoes + "', Desconto=" + desconto + ", ValorItens=" + valorItens + ", ValorFrete=" + frete + ", ValorTotal=" + valorTotal + ", ValorLucro=" + ValorLucro + " WHERE Id=" + ClassInfo.IdVendaGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;

                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso! " + idVendedor);

                    this.Close();
                    ConsultaVenda sub = new ConsultaVenda();
                    sub.Show();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
            }
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
                try
                {
                    // pega o valor do id na ccoluna selecionada
                    IdProd = Convert.ToInt32(dgvVenda.CurrentRow.Cells[0].Value);
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
                    MySqlCommand Query = new MySqlCommand("DELETE FROM produtosvendas WHERE id=" + IdProd + ";", conex);
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

        private void btIncluirProduto_Click(object sender, EventArgs e)
        {
            AlterarProdutoVenda al = new AlterarProdutoVenda();
            al.Show();

        }

        public void btnOculto_Click(object sender, EventArgs e)
        {
            ValorFrete = 0;
            ValorItens = 0;
            Desconto = 0;

            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM produtosvendas WHERE IdVenda="+ClassInfo.IdVendaGlobal+";", conex);
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

            for (int i = 0; i < dgvVenda.Rows.Count; i++)
            {

                ValorItens += Convert.ToDouble(dgvVenda.Rows[i].Cells[7].Value);
                ValorCusto += Convert.ToDouble(dgvVenda.Rows[i].Cells[7].Value);
                ValorFrete += Convert.ToDouble(dgvVenda.Rows[i].Cells[9].Value);
            }
            dgvVenda.Columns[0].Visible = false;
            dgvVenda.Columns[7].Visible = false;


            txtValorItens.Text = Convert.ToString(ValorItens);
            txtFrete.Text = Convert.ToString(ValorFrete);


            ValorLucro = ValorItens - ValorCusto;
            Desconto = Convert.ToInt32(txtDescontos.Text);
            txtValorTotal.Text = Convert.ToString((ValorFrete + ValorItens) - Desconto);

            if (ClassInfo.IdClienteGlobal != "0")
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

        private void txtDescontos_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            
            
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
            if (txtDescontos.Text != "")
            {
                Desconto = Convert.ToInt32(txtDescontos.Text);
                ValorFrete = Convert.ToInt32(txtFrete.Text);
                ValorItens = Convert.ToInt32(txtValorItens.Text);
                txtValorTotal.Text = Convert.ToString(ValorFrete + ValorItens - Desconto);
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

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 || !char.IsLetter(e.KeyChar))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtVendedor_Click(object sender, EventArgs e)
        {
            txtVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            idVendedor = (txtVendedor.SelectedIndex) + 1;
        }

        private void btAddCliente_Click(object sender, EventArgs e)
        {
            ConsultaClientesVenda cons = new ConsultaClientesVenda();
            cons.Show();
        }


    }
}
