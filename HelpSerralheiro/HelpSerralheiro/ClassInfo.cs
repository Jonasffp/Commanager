using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpSerralheiro
{
    class ClassInfo
    {
        private static string usuarioentrou;

public static string Usuarioentrou
{
  get { return ClassInfo.usuarioentrou; }
  set { ClassInfo.usuarioentrou = value; }
}

private static string tipousuario;

public static string Tipousuario
{
    get { return ClassInfo.tipousuario; }
    set { ClassInfo.tipousuario = value; }
}

private static string idClienteGlobal;

public static string IdClienteGlobal
{
    get { return ClassInfo.idClienteGlobal; }
    set { ClassInfo.idClienteGlobal = value; }
}
private static string tipoUsuario;
    
public static string TipoUsuario
{
  get { return ClassInfo.tipoUsuario; }
  set { ClassInfo.tipoUsuario = value; }
}
private static int idProdutoGlobal;

public static int IdProdutoGlobal
{
    get { return ClassInfo.idProdutoGlobal; }
    set { ClassInfo.idProdutoGlobal = value; }
}
        private static int idFornecedorGlobal;

        public static int IdFornecedorGlobal
        {
            get { return ClassInfo.idFornecedorGlobal; }
            set { ClassInfo.idFornecedorGlobal = value; }
        }
        private static int idVendaGlobal;

        public static int IdVendaGlobal
        {
            get { return ClassInfo.idVendaGlobal; }
            set { ClassInfo.idVendaGlobal = value; }
        }
        private static int idDespesaGlobal;

        public static int IdDespesaGlobal
        {
            get { return ClassInfo.idDespesaGlobal; }
            set { ClassInfo.idDespesaGlobal = value; }
        }
        private static int idAgendaGlobal;

        public static int IdAgendaGlobal
        {
            get { return ClassInfo.idAgendaGlobal; }
            set { ClassInfo.idAgendaGlobal = value; }
        }
        private static int idFuncionarioGlobal;

        public static int IdFuncionarioGlobal
        {
            get { return ClassInfo.idFuncionarioGlobal; }
            set { ClassInfo.idFuncionarioGlobal = value; }
        }

        private static int idUsuarioGlobal;

        public static int IdUsuarioGlobal
        {
            get { return ClassInfo.idUsuarioGlobal; }
            set { ClassInfo.idUsuarioGlobal = value; }
        }



        public decimal AjustarNumero(string numero)
        {
            string novoNumero = "";
            char[] arr = numero.ToCharArray();
            foreach (char item in arr)
            {
                //verifico se existe alguma virgula no "numero" digitado
                if (item.ToString() != ",")
                {
                    //cada vez que o item for diferente de virgula
                    //adiciona seu valor ao do novoNumero
                    novoNumero += item.ToString();
                }
                else if (item.ToString() == ",")
                {
                    //caso o item seja uma virgula ele o substitui 
                    //altomaticamente a virgula por ponto
                    //subistituo a virgula por ponto
                    novoNumero += ".";
                }
            }
            //crio uma variavel de retorno decimal e especifico
            //quantas casas iram aparecer depois da virgula e 
            //retorno seu valor
            decimal retorno = Decimal.Round(Convert.ToDecimal(novoNumero), 2);
            return retorno;
        }

    }
}

