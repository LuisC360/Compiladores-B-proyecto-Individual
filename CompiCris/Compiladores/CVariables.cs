using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Compiladores
{
    class CVariables
    {
        Produccion listaVariables;
        DataGridView tablaSi;
        int varTemp;

        public CVariables(DataGridView tablaSi)
        {
            this.tablaSi = tablaSi;
            listaVariables = new Produccion();
            varTemp = 1;
        }

        public void agregar(string nombreVar)
        {
            Token tk = listaVariables.buscaToken(nombreVar, listaVariables.LISTATOKENS);
            if (tk == null)
            {
                tk = new Token(nombreVar);
                listaVariables.agregar(tk);
                tk.VALOR = "0";
                tablaSi.Rows.Add(nombreVar);
            }
            ActualizaVariable(nombreVar);
        }

        public void Clear()
        {
            listaVariables.LISTATOKENS.Clear();
            tablaSi.Rows.Clear();
            varTemp = 1;
        }

        public Token buscaVariable(string nombreVar)
        {
            return listaVariables.buscaToken(nombreVar, listaVariables.LISTATOKENS);
        }

        public Token nuevaVarTemp()
        {
            Token tk = new Token("_T" + varTemp.ToString());
            varTemp++;
            listaVariables.agregar(tk);
            tk.VALOR = "0";
            tablaSi.Rows.Add(tk.NOMBRE);
            ActualizaVariable(tk.NOMBRE);
            return tk;
        }

        unsafe public void ActualizaVariable(string nombre)
        {
            string[] datos = new string[3];
            for (int i = 0; i < listaVariables.LISTATOKENS.Count; i++)
            {
                if (listaVariables.LISTATOKENS[i].NOMBRE == nombre)
                {
                    datos[0] = listaVariables.LISTATOKENS[i].NOMBRE;// para ver el nombre
                    datos[1] = listaVariables.LISTATOKENS[i].VALOR; // para ver valor

                    tablaSi.Rows[i].SetValues(datos);
                    break;
                }
            }
        }
    }
}
