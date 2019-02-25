using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Compiladores
{
    class Boton
    {
        public String id;
        public String cadena;
        public int x1, y1, x2, y2;

        public Boton(String id, String cadena, int x1, int y1, int x2, int y2)
        {
            this.id = id;
            this.cadena = cadena;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}
