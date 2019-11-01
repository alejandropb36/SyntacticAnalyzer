using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntacticAnalyzer
{
    public class Nodo
    {
        public string simbolo;
        public Nodo siguiente;
        public static string ambito;
        public char tipodato;


        public Nodo()
        {
            simbolo = "";
            ambito = "";
            siguiente = null;
        }

        public Nodo(string _ambito)
        {
            simbolo = "";
            ambito = _ambito;
            siguiente = null;
        }
    }
    public class programa : Nodo
    {
        public programa(Stack pila)
        {
            pila.Pop();//quita estado
            siguiente = ((NoTerminal)pila.Pop()).nodo;
        }
    }

    public class Id : Nodo
    {
        public Id(string _simbolo)
        {
            simbolo = _simbolo;
            clase = "id";
        }
    }
    
    public class Tipo : Nodo
    {
        public Tipo(string _simbolo)
        {
            simbolo = _simbolo;
        }
    }

    public class DefVar : Nodo
    {
        Nodo tipo;
        Nodo id;
        Nodo lvar;

        public DefVar(Stack pila)//<DefVar> ::= tipo id <ListaVar> ; 
        {
            pila.Pop();//quita estado
            pila.Pop(); //quita  ;
            pila.Pop(); //quita estado estado
            lvar = ((NoTerminal)pila.Pop()).nodo; //quita ListaVar
            pila.Pop(); //quita estado
            id = new Id(((Terminal)pila.Pop()).simbolo); //quita Id

            pila.Pop(); //quita estado
            tipo = new Tipo(((Terminal)pila.Pop()).simbolo); //quita tipo
        }
    }

    public class DefFunc : Nodo
    {
        Nodo tipo;
        Nodo id;
        Nodo parametros;
        Nodo bloqFunc;
        public static string varlocal;
        public DefFunc(Stack pila)//<DefFunc> ::= tipo id ( <Parametros> ) <BloqFunc> 
        {
            pila.Pop();//quita estado
            bloqFunc = ((NoTerminal)pila.Pop()).nodo;//quita <bloqfunc>
            pila.Pop();//quita estado
            pila.Pop();//quita )
            pila.Pop();//quita estado
            parametros = ((NoTerminal)pila.Pop()).nodo;//quita <parametros>
            pila.Pop();//quita estado
            pila.Pop();//quita (
            pila.Pop();//quita estado
            id = new Id(((Terminal)pila.Pop()).simbolo);//quita id
            pila.Pop();//quita estado
            tipo = new Tipo(((Terminal)pila.Pop()).simbolo);//quita el tipo
        }
    }

    public class Parametros : Nodo  //<Parametros> ::= tipo id <ListaParam> 
    {
        Nodo tipo;
        Nodo id;
        public Nodo lparametros;
        public Parametros(Stack pila)
        {
            pila.Pop();//quita estado

            lparametros = ((NoTerminal)pila.Pop()).nodo;//quita la lista de aprametros
            pila.Pop();//quita estado
            id = new Id(((Terminal)pila.Pop()).simbolo);//quita el id
            pila.Pop(); //quita estado
            tipo = new Tipo(((Terminal)pila.Pop()).simbolo);//quita el tipo

        }
    }

    public class Asignacion : Nodo//<Sentencia> ::= id = <Expresion> ; 
    {
        Nodo id;
        Nodo expresion;

        public Asignacion(Stack pila)//<Sentencia> ::= id = <Expresion> ;
        {
            pila.Pop();
            pila.Pop();//quita la ;
            pila.Pop();
            expresion = ((NoTerminal)pila.Pop()).nodo;//quita expresion
            pila.Pop();
            pila.Pop();//quita =
            pila.Pop();
            id = new Id(((Terminal)pila.Pop()).simbolo);//quita id
        }
    }
    public class While : Nodo //<Sentencia> ::= while ( <Expresion> ) <Bloque> 
    {
        Nodo expresion;
        Nodo bloque;

        public While(Stack pila)
        {
            pila.Pop();
            bloque = ((NoTerminal)pila.Pop()).nodo;//quita bloque
            pila.Pop();
            pila.Pop(); //quita )
            pila.Pop();
            expresion = ((NoTerminal)pila.Pop()).nodo;//quita expresion
            pila.Pop();
            pila.Pop(); //quita (
            pila.Pop();
            pila.Pop(); //quita while
        }
    }

    // <Sentencia> ::= do <Bloque> while ( <Expresion> ) ;
    public class Dowhile : Nodo
    {
        Nodo bloque;
        Nodo expresion;

        public Dowhile(Stack pila)
        {
            pila.Pop();
            pila.Pop();//quita ;
            pila.Pop();
            pila.Pop();//quita )
            pila.Pop();
            expresion = ((NoTerminal)pila.Pop()).nodo;//quita exprecion
            pila.Pop();
            pila.Pop();//quita (
            pila.Pop();
            pila.Pop();//quita el while
            pila.Pop();
            bloque = ((NoTerminal)pila.Pop()).nodo;//quita bloque
            pila.Pop();
            pila.Pop();//quita do
        }
    }

    public class For : Nodo //<Sentencia> ::= for id = <Expresion> : <Expresion> : <Expresion> <SentenciaBloque>
    {
        Nodo senbloque;
        Nodo expresion1;
        Nodo expresion2;
        Nodo expresion3;
        Nodo id;

        public For(Stack pila)
        {
            pila.Pop();
            senbloque = ((NoTerminal)pila.Pop()).nodo;//quita senteciabloque
            pila.Pop();
            expresion3 = ((NoTerminal)pila.Pop()).nodo;//quita expresion
            pila.Pop();
            pila.Pop();//quita ;
            pila.Pop();
            expresion2 = ((NoTerminal)pila.Pop()).nodo;//quita expresion
            pila.Pop();
            expresion1 = ((NoTerminal)pila.Pop()).nodo;//quita expresion
            pila.Pop();
            pila.Pop();//quita =
            pila.Pop();
            id = new Id(((Terminal)pila.Pop()).simbolo);//quita id
            pila.Pop();
            pila.Pop();//quita for
        }
    }

    public class Constante : Nodo
    {
        public Constante(string _simbolo)
        {
            simbolo = _simbolo;
            clase = "cons";
        }
    }

    public class Llamadafunc : Nodo//<LlamadaFunc> ::= id ( <Argumentos> )
    {
        Nodo id;
        Nodo argumentos;

        public Llamadafunc(Stack pila)
        {
            clase = "fun";
            pila.Pop();
            pila.Pop();//quita )
            pila.Pop();
            argumentos = ((NoTerminal)pila.Pop()).nodo;//quita exprecion
            pila.Pop();
            pila.Pop();//quita (
            pila.Pop();
            id = new Id(((Terminal)pila.Pop()).simbolo);//quita id
        }
    }

    public class Operacion1 : Nodo//<Expresion> ::= opSuma <Expresion> 
    {
        Nodo der;

        public Operacion1(Stack pila)
        {
            pila.Pop();
            der = ((NoTerminal)pila.Pop()).nodo;//quita exprsion
            pila.Pop();
            simbolo = ((Terminal)pila.Pop()).simbolo;//quita el operador
        }
    }

    public class Operacion2 : Nodo
    {
        Nodo der;
        Nodo izq;
        public Operacion2(Stack pila)
        {
            pila.Pop();
            der = ((NoTerminal)pila.Pop()).nodo;//quita exprsion
            pila.Pop();
            simbolo = ((Terminal)pila.Pop()).simbolo;//quita el operador
            pila.Pop();
            izq = ((NoTerminal)pila.Pop()).nodo;//quita expresion
        }
    }

    public class Constructores
    {

        public Constructores()
        {

        }
    }
}
