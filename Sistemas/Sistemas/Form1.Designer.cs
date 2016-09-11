namespace Sistemas
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
            this.gaussSeidel = new System.Windows.Forms.RadioButton();
            this.jacobi = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cholesky = new System.Windows.Forms.RadioButton();
            this.lu = new System.Windows.Forms.RadioButton();
            this.gaussComp = new System.Windows.Forms.RadioButton();
            this.gaussPT = new System.Windows.Forms.RadioButton();
            this.gaussPP = new System.Windows.Forms.RadioButton();
            this.gaussSimples = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.ordemSist = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tolerancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numItera = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.matAPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.vetBPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.vetXPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordemSist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItera)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gaussSeidel);
            this.groupBox1.Controls.Add(this.jacobi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cholesky);
            this.groupBox1.Controls.Add(this.lu);
            this.groupBox1.Controls.Add(this.gaussComp);
            this.groupBox1.Controls.Add(this.gaussPT);
            this.groupBox1.Controls.Add(this.gaussPP);
            this.groupBox1.Controls.Add(this.gaussSimples);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Métodos";
            // 
            // gaussSeidel
            // 
            this.gaussSeidel.AutoSize = true;
            this.gaussSeidel.Location = new System.Drawing.Point(195, 107);
            this.gaussSeidel.Name = "gaussSeidel";
            this.gaussSeidel.Size = new System.Drawing.Size(87, 17);
            this.gaussSeidel.TabIndex = 9;
            this.gaussSeidel.TabStop = true;
            this.gaussSeidel.Text = "Gauss-Seidel";
            this.gaussSeidel.UseVisualStyleBackColor = true;
            // 
            // jacobi
            // 
            this.jacobi.AutoSize = true;
            this.jacobi.Location = new System.Drawing.Point(195, 84);
            this.jacobi.Name = "jacobi";
            this.jacobi.Size = new System.Drawing.Size(113, 17);
            this.jacobi.TabIndex = 8;
            this.jacobi.TabStop = true;
            this.jacobi.Text = "Jacobi-Richardson";
            this.jacobi.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Iterativos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Diretos:";
            // 
            // cholesky
            // 
            this.cholesky.AutoSize = true;
            this.cholesky.Location = new System.Drawing.Point(195, 38);
            this.cholesky.Name = "cholesky";
            this.cholesky.Size = new System.Drawing.Size(68, 17);
            this.cholesky.TabIndex = 5;
            this.cholesky.TabStop = true;
            this.cholesky.Text = "Cholesky";
            this.cholesky.UseVisualStyleBackColor = true;
            // 
            // lu
            // 
            this.lu.AutoSize = true;
            this.lu.Location = new System.Drawing.Point(195, 15);
            this.lu.Name = "lu";
            this.lu.Size = new System.Drawing.Size(39, 17);
            this.lu.TabIndex = 4;
            this.lu.TabStop = true;
            this.lu.Text = "LU";
            this.lu.UseVisualStyleBackColor = true;
            // 
            // gaussComp
            // 
            this.gaussComp.AutoSize = true;
            this.gaussComp.Location = new System.Drawing.Point(6, 107);
            this.gaussComp.Name = "gaussComp";
            this.gaussComp.Size = new System.Drawing.Size(106, 17);
            this.gaussComp.TabIndex = 3;
            this.gaussComp.TabStop = true;
            this.gaussComp.Text = "Gauss Compacto";
            this.gaussComp.UseVisualStyleBackColor = true;
            // 
            // gaussPT
            // 
            this.gaussPT.AutoSize = true;
            this.gaussPT.Location = new System.Drawing.Point(6, 84);
            this.gaussPT.Name = "gaussPT";
            this.gaussPT.Size = new System.Drawing.Size(139, 17);
            this.gaussPT.TabIndex = 2;
            this.gaussPT.TabStop = true;
            this.gaussPT.Text = "Gauss pivotamento total";
            this.gaussPT.UseVisualStyleBackColor = true;
            // 
            // gaussPP
            // 
            this.gaussPP.AutoSize = true;
            this.gaussPP.Location = new System.Drawing.Point(6, 61);
            this.gaussPP.Name = "gaussPP";
            this.gaussPP.Size = new System.Drawing.Size(150, 17);
            this.gaussPP.TabIndex = 1;
            this.gaussPP.TabStop = true;
            this.gaussPP.Text = "Gauss pivotamento parcial";
            this.gaussPP.UseVisualStyleBackColor = true;
            // 
            // gaussSimples
            // 
            this.gaussSimples.AutoSize = true;
            this.gaussSimples.Location = new System.Drawing.Point(6, 38);
            this.gaussSimples.Name = "gaussSimples";
            this.gaussSimples.Size = new System.Drawing.Size(100, 17);
            this.gaussSimples.TabIndex = 0;
            this.gaussSimples.TabStop = true;
            this.gaussSimples.Text = "Gauss - Simples";
            this.gaussSimples.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.reset);
            this.groupBox2.Controls.Add(this.ordemSist);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tolerancia);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numItera);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(387, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 148);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(225, 50);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 7;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // ordemSist
            // 
            this.ordemSist.Location = new System.Drawing.Point(127, 27);
            this.ordemSist.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ordemSist.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ordemSist.Name = "ordemSist";
            this.ordemSist.Size = new System.Drawing.Size(61, 20);
            this.ordemSist.TabIndex = 1;
            this.ordemSist.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ordemSist.ValueChanged += new System.EventHandler(this.ordemSist_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ordem do sistema: ";
            // 
            // tolerancia
            // 
            this.tolerancia.Location = new System.Drawing.Point(127, 79);
            this.tolerancia.Name = "tolerancia";
            this.tolerancia.Size = new System.Drawing.Size(61, 20);
            this.tolerancia.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tolerância: ";
            // 
            // numItera
            // 
            this.numItera.Location = new System.Drawing.Point(127, 53);
            this.numItera.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numItera.Name = "numItera";
            this.numItera.Size = new System.Drawing.Size(61, 20);
            this.numItera.TabIndex = 4;
            this.numItera.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número de iterações: ";
            // 
            // matAPanel
            // 
            this.matAPanel.ColumnCount = 10;
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.matAPanel.Location = new System.Drawing.Point(12, 188);
            this.matAPanel.Name = "matAPanel";
            this.matAPanel.RowCount = 10;
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.matAPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.matAPanel.Size = new System.Drawing.Size(675, 260);
            this.matAPanel.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Matriz A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Vetor B";
            // 
            // vetBPanel
            // 
            this.vetBPanel.ColumnCount = 10;
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetBPanel.Location = new System.Drawing.Point(12, 478);
            this.vetBPanel.Name = "vetBPanel";
            this.vetBPanel.RowCount = 1;
            this.vetBPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vetBPanel.Size = new System.Drawing.Size(675, 26);
            this.vetBPanel.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Vetor X (Solução)";
            // 
            // vetXPanel
            // 
            this.vetXPanel.ColumnCount = 10;
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.vetXPanel.Location = new System.Drawing.Point(12, 537);
            this.vetXPanel.Name = "vetXPanel";
            this.vetXPanel.RowCount = 1;
            this.vetXPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vetXPanel.Size = new System.Drawing.Size(675, 26);
            this.vetXPanel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 582);
            this.Controls.Add(this.vetXPanel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vetBPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.matAPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sistemas Lineares";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordemSist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton gaussSimples;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ordemSist;
        private System.Windows.Forms.RadioButton lu;
        private System.Windows.Forms.RadioButton gaussComp;
        private System.Windows.Forms.RadioButton gaussPT;
        private System.Windows.Forms.RadioButton gaussPP;
        private System.Windows.Forms.TextBox tolerancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numItera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton gaussSeidel;
        private System.Windows.Forms.RadioButton jacobi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton cholesky;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TableLayoutPanel matAPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel vetBPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel vetXPanel;
        private System.Windows.Forms.Button button1;
    }
}

