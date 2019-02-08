using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class NT
    {

        public string valex;
        //Es el nombre del terminal o no terminal
        public string nom;
        //Esta variable representa un primero.
        public Produccion primero;
        //Representa los siguientes.
        public Produccion siguiente;
        //Es una lista de todas las producciones que son no terminales.
        public List<Produccion> listaP;
        public string oper;
        //Esta variable determina si es o no terminal.
        public bool esTerminal;
        public int nCol;

        public NT(string cad)
        {
            nom = cad;
            listaP = null;
            esTerminal = true;
            oper = null;
            nCol = -1;
            valex = null;
        }

        //Este metodo inicializa los NT.
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

        public void op(string text)
        {
            oper = text;
        }

        public NT copiar()
        {
            NT copia = new NT(nom);
            copia.esTerminal = esTerminal;
            copia.oper = oper;
            copia.nCol = nCol;
            copia.valex = valex;
            return copia;
        }
    }
}
