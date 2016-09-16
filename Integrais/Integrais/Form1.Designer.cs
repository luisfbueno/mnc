namespace Integrais
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
            this.quadGauss = new System.Windows.Forms.RadioButton();
            this.oitavoSimpson = new System.Windows.Forms.RadioButton();
            this.tercoSimpson = new System.Windows.Forms.RadioButton();
            this.rDireita = new System.Windows.Forms.RadioButton();
            this.rEsquerda = new System.Windows.Forms.RadioButton();
            this.trapezio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.valN = new System.Windows.Forms.TextBox();
            this.valB = new System.Windows.Forms.TextBox();
            this.valA = new System.Windows.Forms.TextBox();
            this.fx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.solucao = new System.Windows.Forms.TextBox();
            this.calc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quadGauss);
            this.groupBox1.Controls.Add(this.oitavoSimpson);
            this.groupBox1.Controls.Add(this.tercoSimpson);
            this.groupBox1.Controls.Add(this.rDireita);
            this.groupBox1.Controls.Add(this.rEsquerda);
            this.groupBox1.Controls.Add(this.trapezio);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Métodos";
            // 
            // quadGauss
            // 
            this.quadGauss.AutoSize = true;
            this.quadGauss.Location = new System.Drawing.Point(143, 68);
            this.quadGauss.Name = "quadGauss";
            this.quadGauss.Size = new System.Drawing.Size(131, 17);
            this.quadGauss.TabIndex = 5;
            this.quadGauss.TabStop = true;
            this.quadGauss.Text = "Quadratura Gaussiana";
            this.quadGauss.UseVisualStyleBackColor = true;
            // 
            // oitavoSimpson
            // 
            this.oitavoSimpson.AutoSize = true;
            this.oitavoSimpson.Location = new System.Drawing.Point(143, 45);
            this.oitavoSimpson.Name = "oitavoSimpson";
            this.oitavoSimpson.Size = new System.Drawing.Size(100, 17);
            this.oitavoSimpson.TabIndex = 4;
            this.oitavoSimpson.TabStop = true;
            this.oitavoSimpson.Text = "3/8 de Simpson";
            this.oitavoSimpson.UseVisualStyleBackColor = true;
            // 
            // tercoSimpson
            // 
            this.tercoSimpson.AutoSize = true;
            this.tercoSimpson.Location = new System.Drawing.Point(143, 22);
            this.tercoSimpson.Name = "tercoSimpson";
            this.tercoSimpson.Size = new System.Drawing.Size(100, 17);
            this.tercoSimpson.TabIndex = 3;
            this.tercoSimpson.TabStop = true;
            this.tercoSimpson.Text = "1/3 de Simpson";
            this.tercoSimpson.UseVisualStyleBackColor = true;
            // 
            // rDireita
            // 
            this.rDireita.AutoSize = true;
            this.rDireita.Location = new System.Drawing.Point(7, 68);
            this.rDireita.Name = "rDireita";
            this.rDireita.Size = new System.Drawing.Size(116, 17);
            this.rDireita.TabIndex = 2;
            this.rDireita.TabStop = true;
            this.rDireita.Text = "Retângulo à Direita";
            this.rDireita.UseVisualStyleBackColor = true;
            // 
            // rEsquerda
            // 
            this.rEsquerda.AutoSize = true;
            this.rEsquerda.Location = new System.Drawing.Point(7, 44);
            this.rEsquerda.Name = "rEsquerda";
            this.rEsquerda.Size = new System.Drawing.Size(131, 17);
            this.rEsquerda.TabIndex = 1;
            this.rEsquerda.TabStop = true;
            this.rEsquerda.Text = "Retângulo à Esquerda";
            this.rEsquerda.UseVisualStyleBackColor = true;
            // 
            // trapezio
            // 
            this.trapezio.AutoSize = true;
            this.trapezio.Location = new System.Drawing.Point(7, 20);
            this.trapezio.Name = "trapezio";
            this.trapezio.Size = new System.Drawing.Size(66, 17);
            this.trapezio.TabIndex = 0;
            this.trapezio.TabStop = true;
            this.trapezio.Text = "Trapézio";
            this.trapezio.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.valN);
            this.groupBox2.Controls.Add(this.valB);
            this.groupBox2.Controls.Add(this.valA);
            this.groupBox2.Controls.Add(this.fx);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados";
            // 
            // valN
            // 
            this.valN.Location = new System.Drawing.Point(214, 54);
            this.valN.Name = "valN";
            this.valN.Size = new System.Drawing.Size(77, 20);
            this.valN.TabIndex = 7;
            // 
            // valB
            // 
            this.valB.Location = new System.Drawing.Point(120, 54);
            this.valB.Name = "valB";
            this.valB.Size = new System.Drawing.Size(69, 20);
            this.valB.TabIndex = 6;
            // 
            // valA
            // 
            this.valA.Location = new System.Drawing.Point(26, 54);
            this.valA.Name = "valA";
            this.valA.Size = new System.Drawing.Size(69, 20);
            this.valA.TabIndex = 5;
            // 
            // fx
            // 
            this.fx.Location = new System.Drawing.Point(39, 20);
            this.fx.Name = "fx";
            this.fx.Size = new System.Drawing.Size(252, 20);
            this.fx.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "n =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "b =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "a =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.solucao);
            this.groupBox3.Location = new System.Drawing.Point(13, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 46);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Solução";
            // 
            // solucao
            // 
            this.solucao.Location = new System.Drawing.Point(6, 19);
            this.solucao.Name = "solucao";
            this.solucao.Size = new System.Drawing.Size(284, 20);
            this.solucao.TabIndex = 0;
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(13, 215);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(297, 23);
            this.calc.TabIndex = 3;
            this.calc.Text = "Calcular";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 296);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Integrais";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton quadGauss;
        private System.Windows.Forms.RadioButton oitavoSimpson;
        private System.Windows.Forms.RadioButton tercoSimpson;
        private System.Windows.Forms.RadioButton rDireita;
        private System.Windows.Forms.RadioButton rEsquerda;
        private System.Windows.Forms.RadioButton trapezio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox valN;
        private System.Windows.Forms.TextBox valB;
        private System.Windows.Forms.TextBox valA;
        private System.Windows.Forms.TextBox fx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox solucao;
        private System.Windows.Forms.Button calc;
    }
}

