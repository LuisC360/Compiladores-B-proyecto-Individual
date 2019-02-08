using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Infoenla
    {
        public AFD estAFD;
        public NT token;

        public Infoenla(AFD est, NT tk)
        {
            estAFD = est;
            token = tk;
        }

        //Metodo que muestra el contenido de este enlace por medio de un string.
        public string muestraEnlace()
        {
            return token.nom + " -> " + estAFD.num.ToString();
        }
    }
}
