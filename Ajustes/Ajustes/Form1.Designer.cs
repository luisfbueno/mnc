namespace Ajustes
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelY = new System.Windows.Forms.FlowLayoutPanel();
            this.panelX = new System.Windows.Forms.FlowLayoutPanel();
            this.nPontos = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.calcPoli = new System.Windows.Forms.Button();
            this.coeficiente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPoli = new System.Windows.Forms.FlowLayoutPanel();
            this.grauPoli = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.curvasCalc = new System.Windows.Forms.Button();
            this.textR = new System.Windows.Forms.TextBox();
            this.textB = new System.Windows.Forms.TextBox();
            this.textA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauPoli)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panelY);
            this.groupBox1.Controls.Add(this.panelX);
            this.groupBox1.Controls.Add(this.nPontos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pontos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valores de Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valores de X:";
            // 
            // panelY
            // 
            this.panelY.Location = new System.Drawing.Point(136, 78);
            this.panelY.Name = "panelY";
            this.panelY.Size = new System.Drawing.Size(123, 235);
            this.panelY.TabIndex = 4;
            // 
            // panelX
            // 
            this.panelX.Location = new System.Drawing.Point(7, 78);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(123, 235);
            this.panelX.TabIndex = 3;
            // 
            // nPontos
            // 
            this.nPontos.Location = new System.Drawing.Point(149, 18);
            this.nPontos.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nPontos.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nPontos.Name = "nPontos";
            this.nPontos.Size = new System.Drawing.Size(58, 20);
            this.nPontos.TabIndex = 2;
            this.nPontos.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nPontos.ValueChanged += new System.EventHandler(this.nPontos_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de Pontos: (2 a 20)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.calcPoli);
            this.groupBox2.Controls.Add(this.coeficiente);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.panelPoli);
            this.groupBox2.Controls.Add(this.grauPoli);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(289, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajuste Polinomial";
            // 
            // calcPoli
            // 
            this.calcPoli.Location = new System.Drawing.Point(6, 117);
            this.calcPoli.Name = "calcPoli";
            this.calcPoli.Size = new System.Drawing.Size(501, 23);
            this.calcPoli.TabIndex = 6;
            this.calcPoli.Text = "Calcular";
            this.calcPoli.UseVisualStyleBackColor = true;
            this.calcPoli.Click += new System.EventHandler(this.calcPoli_Click);
            // 
            // coeficiente
            // 
            this.coeficiente.Location = new System.Drawing.Point(336, 22);
            this.coeficiente.Name = "coeficiente";
            this.coeficiente.Size = new System.Drawing.Size(171, 20);
            this.coeficiente.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Coeficiente de rendimento: (R²)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pontos:";
            // 
            // panelPoli
            // 
            this.panelPoli.Location = new System.Drawing.Point(10, 65);
            this.panelPoli.Name = "panelPoli";
            this.panelPoli.Size = new System.Drawing.Size(497, 46);
            this.panelPoli.TabIndex = 2;
            // 
            // grauPoli
            // 
            this.grauPoli.Location = new System.Drawing.Point(109, 22);
            this.grauPoli.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.grauPoli.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.grauPoli.Name = "grauPoli";
            this.grauPoli.Size = new System.Drawing.Size(51, 20);
            this.grauPoli.TabIndex = 1;
            this.grauPoli.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.grauPoli.ValueChanged += new System.EventHandler(this.grauPoli_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grau do Polinômio:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.curvasCalc);
            this.groupBox3.Controls.Add(this.textR);
            this.groupBox3.Controls.Add(this.textB);
            this.groupBox3.Controls.Add(this.textA);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(289, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 148);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajustes de outras curvas";
            // 
            // curvasCalc
            // 
            this.curvasCalc.Location = new System.Drawing.Point(6, 122);
            this.curvasCalc.Name = "curvasCalc";
            this.curvasCalc.Size = new System.Drawing.Size(501, 23);
            this.curvasCalc.TabIndex = 7;
            this.curvasCalc.Text = "Calcular";
            this.curvasCalc.UseVisualStyleBackColor = true;
            this.curvasCalc.Click += new System.EventHandler(this.curvasCalc_Click);
            // 
            // textR
            // 
            this.textR.Location = new System.Drawing.Point(363, 87);
            this.textR.Name = "textR";
            this.textR.Size = new System.Drawing.Size(120, 20);
            this.textR.TabIndex = 7;
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(189, 87);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(120, 20);
            this.textB.TabIndex = 6;
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(30, 87);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(120, 20);
            this.textA.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "R:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "b:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "a:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "y = a + b*x",
            "y = a *b^x"});
            this.comboBox1.Location = new System.Drawing.Point(71, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Equações:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 340);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Ajustes ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauPoli)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nPontos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelY;
        private System.Windows.Forms.FlowLayoutPanel panelX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel panelPoli;
        private System.Windows.Forms.NumericUpDown grauPoli;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coeficiente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button calcPoli;
        private System.Windows.Forms.Button curvasCalc;
        private System.Windows.Forms.TextBox textR;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.TextBox textA;
    }
}

