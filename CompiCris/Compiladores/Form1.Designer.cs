namespace Compiladores
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.GroupBox();
            this.botonCuadruplos = new System.Windows.Forms.Button();
            this.botonCodigo = new System.Windows.Forms.Button();
            this.botonEjecutar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Pila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cadena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionTraduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tablaCu = new System.Windows.Forms.DataGridView();
            this.Operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operando1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operando2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tablaSi = new System.Windows.Forms.DataGridView();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Codigo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCu)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaSi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(113, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(71, 38);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gramatica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(298, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Calcula LR1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(848, 306);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(764, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(45, 15);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arbol";
            this.groupBox2.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 26);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(336, 342);
            this.treeView1.TabIndex = 0;
            this.treeView1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(190, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(44, 42);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de Analisis";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(849, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.Controls.Add(this.botonCuadruplos);
            this.Codigo.Controls.Add(this.botonCodigo);
            this.Codigo.Controls.Add(this.botonEjecutar);
            this.Codigo.Controls.Add(this.button6);
            this.Codigo.Controls.Add(this.button5);
            this.Codigo.Controls.Add(this.button4);
            this.Codigo.Controls.Add(this.richTextBox2);
            this.Codigo.Location = new System.Drawing.Point(12, 12);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(690, 374);
            this.Codigo.TabIndex = 3;
            this.Codigo.TabStop = false;
            this.Codigo.Text = "Codigo";
            // 
            // botonCuadruplos
            // 
            this.botonCuadruplos.Location = new System.Drawing.Point(496, 338);
            this.botonCuadruplos.Name = "botonCuadruplos";
            this.botonCuadruplos.Size = new System.Drawing.Size(75, 29);
            this.botonCuadruplos.TabIndex = 6;
            this.botonCuadruplos.Text = "PPB";
            this.botonCuadruplos.UseVisualStyleBackColor = true;
            this.botonCuadruplos.Click += new System.EventHandler(this.botonCuadruplos_Click);
            // 
            // botonCodigo
            // 
            this.botonCodigo.Location = new System.Drawing.Point(403, 338);
            this.botonCodigo.Name = "botonCodigo";
            this.botonCodigo.Size = new System.Drawing.Size(86, 29);
            this.botonCodigo.TabIndex = 5;
            this.botonCodigo.Text = "PPA";
            this.botonCodigo.UseVisualStyleBackColor = true;
            this.botonCodigo.Click += new System.EventHandler(this.botonCodigo_Click);
            // 
            // botonEjecutar
            // 
            this.botonEjecutar.Location = new System.Drawing.Point(301, 338);
            this.botonEjecutar.Name = "botonEjecutar";
            this.botonEjecutar.Size = new System.Drawing.Size(96, 29);
            this.botonEjecutar.TabIndex = 4;
            this.botonEjecutar.Text = "Ejecutar";
            this.botonEjecutar.UseVisualStyleBackColor = true;
            this.botonEjecutar.Click += new System.EventHandler(this.botonEjecutar_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(180, 338);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 29);
            this.button6.TabIndex = 3;
            this.button6.Text = "Comprobar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(92, 338);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 29);
            this.button5.TabIndex = 2;
            this.button5.Text = "Guardar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 29);
            this.button4.TabIndex = 1;
            this.button4.Text = "Abrir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(0, 28);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(684, 306);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(790, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(35, 42);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de Acciones";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pila,
            this.Cadena,
            this.Acciones,
            this.AccionTraduccion});
            this.dataGridView2.Location = new System.Drawing.Point(8, 26);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(684, 285);
            this.dataGridView2.TabIndex = 0;
            // 
            // Pila
            // 
            this.Pila.HeaderText = "Pila A.S.";
            this.Pila.Name = "Pila";
            // 
            // Cadena
            // 
            this.Cadena.HeaderText = "Cadena de Entrada";
            this.Cadena.Name = "Cadena";
            // 
            // Acciones
            // 
            this.Acciones.HeaderText = "Accion";
            this.Acciones.Name = "Acciones";
            // 
            // AccionTraduccion
            // 
            this.AccionTraduccion.HeaderText = "AccionTraducciom";
            this.AccionTraduccion.Name = "AccionTraduccion";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tablaCu);
            this.groupBox5.Location = new System.Drawing.Point(709, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(489, 373);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cuadruplos";
            // 
            // tablaCu
            // 
            this.tablaCu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaCu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Operador,
            this.Operando1,
            this.Operando2,
            this.Resultado});
            this.tablaCu.Location = new System.Drawing.Point(7, 26);
            this.tablaCu.Name = "tablaCu";
            this.tablaCu.ReadOnly = true;
            this.tablaCu.RowHeadersVisible = false;
            this.tablaCu.RowTemplate.Height = 28;
            this.tablaCu.Size = new System.Drawing.Size(476, 340);
            this.tablaCu.TabIndex = 0;
            // 
            // Operador
            // 
            this.Operador.HeaderText = "Operador";
            this.Operador.Name = "Operador";
            this.Operador.ReadOnly = true;
            // 
            // Operando1
            // 
            this.Operando1.HeaderText = "Operando1";
            this.Operando1.Name = "Operando1";
            this.Operando1.ReadOnly = true;
            // 
            // Operando2
            // 
            this.Operando2.HeaderText = "Operando2";
            this.Operando2.Name = "Operando2";
            this.Operando2.ReadOnly = true;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tablaSi);
            this.groupBox6.Location = new System.Drawing.Point(1211, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(379, 373);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tabla de Simbolos";
            // 
            // tablaSi
            // 
            this.tablaSi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaSi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo,
            this.Valor});
            this.tablaSi.Location = new System.Drawing.Point(7, 27);
            this.tablaSi.Name = "tablaSi";
            this.tablaSi.ReadOnly = true;
            this.tablaSi.RowHeadersVisible = false;
            this.tablaSi.RowTemplate.Height = 28;
            this.tablaSi.Size = new System.Drawing.Size(366, 339);
            this.tablaSi.TabIndex = 0;
            // 
            // Simbolo
            // 
            this.Simbolo.HeaderText = "Simbolo";
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1611, 401);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Codigo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaCu)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaSi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox Codigo;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccionTraduccion;
        private System.Windows.Forms.Button botonCuadruplos;
        private System.Windows.Forms.Button botonCodigo;
        private System.Windows.Forms.Button botonEjecutar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView tablaCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operando1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operando2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView tablaSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}

