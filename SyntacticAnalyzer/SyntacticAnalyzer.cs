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

        }

    }
}
