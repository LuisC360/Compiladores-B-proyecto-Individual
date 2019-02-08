using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Compiladores
{
    class CCuadruplos
    {
        List<Produccion> listaCuadruplos;
        RichTextBox codigo;
        DataGridView tablaCu;
        CVariables listaVar;
        RichTextBox consola;
        Form1 compilador;
        int iterador;
        Produccion cuadruplo;
        bool espera;
        int modoAnt;
        int filaAux;
        int fila;

        public CCuadruplos(RichTextBox codigo, DataGridView tablaCu, CVariables listaVar, RichTextBox consola, Form1 comp)
        {
            this.codigo = codigo;
            this.tablaCu = tablaCu;
            this.listaVar = listaVar;
            this.consola = consola;
            this.compilador = comp;
            listaCuadruplos = new List<Produccion>();
            iterador = 0;
            cuadruplo = null;
            espera = false;
            modoAnt = 0;
            filaAux = 0;
            fila = 0;
        }

        public int agregar(Produccion nuevoCuadruplo)
        {
            string[] datos = new string[4];
            int num = listaCuadruplos.Count;
            listaCuadruplos.Add(nuevoCuadruplo);
            datos[0] = nuevoCuadruplo.LISTATOKENS[0].NOMBRE;
            datos[1] = nuevoCuadruplo.LISTATOKENS[1].NOMBRE;
            datos[2] = nuevoCuadruplo.LISTATOKENS[2].NOMBRE;
            datos[3] = nuevoCuadruplo.LISTATOKENS[3].NOMBRE;
            tablaCu.Rows.Add(datos);
            return (listaCuadruplos.Count - 1);
        }

        public void Clear()
        {
            listaCuadruplos.Clear();
            tablaCu.Rows.Clear();
        }

        public void ejecutaCuadruplos(int modo)
        {
            if (modo == 0)
                modo = modoAnt;
            else
            {
                modoAnt = modo;
                compilador.activaBoton(modo);
                if (modo == 1 || iterador >= listaCuadruplos.Count)
                {
                    consola.Clear();
                    iterador = 0;
                    espera = false;
                }
                else
                {
                    if (espera == true)
                    {
                        consola.Select();
                        return;
                    }
                }
            }
            if (modo != 3)
                modo_1_y_2(modo);
            else
                modo_3();
        }

        public void modo_1_y_2(int modo)
        {
            do
            {
                if (cuadruplo != null)
                {
                    evaluaCuadruplo();
                    if (espera == true)
                        break;
                }
                if (iterador < listaCuadruplos.Count)
                {
                    resaltaCuadruplo();
                    seleccionar(listaCuadruplos[iterador].FILA);
                    cuadruplo = listaCuadruplos[iterador];
                    iterador++;
                }
                if (iterador == listaCuadruplos.Count)
                {
                    MessageBox.Show("Fin de programa, el resultado es: " + listaCuadruplos[iterador - 2].LISTATOKENS[3].VALOR);
                    cuadruplo = null;
                    compilador.activaBoton(0);
                    break;
                }
                if (modo != 1)
                    break;
            } while (modo == 1);
        }

        public void modo_3()
        {
            if (cuadruplo != null)
            {
                filaAux = fila;
                do
                {
                    evaluaCuadruplo();
                    if (espera == true)
                    {
                        seleccionar(filaAux);
                        break;
                    }
                    fila = listaCuadruplos[iterador].FILA;
                    if (fila == filaAux)
                    {
                        cuadruplo = listaCuadruplos[iterador];
                        if (iterador < listaCuadruplos.Count)
                            iterador++;
                    }
                } while (fila == filaAux);
                if (espera == false)
                    cuadruplo = null;
            }
            if (iterador < listaCuadruplos.Count && espera == false)
            {
                cuadruplo = listaCuadruplos[iterador];
                resaltaCuadruplo();
                seleccionar(listaCuadruplos[iterador].FILA);
                fila = listaCuadruplos[iterador].FILA;
                iterador++;
                if (iterador == listaCuadruplos.Count)
                {
                    MessageBox.Show("Fin de programa, el resultado es: " + listaCuadruplos[iterador - 2].LISTATOKENS[3].VALOR);
                    compilador.activaBoton(0);
                    fila = 0;
                    cuadruplo = null;
                    filaAux = 0;
                }
            }
        }

        public void deseleccionar()
        {
            codigo.SelectAll();
            codigo.SelectionColor = Color.Black;
            codigo.SelectionBackColor = Color.White;
            codigo.DeselectAll();
        }

        public void seleccionar(int num)
        {
            if (num >= 0)
            {
                deseleccionar();
                int start = codigo.GetFirstCharIndexFromLine(num);
                int length = codigo.Lines[num].Length;
                codigo.Select(start, length);
                codigo.SelectionColor = Color.White;
                codigo.SelectionBackColor = Color.Blue;
            }
        }

        public void resaltaCuadruplo()
        {
            tablaCu.ClearSelection();
            tablaCu.Rows[iterador].Selected = true;
            tablaCu.FirstDisplayedScrollingRowIndex = iterador;
        }

        public void evaluaCuadruplo()
        {
            string nom = cuadruplo.LISTATOKENS[0].NOMBRE;
            switch (nom)
            {
                case "VAR":
                    casoVAR();
                    break;
                case "READ":
                    casoREAD();
                    break;
                case "WRITE":
                    casoWRITE();
                    break;
                case ":=":
                    casoAsignacion();
                    break;
                case "IF":
                    casoIF();
                    break;
                case "ELSE":
                    casoELSE();
                    break;
                case "REPEAT":
                    casoREPEAT();
                    break;
                case "CONCAT":
                    casoCONCAT();
                    break;
                default:
                    if (nom == "==" || nom == "<" || nom == ">")
                        casoComparacion();
                    if (nom == "+" || nom == "-" || nom == "*" || nom == "/" || nom == "^")
                        casoOperacion();
                    break;
            }
        }

        public void casoCONCAT()
        {
            cuadruplo.LISTATOKENS[3].VALOR = cuadruplo.LISTATOKENS[3].VALOR + cuadruplo.LISTATOKENS[1].VALOR + " ";
            listaVar.ActualizaVariable(cuadruplo.LISTATOKENS[3].NOMBRE);
        }

        public void casoREPEAT()
        {
            if (cuadruplo.LISTATOKENS[1].VALOR == "FALSE")
            {
                iterador -= (int.Parse(cuadruplo.LISTATOKENS[2].VALOR) + 1);
            }
        }

        public void casoIF()
        {
            if (cuadruplo.LISTATOKENS[1].VALOR == "FALSE")
                iterador += (int.Parse(cuadruplo.LISTATOKENS[2].VALOR));
        }

        public void casoELSE()
        {
            if (cuadruplo.LISTATOKENS[1].VALOR == "TRUE")
                iterador += (int.Parse(cuadruplo.LISTATOKENS[2].VALOR));
        }

        public void casoAsignacion()
        {
            cuadruplo.LISTATOKENS[3].VALOR = cuadruplo.LISTATOKENS[1].VALOR;
            listaVar.ActualizaVariable(cuadruplo.LISTATOKENS[3].NOMBRE);
        }

        public void casoOperacion()
        {
            float val1 = float.Parse(cuadruplo.LISTATOKENS[1].VALOR);
            float val2 = float.Parse(cuadruplo.LISTATOKENS[2].VALOR);
            switch (cuadruplo.LISTATOKENS[0].NOMBRE)
            {
                case "+":
                    cuadruplo.LISTATOKENS[3].VALOR = (val1 + val2).ToString();
                    break;
                case "-":
                    cuadruplo.LISTATOKENS[3].VALOR = (val1 - val2).ToString();
                    break;
                case "*":
                    cuadruplo.LISTATOKENS[3].VALOR = (val1 * val2).ToString();
                    break;
                case "/":
                    cuadruplo.LISTATOKENS[3].VALOR = (val1 / val2).ToString();
                    break;
                case "^":
                    cuadruplo.LISTATOKENS[3].VALOR = Math.Pow(val1, val2).ToString();
                    break;
            }
            listaVar.ActualizaVariable(cuadruplo.LISTATOKENS[3].NOMBRE);
        }

        public void casoComparacion()
        {
            switch (cuadruplo.LISTATOKENS[0].NOMBRE)
            {
                case "==":
                    if (cuadruplo.LISTATOKENS[1].VALOR == cuadruplo.LISTATOKENS[2].VALOR)
                        cuadruplo.LISTATOKENS[3].VALOR = "TRUE";
                    else
                        cuadruplo.LISTATOKENS[3].VALOR = "FALSE";
                    break;
                case "<":
                    if (int.Parse(cuadruplo.LISTATOKENS[1].VALOR) < int.Parse(cuadruplo.LISTATOKENS[2].VALOR))
                        cuadruplo.LISTATOKENS[3].VALOR = "TRUE";
                    else
                        cuadruplo.LISTATOKENS[3].VALOR = "FALSE";
                    break;
                case ">":
                    if (int.Parse(cuadruplo.LISTATOKENS[1].VALOR) > int.Parse(cuadruplo.LISTATOKENS[2].VALOR))
                        cuadruplo.LISTATOKENS[3].VALOR = "TRUE";
                    else
                        cuadruplo.LISTATOKENS[3].VALOR = "FALSE";
                    break;
            }
            listaVar.ActualizaVariable(cuadruplo.LISTATOKENS[3].NOMBRE);
        }

        public void casoVAR()
        {
            Token tk = cuadruplo.LISTATOKENS[3];
            if (cuadruplo.LISTATOKENS[1].NOMBRE == "int")
                tk.VALOR = "0";
            else
                tk.VALOR = "0,0";
            listaVar.ActualizaVariable(tk.NOMBRE);
        }

        public void casoREAD()
        {
            //compilador.ReadConsola();
            espera = true;
        }

        public void casoWRITE()
        {
            consola.AppendText(cuadruplo.LISTATOKENS[1].VALOR);
            consola.AppendText(System.Environment.NewLine);
        }

        public void finREAD(string captura)
        {
            cuadruplo.LISTATOKENS[3].VALOR = captura;
            listaVar.ActualizaVariable(cuadruplo.LISTATOKENS[3].NOMBRE);
            espera = false;
            if (modoAnt == 3)
            {
                cuadruplo = null;
                codigo.Select();
            }
            else
            {
                cuadruplo = null;
                tablaCu.Select();
            }
            ejecutaCuadruplos(0);
        }
    }
}
