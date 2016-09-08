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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(269, 316);
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
            this.panelY.Size = new System.Drawing.Size(123, 221);
            this.panelY.TabIndex = 4;
            // 
            // panelX
            // 
            this.panelX.Location = new System.Drawing.Point(7, 78);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(123, 221);
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
            7,
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 439);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Ajustes ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPontos)).EndInit();
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
    }
}

