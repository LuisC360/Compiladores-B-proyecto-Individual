using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Token
    {
        /// <summary>
        /// Es el nombre o simbolo del Token.
        /// </summary>
        string nombre;
        /// <summary>
        /// Una variable publica que da acceso a la variable cadena.
        /// </summary>
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        /// <summary>
        /// Una variable boleana que indica si el Token es Terminal o no.
        /// </summary>
        bool esTerminal;
        /// <summary>
        /// Una variable publica que da acceso a la variable esTerminal.
        /// </summary>
        public bool ESTERMINAL { get { return esTerminal; } set { esTerminal = value; } }
        /// <summary>
        /// Una lista de producciones, si es que el Token es un NoTerminal.
        /// </summary>
        List<Produccion> listaP;
        /// <summary>
        /// Una variable publica que da acceso a la lista de producciones del Token (listaP).
        /// </summary>
        public List<Produccion> LISTAP { get { return listaP; } set { listaP = value; } }

        string operando;
        public string OPERANDO { get { return operando; } set { operando = value; } }

        /// <summary>
        /// Representa el conjunto de Primero.
        /// </summary>
        Produccion primero;
        /// <summary>
        /// Una variable publica que da acceso al conjunto de Primero de este token, si es que es NoTerminal.
        /// </summary>
        public Produccion PRIMERO { get { return primero; } set { primero = value; } }
        /// <summary>
        /// Representa el conjunto de Siguiente.
        /// </summary>
        Produccion siguiente;
        /// <summary>
        /// Una variable publica que da acceso al conjunto de Siguiente de este token, si es que es NoTerminal.
        /// </summary>
        public Produccion SIGUIENTE { get { return siguiente; } set { siguiente = value; } }

        int numCol;
        public int NUMCOL { get { return numCol; } set { numCol = value; } }

        string valor;
        public string VALOR { get { return valor; } set { valor = value; } }

        List<Produccion> cuadruplos;
        public List<Produccion> CUADRUPLOS { get { return cuadruplos; } set { cuadruplos = value; } }

        int fila;
        public int FILA { get { return fila; } set { fila = value; } }


        /// <summary>
        /// Este metodo es el constructor de la clase Token. Inicializa variables.
        /// </summary>
        /// <param name="cad">Una cadena que representara el simbolo o nombre del Token.</param>
        /// <param name="Terminal">Un boleano que indica si este Token sera un simbolo registrado en la Gramatica.</param>
        public Token(string cad)
        {
            nombre = cad;
            listaP = null;
            esTerminal = true;
            operando = null;
            numCol = -1;
            cuadruplos = null;
            VALOR = cad;
            fila = -1;
        }

        public void NoTerminal()
        {
            esTerminal = false;
            primero = new Produccion();
            siguiente = new Produccion();
        }

        public void Terminal()
        {
            esTerminal = true;
            primero = null;
            siguiente = null;
        }

        public void Operando(string text)
        {
            operando = text;
        }

        public Token clonar()
        {
            Token clon = new Token(nombre);
            clon.ESTERMINAL = esTerminal;
            clon.listaP = listaP;
            clon.OPERANDO = operando;
            clon.primero = primero;
            clon.siguiente = siguiente;
            clon.NUMCOL = numCol;
            clon.VALOR = valor;
            clon.FILA = fila;
            return clon;
        }

        public void nuevoCuadruplo(Produccion cuadruplo)
        {
            if (cuadruplos == null)
                cuadruplos = new List<Produccion>();
            cuadruplos.Add(cuadruplo);
        }

        public void vaciaCuadruplos(List<Produccion> lista)
        {
            if (lista != null)
            {
                foreach (Produccion cuadruplo in lista)
                    nuevoCuadruplo(cuadruplo);
                lista.Clear();
            }
        }
    }
}
