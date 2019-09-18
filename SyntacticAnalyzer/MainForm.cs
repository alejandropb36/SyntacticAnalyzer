using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SyntacticAnalyzer
{
    public partial class MainForm : Form
    {
        AnalizadorLexico analizador;
        LinkedList<Token> tokens;
        SyntacticAnalyzer syntacticAnalyzer;

        public MainForm()
        {
            syntacticAnalyzer = new SyntacticAnalyzer();
            analizador = new AnalizadorLexico();
            InitializeComponent();
        }

        private void buttonSplitWords_Click(object sender, EventArgs e)
        {
            string[] words;
            string textContent1;
            string pattern = @"\s+";

            textBoxContent2.Clear();
            dataGridViewWords.Rows.Clear();
            if (textBoxContent1.Text != "")
            {
                textContent1 = textBoxContent1.Text;
                tokens = analizador.analizar(textContent1);
                textBoxContent2.Text = textContent1;
                printTokens(tokens);
            }
        }

        private void printTokens(LinkedList<Token> tokens)
        {
            foreach (Token token in tokens)
            {
                dataGridViewWords.Rows.Add(token.Valor, token.GetTipoToken(), token.TipoToken.GetHashCode().ToString());
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxContent1.Clear();
            textBoxContent2.Clear();
            dataGridViewWords.Rows.Clear();
        }
    }
}
