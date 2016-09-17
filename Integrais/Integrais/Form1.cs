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

            /*fx.Text = "sin(x)";
            valA.Text = "0";
            valB.Text = "1,0472";
            valN.Text = "5";
            tercoSimpson.Checked = true;*/

            quadGauss.Enabled = false;
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
//------------------------------------------------------------------
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
//------------------------------------------------------------------
        private void MetodoTrapezio()
        {
            double h = (b - a) / n;
            ExpressionParser parser = new ExpressionParser(); //Interpretador

            double x = a + h;

            parser.Values.Add("x", a);
            double fzero = parser.Parse(func);
            MessageBox.Show("Fzero = " + fzero);

            double somatorio = 0;
            while (x < b)
            {
                parser.Values["x"].SetValue(x);
                somatorio += parser.Parse(func);
                MessageBox.Show(parser.Parse(func).ToString());
                x += h;
            }

            parser.Values["x"].SetValue(b);
            double fn = parser.Parse(func);

            MessageBox.Show("Fzero = " + fn);

            double resu = (h / 2) * (fzero + fn + 2 * somatorio);

            solucao.Text = resu.ToString();

        }
//------------------------------------------------------------------
        private void MetodoTercoSimpson()
        {
            ExpressionParser parser = new ExpressionParser();

            if (n % 2 == 0) //Se n for par, somente aplicar 1/3 de simpson
            {
                double h = (b - a) / n;

                parser.Values.Add("x", a);
                double fzero = parser.Parse(func); //calcula f0
                double x = a + h;

                double somatorioPar = 0;
                double somatorioImpar = 0;

                for (int i = 1; i < n; i++)
                {
                    parser.Values["x"].SetValue(x);

                    if (i % 2 == 0)
                    {
                        somatorioPar += parser.Parse(func);
                    }

                    else
                    {
                        somatorioImpar += parser.Parse(func);
                    }

                    x += h;

                }

                parser.Values["x"].SetValue(b);
                double fn = parser.Parse(func);

                double resu = (h / 3) * (fzero + fn + (4 * somatorioImpar) + (2 * somatorioPar));

                solucao.Text = resu.ToString();

            }

            else //se n for impar, de 0 a n-1 aplicar 1/3 de simpson e de n-1 a n trapézios
            {
                //Simpson -> 0 ate m(n-1) / Trapezio -> m até n

                double h = (b - a) / n; //divide o intervalo maior em pedaços
                double m = a + (n - 1) * h; //salva o penultimo pedaço
                //Faz o Simpson de a até m                

                parser.Values.Add("x", a);
                double fzero = parser.Parse(func); //calcula f0
                double x = a + h;

                double somatorioPar = 0;
                double somatorioImpar = 0;

                for (int i = 1;i<n-1;i++)
                {
                    parser.Values["x"].SetValue(x);

                    if (i % 2 == 0)
                    {
                        somatorioPar += parser.Parse(func);
                    }

                    else
                    {
                        somatorioImpar += parser.Parse(func);
                    }

                    x += h;

                }

               // MessageBox.Show(somatorioImpar.ToString());
               // MessageBox.Show(somatorioPar.ToString());

                parser.Values["x"].SetValue(m);
                double fn = parser.Parse(func);

                double resuSimpson = (h / 3) * (fzero + fn + (4 * somatorioImpar) + (2 * somatorioPar));

                //Trapézio
                parser.Values["x"].SetValue(m);
                double fm = parser.Parse(func);
                parser.Values["x"].SetValue(b);
                double fb = parser.Parse(func);

                double resuTrapezio = (h / 2) * (fm + fb);

                double resuFinal = resuTrapezio + resuSimpson;
                solucao.Text = resuFinal.ToString();


            }
    

        }
//------------------------------------------------------------------
        private void MetodoOitavoSimpson()
        {
            ExpressionParser parser = new ExpressionParser();

            if(n%3 == 0)
            {
                double h = (b - a) / 2;

                parser.Values.Add("x", a);
                double fzero = parser.Parse(func);
                double x = a + h;

                



            }


        }

//FUNÇÕES DE INTERFACE
        private bool PassaTextDouble()
        {

            if (fx.Text == "" || valA.Text == "" || valB.Text == "" || valN.Text == "")
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
 //--------------------------------------------------------------------
        private void calc_Click(object sender, EventArgs e)
        {

            if (!PassaTextDouble())
            {
                MessageBox.Show("Preencha todos os espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(n.ToString());
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

            if (trapezio.Checked)
            {
                MetodoTrapezio();
            }

            if (tercoSimpson.Checked)
            {
                MetodoTercoSimpson();
            }

        }
    }
}
