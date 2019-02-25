using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores
{
    public partial class Form1 : Form
    {
        Algoritmos principal;

        public Form1()
        {
            InitializeComponent();
            principal = new Algoritmos(richTextBox1, tablaCu, tablaSi);
            LoadFile();
            button3_Click(this, null);
        }

        //Cuando se presiona el boton de abrir en la gramatica se abre una ventana para poder
        //abrir un archivo.
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = Environment.CurrentDirectory;
            abrir.RestoreDirectory = true;
            string line;

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(abrir.FileName);
                richTextBox1.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox1.Text += line + Environment.NewLine;
                }
                file.Close();
            }
        }

        private void LoadFile()
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(Environment.CurrentDirectory+"\\TinyFinal.txt");
            richTextBox1.Clear();
            while ((line = file.ReadLine()) != null)
            {
                richTextBox1.Text += line + Environment.NewLine;
            }
            file.Close();
        }
        //Al presionar el boton de guardar en la gramatica se activa esta funcion.
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.InitialDirectory = Environment.CurrentDirectory;

            guarda.DefaultExt = "*.txt";
            guarda.Filter = "txt Files|*.txt";

            if (guarda.ShowDialog() == System.Windows.Forms.DialogResult.OK && guarda.FileName.Length > 0)
            {
                richTextBox1.SaveFile(guarda.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        //Este funcion se activa cuando se quiere abrir un codigo
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = Environment.CurrentDirectory;
            abrir.RestoreDirectory = true;
            string line;

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(abrir.FileName);
                richTextBox2.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox2.Text += line + Environment.NewLine;
                }
                file.Close();
            }
        }

        //Esta funcion guarda el texto de la parte de codigo al presionar el boton.
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.InitialDirectory = Environment.CurrentDirectory;

            guarda.DefaultExt = "*.txt";
            guarda.Filter = "txt Files|*.txt";

            if (guarda.ShowDialog() == System.Windows.Forms.DialogResult.OK && guarda.FileName.Length > 0)
            {
                richTextBox2.SaveFile(guarda.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        //Esta funcion se activa cuando se va a calcular el LR1
        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Lines.Count() < 1)
            {
                MessageBox.Show("Tienes que escribir una gramatica");
            }
            else
            {
                if (principal.creglas() == true)
                {
                    principal.lr1princ(treeView1, dataGridView1);
                    if (principal.tlr1 == false)
                    {
                        MessageBox.Show("Gramatica no valida" + principal.errorCelda);
                        dataGridView2.Rows.Clear();
                        Codigo.Enabled = false;
                    }
                    else
                    {
                        Codigo.Enabled = true;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tablaCu.Rows.Clear();
            tablaSi.Rows.Clear();

            if (richTextBox2.Lines.Count() == 0)
            {
                MessageBox.Show("Tienes que escribir algo");
            }
            else
            {
                if (principal.evaluar(richTextBox2, dataGridView2, dataGridView1) == false)
                {
                    MessageBox.Show("No es valida dentro de la gramatica");
                }
                else
                {
                    principal.RecorreArbol();
                    principal.tree.Show();
                  //  this.Controls.Add(principal.tree);
                    Form control = new Form();
                    control.Size = new Size(1024, 720);
                    control.Controls.Add(principal.tree);
                    control.Show();                   
                }
            }
        }

        private void botonEjecutar_Click(object sender, EventArgs e)
        {

        }

        private void botonCodigo_Click(object sender, EventArgs e)
        {

        }

        private void botonCuadruplos_Click(object sender, EventArgs e)
        {

        }
    }
}
