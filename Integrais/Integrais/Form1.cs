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

            if (Double.IsInfinity(resu) || double.IsNaN(resu))
            {
                MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                solucao.Text = "Indeterminação!";
                return;
            }
            else
            {
                solucao.Text = resu.ToString();
            }
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

            if (Double.IsInfinity(resu) || double.IsNaN(resu))
            {
                MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                solucao.Text = "Indeterminação!";
                return;
            }
            else
            {
                solucao.Text = resu.ToString();
            }
        }
//------------------------------------------------------------------
        private void MetodoTrapezio()
        {
            double h = (b - a) / n;
            ExpressionParser parser = new ExpressionParser(); //Interpretador

            double x = a + h;

            parser.Values.Add("x", a);
            double fzero = parser.Parse(func);

            double somatorio = 0;
            while (x < b)
            {
                parser.Values["x"].SetValue(x);
                somatorio += parser.Parse(func);
                x += h;
            }

            parser.Values["x"].SetValue(b);
            double fn = parser.Parse(func);

            double resu = (h / 2) * (fzero + fn + 2 * somatorio);

            if (Double.IsInfinity(resu) || double.IsNaN(resu))
            {
                MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                solucao.Text = "Indeterminação!";
                return;
            }
            else
            {
                solucao.Text = resu.ToString();
            }

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

                if (Double.IsInfinity(resu) || double.IsNaN(resu))
                {
                    MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    solucao.Text = "Indeterminação!";
                    return;
                }
                else
                {
                    solucao.Text = resu.ToString();
                }

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

                double resu = resuTrapezio + resuSimpson;
                if (Double.IsInfinity(resu) || Double.IsNaN(resu))
                {
                    MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    solucao.Text = "Indeterminação!";
                    return;
                }
                else
                {
                    solucao.Text = resu.ToString();
                }


            }
    

        }
//------------------------------------------------------------------
        private void MetodoOitavoSimpson()
        {
            ExpressionParser parser = new ExpressionParser();

            if (n % 3 != 0) //Se n não for múltiplo de 3, multiplica ele por 3
            {
                n *= 3;
            }

            double h = (b - a) / n;

            parser.Values.Add("x", a);
            double fzero = parser.Parse(func);
            double x = a + h;

            double somatorioMultiplo = 0;
            double somatorioNaoMultiplo = 0;

            for(int i = 1; i < n; i++)
            {
                parser.Values["x"].SetValue(x);

                if (i % 3 == 0)
                {
                somatorioMultiplo += parser.Parse(func);
                }

                else
                {
                    somatorioNaoMultiplo += parser.Parse(func);
                }

                x += h;

            }

            parser.Values["x"].SetValue(b);
            double fn = parser.Parse(func);

            double resu = ((3 * h) / 8) * (fzero + 3 * somatorioNaoMultiplo + 2 * somatorioMultiplo + fn);

            if(Double.IsInfinity(resu) || double.IsNaN(resu))
            {
                MessageBox.Show("Ocorreu indeterminação durante os cálculos! Reveja os valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                solucao.Text = "Indeterminação!";
                return;
            }
            else
            {
                solucao.Text = resu.ToString();
            }
                
        }
//------------------------------------------------------------------
        private void QuadraturaGaussiana()
        {
            ExpressionParser parser = new ExpressionParser();

            if(n > 5)
            {
                MessageBox.Show("O valor de n tem que ser entre 1 e 5","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


        }

        //FUNÇÕES DE INTERFACE
        private void button1_Click(object sender, EventArgs e)
        {
            if (!PassaTextDouble())
            {
                MessageBox.Show("Algum espaço esta vazio ou um dado é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(n.ToString());
                return;
            }

            Grafico g = new Grafico(func, a, b);
            g.Show();
        }
//--------------------------------------------------------------------
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
                MessageBox.Show("Algum espaço esta vazio ou um dado é inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (oitavoSimpson.Checked)
            {
                MetodoOitavoSimpson();
            }

        }
    }
}
