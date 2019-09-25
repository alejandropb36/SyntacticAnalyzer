using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SyntacticAnalyzer
{
    class AnalizadorLexico
    {
        private List<Token> tokens;
        private int estado;
        private String auxiliarLexico;

        public List<Token> analizar(string entrada)
        {
            entrada = entrada + "$";
            tokens = new List<Token>();
            estado = 0;
            auxiliarLexico = "";
            Char caracter;


            for (int i = 0; i < entrada.Length; i++)
            {
                caracter = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (char.IsDigit(caracter))
                        {
                            estado = 1;
                            auxiliarLexico += caracter;
                        }
                        else if (caracter == '"')
                        {
                            estado = 11;
                            auxiliarLexico += caracter;
                        }
                        else if (caracter == '_')
                        {
                            estado = 8;
                            auxiliarLexico += caracter;
                        }
                        else if (char.IsLetter(caracter))
                        {
                            estado = 10;
                            auxiliarLexico += caracter;
                        }
                        else if (caracter == '<')
                        {
                            auxiliarLexico += caracter;
                            estado = 4;
                        }
                        else if (caracter == '>')
                        {
                            auxiliarLexico += caracter;
                            estado = 4;
                        }
                        else if (caracter == '!')
                        {
                            auxiliarLexico += caracter;
                            estado = 12;
                        }
                        else if (caracter == '=')
                        {
                            auxiliarLexico += caracter;
                            estado = 5;
                        }
                        else if (caracter == '&')
                        {
                            auxiliarLexico += caracter;
                            estado = 6;
                        }
                        else if (caracter == '|')
                        {
                            auxiliarLexico += caracter;
                            estado = 7;
                        }
                        else if (caracter == ';')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.PuntoComa);
                        }
                        else if (char.IsWhiteSpace(caracter))
                        {
                            estado = 0;
                            auxiliarLexico = "";
                        }
                        else if (caracter == ',')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Coma);
                        }
                        else if (caracter == '(')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.ParentesisIzquierdo);
                        }
                        else if (caracter == ')')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.ParentesisDerecho);
                        }
                        else if (caracter == '{')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveIzquierda);
                        }
                        else if (caracter == '}')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveDerecha);
                        }
                        else if (caracter == '*')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorMultiplicador);
                        }
                        else if (caracter == '/')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorMultiplicador);
                        }
                        else if (caracter == '+')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorSuma);
                        }
                        else if (caracter == '-')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorSuma);
                        }
                        else
                        {
                            if (caracter == '$' && i == entrada.Length - 1)
                            {
                                auxiliarLexico = "$";
                                agregarToken(Token.Tipo.Pesos);
                            }
                            else
                            {
                                auxiliarLexico += caracter;
                                agregarToken(Token.Tipo.Error);
                                Console.WriteLine("Error");
                            }
                        }
                        break;
                    case 1:
                        if (char.IsDigit(caracter))
                        {
                            estado = 1;
                            auxiliarLexico += caracter;
                        }
                        else if (caracter == '.')
                        {
                            estado = 2;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Constante);
                            i -= 1;
                        }
                        break;
                    case 2://Numero Entero o Falla
                        if (Char.IsDigit(caracter))
                        {
                            estado = 3;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            Console.WriteLine("Error lexico");
                            estado = 0;
                        }
                        break;
                    case 3://Numero Foltante
                        if (Char.IsDigit(caracter))
                        {
                            estado = 3;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Constante);
                            i -= 1;
                        }
                        break;
                    case 4://Operador Relacional
                        if (caracter == '=')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorRel);
                        }
                        else
                        {
                            agregarToken(Token.Tipo.OperadorRel);
                            i -= 1;
                        }
                        break;
                    case 5://Operador Igualdad o Igual
                        if (caracter == '=')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorIgualdad);
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Igual);
                            i -= 1;
                        }
                        break;
                    case 6://Operador And
                        if (caracter == '&')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorAnd);
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Error);
                            estado = 0;
                        }
                        break;
                    case 7://Operador Or
                        if (caracter == '|')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorOr);
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Error);
                            estado = 0;
                        }
                        break;
                    case 8://Variables Iniciando con "_"
                        if (char.IsLetter(caracter))
                        {
                            estado = 9;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Error);
                            estado = 0;
                        }
                        break;
                    case 9:
                        if (char.IsLetter(caracter))
                        {
                            estado = 9;
                            auxiliarLexico += caracter;
                        }
                        else if (char.IsDigit(caracter))
                        {
                            estado = 9;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Identificador);
                            i -= 1;
                        }
                        break;
                    case 10:
                        if (char.IsLetter(caracter))
                        {
                            estado = 10;
                            auxiliarLexico += caracter;
                        }
                        else if (char.IsDigit(caracter))
                        {
                            estado = 10;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            if (auxiliarLexico == "if")
                            {
                                agregarToken(Token.Tipo.If);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "else")
                            {
                                agregarToken(Token.Tipo.Else);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "return")
                            {
                                agregarToken(Token.Tipo.Return);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "while")
                            {
                                agregarToken(Token.Tipo.While);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "int")
                            {
                                agregarToken(Token.Tipo.Tipo);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "float")
                            {
                                agregarToken(Token.Tipo.Tipo);
                                i -= 1;
                            }
                            else if (auxiliarLexico == "char")
                            {
                                agregarToken(Token.Tipo.Tipo);
                                i -= 1;
                            }
                            else
                            {
                                agregarToken(Token.Tipo.Identificador);
                                i -= 1;
                            }
                        }
                        break;
                    case 11:
                        if (caracter != '"')
                        {
                            estado = 11;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Constante);
                        }
                        break;
                    case 12:
                        if (caracter == '=')
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorRel);
                        }
                        else
                        {
                            //auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorNot);
                            i -= 1;
                        }
                        break;
                }



            }
            return tokens;
        }

        public void agregarToken(Token.Tipo tipo)
        {
            tokens.Add(new Token(tipo, auxiliarLexico));
            auxiliarLexico = "";
            estado = 0;
        }

    }
}
