namespace Sistemas_não_lineares
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
            this.label1 = new System.Windows.Forms.Label();
            this.ordemSist = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newtonMod = new System.Windows.Forms.RadioButton();
            this.newton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.epsilon = new System.Windows.Forms.TextBox();
            this.iteracoes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calc = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabelaPontos = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordemSist)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iteracoes)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabelaPontos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ordemSist);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordem do sistema";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "2 <= n <= 10";
            // 
            // ordemSist
            // 
            this.ordemSist.Location = new System.Drawing.Point(9, 53);
            this.ordemSist.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ordemSist.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ordemSist.Name = "ordemSist";
            this.ordemSist.Size = new System.Drawing.Size(64, 20);
            this.ordemSist.TabIndex = 0;
            this.ordemSist.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ordemSist.ValueChanged += new System.EventHandler(this.ordemSist_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newtonMod);
            this.groupBox2.Controls.Add(this.newton);
            this.groupBox2.Location = new System.Drawing.Point(150, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Métodos";
            // 
            // newtonMod
            // 
            this.newtonMod.AutoSize = true;
            this.newtonMod.Location = new System.Drawing.Point(6, 56);
            this.newtonMod.Name = "newtonMod";
            this.newtonMod.Size = new System.Drawing.Size(117, 17);
            this.newtonMod.TabIndex = 1;
            this.newtonMod.TabStop = true;
            this.newtonMod.Text = "Newton Modificado";
            this.newtonMod.UseVisualStyleBackColor = true;
            // 
            // newton
            // 
            this.newton.AutoSize = true;
            this.newton.Location = new System.Drawing.Point(6, 24);
            this.newton.Name = "newton";
            this.newton.Size = new System.Drawing.Size(65, 17);
            this.newton.TabIndex = 0;
            this.newton.TabStop = true;
            this.newton.Text = "Newton ";
            this.newton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.epsilon);
            this.groupBox3.Controls.Add(this.iteracoes);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(296, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Critérios de parada";
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(172, 55);
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(60, 20);
            this.epsilon.TabIndex = 3;
            // 
            // iteracoes
            // 
            this.iteracoes.Location = new System.Drawing.Point(172, 18);
            this.iteracoes.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.iteracoes.Name = "iteracoes";
            this.iteracoes.Size = new System.Drawing.Size(60, 20);
            this.iteracoes.TabIndex = 2;
            this.iteracoes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ε: (de 0,0001 a 0,01)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Iterações: (de 10 a 100)";
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(540, 14);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(85, 86);
            this.calc.TabIndex = 3;
            this.calc.Text = "Calcula";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tabelaPontos);
            this.groupBox4.Location = new System.Drawing.Point(13, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(612, 283);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pontos e equações";
            // 
            // tabelaPontos
            // 
            this.tabelaPontos.ColumnCount = 5;
            this.tabelaPontos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tabelaPontos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tabelaPontos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tabelaPontos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelaPontos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelaPontos.Controls.Add(this.label8, 4, 0);
            this.tabelaPontos.Controls.Add(this.label7, 3, 0);
            this.tabelaPontos.Controls.Add(this.label6, 2, 0);
            this.tabelaPontos.Controls.Add(this.label4, 0, 0);
            this.tabelaPontos.Controls.Add(this.label5, 1, 0);
            this.tabelaPontos.Location = new System.Drawing.Point(9, 20);
            this.tabelaPontos.Name = "tabelaPontos";
            this.tabelaPontos.RowCount = 11;
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tabelaPontos.Size = new System.Drawing.Size(597, 258);
            this.tabelaPontos.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(478, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "f[i](x) final";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(359, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "x[i] final";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(121, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "f[i](x)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "i";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(32, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "x[i] inicial";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 392);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sistemas de equações não-lineares";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordemSist)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iteracoes)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tabelaPontos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ordemSist;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton newtonMod;
        private System.Windows.Forms.RadioButton newton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown iteracoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox epsilon;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tabelaPontos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

