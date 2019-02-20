using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Compiladores
{
    class CTK
    {
        // Una lista de Tokens.
        public List<NT> lista;

        public CTK()
        {
            lista = new List<NT>();
        }

        //Busca en la lista actual todos aquellos token que sean no terminales y los regresa en una lista.
        public List<NT> noterm()
        {
            List<NT> listado = new List<NT>();

            for(int x=0; x<lista.Count; x++)
            {
                if (lista[x].esTerminal != true)
                {
                    listado.Add(lista[x]);
                }
            }
            return listado;
        }

        // Este metodo se encarga de agregar tokens a la lista, mientras este no exsita previamente.
        // Recibe como parametro el token a agregar y regresa si pudo agregarlo o no.
        public bool agregaToken(NT tkn)
        {
            for (int x = 0; x < lista.Count; x++)
             if (lista[x].nom == tkn.nom)
             {
                    return false;
             }
            lista.Add(tkn);
            return true;
        }

        // Este metodo busca los terminales en la lista existente y regresa todos los que encontro
        // en otra lista.
        public List<NT> buscaterminales()
        {
            List<NT> terminales = new List<NT>();
            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].esTerminal == true)
                    terminales.Add(lista[x]);
            }
            return terminales;
        }

        // Este metodo elimina un token determinado y regresa una bandera si lo pudo eliminar o no.
        public bool eliminartk(string nombre)
        {
            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].nom == nombre)
                {
                    lista.Remove(lista[x]);
                    return true;
                }
            }
            return false;
        }

        // Limpiar la lista con tokens actual.
        public void Clear()
        {
            lista.Clear();
        }

        // Busca un token especifico dentro de la lista y lo regresa cuando lo encuentra.
        public NT buscar(string nombre)
        {
            string valorlexico = "";

            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].nom == nombre)
                {
                    switch (nombre)
                    {
                        case "/":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "*":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "^":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "float":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "boton":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "label":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "textBox":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "vent":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "string":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "int":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "-":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "+":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "<":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case ">":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                        case "==":
                            valorlexico = nombre;
                            lista[x].valex = valorlexico;
                            break;
                    }
                    return lista[x];
                }
            }
            return null;
        }

        public NT buscar2(string nombre)
        {
            string pattern = @"[a-z\\s]"; //id
            Regex rgx = new Regex(pattern);
            string valorlexico = "";

            if (rgx.IsMatch(nombre))
            {
                valorlexico = nombre;
                nombre = "id";
            }
            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].nom == nombre)
                {
                    lista[x].valex = valorlexico;
                    return lista[x];
                }
            }
            return null;
        }

        public NT buscar3(string nombre)
        {
            string pattern = @"^[+-]?\d+$"; //int
            Regex rgx = new Regex(pattern);
            string valorlexico = "";

            if (rgx.IsMatch(nombre))
            {
                valorlexico = nombre;
                nombre = "num";
            }

            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].nom == nombre)
                {
                    lista[x].valex = valorlexico;
                    return lista[x];
                }
            }
            return null;
        }

        public NT buscar4(string nombre)
        {
            string pattern = @"([+-]?[0-9]*\.[0-9]*)"; //float
            Regex rgx = new Regex(pattern);
            string valorlexico = "";

            if (rgx.IsMatch(nombre))
            {
                valorlexico = nombre;
                nombre = "flotante";
            }

            for (int x = 0; x < lista.Count; x++)
            {
                if (lista[x].nom == nombre)
                {
                    lista[x].valex = valorlexico;
                    return lista[x];
                }
            }
            return null;
        }

        public NT buscar5(string nombre)
        {
            if (nombre[0] == '"' && nombre[nombre.Length-1] == '"')
            {
                string pattern = @"[a-z\\s]"; //cadena
                Regex rgx = new Regex(pattern);
                string valorlexico = "";

                if (rgx.IsMatch(nombre))
                {
                    valorlexico = nombre;
                    nombre = "cadena";
                }
                for (int x = 0; x < lista.Count; x++)
                {
                    if (lista[x].nom == nombre)
                    {
                        lista[x].valex = valorlexico;
                        return lista[x];
                    }
                }
            }
            return null;
        }
    }
}
