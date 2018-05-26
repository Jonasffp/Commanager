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
    public partial class ConsultaFinancasGeral : Form
    {
        public ConsultaFinancasGeral()
        {
            InitializeComponent();
        }
        double ValorTotal, ValorLucro, ValorDespesas;
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            SubFinancas sub = new SubFinancas();
            sub.Show();
            this.Close();
        }

        private void ConsultaFinancasGeral_Load(object sender, EventArgs e)
        {
            ValorTotal = 0;
            ValorLucro = 0;
            ValorDespesas = 0;
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string dataInicial = Convert.ToDateTime(txtDataInicial.Text).ToString("yyyy/MM/dd");
            string dataFinal = Convert.ToDateTime(txtDataFinal.Text).ToString("yyyy/MM/dd");

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas WHERE DataVenda BETWEEN('" + dataInicial + "') AND('" + dataFinal + "'); ", conex);
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

            foreach (DataGridViewColumn column in dgvVendas.Columns)
            {
                if (column.DataPropertyName == "id")
                    column.Width = 15; //tamanho fixo da primeira coluna

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


            MySqlCommand Query2 = new MySqlCommand("SELECT * FROM despesas WHERE DataVencimento BETWEEN('" + dataInicial + "') AND('" + dataFinal + "'); ", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da2 = new MySqlDataAdapter(Query2);

            //cria um objeto datatable
            DataTable despesa = new DataTable();

            //preenche o datatable via dataadapter
            da2.Fill(despesa);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvDespesas.DataSource = despesa;
            foreach (DataGridViewColumn column in dgvDespesas.Columns)
            {
                if (column.DataPropertyName == "Id")
                    column.Width = 15; //tamanho fixo da primeira coluna

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            MySqlCommand Query3 = new MySqlCommand("SELECT * FROM financasfuncionarios; ", conex);
            //define o tipo do comando
            Query3.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da3 = new MySqlDataAdapter(Query3);

            //cria um objeto datatable
            DataTable funcionario = new DataTable();

            //preenche o datatable via dataadapter
            da3.Fill(funcionario);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvFuncionarios.DataSource = funcionario;
            dgvVendas.Columns[9].Visible = false;

            foreach (DataGridViewColumn column in dgvFuncionarios.Columns)
            {
                if (column.DataPropertyName == "Id")
                    column.Width = 15; //tamanho fixo da primeira coluna

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            
            for (int i = 0; i < dgvVendas.Rows.Count ; i++)
            {

                ValorTotal += Convert.ToDouble(dgvVendas.Rows[i].Cells[13].Value);
                ValorLucro += Convert.ToDouble(dgvVendas.Rows[i].Cells[14].Value);

            }
            for (int i = 0; i < dgvDespesas.Rows.Count; i++)
            {

                ValorDespesas += Convert.ToDouble(dgvDespesas.Rows[i].Cells[3].Value);


            }
            for (int i = 0; i < dgvFuncionarios.Rows.Count; i++)
            {

                ValorDespesas += Convert.ToDouble(dgvFuncionarios.Rows[i].Cells[2].Value);


            }
            dgvVendas.Columns[1].Visible = false;
            dgvVendas.Columns[2].Visible = false;
            dgvVendas.Columns[6].Visible = false;
            dgvVendas.Columns[7].Visible = false;
            dgvVendas.Columns[8].Visible = false;
            dgvVendas.Columns[9].Visible = false;

            txtValorTotal.Text = Convert.ToString(ValorTotal);
            txtLucro.Text = Convert.ToString(ValorLucro);
            txtDespesas.Text = Convert.ToString(ValorDespesas);
            btnPesquisar.PerformClick();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ValorTotal=0;
            ValorLucro=0;
            ValorDespesas=0;
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";
            string dataInicial = Convert.ToDateTime(txtDataInicial.Text).ToString("yyyy/MM/dd");
            string dataFinal = Convert.ToDateTime(txtDataFinal.Text).ToString("yyyy/MM/dd");

            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();

            MySqlCommand Query = new MySqlCommand("SELECT * FROM vendas WHERE DataVenda BETWEEN('" + dataInicial + "') AND('" + dataFinal + "'); ", conex);
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

            MySqlCommand Query2 = new MySqlCommand("SELECT * FROM despesas WHERE DataVencimento BETWEEN('" + dataInicial + "') AND('" + dataFinal + "'); ", conex);
            //define o tipo do comando
            Query2.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da2 = new MySqlDataAdapter(Query2);

            //cria um objeto datatable
            DataTable despesa = new DataTable();

            //preenche o datatable via dataadapter
            da2.Fill(despesa);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvDespesas.DataSource = despesa;

            MySqlCommand Query3 = new MySqlCommand("SELECT * FROM financasfuncionarios; ", conex);
            //define o tipo do comando
            Query3.CommandType = CommandType.Text;
            //cria um dataadapter
            MySqlDataAdapter da3 = new MySqlDataAdapter(Query3);

            //cria um objeto datatable
            DataTable funcionario = new DataTable();

            //preenche o datatable via dataadapter
            da3.Fill(funcionario);

            //atribui o datatable ao datagridview para exibir o resultado
            dgvFuncionarios.DataSource = funcionario;

            for (int i = 0; i < dgvVendas.Rows.Count ; i++)
            { 

                ValorTotal += Convert.ToDouble(dgvVendas.Rows[i].Cells[13].Value);
                ValorLucro += Convert.ToDouble(dgvVendas.Rows[i].Cells[14].Value);

            }
            for (int i = 0; i < dgvDespesas.Rows.Count ; i++)
            {

                ValorDespesas += Convert.ToDouble(dgvDespesas.Rows[i].Cells[3].Value);


            }
            for (int i = 0; i < dgvFuncionarios.Rows.Count; i++)
            {

                ValorDespesas += Convert.ToDouble(dgvFuncionarios.Rows[i].Cells[2].Value);


            }
            dgvVendas.Columns[1].Visible = false;
            dgvVendas.Columns[2].Visible = false;
            dgvVendas.Columns[6].Visible = false;
            dgvVendas.Columns[7].Visible = false;
            dgvVendas.Columns[8].Visible = false;
            dgvVendas.Columns[9].Visible = false;
           

            


            txtValorTotal.Text = Convert.ToString(ValorTotal);
            txtLucro.Text = Convert.ToString(ValorLucro);
            txtDespesas.Text = Convert.ToString(ValorDespesas);
            txtGasto.Text = Convert.ToString(ValorTotal - ValorLucro);
            txtGeral.Text = Convert.ToString(ValorTotal-ValorDespesas);
        }
    }
}
