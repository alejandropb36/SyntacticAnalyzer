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
        Stack<int> syntacticStack;

        public SyntacticAnalyzer()
        {
            this.table = new int[93,43];
            this.reglas = new string[48, 2];
            this.reglasId = new int[48, 2];
            syntacticStack = new Stack<int>();
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

        public int getReglaReduccion(int numero)
        {
            return (numero * -1) - 1;
        }

        public bool analyzer(LinkedList<Token> tokensList)
        {
            int columna = 0;
            int fila = 0;
            int accion = 0;
            int regla = 0;
            int reduccion = 0;
            bool result = false;
            Token[] tokens = tokensList.ToArray();

            syntacticStack.Push(0);
            for(int i = 0; i < tokens.Length; i++)
            {
                columna = (int)tokens[i].TipoToken;
                fila = syntacticStack.Peek();
                accion = table[fila, columna];

                if(accion > 0)
                {
                    syntacticStack.Push(columna);
                    syntacticStack.Push(accion);
                }
                else if (accion == 0)
                {
                    result = false;
                }
                else if (accion == -1)
                {
                    result = true;
                }
                else
                {
                    regla = getReglaReduccion(accion);
                    reduccion = reglasId[regla, 1] * 2;
                    while(reduccion > 0)
                    {
                        syntacticStack.Pop();
                        reduccion--;
                    }
                    fila = syntacticStack.Peek();
                    columna = reglasId[regla, 0];

                    syntacticStack.Push(columna);
                    syntacticStack.Push(table[fila, columna]);
                    --i;
                }
            }

            return result;
        }

    }
}
