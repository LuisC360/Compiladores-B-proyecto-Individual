using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Variable
    {
        public Variable(String tipo, String id)
        {
            this.tipo = tipo;
            this.id = id;
        }
        public String tipo;
        public String id;
    }
}
