using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Separa
    {
        //Esto representa la parte izquierda de la produccion.
        public NT ladoIzq;
        //Se crea una lista que representa las producciones del lado derecho.
        public List<Produccion> derecha;
        public Produccion tksbusqueda;

        public Separa()
        {
            ladoIzq = null;
            derecha = new List<Produccion>();
        }

        //Este metodo es el encargado de crear las nuevas producciones, recibe una cadena que es de
        //donde se extraeran los tokens al igual que una lista de tokens, regresa la nueva produccion
        //si es que se pudo crear.
        private Produccion nuevaprod(string cadena, CTK listokens)
        {
            Produccion prodaux = new Produccion();
            if (prodaux.crealistok(cadena, listokens) == true)
                return prodaux;
            else
                return null;
        }

        //Este metodo crea la parte izquierda de la produccion, recibe una cadena de la cual se
        //extraeran los tokens y una lista de tokens.
        public bool partiz(string texto, CTK listokens)
        {
            ladoIzq = listokens.buscar(texto);
            if (ladoIzq == null)
            {
                ladoIzq = new NT(texto);
                listokens.agregaToken(ladoIzq);
            }
            ladoIzq.NoTerminal();
            return true;
        }

        //Este metodo crea la parte derecha de la produccion, recibe una cadena de la cual se
        //extraeran los tokens y una lista de tokens.
        public bool parder(string entrada, CTK tkns, ref int numero)
        {
            string cadena = entrada;
            if (cadena == "")
                return false;
            cadena = cadena.Replace("\\|", "::");
            string[] datos = cadena.Split('|');
            Produccion produccion;
            string text;

            foreach (string cad in datos)
            {
                if (cad != "")
                {
                    Char[] c = new char[1] { ' ' };
                    text = "";
             //       text = cad.Replace(" ", "");
                    foreach(var it in cad.Split(c,StringSplitOptions.RemoveEmptyEntries))
                    {
                        if(it != " ")
                        {
                            text += "<" + it + ">";
                        }
                    }

                    produccion = nuevaprod(text, tkns);
                    if ((produccion == null) || (produccion.epsnovalido() == true))
                        return false;
                    else if (existpro(produccion) == false)
                    {
                        produccion.numero = numero;
                        numero++;
                        derecha.Add(produccion);
                    }
                }
            }
            return true;
        }

        //Este metodo nos sirve para identificar si una produccion ya existia en la lista de producciones
        //del lado derecho.
        public bool existpro(Produccion nueva)
        {
            int x;
            bool resp = true;
            foreach (Produccion prod in derecha)
            {
                if (nueva.ltok.Count == prod.ltok.Count)
                {
                    x = 0;
                    resp = true;
                    foreach (NT token in prod.ltok)
                    {
                        if (token.nom != nueva.ltok[x].nom)
                        {
                            resp = false;
                            break;
                        }
                        x++;
                    }
                    if (resp == true)
                        return true;
                }
            }
            return false;
        }

        //Este metodo es el encargado de mostrar las producciones en el treeview.
        public string muestraprod()
        {
            string cadenaIzq;
            string cadenaDer;
            string cadBusqueda;
            cadenaIzq = "";
            cadenaIzq += ladoIzq.nom;
            cadenaDer = "";
            foreach (Produccion prod in derecha)
            {
                cadenaDer += " ";
                foreach (NT token in prod.ltok)
                {
                    if (token.nom.Length == 1)
                        cadenaDer += token.nom;
                    else
                        cadenaDer +=  token.nom;
                }
                cadenaDer += " ";
            }
            cadBusqueda = "";
            for (int x = 0; x < tksbusqueda.ltok.Count; x++)
            {
                cadBusqueda += tksbusqueda.ltok[x].nom;
                if (x + 1 < tksbusqueda.ltok.Count)
                    cadBusqueda += ", ";
            }
            return cadenaIzq + " -> " + cadenaDer + "( " + cadBusqueda + " )";
        }
        
        //Este metodo se encarga de duplicar una produccion.
        public Separa coprod()
        {
            Separa nr = new Separa();
            Produccion np;

            NT izq = new NT(ladoIzq.nom);
            izq.NoTerminal();
            izq.primero = ladoIzq.primero;
            izq.siguiente = ladoIzq.siguiente;

            foreach (Produccion paux in derecha)
            {
                np = paux.duprod();
                nr.derecha.Add(np);
            }

            izq.listaP = nr.derecha;
            nr.ladoIzq = izq;
            nr.tksbusqueda = new Produccion();
            if (tksbusqueda != null)
                nr.tksbusqueda.agregafintk(tksbusqueda.ltok);

            return nr;
        }

        //Este metodo es el encargado de mostrar las reglas en la produccion de entrada.
        public string mostrarr()
        {
            string cadiz;
            string cader;
            cadiz = "";
            cadiz += ladoIzq.nom;
            cader = "";
            foreach (Produccion prod in derecha)
            {
                foreach (NT token in prod.ltok)
                {
                    if (token.nom.Length == 1)
                        cader += token.nom;
                    else
                        cader += token.nom ;
                }
            }
            return cadiz + "->" + cader;
        }
    }
}
