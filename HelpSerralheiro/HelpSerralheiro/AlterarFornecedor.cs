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
    public partial class AlterarFornecedor : Form
    {
        public AlterarFornecedor()
        {
            InitializeComponent();
        }
        private void AlterarFornecedor_Load(object sender, EventArgs e)
        {
            string Config = "server=127.0.0.1;userid=root;database=bd_commanager";


            MySqlConnection conex = new MySqlConnection(Config);
            conex.Open();
            MySqlCommand Query = new MySqlCommand("SELECT * FROM fornecedor WHERE id = '" + ClassInfo.IdFornecedorGlobal + "';", conex);

            try

            {
                MySqlDataReader leitor = Query.ExecuteReader();

                leitor.Read(); //lê a primeira row da pesquisa
                txtNomeFornecedor.Text = leitor["NomeCompleto"].ToString();
                cbSegmentoFornecedor.Text = leitor["Segmento"].ToString();
                txtApelido.Text = leitor["NomeFantasia"].ToString();
                txtNomeRuaFornecedor.Text = leitor["Rua"].ToString();
                txtnumeroRua.Text = leitor["NumeroRua"].ToString();
                txtBairroFornecedor.Text = leitor["Bairro"].ToString();
                txtCidadeFornecedor.Text = leitor["Cidade"].ToString();
                txtufFornecedor.Text = leitor["UF"].ToString();
                txtCEPFornecedor.Text = leitor["CEP"].ToString();
                txtTelefoneFornecedor.Text = leitor["Telefone"].ToString();
                txtTelefone2Fornecedor.Text = leitor["Telefone2"].ToString();
                txtCelularFornecedor.Text = leitor["Celular"].ToString();
                txtCelular2Fornecedor.Text = leitor["Celular2"].ToString();
                txtComplementoFornecedor.Text = leitor["Complemento"].ToString();
                txtEmailFornecedor.Text = leitor["Email"].ToString();
                txtNomeRepresentanteFornecedor.Text = leitor["NomeRepresentante"].ToString();
                txtCNPJFornecedor.Text = leitor["CNPJ"].ToString();
                txtNumIEFornecedor.Text = leitor["IE"].ToString();
                txtOBSFornecedor.Text = leitor["Observacoes"].ToString();
                txtEmailRepresentante.Text = leitor["EmailRepresentante"].ToString();
                DataCadastro.Text = leitor["DataCadastro"].ToString();

                

            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            finally { conex.Close(); }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ConsultaFornecedor cons = new ConsultaFornecedor();
            cons.Show();
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

                String nomeFornecedor = txtNomeFornecedor.Text;
                String seguimentoFornecedor = cbSegmentoFornecedor.Text;
                String apelidoFornecedor = txtApelido.Text;
                String nomeruaFornecedor = txtNomeRuaFornecedor.Text;
                String numeroRua = txtnumeroRua.Text;
                String bairroFornecedor = txtBairroFornecedor.Text;
                String cidadeFornecedor = txtCidadeFornecedor.Text;
                String ufFornecedor = txtufFornecedor.Text;
                String cepFornecedor = txtCEPFornecedor.Text;
                String telefoneFornecedor = txtTelefoneFornecedor.Text;
                String telefone2Fornecedor = txtTelefone2Fornecedor.Text;
                String celularFornecedor = txtCelularFornecedor.Text;
                String celular2Fornecedor = txtCelular2Fornecedor.Text;
                String complementoFornecedor = txtComplementoFornecedor.Text;
                String emailFornecedor = txtEmailFornecedor.Text;
                String nomerepresentanteFornecedor = txtNomeRepresentanteFornecedor.Text;
                String cnpjFornecedor = txtCNPJFornecedor.Text;
                String numieFornecedor = txtNumIEFornecedor.Text;
                String obsFornecedor = txtOBSFornecedor.Text;
                String emailrepresentanteFornecedor = txtEmailRepresentante.Text;
                String dataCadastro = DataCadastro.Text;

                if (txtNomeFornecedor.TextLength < 1 || txtApelido.TextLength < 1 || txtEmailFornecedor.TextLength < 1 || txtNomeRepresentanteFornecedor.TextLength < 1 || txtEmailRepresentante.TextLength < 1)
                {
                    MessageBox.Show("Por favor, preencha adequadamente os campos referentes ao Nome Completo, Nome Fantasia, Email, Nome Representante e Emai Representante !");
                }
                else
                {

                string Config = "server=127.0.0.1;userid=root;database=bd_commanager";

                MySqlConnection conex = new MySqlConnection(Config);
                conex.Open();
                MySqlCommand Query = new MySqlCommand("UPDATE fornecedor SET NomeCompleto='" + nomeFornecedor + "', NomeFantasia='" + apelidoFornecedor + "', DataCadastro='" + dataCadastro + "', CNPJ='" + cnpjFornecedor + "', IE='" + numieFornecedor + "', Segmento='" + seguimentoFornecedor + "', Email='" + emailFornecedor + "', Rua='" + nomeruaFornecedor + "', NumeroRua='" + numeroRua + "', Bairro='" + bairroFornecedor + "', Cidade='" + cidadeFornecedor + "', UF='" + ufFornecedor + "', CEP='" + cepFornecedor + "', Telefone='" + telefoneFornecedor + "', Telefone2='" + telefone2Fornecedor + "', Celular='" + celularFornecedor + "', Celular2='" + celular2Fornecedor + "', Complemento='" + complementoFornecedor + "', NomeRepresentante='" + nomerepresentanteFornecedor + "', EmailRepresentante='" + emailrepresentanteFornecedor + "', Observacoes='" + obsFornecedor + "' WHERE Id =" + ClassInfo.IdFornecedorGlobal + ";", conex);
                Query.ExecuteNonQuery();
                Query.Connection = conex;
                if (conex.State == ConnectionState.Open)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    ConsultaFornecedor cons = new ConsultaFornecedor();
                    cons.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar!");
                }
                conex.Close();
                }
            }

        }
    }

