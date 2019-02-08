using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Nodo
    {

        public object info;
        public Nodo izq, der;
        public Nodo(Object info)
        {
            this.info = info;
        }
    }
}
