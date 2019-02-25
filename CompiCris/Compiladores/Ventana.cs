using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores
{
    class Ventana
    {
        public String id;
        public String nombre;
        public Form window;

        public Ventana(String id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
