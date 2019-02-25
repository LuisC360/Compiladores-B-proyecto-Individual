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
        public object variable;
        public String  tipo;


        public Temporal(String id, String val, int idt, String tipo)
        {
            this.id = id;
            this.valor = val;
            this.idTemporal = idt;
            this.tipo = tipo;
            if(tipo == "bool")
            {
                variable = new bool();
            }
            else if( tipo == "int")
            {
                variable = new Int32();
            }
            
        }
    }
}
