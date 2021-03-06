﻿namespace Interpolação
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
            this.newtonGregory = new System.Windows.Forms.RadioButton();
            this.newton = new System.Windows.Forms.RadioButton();
            this.sistLinear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grafico = new System.Windows.Forms.Button();
            this.pRef = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grauPoli = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.nPontos = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textEqu = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panelX = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelY = new System.Windows.Forms.FlowLayoutPanel();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauPoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newtonGregory);
            this.groupBox1.Controls.Add(this.newton);
            this.groupBox1.Controls.Add(this.sistLinear);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Métodos";
            // 
            // newtonGregory
            // 
            this.newtonGregory.AutoSize = true;
            this.newtonGregory.Location = new System.Drawing.Point(6, 65);
            this.newtonGregory.Name = "newtonGregory";
            this.newtonGregory.Size = new System.Drawing.Size(102, 17);
            this.newtonGregory.TabIndex = 2;
            this.newtonGregory.TabStop = true;
            this.newtonGregory.Text = "Newton-Gregory\r\n";
            this.newtonGregory.UseVisualStyleBackColor = true;
            // 
            // newton
            // 
            this.newton.AutoSize = true;
            this.newton.Location = new System.Drawing.Point(6, 42);
            this.newton.Name = "newton";
            this.newton.Size = new System.Drawing.Size(62, 17);
            this.newton.TabIndex = 1;
            this.newton.TabStop = true;
            this.newton.Text = "Newton";
            this.newton.UseVisualStyleBackColor = true;
            // 
            // sistLinear
            // 
            this.sistLinear.AutoSize = true;
            this.sistLinear.Location = new System.Drawing.Point(6, 19);
            this.sistLinear.Name = "sistLinear";
            this.sistLinear.Size = new System.Drawing.Size(94, 17);
            this.sistLinear.TabIndex = 0;
            this.sistLinear.TabStop = true;
            this.sistLinear.Text = "Sistema Linear\r\n";
            this.sistLinear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grafico);
            this.groupBox2.Controls.Add(this.pRef);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.grauPoli);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.calc);
            this.groupBox2.Controls.Add(this.reset);
            this.groupBox2.Controls.Add(this.nPontos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 186);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // grafico
            // 
            this.helpProvider1.SetHelpString(this.grafico, "Apaga todos os campos do programa");
            this.grafico.Location = new System.Drawing.Point(6, 149);
            this.grafico.Name = "grafico";
            this.grafico.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.helpProvider1.SetShowHelp(this.grafico, true);
            this.grafico.Size = new System.Drawing.Size(218, 31);
            this.grafico.TabIndex = 11;
            this.grafico.Text = "Gráfico";
            this.grafico.UseVisualStyleBackColor = true;
            this.grafico.Click += new System.EventHandler(this.grafico_Click);
            // 
            // pRef
            // 
            this.pRef.Location = new System.Drawing.Point(165, 75);
            this.pRef.Name = "pRef";
            this.pRef.Size = new System.Drawing.Size(63, 20);
            this.pRef.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ponto de referência(z,se k<n)";
            // 
            // grauPoli
            // 
            this.grauPoli.Location = new System.Drawing.Point(165, 48);
            this.grauPoli.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.grauPoli.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.grauPoli.Name = "grauPoli";
            this.grauPoli.Size = new System.Drawing.Size(63, 20);
            this.grauPoli.TabIndex = 8;
            this.grauPoli.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Grau do polinômio(k,se k<n)";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(6, 106);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(102, 37);
            this.calc.TabIndex = 1;
            this.calc.Text = "Calcula";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // reset
            // 
            this.helpProvider1.SetHelpString(this.reset, "Apaga todos os campos do programa");
            this.reset.Location = new System.Drawing.Point(122, 106);
            this.reset.Name = "reset";
            this.reset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.helpProvider1.SetShowHelp(this.reset, true);
            this.reset.Size = new System.Drawing.Size(102, 37);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // nPontos
            // 
            this.nPontos.Location = new System.Drawing.Point(165, 20);
            this.nPontos.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nPontos.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nPontos.Name = "nPontos";
            this.nPontos.Size = new System.Drawing.Size(63, 20);
            this.nPontos.TabIndex = 6;
            this.nPontos.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nPontos.ValueChanged += new System.EventHandler(this.nPontos_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de pontos: (n+1)\r\n\r\n";
            // 
            // textEqu
            // 
            this.helpProvider1.SetHelpString(this.textEqu, "Mostra a expressão obtida pelos cálculos");
            this.textEqu.Location = new System.Drawing.Point(13, 299);
            this.textEqu.Name = "textEqu";
            this.helpProvider1.SetShowHelp(this.textEqu, true);
            this.textEqu.Size = new System.Drawing.Size(497, 20);
            this.textEqu.TabIndex = 6;
            // 
            // panelX
            // 
            this.panelX.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.helpProvider1.SetHelpString(this.panelX, "Espaço para inserção de dados. Lembre-se de sempre usar virgula para separar as c" +
        "asas decimais");
            this.panelX.Location = new System.Drawing.Point(253, 39);
            this.panelX.Name = "panelX";
            this.helpProvider1.SetShowHelp(this.panelX, true);
            this.panelX.Size = new System.Drawing.Size(125, 254);
            this.panelX.TabIndex = 7;
            this.panelX.WrapContents = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valores de X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Valores de Y:";
            // 
            // panelY
            // 
            this.panelY.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.helpProvider1.SetHelpString(this.panelY, "Espaço para inserção de dados. Lembre-se de sempre usar virgula para separar as c" +
        "asas decimais");
            this.panelY.Location = new System.Drawing.Point(384, 39);
            this.panelY.Name = "panelY";
            this.helpProvider1.SetShowHelp(this.panelY, true);
            this.panelY.Size = new System.Drawing.Size(125, 254);
            this.panelY.TabIndex = 8;
            this.panelY.WrapContents = false;
            // 
            // Form1
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 325);
            this.Controls.Add(this.panelY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelX);
            this.Controls.Add(this.textEqu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Interpolação";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauPoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton newtonGregory;
        private System.Windows.Forms.RadioButton newton;
        private System.Windows.Forms.RadioButton sistLinear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nPontos;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.TextBox textEqu;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel panelX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel panelY;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.NumericUpDown grauPoli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pRef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button grafico;
    }
}

