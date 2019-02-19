using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;

namespace Compiladores
{
    class Algoritmos
    {
        //Lista de reglas que se utilizaran
        List<Separa> lregl;
        //Este es un objeto contenedor de tokens
        CTK contks;
        //Variable que representa el simbolo inicial
        NT inicial;
        //Variable que representa la expresion regular
        Separa expreg;
        //Este es el textbox donde esta la gramatica.
        RichTextBox textgram;
        //Bandera que nos dice si es tipo LR(1)
        public bool tlr1,ReduArr,ReduSwitch,SentIf,Skip;
        //Variable para identificar errores
        public string errorCelda;

        public Stack<string> Esquema;//////////////////////// 
        public int ReduTemp;
        public List<string> Temporal;
        string acciontrad;

        public List<Cuadruplo> Cuadruplos;
        public List<Nodo> PilaNodos;
        public List<Nodo> PilaTemporal;
        public List<Nodo> Conexion;
        public List<int> PilaContSent;
        public TreeView tree;
        public List<String> PilaUnknowVals;
        public List<Variable> PilaListDeclaraciones;
        public List<ElementoVentana> PilaElementosVentana;
        public List<Ventana> PilaVentanas;
        public List<Label> PilaLabel;
        public List<MessageB> PilaMessageBox;
        public List<Boton> PilaBotones;
        public List<Simbolo> Simbolos;
        public List<String> Errores;
        public string defaultf;
        public Cuadruplo cuadruploTemp;
        public int rango_cuadruplos;

        // Todos los valores temporales para los cuadruplos serán almacenados en esta lista.
        public List<Temporal> temporales;

        // Identificador de cuadruplos
        public int idCuadruplo = 0;

        public int idSimbolo = 0;
        public int idTemporal = 0;
        
        Nodo RaizTemp;
        public int numBloque;

        String temp = "_T";
        int tempCount = 1;
        DataGridView tablaCu;
        DataGridView tablaSi;

        int valorInicial = 0;

        //Constructor donde se inicializan las variables
        public Algoritmos(RichTextBox txtbx, DataGridView tC, DataGridView tS)
        {
            lregl = new List<Separa>();
            contks = new CTK();
            inicial = null;
            expreg = new Separa();
            expreg.ladoIzq = new NT("E.R.");
            textgram = txtbx;
            tlr1 = false;
            ReduTemp = 0;
            acciontrad = "";
            PilaNodos = new List<Nodo>();
            PilaContSent = new List<int>();

            PilaTemporal = new List<Nodo>();
            Conexion = new List<Nodo>();
            Cuadruplos = new List<Cuadruplo>();
            PilaUnknowVals = new List<string>();
            PilaListDeclaraciones = new List<Variable>();
            PilaElementosVentana = new List<ElementoVentana>();
            PilaVentanas = new List<Ventana>();
            PilaLabel = new List<Label>();
            PilaMessageBox = new List<MessageB>();
            PilaBotones = new List<Boton>();
            Simbolos = new List<Simbolo>();
            Errores = new List<string>();
            temporales = new List<Temporal>();
            defaultf = "NONE";
            tablaCu = tC;
            tablaSi = tS;
        }

        //Metodo que busca los simbolos iniciales.
        public void sinicial()
        {
            bool inic;
            inicial = null;

            for(int g=0; g<lregl.Count(); g++)
            {
                inic = true;
                for (int x = 0; x < lregl.Count; x++)
                {
                    if (x != g)
                    {
                        foreach (Produccion p in lregl[x].derecha)
                        {
                            foreach (NT tk in p.ltok)
                            {
                                if (tk == lregl[g].ladoIzq)
                                {
                                    inic = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (inic == true)
                {
                    inicial = lregl[g].ladoIzq;
                    break;
                }
            }
            if (inicial == null)
                inicial = lregl[0].ladoIzq;
        }

        //Metodo para obtener los primeros de los NT primero y depues de los Term.
        public void Primeros()
        {
            bool b = false;
            bool b2 = false;
            List<NT> lNT = contks.noterm();

            for(int x=0; x< lNT.Count(); x++)
            {
                for(int y=0; y<lNT[x].listaP.Count(); y++)
                {
                    if (lNT[x].listaP[y].ltok[0].esTerminal == true)
                    {
                        b = lNT[x].primero.agregatkprim(lNT[x].listaP[y].ltok[0]);
                    }
                }
            }
            int n;
            do
            {
                b2 = false;
                for(int e=0; e<lNT.Count; e++)
                {
                    /////////////////////////Thread.Sleep(40);
                    for(int w=0; w<lNT[e].listaP.Count; w++)
                    {
                        n = 0;
                        for(int v=0; v<lNT[e].listaP[w].ltok.Count(); v++)
                        {
                            if (lNT[e].listaP[w].ltok[v].esTerminal == false)
                            {
                                b = lNT[e].primero.agconjunto(lNT[e].listaP[w].ltok[v].primero.ltok);
                                if (b == true)
                                    b2 = true;
                                if (lNT[e].listaP[w].ltok[v].primero.seps() == false)
                                    break;                                
                                else
                                {
                                    if ((n + 1) == lNT[e].listaP[w].ltok.Count)
                                    {
                                        
                                        b = lNT[e].primero.agregatkprim(new NT("ε"));
                                        if (b == true)
                                            b2 = true;
                                    }
                                }
                            }
                            else
                            {
                                lNT[e].primero.agregatkprim(lNT[e].listaP[w].ltok[v]);
                                break;
                            }
                            n++;
                        }
                    }
                }
            } while (b2 == true);
        }

        //Metodo para obtener los siguientes.
        public void Siguientes()
        {
            bool b = false;
            bool b2 = false;
            NT tk = new NT("$");
            tk.op("$");
            contks.agregaToken(tk);

            sinicial();

            if (inicial != null)
            {
                inicial.siguiente.agregatkprim(tk);
                do
                {
                    b2 = false;
                    foreach (Separa r in lregl)
                    {
                        foreach (Produccion pro in r.derecha)
                        {
                            for (int x = 0; x < pro.ltok.Count; x++)
                            {
                                tk = pro.ltok[x];
                                if (tk.esTerminal == false)
                                {
                                    if ((x + 1) < pro.ltok.Count)
                                    {
                                        for (int k = (x + 1); k < pro.ltok.Count; k++)
                                        {
                                            if (pro.ltok[k].esTerminal == true)
                                            {
                                                b = tk.siguiente.agregatkprim(pro.ltok[k]);
                                                if (b == true) b2 = true;
                                                break;
                                            }
                                            else
                                            {
                                                b = tk.siguiente.agconjunto(pro.ltok[k].primero.ltok);
                                                if (b == true) b2 = true;
                                                if (pro.ltok[k].primero.seps() == false) break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        b = tk.siguiente.agconjunto(r.ladoIzq.siguiente.ltok);
                                        if (b == true) b2 = true;
                                    }
                                }
                            }
                        }
                    }

                } while (b2 == true);
            }
            else
                MessageBox.Show("No hay simbolo inicial");
        }

        //Se crea la lista de reglas.
        public bool creglas()
        {
            string r;
            int act = 0;
            bool res = false;
            int prodact = 1;

            lregl.Clear();
            contks.Clear();

            for (int aux = 0; aux < textgram.Lines.Count(); aux++)
            {
                r = textgram.Lines[aux];
                textgram.SelectionStart = act;

                if ((r.Length > 0))
                {
                    if (verifica(r, ref prodact) == true)
                    {
                        res = true;
                        textgram.Select(act, r.Length);
                        textgram.SelectionColor = Color.Black;
                        textgram.SelectionBackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Existen errores en la gramatica");
                        textgram.Select(act, r.Length);
                        textgram.SelectionColor = Color.Green;
                        textgram.SelectionBackColor = Color.Black;
                    }
                }
                act = act + r.Length + 1;
            }
            foreach (var t in contks.lista)
            {

                if (lregl.Find(x => x.ladoIzq.nom == t.nom) == null)
                {
                    t.esTerminal = true;
                }
            }
            return res;
        }

        //Metodo para aumentar la gramatica.
        public void gramaum()
        {
            Separa aumentada = new Separa();
            aumentada.ladoIzq = new NT(inicial.nom + "'");
            aumentada.ladoIzq.NoTerminal();
            contks.agregaToken(aumentada.ladoIzq);
            Produccion prod = new Produccion();
            prod.agregarprim(inicial);
            aumentada.derecha.Add(prod);
            aumentada.ladoIzq.listaP = aumentada.derecha;
            lregl.Insert(0, aumentada);
        }

        //Esta funcion hace un split cuando encuatra la flecha y verifica que se divida en dos
        //y que en ninguno de los dos lados existan errores.
        public bool verifica(string ren, ref int act)
        {
            string cad = ren.Replace("->", "→");
            string[] datos = cad.Split('→');

            if (datos.Count() == 2)
            {
                if (evaluavalidez(datos[0], datos[1], ref act) == true)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        //Se evaluan 2 cadenas para verificar que tengan tokens validos.
        public bool evaluavalidez(string izq, string der, ref int act)
        {
            Separa nuev = new Separa();
            Separa verex;
            nuev.partiz(izq.Replace(" ", ""), contks);
            verex = buscar(nuev);
            if (verex != null)
                nuev = verex;
            if (nuev.parder(der, contks, ref act) == false)
            {
                nuev.ladoIzq.Terminal();
                return false;
            }
            if (verex == null)
            {
                lregl.Add(nuev);
                nuev.ladoIzq.listaP = nuev.derecha;
            }
            return true;
        }

        //Se busca si hay una regla ingual a la que se le pasa 
        public Separa buscar(Separa aux)
        {
            return lregl.Find((Predicate<Separa>)delegate (Separa regla)
            {
                return aux.ladoIzq.nom == regla.ladoIzq.nom;
            });
        }

        //Metodo que crea las filas de la tabla de AS.
        public void filastabla(DataGridView tabla, CEdos conestados, List<NT> lterm, List<NT> lnt)
        {
            string vcel;
            string[] data;
            data = new string[tabla.ColumnCount];

            foreach (AFD estado in conestados.estados)
            {
                for (int i = 0; i < tabla.ColumnCount; i++)
                    data[i] = "";
                data[0] = estado.num.ToString();

                foreach (Infoenla en in estado.listaEnlaces)
                {
                    vcel = data[en.token.nCol];
                    if (vcel != "")
                    {
                        if (errorCelda == "")
                        {
                            if (vcel[0] == 'S') errorCelda = "Desplazar/";
                            else errorCelda = "Reducir/";
                            errorCelda += "Desplazar a " + estado.num.ToString();
                        }
                        tlr1 = false;
                    }
                    if (en.token.esTerminal == true)
                        data[en.token.nCol] = data[en.token.nCol] + "Desplazar a " + en.estAFD.num.ToString();
                    else
                        data[en.token.nCol] = data[en.token.nCol] + en.estAFD.num.ToString();
                }
                foreach (Separa reg in estado.lreg)
                {
                    if (reg.derecha[0].ult().oper == ".")
                    {
                        foreach (NT tk in reg.tksbusqueda.ltok)
                        {
                            vcel = data[tk.nCol];
                            if (vcel != "")
                            {
                                if (errorCelda == "")
                                {
                                    if (vcel[0] == 'S') errorCelda = "Desplazar/";
                                    else errorCelda = "Reducir/";
                                    errorCelda += "Reducir en " + estado.num.ToString();
                                }
                                tlr1 = false;
                            }
                            if (reg.derecha[0].numero == 0)
                                data[tk.nCol] = data[tk.nCol] + "Aceptar";
                            else
                                data[tk.nCol] = data[tk.nCol] + "Reducir " /*+ reg.mostrarr()*/ + reg.derecha[0].numero.ToString();
                        }
                    }
                }
                tabla.Rows.Add(data);
            }
        }

        //Metodo que crea el AFD.
        public AFD creacionafd(CEdos cjedos)
        {
            List<Separa> laux = new List<Separa>();
            Separa inic = lregl[0].coprod();
            inic.derecha[0].ponerpunto();
            inic.tksbusqueda.agregarprim(contks.buscar("$"));
            laux.Add(inic);
            AFD ini = new AFD(laux, cjedos);
            cjedos.agregaEstado(ini);
            ini.eval();
            return ini;
        }

        //Metodo para mostrar el treeview.
        public void motrafd(CEdos cjedos, TreeView arbol)
        {
            TreeNode rz;
            TreeNode nd;
            arbol.Nodes.Clear();
            foreach (AFD estado in cjedos.estados)
            {
                rz = new TreeNode(estado.num.ToString());
                arbol.Nodes.Add(rz);
                foreach (Separa regla in estado.lreg)
                {
                    nd = new TreeNode(regla.muestraprod());
                    rz.Nodes.Add(nd);
                }
                foreach (Infoenla en in estado.listaEnlaces)
                {
                    nd = new TreeNode(en.muestraEnlace());
                    rz.Nodes.Add(nd);
                }
                rz.ExpandAll();
            }
        }

        //Metodo principal para obtener el AFD y la tabla de Analisis.
        public void lr1princ(TreeView arbol, DataGridView tabla)
        {
            CEdos cjedos = new CEdos();
            AFD grf;
            tlr1 = true;
            errorCelda = "";
            sinicial();
            if (inicial != null)
            {
                gramaum();
                sinicial();
                Primeros();
                Siguientes();
                grf = creacionafd(cjedos);
                motrafd(cjedos, arbol);
                tablas(tabla, cjedos);
            }
            else
                MessageBox.Show("No hay simbolo inicial");
        }

        //Metodo para crear la tabla de AS.
        public void tablas(DataGridView tabla, CEdos cjedos)
        {
            int contColumnas = 1;
            tabla.Columns.Clear();
            List<NT> lt = contks.buscaterminales();
            List<NT> lnt = contks.noterm();
            DataGridViewCell ren = new DataGridViewTextBoxCell();
            DataGridViewColumn col = new DataGridViewColumn();
            col.Name = "Estado";
            col.CellTemplate = ren;
            tabla.Columns.Add(col);
          /*  String terminales = "";
            String noterminales = "";
            String numestados;
            String data="";*/
            foreach (NT tk in lt)
            {
                if (tk.nom != "ε")
                {
                    col = new DataGridViewColumn();
                    col.Name = tk.nom;
                    col.CellTemplate = ren;
                    tabla.Columns.Add(col);
                    tk.nCol = contColumnas;
                    contColumnas++;
                 //   terminales += tk.nom+" ";
                }
            }
            int n = 1;
            foreach (NT tk in lnt)
            {
                if (n < lnt.Count)
                {
                    col = new DataGridViewColumn();
                    col.Name = tk.nom;
                    col.CellTemplate = ren;
                    tabla.Columns.Add(col);
                    tk.nCol = contColumnas;
                    contColumnas++;
                   // noterminales += tk.nom + " ";
                }
                n++;
            }
            filastabla(tabla, cjedos, lt, lnt);
         /*   numestados = cjedos.estados.Count().ToString();
            for (int r = 0; r < tabla.RowCount; r++)
            {
                for (int c = 1; c < tabla.ColumnCount ; c++)
                {
                    data += tabla.Rows[r].Cells[0].Value + " "+tabla.Columns[c].HeaderText+ " ";
                    if (tabla.Rows[r].Cells[c].Value == "")
                    {
                        data += "VACIO";
                    }
                    else
                    {
                        data += tabla.Rows[r].Cells[c].Value;
                    }
                    data += Environment.NewLine;
                }
            }
            File.WriteAllText(Environment.CurrentDirectory+"TablaAS.txt", terminales + Environment.NewLine + noterminales + Environment.NewLine + numestados + Environment.NewLine + data);*/
        }

        //Metodo para reducir la pila
        public bool reducir(Separa rg, Produccion pila, DataGridView tablan)
        {
            string cad;
            if (rg.derecha[0].ltok[0].nom == "ε")
            {
                cad = buscacel(tablan, int.Parse(pila.ult().nom), rg.ladoIzq.nCol);
                pila.nuevo(rg.ladoIzq);
                pila.nuevo(new NT(cad));
            }
            else
            {
                for (int i = rg.derecha[0].ltok.Count - 1; i >= 0; i--)
                {
                    pila.removult();
                    if (pila.ult().nom == rg.derecha[0].ltok[i].nom)
                    {
                        if (pila.ult().valex != null)
                        {
                                PilaNodos.Insert(0,new Nodo(pila.ult().valex));
                        }
                        pila.removult();
                    }
                    else
                        return false;
                }
           
                   Acc(ReduTemp,PilaTemporal);
               
            }
            return true;
        }

        //Metodo que busca una celda en especifico en la tabla de AS.
        public string buscacel(DataGridView tabs, int row, int col)
        {
            string valor;
            if (tabs[col, row].Value == null)
                valor = "";
            else
                valor = tabs[col, row].Value.ToString();
            return valor;
        }

        //Metodo para verificar que una cadena sea valida y regresa la respuesta si es o no valida
        public bool evaluar(RichTextBox bloc2, DataGridView tabla, DataGridView tablaAS)
        {
            int row;
            string linea;
            Produccion pila = new Produccion();
            Produccion cadena = new Produccion();
            string cadPila = "";
            string cadCad = "";
            string accion = "";
            List<Separa> listaR = new List<Separa>();
                     
            PilaNodos.Clear();
            tabla.Rows.Clear();
            RaizTemp = null;
            Conexion = new List<Nodo>();
            if (lregl.Count == 0)
            {
                MessageBox.Show("No es LR1");
                return false;
            }

            Separa nuevaR;
            foreach (Separa r in lregl)
            {
                foreach (Produccion prod in r.derecha)
                {
                    nuevaR = new Separa();
                    nuevaR.ladoIzq = r.ladoIzq;
                    nuevaR.derecha.Add(prod);
                    listaR.Add(nuevaR);
                }
            }

            pila.agregatkprim(contks.buscar("$"));
            pila.agregatkprim(new NT("0"));

            for (int fila = 0; fila < bloc2.Lines.Count(); fila++)
            {
                linea = bloc2.Lines[fila];
                if (linea.Length > 0)
                {
                    linea = linea + " \0";
                    if (cadena.creaCadena(linea, contks) == false)
                        return false;
                }
            }

            cadena.agregatkprim(contks.buscar("$"));

            while (accion != "Aceptar")
            {
                acciontrad = "";
                accion = buscacel(tablaAS, int.Parse(pila.ult().nom), cadena.primero().nCol);
                cadPila = pila.muestracontprod();
                cadCad = cadena.muestracontprod();
                if (accion != "")
                {
                    if (accion[0] == 'D')
                    {
                        linea = accion.Replace("Desplazar a ", "");
                        if( linea == "5"|| linea == "206" || linea == "223" || linea == "21" || linea == "156" || linea == "140" || linea == "164")
                        {
                            PilaContSent.Insert(0, 0);
                        }
                        pila.nuevo(cadena.quitaPrimero());
                        pila.nuevo(new NT(linea));
                    }
                    if (accion[0] == 'R')
                    {
                       
                        linea = accion.Replace("Reducir ", "");
                        if(linea == "39" )
                        {
                            Skip = false;
                        }
                        if (linea == "36")
                        {
                            Skip = false;
                        }
                        if( linea == "26")
                        {
                            Skip = false;
                        }

                        row = int.Parse(linea);
                        ReduTemp = row;
                        accion += "   " + listaR[row].mostrarr() ;
                        if ((reducir(listaR[row], pila, tablaAS) == true))
                        {
                            if (listaR[row].derecha[0].ltok[0].nom != "ε")
                            {
                                linea = buscacel(tablaAS, int.Parse(pila.ult().nom), listaR[row].ladoIzq.nCol);
                                pila.nuevo(listaR[row].ladoIzq);
                                pila.nuevo(new NT(linea));
                            }
                        }
                        else return false;
                    }
                }
                else return false;
                tabla.Rows.Add(cadPila, cadCad, accion, acciontrad);
            }
            return true;
        }

        public bool Acc(int NumRedu,List<Nodo> nodos)
        {
           if(true)
            {
                switch (NumRedu)
                {

                    case 64:
                        Nodo left_64, right_64, papa_64;
                        papa_64 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_64 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_64 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_64.izq = left_64; papa_64.der = right_64;
                        PilaNodos.Insert(0, papa_64);
                        break;
                    case 62: // term opmult potencia
                        Nodo left_62, right_62, papa_62;
                        right_62 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_62 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_62 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_62.izq = left_62; papa_62.der = right_62;
                        PilaNodos.Insert(0, papa_62);
                        break;
                    case 63: // term opmult potencia
                        break;

                    case 51:
                        Nodo left_51, right_51, papa_51;
                        right_51 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_51 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_51 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_51.izq = left_51; papa_51.der = right_51;
                        PilaNodos.Insert(0, papa_51);
                        break;
                    case 50:
                        break;
                    case 49:
                        break;
                    case 48:
                        break;
                    case 46:
                        Nodo left, right, papa;
                        right = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa.izq = left; papa.der = right;
                        PilaNodos.Insert(0, papa);
                        break;
                    case 45:
                        break;
                    case 44:
                        break;
                    case 43:
                        Nodo left_43, right_43, papa_43;
                        String tam = (string)PilaNodos.First().info; PilaNodos.RemoveAt(0);
                        Nodo tipo=null;
                        for (var i42 = 0; i42 < PilaNodos.Count; i42++)
                        {
                            if(((String)PilaNodos[i42].info != "int") && ((String)PilaNodos[i42].info != "float") &&
                                   ((String)PilaNodos[i42].info != "int") && ((String)PilaNodos[i42].info != "string") &&
                                   ((String)PilaNodos[i42].info != "vent") && ((String)PilaNodos[i42].info != "textBox") &&
                                   ((String)PilaNodos[i42].info != "label") && ((String)PilaNodos[i42].info != "boton"))
                            {
                            }
                            else
                            {
                                tipo = new Nodo((String)PilaNodos[i42].info);
                            }
                            
                        }
                       
                        while (((String)PilaNodos[1].info != "int") && ((String)PilaNodos[1].info != "float") &&
                            ((String)PilaNodos[1].info != "int") && ((String)PilaNodos[1].info != "string") &&
                            ((String)PilaNodos[1].info != "vent") && ((String)PilaNodos[1].info != "textBox") &&
                            ((String)PilaNodos[1].info != "label") && ((String)PilaNodos[1].info != "boton"))
                        {

                            left_43 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            right_43 = tipo;
                            papa_43 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            papa_43.izq = left_43; papa_43.der = right_43;
                            PilaNodos.Insert(0, papa_43);
                        }
                        left_43 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_43 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_43 = new Nodo("DEF_ARR");
                        papa_43.izq = left_43; papa_43.der = right_43;  papa_43.der.der = new Nodo(tam);
                        PilaNodos.Insert(0, papa_43);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 42:
                        Nodo left_42, right_42, papa_42;
                        Nodo tipo_42 = null;
                        for (var i42 = 0; i42 < PilaNodos.Count; i42++)
                        {
                            if (((String)PilaNodos[i42].info != "int") && ((String)PilaNodos[i42].info != "float") &&
                                   ((String)PilaNodos[i42].info != "int") && ((String)PilaNodos[i42].info != "string") &&
                                   ((String)PilaNodos[i42].info != "vent") && ((String)PilaNodos[i42].info != "textBox") &&
                                   ((String)PilaNodos[i42].info != "label") && ((String)PilaNodos[i42].info != "boton"))
                            {
                            }
                            else
                            {
                                tipo_42 = new Nodo((String)PilaNodos[i42].info);
                            }

                        }
                        while (((String)PilaNodos[1].info != "int") && ((String)PilaNodos[1].info != "float") &&
                                ((String)PilaNodos[1].info != "int") && ((String)PilaNodos[1].info != "string") &&
                                ((String)PilaNodos[1].info != "vent") && ((String)PilaNodos[1].info != "textBox") &&
                                ((String)PilaNodos[1].info != "label") && ((String)PilaNodos[1].info != "boton"))
                        {

                            left_42 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            right_42 = tipo_42;
                            papa_42 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            papa_42.izq = left_42; papa_42.der = right_42;
                            PilaNodos.Insert(0, papa_42);

                        }
                        left_42 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_42 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_42 = new Nodo("DEF_VAR");
                        papa_42.izq = left_42; papa_42.der = right_42;
                        PilaNodos.Insert(0, papa_42);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 41:
                        Nodo  right41, padre41;
                        padre41 = new Nodo("MessageBox");
                        right41 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre41.der = right41;
                        PilaNodos.Insert(0,padre41 );
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }

                        break;
                    case 40:
                        break;
                    case 39:
                        Nodo left1, right1, padre1;

                        if( RaizTemp == null)
                        {
                            padre1 = new Nodo("case");
                            left1 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            right1 = PilaNodos[0]; PilaNodos.RemoveAt(0);
                            padre1.izq = left1; padre1.der = right1;
                            RaizTemp = padre1;
                        }
                        else
                        {
                            Nodo recorre = RaizTemp;
                            while(recorre.der!=null)
                            {
                                recorre = recorre.der;
                            }
                            padre1 = new Nodo("case");
                            left1 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            right1 = PilaNodos[0]; PilaNodos.RemoveAt(0);
                            padre1.izq = left1; padre1.der = right1;
                            recorre.der = padre1;
                        }
                       
                        break;
                    case 37:
                       
                        break;
                    case 36:
                        PilaNodos.Insert(0, RaizTemp);  RaizTemp = null;
                        Nodo right_37, left_37, padre_37;
                        padre_37 = new Nodo("switch");
                        right_37 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_37 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_37.izq = left_37; padre_37.der = right_37;
                        PilaNodos.Insert(0, padre_37);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 35:
                        Nodo right_35, left_35, padre_35;

                        right_35 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_35 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_35 = new Nodo("while");
                        padre_35.izq = left_35; padre_35.der = right_35;
                        PilaNodos.Insert(0, padre_35);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 34:
                        Nodo right_34, left_34, padre_34;

                        right_34 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_34 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_34 = new Nodo("while");
                        padre_34.izq = left_34; padre_34.der = right_34;
                        PilaNodos.Insert(0, padre_34);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 33:
                        Nodo right_33, left_33, padre_33;

                        left_33 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_33 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_33 = new Nodo(":=");
                        padre_33.izq = left_33; padre_33.der = right_33;

                        right_33.der = new Nodo("ID["+PilaNodos.First().info+"]"); PilaNodos.RemoveAt(0);
                        right_33.izq = null;
                        
                        PilaNodos.Insert(0, padre_33);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 32:
                        Nodo right_32, left_32, padre_32;

                        left_32 = PilaNodos[0]; PilaNodos.RemoveAt(0);
                        left_32.der = new Nodo("ID[" + PilaNodos.First().info + "]"); PilaNodos.RemoveAt(0);
                        left_32.izq = null;
                        right_32 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_32 = new Nodo(":=");
                        padre_32.izq = left_32; padre_32.der = right_32;
                        PilaNodos.Insert(0, padre_32);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 31:
                        Nodo right_31, left_31, padre_31;

                        left_31 = PilaNodos[0]; PilaNodos.RemoveAt(0);
                        left_31.der = new Nodo("NUM[" + PilaNodos.First().info + "]"); PilaNodos.RemoveAt(0);
                        left_31.izq = null;
                        right_31 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_31 = new Nodo(":=");
                        padre_31.izq = left_31; padre_31.der = right_31;
                        PilaNodos.Insert(0, padre_31);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 30:
                        Nodo right_30, left_30, padre_30;

                        left_30 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_30 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_30 = new Nodo(":=");
                        padre_30.izq = left_30; padre_30.der = right_30;

                        right_30.der = new Nodo("NUM[" + PilaNodos.First().info + "]"); PilaNodos.RemoveAt(0);
                        right_30.izq = null;

                        PilaNodos.Insert(0, padre_30);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }

                        break;
                    case 29:
                        Nodo right_29, left_29, padre_29;

                        left_29 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        right_29 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_29 = new Nodo(":=");
                        padre_29.izq = left_29; padre_29.der = right_29;
                        PilaNodos.Insert(0, padre_29);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 28:
                       
                        break;
                    case 27:
                        Nodo left_27, right_27, papa_27;
                        PilaNodos.Insert(1, new Nodo("else"));
                        right_27 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_27 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_27 = new Nodo("if");  left_27.der = PilaNodos.First(); PilaNodos.RemoveAt(0); left_27.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_27.izq = left_27; papa_27.der = right_27;
                        PilaNodos.Insert(0, papa_27);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 26:
                        Nodo left_26, right_26, papa_26;
                        papa_26 = new Nodo("if");
                        right_26 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        left_26 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        papa_26.izq = left_26; papa_26.der = right_26;
                        PilaNodos.Insert(0,papa_26);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 15:
                        Nodo right_15, papa_15;
                        if (PilaContSent.Count > 0)
                        {
                            while (PilaContSent[0] > 0)
                            {
                                right_15 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                                if ((String)right_15.info == "SECUENCIA" && right_15.izq == null)
                                {
                                    right_15.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                                    papa_15 = right_15;
                                }
                                else
                                {
                                    papa_15 = new Nodo("SECUENCIA");
                                    papa_15.der = right_15;
                                }
                                PilaNodos.Insert(0, papa_15);
                                PilaContSent[0]--;
                            }
                            PilaContSent.RemoveAt(0);
                        }
                        break;
                    case 14:
                        Nodo right_14, papa_14;
                        if (PilaContSent.Count > 0)
                        {
                            while (PilaContSent[0] > 0)
                            {
                                right_14 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                                if ((String)right_14.info == "SECUENCIA" && right_14.izq == null)
                                {
                                    right_14.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                                    papa_14 = right_14;
                                }
                                else
                                {
                                    papa_14 = new Nodo("SECUENCIA");
                                    papa_14.der = right_14;
                                }

                                PilaNodos.Insert(0, papa_14);
                                PilaContSent[0]--;
                            }
                            PilaContSent.RemoveAt(0);
                        }
                        break;
                    case 12:
                        Nodo padre_12, left_12;
                        padre_12 = new Nodo("Click");
                        left_12 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        padre_12.izq = left_12;
                        PilaNodos.Insert(0, padre_12);
                        break;
                    case 13:
                        while (PilaNodos.Count >1 )
                        {
                            right_14 = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            if ((String)right_14.info == "SECUENCIA" && right_14.izq == null)
                            {
                                right_14.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                                papa_14 = right_14;
                            }
                            else
                            {
                                papa_14 = new Nodo("SECUENCIA");
                                papa_14.der = right_14;
                            }

                            PilaNodos.Insert(0, papa_14);
                        }
                        break;
                    case 11:
                        Nodo raiz_11, recorre_11;
                        int contParams_11 = 0;
                        raiz_11 = new Nodo("CreaLabel");
                        while (contParams_11 <4 )
                        {
                            recorre_11 = raiz_11;
                            while (recorre_11.izq != null)
                            {
                                recorre_11 = recorre_11.izq;
                            }
                            recorre_11.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            contParams_11++;
                        }
                        PilaNodos.Insert(0, raiz_11);
                        break;
                    case 10:
                        Nodo raiz_10, recorre_10;
                        int contParams_10 = 0;
                        raiz_10 = new Nodo("CreaTextbox");
                         while (contParams_10 < 5)
                        {
                            recorre_10 = raiz_10;
                            while (recorre_10.izq != null)
                            {
                                recorre_10 = recorre_10.izq;
                            }
                            recorre_10.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            contParams_10++;
                        }
                        PilaNodos.Insert(0, raiz_10);
                        break;
                    case 9:
                        Nodo raiz, recorre_9;
                        int contParams_9 = 0 ;
                        raiz = new Nodo("CreaBoton");
                        while(contParams_9<6)
                        {
                            recorre_9 = raiz;
                            while(recorre_9.izq != null)
                            {
                                recorre_9 = recorre_9.izq;
                            }
                            recorre_9.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            contParams_9++;
                        }
                        raiz.der = PilaNodos.First(); PilaNodos.RemoveAt(0);
                        PilaNodos.Insert(0, raiz);
                        break;
                    case 7:
                        break;
                    case 6:
                        Nodo  padre_6, recorre_6;
                        int contParms_6 = 0;
                        padre_6 = new Nodo("CreaVentana");

                        while (contParms_6 < 2)
                        {
                            recorre_6 = padre_6;
                            while (recorre_6.izq != null)
                            {
                                recorre_6 = recorre_6.izq;
                            }
                            recorre_6.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            contParms_6++;
                        }

                        while ((String)PilaNodos[0].info == "CreaBoton" || (String)PilaNodos[0].info == "CreaTextbox"
                            || (String)PilaNodos[0].info == "CreaLabel")
                        {
                            Conexion.Insert(0, PilaNodos.First()); PilaNodos.RemoveAt(0);
                            if (PilaNodos.Count == 0)
                            {
                                break;
                            }
                        }
                        recorre_6 = Conexion.First(); Conexion.RemoveAt(0);
                        Nodo raiz_6 = recorre_6;
                        while (Conexion.Count > 0)
                        {
                            while (recorre_6.der != null)
                            {
                                recorre_6 = recorre_6.der;
                            }
                            recorre_6.der = Conexion.First(); Conexion.RemoveAt(0);
                        }
                        padre_6.der = raiz_6;
                        PilaNodos.Insert(0, padre_6);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                    case 5:
                        Nodo padre_5;
                        int contParms_5 = 0;
                        padre_5 = new Nodo("CreaVentana");
                        
                        while (contParms_5 < 6)
                        {
                            recorre_10 = padre_5;
                            while (recorre_10.izq != null)
                            {
                                recorre_10 = recorre_10.izq;
                            }
                            recorre_10.izq = PilaNodos.First(); PilaNodos.RemoveAt(0);
                            contParms_5++;
                        }
                        
                        while ((String)PilaNodos[0].info == "CreaBoton" || (String)PilaNodos[0].info == "CreaTextbox"
                            || (String)PilaNodos[0].info == "CreaLabel")
                        {
                            Conexion.Insert(0, PilaNodos.First()); PilaNodos.RemoveAt(0);
                            if(PilaNodos.Count==0)
                            {
                                break;
                            }
                        }
                        recorre_10 = Conexion.First(); Conexion.RemoveAt(0);
                       Nodo  raiz_5 = recorre_10;
                        while (Conexion.Count > 0)
                        {
                            while (recorre_10.der != null)
                            {
                                recorre_10 = recorre_10.der;
                            }
                            recorre_10.der = Conexion.First(); Conexion.RemoveAt(0);
                        }
                        padre_5.der = raiz_5;
                        PilaNodos.Insert(0,padre_5);
                        if (PilaContSent.Count > 0)
                        {
                            PilaContSent[0]++;
                        }
                        break;
                }
            }
            return true;
        }

        public void RecorreArbol()
        {
            Nodo recorre,raiz;
            PilaUnknowVals.Clear();
            PilaListDeclaraciones.Clear();
            Errores.Clear();
            tree = new TreeView();
            tree.Size = new Size(1042, 720);
            raiz = PilaNodos[0];
            recorre = raiz;
            tree.Nodes.Add((String)recorre.info);
            Recursivo(recorre,tree.Nodes[0]);
            muestra_cuadruplos();
            muestra_simbolos();
            tree.ExpandAll();
        }

        public void Recursivo(Nodo node,TreeNode tree)
        {
            if(node!=null)
            { 
                TreeNode aux = new TreeNode((String)node.info);
                tree.Nodes.Add(aux);
                GeneraCuadruplos(node);
                if (node.izq != null)
                {
                    Recursivo(node.izq, aux);
                }
                
                if (node.der != null)
                {
                    Recursivo(node.der, aux);
                }
                
            }
        }

        public void GeneraCuadruplos(Nodo node)
        {
            String tipo, id;
            switch ((String)node.info)
            {
                case "SENTENCIA":
                    break;
                case "if":
                  //  Cuadruplos.Add(new Cuadruplo("if",idCuadruplo+1,idCuadruplo+2,tem,idCuadruplo))
                    int i = 0;
                    break;
                case "else":
                    int j = 0;
                    break;
                case "while":
                    int k = 0;
                    break;
                case "switch":
                    break;
                case "case":
                    break;
                case "MessageBox":
                    String cadena = (String)node.der.info;
                    String slC = cadena.Replace("\"", "");

                    PilaMessageBox.Add(new MessageB(slC));
                    break;
                case "CreaVentana":
                    int w = 1;
                    break;
                case "CreaLabel":
                    String idLabel = (String)node.izq.info;
                    String stringLabel = (String)node.izq.izq.info;
                    String slN = stringLabel.Replace("\"", "");

                    int c1 = int.Parse((string)node.izq.izq.izq.info);
                    int c2 = int.Parse((string)node.izq.izq.izq.izq.info);

                    PilaLabel.Add(new Label(idLabel, slN, c1, c2));
                    break;
                case "CreaBoton":
                    String idBoton = (String)node.izq.info;
                    String cadenaBoton = (String)node.izq.izq.info;
                    String cb2 = cadenaBoton.Replace("\"", "");

                    int a1 = int.Parse((string)node.izq.izq.izq.info);
                    int b1 = int.Parse((string)node.izq.izq.izq.izq.info);
                    int a2 = int.Parse((string)node.izq.izq.izq.izq.izq.info);
                    int b2 = int.Parse((string)node.izq.izq.izq.izq.izq.izq.info);

                    PilaBotones.Add(new Boton(idBoton, cb2, a1, b1, a2, b2));
                    break;
                case "CreaTextbox":
                    String nombreTb = (String)node.izq.info;
                    int x1 = int.Parse((string)node.izq.izq.info);
                    int y1 = int.Parse((string)node.izq.izq.izq.info);
                    int x2 = int.Parse((string)node.izq.izq.izq.izq.info);
                    int y2 = int.Parse((string)node.izq.izq.izq.izq.izq.info);

                    PilaElementosVentana.Add(new ElementoVentana(nombreTb, x1, y1, x2, y2));
                    Simbolos.Add(new Simbolo(nombreTb, "\0", idSimbolo));
                    idSimbolo++;
                    break;
                case "Click":
                    int u = 1;
                    break;
                case "DEF_VAR":
                    tipo = (String)node.der.info;
                    id = (String)node.izq.info;
                    if (!PilaListDeclaraciones.Exists(x => x.id == id))
                    {
                        PilaListDeclaraciones.Add(new Variable(tipo, id));
                        defaultf = "DEF_VAR"; //Activa bandera para indicar que se estan haciendo asignaciones
                    }
                    else
                    {
                        Errores.Add("Error:Ya se ha declarado previamente la variable" + id);
                    }
                    break;
                case "DEF_ARR":
                    tipo = "ARR-"+(String)node.der.info+"-"+node.der.der.info;  //Genera una variable con toda la informacion especificada en los guiones 
                    id = (String)node.izq.info;
                    if (!PilaListDeclaraciones.Exists(x => x.id == id))
                    {
                        PilaListDeclaraciones.Add(new Variable(tipo, id));
                        defaultf = "DEF_ARR"; //Activa bandera para indicar que se estan haciendo asignaciones
                    }
                    else
                    {
                        Errores.Add("Error:Ya se ha declarado previamente la variable" + id);
                    }
                    break;
                case "int":
                    break;
                case "string":
                    break;
                case "vent":
                    break;
                case "textBox":
                    break;
                case "label":
                    break;
                case "boton":
                    break;
                case "float":
                    break;
                case ":=":
                    String OPERADOR = (string)node.info;
                    String OPERANDO1 = (string)node.izq.info;
                    String OPERANDO2 = (string)node.izq.info;

                    if((string)node.der.info == "+"||(string)node.der.info == "-" ||
                        (string)node.der.info == "*"||(string)node.der.info == "/")
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR, OPERANDO1,temp + tempCount, OPERANDO1, idCuadruplo));
                        temporales.Add(new Temporal(temp+tempCount, "0", idTemporal));
                        Simbolos.Add(new Simbolo(temp+tempCount, valorInicial.ToString(), idSimbolo));
                        cuadruploTemp = Cuadruplos.Last();  cuadruploTemp.RANGO++;  cuadruploTemp.final = idCuadruplo;
                        idTemporal++;
                        tempCount++;
                        idSimbolo++;
                        idCuadruplo++;
                    }
                    else
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR, OPERANDO1, OPERANDO2,OPERANDO1, idCuadruplo));
                        cuadruploTemp.RANGO++;   cuadruploTemp.final = idCuadruplo;
                        cuadruploTemp = null;
                        idCuadruplo++;
                    }
                  /*  if(node.der.izq != null)
                    {
                        String OPERANDO2 = (string)node.der.der.info;
                        String OPERANDO3 = (string)node.der.izq.info;
                        String tempActual = temp + tempCount.ToString();

                        if (node.der.der.izq != null)
                        {
                            String OPERANDO4 = (string)node.der.der.der.info;
                            String OPERANDO5 = (string)node.der.der.izq.info;
                            tempCount++;
                            String temp2 = temp + tempCount.ToString();

                            if (node.der.der.izq.izq != null)
                            {
                                String OPERANDO6 = (string)node.der.der.izq.izq.info;
                                String OPERANDO7 = (string)node.der.der.izq.der.info;
                                tempCount++;
                                String temp3 = temp + tempCount.ToString();

                                if (node.der.der.izq.izq.izq != null)
                                {
                                    String OPERANDO8 = (string)node.der.der.izq.izq.izq.info;
                                    String OPERANDO9 = (string)node.der.der.izq.izq.der.info;
                                    tempCount++;
                                    String temp4 = temp + tempCount.ToString();

                                    Cuadruplos.Add(new Cuadruplo(OPERANDO6, OPERANDO8, OPERANDO9, temp4, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO5, temp4, OPERANDO7, temp3, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO2, temp3, OPERANDO4, temp2, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO1, OPERANDO3, temp2, tempActual, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                                    idCuadruplo++;

                                    temporales.Add(new Temporal(tempActual, "0", idTemporal));
                                    idTemporal++;
                                    temporales.Add(new Temporal(temp2, "0", idTemporal));
                                    idTemporal++;
                                    temporales.Add(new Temporal(temp3, "0", idTemporal));
                                    idTemporal++;
                                    temporales.Add(new Temporal(temp4, "0", idTemporal));
                                    idTemporal++;

                                    tempCount++;
                                    
                                    Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(temp2, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(temp3, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(temp4, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                }
                                else
                                {
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO5, OPERANDO6, OPERANDO7, temp3, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO2, temp3, OPERANDO4, temp2, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERANDO1, OPERANDO3, temp2, tempActual, idCuadruplo));
                                    idCuadruplo++;
                                    Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                                    idCuadruplo++;

                                    temporales.Add(new Temporal(tempActual, "0", idTemporal));
                                    idTemporal++;
                                    temporales.Add(new Temporal(temp2, "0", idTemporal));
                                    idTemporal++;
                                    temporales.Add(new Temporal(temp3, "0", idTemporal));
                                    idTemporal++;

                                    tempCount++;

                                    Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(temp2, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                    Simbolos.Add(new Simbolo(temp3, valorInicial.ToString(), idSimbolo));
                                    idSimbolo++;
                                }
                            }
                            else
                            {
                                Cuadruplos.Add(new Cuadruplo(OPERANDO3, OPERANDO4, OPERANDO5, temp2, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERANDO1, temp2, OPERANDO2, tempActual, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                                idCuadruplo++;

                                temporales.Add(new Temporal(tempActual, "0", idTemporal));
                                idTemporal++;
                                temporales.Add(new Temporal(temp2, "0", idTemporal));
                                idTemporal++;

                                tempCount++;

                                Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(temp2, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                            }
                        }
                        else if (node.der.izq.der != null)
                        {
                            String OPERANDO4 = (string)node.der.izq.der.info;
                            String OPERANDO5 = (string)node.der.izq.izq.info;
                            tempCount++;
                            String temp2 = temp + tempCount.ToString();

                            if (node.der.izq.izq.izq != null)
                            {
                                String OPERANDO6 = (string)node.der.izq.izq.izq.info;
                                String OPERANDO7 = (string)node.der.izq.izq.der.info;
                                tempCount++;
                                String temp3 = temp + tempCount.ToString();

                                Cuadruplos.Add(new Cuadruplo(OPERANDO5, OPERANDO6, OPERANDO7, temp3, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERANDO3, temp3, OPERANDO4, temp2, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERANDO1, temp2, OPERANDO2, tempActual, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                                idCuadruplo++;

                                temporales.Add(new Temporal(tempActual, "0", idTemporal));
                                idTemporal++;
                                temporales.Add(new Temporal(temp2, "0", idTemporal));
                                idTemporal++;
                                temporales.Add(new Temporal(temp3, "0", idTemporal));
                                idTemporal++;

                                tempCount++;

                                Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(temp2, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(temp3, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                            }
                            else
                            {
                                Cuadruplos.Add(new Cuadruplo(OPERANDO3, OPERANDO4, OPERANDO5, temp2, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERANDO1, temp2, OPERANDO2, tempActual, idCuadruplo));
                                idCuadruplo++;
                                Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                                idCuadruplo++;

                                temporales.Add(new Temporal(tempActual, "0", idTemporal));
                                idTemporal++;
                                temporales.Add(new Temporal(temp2, "0", idTemporal));
                                idTemporal++;

                                tempCount++;

                                Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                                Simbolos.Add(new Simbolo(temp2, valorInicial.ToString(), idSimbolo));
                                idSimbolo++;
                            }
                        }
                        else
                        {
                            Cuadruplos.Add(new Cuadruplo(OPERANDO1, OPERANDO3, OPERANDO2, tempActual, idCuadruplo));
                            idCuadruplo++;
                            Cuadruplos.Add(new Cuadruplo(OPERADOR, tempActual, "", RESULTADO, idCuadruplo));
                            idCuadruplo++;
                            temporales.Add(new Temporal(tempActual, "0", idTemporal));
                            idTemporal++;
                            tempCount++;

                            Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                            idSimbolo++;
                            Simbolos.Add(new Simbolo(tempActual, valorInicial.ToString(), idSimbolo));
                            idSimbolo++;
                        }
                    }
                    else
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR, OPERANDO1, "", RESULTADO, idCuadruplo));
                        idCuadruplo++;

                        Simbolos.Add(new Simbolo(RESULTADO, valorInicial.ToString(), idSimbolo));
                        idSimbolo++;
                    }*/
                    break;
                case "+":
                    //    Cuadruplos.Add(new Cuadruplo(node.info,node.izq.info,node.der.info,))
                     OPERADOR = (string)node.info;
                     OPERANDO1 = (string)node.der.info;
                     OPERANDO2 = (string)node.izq.info;

                    if ((string)node.izq.info == "+" || (string)node.izq.info == "-" ||
                        (string)node.izq.info == "*" || (string)node.izq.info == "/")
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR, OPERANDO1, temp + tempCount, OPERANDO1, idCuadruplo));
                        temporales.Add(new Temporal(temp + tempCount, "0", idTemporal));
                        Simbolos.Add(new Simbolo(temp + tempCount, valorInicial.ToString(), idSimbolo));
                        cuadruploTemp.RANGO++;
                        idTemporal++;
                        tempCount++;
                        idSimbolo++;
                        idCuadruplo++;
                    }
                    else
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR, OPERANDO1, OPERANDO2, OPERANDO1, idCuadruplo));
                        cuadruploTemp.RANGO++; 
                        cuadruploTemp = null;
                        idCuadruplo++;
                    }
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                case ">":
                    String OPERADOR_ = (string)node.info;
                    String OPERANDO1_ = (string)node.izq.info;
                    String OPERANDO2_ = (string)node.der.info;
                    String RESULTADO_ = temp + tempCount.ToString();
                    String RESULTADO2_ = "";

                    if (node.izq.izq != null)
                    {
                        tempCount++;
                        String OP3_ = (string)node.izq.izq.info;
                        String OP4_ = (string)node.izq.der.info;
                        RESULTADO2_ = temp + tempCount.ToString();

                        Cuadruplos.Add(new Cuadruplo(OPERANDO1_, OP3_, OP4_, RESULTADO2_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RESULTADO2_, "", idSimbolo));
                        idSimbolo++;
                        Cuadruplos.Add(new Cuadruplo(OPERADOR_, RESULTADO2_, OPERANDO2_, RESULTADO_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RESULTADO_, "", idSimbolo));
                        idSimbolo++;
                        tempCount++;
                    }
                    else
                    {
                        Cuadruplos.Add(new Cuadruplo(OPERADOR_, OPERANDO1_, OPERANDO2_, RESULTADO_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RESULTADO_, "", idSimbolo));
                        idSimbolo++;
                        tempCount++;
                    }
                    break;
                case "<":
                    String OP_ = (string)node.info;
                    String OP1_ = (string)node.izq.info;
                    String OP2_ = (string)node.der.info;
                    String RES_ = temp + tempCount.ToString();
                    String RES2_ = "";

                    if (node.der.izq != null)
                    {
                        tempCount++;
                        String OP3_ = (string)node.der.izq.info;
                        String OP4_ = (string)node.der.der.info;
                        RES2_ = temp + tempCount.ToString();

                        Cuadruplos.Add(new Cuadruplo(OP2_, OP4_, OP3_, RES2_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RES2_, "", idSimbolo));
                        idSimbolo++;
                        Cuadruplos.Add(new Cuadruplo(OP_, OP1_, RES2_, RES_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RES_, "", idSimbolo));
                        idSimbolo++; 
                        tempCount++;
                    }
                    else
                    {
                        Cuadruplos.Add(new Cuadruplo(OP_, OP1_, OP2_, RES_, idCuadruplo));
                        idCuadruplo++;
                        Simbolos.Add(new Simbolo(RES_, "", idSimbolo));
                        idSimbolo++;
                        tempCount++;
                    }
                    break;
                case "==":
                    String OP = (string)node.info;
                    String OP1 = (string)node.izq.info;
                    String OP2 = (string)node.der.info;
                    String RES = temp + tempCount.ToString();
                    Cuadruplos.Add(new Cuadruplo(OP, OP1, OP2, RES, idCuadruplo));
                    idCuadruplo++;
                    Simbolos.Add(new Simbolo(RES, "", idSimbolo));
                    idSimbolo++;
                    tempCount++;
                    break;
                case "^":
                    break;
                default:
                    switch(defaultf)
                    {
                        case "DEF_VAR":
                            if(node.izq!=null)
                            {
                                tipo = (String)node.der.info;
                                id = (String)node.izq.info;
                                if (!PilaListDeclaraciones.Exists(x=>x.id == id))
                                    PilaListDeclaraciones.Add(new Variable(tipo, id));
                                else
                                    Errores.Add("Error:Ya se ha declarado previamente la variable" + id);
                            }
                            else
                                defaultf = "NONE";
                            //Desactiva bandera para indicar que se estan haciendo asignaciones
                            break;
                        case "DEF_ARR":
                            if (node.izq != null)
                            {
                                String tamlast = PilaListDeclaraciones.Last().tipo.Split('-')[2]; //Toma el tamaño de la ultima variable declarada en la misma linea
                                tipo = "ARR-"+(String)node.der.info+"-"+tamlast; 
                                id = (String)node.izq.info;
                                if (!PilaListDeclaraciones.Exists(x => x.id == id))
                                    PilaListDeclaraciones.Add(new Variable(tipo, id));
                                else
                                    Errores.Add("Error:Ya se ha declarado previamente la variable" + id);
                            }
                            else
                                defaultf = "NONE";
                            //Desactiva bandera para indicar que se estan haciendo asignaciones
                            break;
                    }
                    break;            
            }
        }

        public void muestra_cuadruplos()
        {
            foreach(Cuadruplo c in Cuadruplos)
            {
                tablaCu.Rows.Add(c.OPERADOR, c.OPERANDO1, c.OPERANDO2, c.RESULTADO);
            }
        }

        public void muestra_simbolos()
        {
            foreach(Simbolo s in Simbolos)
            {
                tablaSi.Rows.Add(s.simbolo, s.valor);
            }
        }
    }
}
