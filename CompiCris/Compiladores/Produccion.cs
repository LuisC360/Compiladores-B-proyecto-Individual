using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Produccion
    {
        public List<NT> ltok;
        public int numero;

        public Produccion()
        {
            ltok = new List<NT>();
        }

        //Metodo para crear nuevos tokens.
        public void nuevotok(string stcrear, CTK ctks)
        {
            NT nuevo = ctks.buscar(stcrear);
            if (nuevo != null)
                ltok.Add(nuevo);
            else
            {
                nuevo = new NT(stcrear);
                ctks.agregaToken(nuevo);
                ltok.Add(nuevo);
            }
        }

        //Metodo para crear una cadena de tokens.
        public bool creaCadena(string cadenaEntrada, CTK cajaTokens)
        {
            foreach (var aux in cadenaEntrada.Replace("\t","").Split(' '))
            {
                if (aux != "" && aux != " ")
                {
                    if ((existes(aux.ToString(), cajaTokens) == false) && (aux != "\0"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Metodo para verificar si un simbolo existe
        public bool existes(string cad, CTK centrada)
        {
            NT n;
            NT org = centrada.buscar(cad);
            if(org == null)
            {
                org = centrada.buscar3(cad);
            }
            if (org == null)
            {
                org = centrada.buscar4(cad);
            }
            if (org == null)
            {
                org = centrada.buscar5(cad);
            }
            if (org == null)
            {
                org = centrada.buscar2(cad);
            }
            if (org != null)
            {
                n = org.copiar();
                ltok.Add(n);
                return true;
            }
            else
                return false;
        }

        // Este metodo busca un Token especifico en una lista de Tokens.
        public NT buscatk(string nomcad, List<NT> lext)
        {
            return lext.Find((Predicate<NT>)delegate (NT tok)
            {
                return tok.nom == nomcad;
            });
        }

        //Metodo para crear lista de tokens
        public bool crealistok(string centr, CTK contoks)
        {
            int tipo = 0;
            int tipoant = 0;
            string cad = "";
            string cad2 = centr;

            cad2 = cad2.Replace("\\>", "|>|");
            cad2 = cad2.Replace("\\<", "|<|");
            cad2 = cad2.Replace("\\~", "|~|");
            cad2 = cad2.Replace("\\e", "|℮|");
            cad2 = cad2.Replace("\\0", "\0");
            cad2 = cad2.Replace("::", "|||");
            cad2 = cad2.Replace("~", "ε");

            foreach (char c in cad2)
            {
                switch (tipo)
                {
                    case 0:
                        if (c == '<')
                        {
                            tipo = 1;
                            break;
                        }
                        if (c == '|')
                        {
                            tipoant = 0;
                            tipo = 2;
                            break;
                        }
                        nuevotok(c.ToString(), contoks);
                        if (c == 'ε')
                        {
                            if (cad2.Length == 1) return true;
                            else return false;
                        }
                        break;
                    case 1:
                        if (c == '>')
                        {
                            nuevotok(cad, contoks);
                            tipo = 0;
                            cad = "";
                            break;
                        }
                        else
                        {
                            if (c == '|')
                            {
                                tipoant = 1;
                                tipo = 2;
                                break;
                            }
                            else
                                cad = cad + c.ToString();
                        }
                        break;
                    case 2:
                        cad = cad + c.ToString();
                        tipo = 3;
                        break;
                    case 3:
                        tipo = tipoant;
                        if (tipo == 0)
                        {
                            nuevotok(cad, contoks);
                            cad = "";
                        }
                        break;
                }
            }
            return tipo == 0;
        }

        //Este metodo agrega un Token al inicio de la lista de la Produccion.
        public void agregarprim(NT tk)
        {
            ltok.Insert(0, tk);
        }

        //Este metodo agrega un Token al final de la lista de la Produccion.
        public void agregarult(NT tk)
        {
            ltok.Add(tk);
        }

        /// Este metodo elimina el primer Token en la lista de la Produccion.
        public NT eliminaprim()
        {
            NT tk = null;
            if (ltok.Count > 0)
            {
                tk = ltok[0];
                ltok.RemoveAt(0);
            }
            return tk;
        }

        //Este metodo verifica que todos los tokens esten en la lista.
        public bool verificaexist(List<NT> lista)
        {
            if (lista.Count != ltok.Count)
                return false;
            foreach (NT tk in lista)
            {
                if (buscatk(tk.nom, ltok) == null)
                    return false;
            }
            return true;
        }

        //Metodo que busca Tokens NoTerminales en la Produccion.
        public bool snt()
        {
            foreach (NT token in ltok)
            {
                if (token.esTerminal == false)
                    return true;
            }
            return false;
        }

        /// Este metodo verifica la existencia del simbolo (ε) en la Produccion.
        public bool seps()
        {
            foreach (NT token in ltok)
            {
                if (token.nom == "ε")
                    return true;
            }
            return false;
        }

        public bool epsnovalido()
        {
            if (ltok.Count > 1)
            {
                foreach (NT token in ltok)
                {
                    if (token.nom == "ε")
                        return true;
                }
            }
            return false;
        }

        /// Este metodo elimina un Toquen de la Produccion.
        public void removertk(NT tk)
        {
            ltok.Remove(tk);
        }

        /// Este metodo quita todos aquellos Tokens de la Produccion que coincidan en nombre con el string que pasa como parametro.
        public void quitatks(string cad)
        {
            for(int num = 0; num< ltok.Count;)
            {
                if (ltok[num].nom == cad)
                {
                    ltok.RemoveAt(num);
                }
                else num++;
            }
        }

        /// Este metodo agrega un conjunto de Tokens a la produccion de Primero.
        public bool agconjunto(List<NT> aux)
        {
            bool b1;
            bool b2 = false;
            foreach (NT a in aux)
            {
                b1 = true;
                foreach (NT k in ltok)
                {
                    if (a.nom == k.nom)
                    {
                        b1 = false;
                        break;
                    }
                }
                if ((b1 == true) && (a.nom != "ε"))
                {
                        agregarult(a);
                        b2 = true;
                }
            }
            return b2;
        }

        /// Este metodo agrega un Token a la produccion de Primero.
        public bool agregatkprim(NT tk)
        {
            bool b = true;
            foreach (NT k in ltok)
            {
                if (tk.nom == k.nom)
                {
                    b = false;
                    break;
                }
            }
            if (b == true)
                agregarult(tk);
            return b;
        }

        /// Este metodo remplaza una sucesion de Tokens de la lista de la produccion por otra sucesion diferente de Tokens.
        public void remplazatks(List<NT> original, List<NT> remplazo)
        {
            Queue<NT> iz = new Queue<NT>();
            Queue<NT> med = new Queue<NT>();
            int numor = original.Count;
            int numlist = ltok.Count;
            int posor = 0;
            int contor = 0;
            int contlist = 0;

            if (numor < numlist+1)
            {
                while (posor+numor < numlist+1)
                {
                    if (ltok[contor].nom == original[contlist].nom)
                    {
                        med.Enqueue(ltok[contor]);
                        contor++;
                        contlist++;
                        if (contlist == numor)
                        {
                            foreach (NT tk in remplazo)
                                iz.Enqueue(tk);
                            posor = contor;
                            contlist = 0;
                            med.Clear();
                        }
                    }
                    else
                    {
                        while (med.Count > 0) iz.Enqueue(med.Dequeue());
                        iz.Enqueue(ltok[contor]);
                        contlist = 0;
                        posor++;
                        contor = posor;
                    }
                }
                while (posor < numlist) iz.Enqueue(ltok[posor++]);
                ltok.Clear();
                while (iz.Count > 0) ltok.Add(iz.Dequeue());
            }
        }

        /// Este metodo compara si esta Produccion es igual a otra Produccion.
        public bool comparaprod(Produccion prec)
        {
            int aux = 0;
            if (prec.ltok.Count != ltok.Count)
                return false;
            foreach (NT tk in ltok)
            {
                if (tk.nom != prec.ltok[aux].nom)
                    return false;
                aux++;
            }
            return true;
        }

        public Produccion duprod()
        {
            Produccion aux = new Produccion();
            aux.agregafintk(ltok);
            aux.numero = numero;
            return aux;
        }

        public NT removult()
        {
            int n = ltok.Count - 1;
            NT tk = ltok[n];
            ltok.RemoveAt(n);
            return tk;
        }

        //Agrega una lista de Tokens al final de la lista de la Produccion.
        public void agregafintk(List<NT> lrec)
        {
            foreach (NT aux in lrec)
            {
                agregarult(aux);
            }
        }

        public void ponerpunto()
        {
            NT aux = new NT(".");
            aux.op(".");
            ltok.Insert(0, aux);
        }

        public NT moverpunto()
        {
            NT aux = null;
            int act = 0;
            for (int x = 0; x < ltok.Count; x++)
            {
                if (ltok[x].oper == ".")
                {
                    act = x;
                    aux = ltok[x];
                    break;
                }
            }
            ltok.RemoveAt(act);
            if (act + 1 == (ltok.Count + 1))
                return null;
            ltok.Insert(act + 1, aux);
            return ltok[act];
        }

        //Regresa el token que esta antes del punto
        public NT tkanterior()
        {
            NT auxant = null;
            int act = 0;
            for (int x = 0; x < ltok.Count; x++)
            {
                if (ltok[x].oper == ".")
                {
                    act = x - 1;
                    if (act < 0)
                        return null;
                    auxant = ltok[act];
                    break;
                }
            }
            return auxant;
        }

        //Regresa el token que esta depues del punto
        public NT tksiguiente()
        {
            NT sig = null;
            int act = 0;
            for (int x = 0; x < ltok.Count; x++)
            {
                if (ltok[x].oper == ".")
                {
                    act = x + 1;
                    if (act == ltok.Count)
                        return null;
                    sig = ltok[act];
                    break;
                }
            }
            return sig;
        }

        public NT ult()
        {
            return ltok[ltok.Count - 1];
        }

        public NT primero()
        {
            return ltok[0];
        }

        //Muestra el contenido de una produccion
        public string muestracontprod()
        {
            string cad = "";
            foreach (NT tk in ltok)
            {
                cad += "";
                if (tk.nom.Length == 1) cad += tk.nom;
                else cad += "<" + tk.nom + ">";
                cad += "";
            }
            return cad;
        }

        public NT quitaPrimero()
        {
            NT tk = ltok[0];
            ltok.RemoveAt(0);
            return tk;
        }

        public void nuevo(NT tk)
        {
            ltok.Add(tk);
        }
    }
}
