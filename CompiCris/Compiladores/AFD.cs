using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class AFD
    {
        //Estructura que contiene los estados
        public CEdos ceds;
        public List<Separa> lreg;
        public List<Infoenla> listaEnlaces;

        public AFD(List<Separa> prim, CEdos conj)
        {
            ceds = conj;
            lreg = new List<Separa>(prim);
            listaEnlaces = new List<Infoenla>();
        }

        //Metodo para la regla 2 del AFD.
        public void verel2()
        {
            NT A = null;
            List<NT> B = new List<NT>();
            bool resp = false;
            for (int x = 0; x < lreg.Count; x++)
            {
                A = null;
                B.Clear();
                resp = false;

                for(int o=0; o<lreg[x].derecha[0].ltok.Count(); o++)
                {
                    if (A != null)
                    {
                        B.Add(lreg[x].derecha[0].ltok[o]);
                    }
                    else
                    {
                        if (resp == true)
                            A = lreg[x].derecha[0].ltok[o];
                        if (lreg[x].derecha[0].ltok[o].oper == ".")
                            resp = true;
                    }
                }

                if ((A != null) && (A.esTerminal == false))
                {
                        addinic(A, B, lreg[x].tksbusqueda.ltok);
                }
            }
        }

        //Metodo para agregar elementos iniciales.
        public void addinic(NT X, List<NT> B, List<NT> buscar)
        {
            Separa nregla;
            Separa aux;
            Produccion nproduccion;

            for(int x=0; x<X.listaP.Count(); x++)
            {
                nregla = new Separa();
                nproduccion = X.listaP[x].duprod();
                nproduccion.quitatks("ε");
                nproduccion.ponerpunto();
                nregla.tksbusqueda = new Produccion();
                nregla.derecha.Add(nproduccion);
                nregla.ladoIzq = X;
                Primeragrega(nregla, B, buscar);
                aux = buscaregla(nregla, lreg);
                if (aux == null)
                    lreg.Add(nregla);
                else
                    aux.tksbusqueda.agconjunto(nregla.tksbusqueda.ltok);
            }

        }

        public Separa buscaregla(Separa buscar, List<Separa> lista)
        {
            return lista.Find((Predicate<Separa>)delegate (Separa regla)
            {
                return regla.ladoIzq.nom == buscar.ladoIzq.nom && regla.derecha[0].comparaprod(buscar.derecha[0]) == true;
            });
        }

        //Este Metodo ejecuta los procesos que llevan a la creacion de mas Estados del AFD.
        public void eval()
        {
            verel2();
            Verel3();
        }

        //Metodo que realiza la regla 3 de los AFD.
        public void Verel3()
        {
            AFD nuevoest;
            Infoenla nuevoen;
            List<Separa> listaux = new List<Separa>();
            List<Separa> listaux2 = new List<Separa>();

            for(int x=0; x<lreg.Count(); x++)
            {
                listaux.Add(lreg[x].coprod());
            }

            while (listaux.Count != 0)
                {
                    listaux2 = Buscasim(listaux, listaux[0]);
                    if (listaux2 != null)
                    {
                        for (int x = 0; x < listaux2.Count; x++)
                        {
                            for (int i = 0; i < listaux.Count; i++)
                            {
                                if (Reglasim(listaux2[x], listaux[i]) == true)
                                {
                                    listaux.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        foreach (Separa r in listaux2)
                        {
                            r.derecha[0].moverpunto();
                        }
                        if (listaux2[0].derecha[0].tkanterior() != null)
                        {
                            nuevoest = ceds.buscaEstado(listaux2[0]);
                            if (nuevoest == null)
                            {
                                nuevoest = new AFD(listaux2, ceds);
                                ceds.agregaEstado(nuevoest);
                                nuevoen = new Infoenla(nuevoest, listaux2[0].derecha[0].tkanterior());
                                listaEnlaces.Add(nuevoen);
                                nuevoest.eval();
                            }
                            else
                            {
                                nuevoen = new Infoenla(nuevoest, listaux2[0].derecha[0].tkanterior());
                                listaEnlaces.Add(nuevoen);
                            }
                        }
                    }
                    else listaux.RemoveAt(0);
                }
        }

        public bool Reglasim(Separa r1, Separa r2)
        {

            if ((r1.ladoIzq.nom == r2.ladoIzq.nom) && (r1.derecha[0].comparaprod(r2.derecha[0]) == true) && (r1.tksbusqueda.verificaexist(r2.tksbusqueda.ltok) == true))
                return true;
            else
                return false;
        }

        //Metodo que calcula los primeros a ser agregados
        public void Primeragrega(Separa nue, List<NT> B, List<NT> bucar)
        {
            bool band = false;
            if (B.Count == 0)
            {
                nue.tksbusqueda.agconjunto(bucar);
            }
            else
            {
                for(int d=0; d< B.Count(); d++)
                {
                    if (B[d].esTerminal == true)
                    {
                        nue.tksbusqueda.agregatkprim(B[d]);
                        band = false;
                        break;
                    }
                    else
                    {
                        if (B[d].primero.seps() == false)
                        {
                            nue.tksbusqueda.agconjunto(B[d].primero.ltok);
                            band = false;
                            break;
                        }
                        else
                        {
                            nue.tksbusqueda.agconjunto(B[d].primero.ltok);
                            band = true;
                        }
                    }
                }
                if (band == true)
                {
                    nue.tksbusqueda.agconjunto(bucar);
                }
            }
        }

        public int num;

        List<Separa> Buscasim(List<Separa> list, Separa sepreg)
        {
            List<Separa> listaux = new List<Separa>();
            NT tkaux = sepreg.derecha[0].tksiguiente();

            if (tkaux == null)
            {
                return null;
            }
            else
            {
                for(int x=0; x< list.Count(); x++)
                {
                    if ((list[x].derecha[0].tksiguiente() != null) && (list[x].derecha[0].tksiguiente().nom == tkaux.nom))
                    {
                        listaux.Add(list[x]);
                    }
                }
            }
            if (listaux.Count == 0)
                return null;
            else
                return listaux;
        }
    }
}
