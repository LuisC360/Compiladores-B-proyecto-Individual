using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class ElementoVentana
    {
        public String id;
        public int x1, y1, x2, y2;

        public ElementoVentana(String id, int x1, int y1, int x2, int y2)
        {
            this.id = id;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}
