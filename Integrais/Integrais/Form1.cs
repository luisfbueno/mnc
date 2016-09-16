using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;

namespace Integrais
{
    public partial class Form1 : Form
    {

        string func;
        double a, b, n;

        public Form1()
        {
            InitializeComponent();
        }

        private bool passaTextDouble()
        {

            if(fx.Text == "" || valA.Text=="" || valB.Text=="" || valN.Text == "")
            {
                return false;
            }
            else
            {
                func = fx.Text;
                a = double.Parse(valA.Text);
                b = double.Parse(valB.Text);
                n = double.Parse(valN.Text);
            }


            return true;
        }

        private void MetodoRetanguloEsquerda()
        {
            double h = (b - a) / n;
            ExpressionParser parser = new ExpressionParser(); //Interpretador

            double x = a;
            double somatorio = 0;
            parser.Values.Add("x", x);

            while (x < b)
            {
                somatorio += parser.Parse(func); //adiciona o valor da função ao somatorio
                x += h;
                parser.Values["x"].SetValue(x);
            }

            double resu = h * somatorio;

            solucao.Text = resu.ToString();
        }

        private void MetodoRetanguloDireita()
        {
            double h = (b - a) / n;
            ExpressionParser parser = new ExpressionParser(); //Interpretador

            double x = a+h;
            double somatorio = 0;
            parser.Values.Add("x", x);

            while (x <= b)
            {
                somatorio += parser.Parse(func); //adiciona o valor da função ao somatorio
                x += h;
                parser.Values["x"].SetValue(x);
            }

            double resu = h * somatorio;

            solucao.Text = resu.ToString();
        }

        private void calc_Click(object sender, EventArgs e)
        {

            if (!passaTextDouble())
            {
                MessageBox.Show("Preencha todos os espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rEsquerda.Checked)
            {
                MetodoRetanguloEsquerda();
            }

            else if (rDireita.Checked)
            {
                MetodoRetanguloDireita();
            }

        }
    }
}
