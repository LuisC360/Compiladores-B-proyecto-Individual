using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Simbolo
    {
        public String simbolo;
        public String valor;
        public int idSimbolo;

        public Simbolo(String simbolo, String valor, int id)
        {
            this.simbolo = simbolo;
            this.valor = valor;
            this.idSimbolo = id;
        }
    }
}
