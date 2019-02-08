using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class CEdos
    {
        /// Una lista de objetos de tipo Estados.
        public List<AFD> estados;
        /// Un numero que "nombra" a cada Estado. Este numero se incrementa conforme se agregan mas Estados.
        int numestado;

        /// Metodo constructor de la clase.
        public CEdos()
        {
            estados = new List<AFD>();
            numestado = 0;
        }

        public int Count()
        {
            return estados.Count();
        }

        //Este metodo sirve para buscar un estado en especifico en la lista, recibe como referencia
        //una variable que es la que se intenta buscar y al final regresa un estado de la lista.
        public AFD buscaEstado(Separa estadobuscado)
        {
            foreach (AFD estado in estados)
            {
                if ((estado.lreg[0].ladoIzq.nom == estadobuscado.ladoIzq.nom) && (estado.lreg[0].derecha[0].comparaprod(estadobuscado.derecha[0]) == true) && (estado.lreg[0].tksbusqueda.verificaexist(estadobuscado.tksbusqueda.ltok) == true))
                {
                    return estado;
                }
            }
            return null;
        }

        //Agrega un nuevo estado a la lista.
        public void agregaEstado(AFD nuevo)
        {
            nuevo.num = numestado;
            numestado++;
            estados.Add(nuevo);
        }
    }
}
