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
        { get => usuarioentrou; set => usuarioentrou = value; }


        private static string tipousuario;

        public static string Tipousuario
        { get => tipousuario; set => tipousuario = value; }
    }
}

