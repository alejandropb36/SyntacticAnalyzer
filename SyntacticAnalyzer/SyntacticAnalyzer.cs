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

        public SyntacticAnalyzer()
        {
            this.table = new int[93,43];
            loadTable();
            int i = 8;
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
    }
}
