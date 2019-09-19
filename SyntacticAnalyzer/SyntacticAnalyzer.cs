using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SyntacticAnalyzer
{
    class SyntacticAnalyzer
    {
        int[,] table;
        string[,] reglas;
        int[,] reglasId; 

        public SyntacticAnalyzer()
        {
            this.table = new int[93,43];
            this.reglas = new string[48, 2];
            this.reglasId = new int[48, 2];
            loadTable();
            loadReglas();
            loadReglasId();
        }

        private void loadTable()
        {
            string pattern = " ";
            string[] elementsLine;
            string[] lines = System.IO.File.ReadAllLines("GR1slrTable.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                elementsLine = Regex.Split(lines[i], pattern);
                for(int j = 0; j < elementsLine.Length; j++)
                {
                    table[i,j] = int.Parse(elementsLine[j]);
                }
            }
        }

        private void loadReglas()
        {
            string pattern = " ";
            string[] elementsLine;
            string[] lines = System.IO.File.ReadAllLines("GR1slrReglas.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                elementsLine = Regex.Split(lines[i], pattern);
                for (int j = 0; j < 2; j++)
                {
                    reglas[i, j] = elementsLine[j];
                }
            }
        }

        private void loadReglasId()
        {
            string pattern = " ";
            string[] elementsLine;
            string[] lines = System.IO.File.ReadAllLines("GR1slrReglasId.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                elementsLine = Regex.Split(lines[i], pattern);
                for (int j = 0; j < elementsLine.Length; j++)
                {
                    reglasId[i, j] = int.Parse(elementsLine[j]);
                }
            }
        }

        public int reglaReduccion(int numero)
        {
            numero = (numero * -1) - 1;
            return numero;
        }

        public void analyzer(LinkedList<Token> tokens)
        {
            Stack<string> sintacticStack = new Stack<string>();
            int columna = 0;
            int fila = 0;
            int aux = 0;
            int regla = 0;

            sintacticStack.Push("0");
            foreach(Token token in tokens)
            {
                columna = int.Parse(sintacticStack.Peek());
                fila = (int)token.TipoToken;
                aux = table[fila, columna];

                if(aux < 0)
                {
                    regla = reglaReduccion(aux);
                    // Aqui va el caso en el que se tiene que eliminar

                }
                else
                {
                    sintacticStack.Push(token.GetTipoToken());
                    sintacticStack.Push(aux.ToString());
                }
            }
        }

    }
}
