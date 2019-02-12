using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores
{
    class Cuadruplo
    {
        public string OPERADOR;
        public string OPERANDO1;
        public string OPERANDO2;
        public string RESULTADO;
        public int idCUADRUPLO;

        public Cuadruplo()
        {
            OPERADOR = null;
            OPERANDO1 = null;
            OPERANDO2 = null;
            RESULTADO = null;
            idCUADRUPLO = 0;
        }

        public Cuadruplo (string opr, string op1, string op2, string res, int id)
        {
            OPERADOR = opr;
            OPERANDO1 = op1;
            OPERANDO2 = op2;
            RESULTADO = res;
            idCUADRUPLO = id;
        }

        public void CreaCuadruplo(string opr, string op1, string op2, int id)
        {
            OPERADOR = opr;
            OPERANDO1 = op1;
            OPERANDO2 = op2;
            idCUADRUPLO = id;
        }

        public void CreaCuadruplo(string opr, string op1, string op2,string res, int id)
        {
            OPERADOR = opr;
            OPERANDO1 = op1;
            OPERANDO2 = op2;
            RESULTADO = res;
            idCUADRUPLO = id;
        }
    }
}
