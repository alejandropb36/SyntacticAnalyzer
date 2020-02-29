using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalyzer
{
    public class Nodo
    {
        public string Ambito { set; get; }
        public string Etiqueta { set; get; }
        public int Token { set; get; }
        public string Tipo { set; get; }
        public Nodo Siguiente { set; get; }
        public int Estado { set; get; }
    }


}