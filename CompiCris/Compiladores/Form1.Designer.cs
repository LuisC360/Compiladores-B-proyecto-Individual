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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.comprobarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pasoAPasoAAltoNivelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasoAPasoABajoNivelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HerramientasDebug = new System.Windows.Forms.GroupBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip1.SuspendLayout();
            this.HerramientasDebug.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(89, 564);
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
            this.Codigo.Controls.Add(this.richTextBox2);
            this.Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Codigo.Location = new System.Drawing.Point(12, 43);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(892, 374);
            this.Codigo.TabIndex = 3;
            this.Codigo.TabStop = false;
            this.Codigo.Text = "Codigo";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 28);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(875, 340);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(149, 564);
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
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 25);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(489, 332);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cuadruplos";
            // 
            // tablaCu
            // 
            this.tablaCu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.tablaCu.Size = new System.Drawing.Size(476, 301);
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
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(501, 24);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(379, 333);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tabla de Simbolos";
            // 
            // tablaSi
            // 
            this.tablaSi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tablaSi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaSi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simbolo,
            this.Valor});
            this.tablaSi.Location = new System.Drawing.Point(7, 27);
            this.tablaSi.Name = "tablaSi";
            this.tablaSi.ReadOnly = true;
            this.tablaSi.RowHeadersVisible = false;
            this.tablaSi.RowTemplate.Height = 28;
            this.tablaSi.Size = new System.Drawing.Size(366, 300);
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
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(912, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(42, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprobarToolStripMenuItem,
            this.ejecutarToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(42, 28);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ToolTipText = "Código";
            // 
            // comprobarToolStripMenuItem
            // 
            this.comprobarToolStripMenuItem.Name = "comprobarToolStripMenuItem";
            this.comprobarToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.comprobarToolStripMenuItem.Text = "Comprobar";
            this.comprobarToolStripMenuItem.Click += new System.EventHandler(this.comprobarToolStripMenuItem_Click);
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasoAPasoAAltoNivelToolStripMenuItem,
            this.pasoAPasoABajoNivelToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(42, 28);
            this.toolStripDropDownButton3.Text = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.ToolTipText = "Debug";
            // 
            // pasoAPasoAAltoNivelToolStripMenuItem
            // 
            this.pasoAPasoAAltoNivelToolStripMenuItem.Name = "pasoAPasoAAltoNivelToolStripMenuItem";
            this.pasoAPasoAAltoNivelToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.pasoAPasoAAltoNivelToolStripMenuItem.Text = "Paso a paso a alto nivel";
            this.pasoAPasoAAltoNivelToolStripMenuItem.Click += new System.EventHandler(this.pasoAPasoAAltoNivelToolStripMenuItem_Click);
            // 
            // pasoAPasoABajoNivelToolStripMenuItem
            // 
            this.pasoAPasoABajoNivelToolStripMenuItem.Name = "pasoAPasoABajoNivelToolStripMenuItem";
            this.pasoAPasoABajoNivelToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.pasoAPasoABajoNivelToolStripMenuItem.Text = "Paso a paso a bajo nivel";
            // 
            // HerramientasDebug
            // 
            this.HerramientasDebug.Controls.Add(this.groupBox5);
            this.HerramientasDebug.Controls.Add(this.groupBox6);
            this.HerramientasDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HerramientasDebug.Location = new System.Drawing.Point(13, 424);
            this.HerramientasDebug.Name = "HerramientasDebug";
            this.HerramientasDebug.Size = new System.Drawing.Size(891, 363);
            this.HerramientasDebug.TabIndex = 8;
            this.HerramientasDebug.TabStop = false;
            this.HerramientasDebug.Text = "Herramientas de depurado";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(912, 788);
            this.Controls.Add(this.HerramientasDebug);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Compilador";
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.HerramientasDebug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccionTraduccion;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem comprobarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem pasoAPasoAAltoNivelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasoAPasoABajoNivelToolStripMenuItem;
        private System.Windows.Forms.GroupBox HerramientasDebug;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}

