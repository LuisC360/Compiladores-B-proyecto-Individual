using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores
{
    class Variable
    {
        public Variable(String tipo, String id)
        {
            
            switch(tipo)
            {
                case "int":
                    variable = new Int32();
                    break;
                case "label":
                    variable = new Label(id, "id", 0, 0);
                    break;
                case "textBox":
                    variable = new TextBox();
                    break;
                case "string":
                    variable = "";
                    break;
                case "vent":
                    variable = new Form();
                    break;
                case "boton":
                    variable = new Button();
                    break;
                case "float":
                    variable = new float();
                    break;
                default:
                    String[] split = tipo.Split('-');
                    int tam_arr = Convert.ToInt32(split[2]);
                    tipo = split[0] + "-" + split[1];
                    switch(tipo)
                    {
                        case "ARR-int":
                            variable = new Int32[tam_arr];
                            break;
                        case "ARR-label":
                            variable = new Label[tam_arr];
                            break;
                        case "ARR-textBox":
                            variable = new TextBox[tam_arr];
                            break;
                        case "ARR-string":
                            variable = new String[tam_arr];
                            break;
                        case "ARR-vent":
                            variable = new Form[tam_arr];
                            break;
                        case "ARR-boton":
                            variable = new Button[tam_arr];
                            break;
                        case "ARR-float":
                            variable = new float[tam_arr];
                            break;
                    }
                    break;

            }
           
            this.tipo = tipo;
            this.id = id;
        }
        public String tipo;
        public String id;
        public object variable;
    }
}
