using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    public class Temporal
    {
        public String id;
        public String valor;
        public int idTemporal;

        public Temporal(String id, String val, int idt)
        {
            this.id = id;
            this.valor = val;
            this.idTemporal = idt;
        }
    }
}
