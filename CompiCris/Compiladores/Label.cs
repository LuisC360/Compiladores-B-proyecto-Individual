using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Label
    {
        public String id;
        public String cadena;
        public int x1, y1;

        public Label(String id, String cadena, int x1, int y1)
        {
            this.id = id;
            this.cadena = cadena;
            this.x1 = x1;
            this.y1 = y1;
        }
    }
}
