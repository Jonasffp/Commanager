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


    }
}

