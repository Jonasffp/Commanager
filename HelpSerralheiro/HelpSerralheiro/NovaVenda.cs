using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpSerralheiro
{
    public partial class NovaVenda : Form
    {
        public NovaVenda()
        {
            InitializeComponent();

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            String dataVenda = txtDataVenda.Text.Trim();
            String horaVenda = txtHoraVenda.Text.Trim();
            String comprador = txtComprador.Text.Trim();
            String vendedor = txtVendedor.Text.Trim();
            String dataEntrega = txtDataEntrega.Text.Trim();
            String horaEntrega = txtHoraEntrega.Text.Trim();
            String observacoes = txtObservacoes.Text.Trim();
            int valorItens = Convert.ToInt32(txtValorItens.Text.Trim());
            int desconto = Convert.ToInt32(txtDescontos.Text.Trim());
            int frete = Convert.ToInt32(txtFrete.Text.Trim());
            int valorTotal = Convert.ToInt32(txtValorTotal.Text.Trim());
        }

        private void btIncluirProduto_Click(object sender, EventArgs e)
        {
            
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
    }
}
