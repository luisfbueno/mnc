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

            MessageBox.Show("Versão 2:\n\n-Quadratura Gaussiana para n de 1 a 8 adicionado");

            /*fx.Text = "sin(x)";
            valA.Text = "0";
            valB.Text = "1,0472";
            valN.Text = "5";
            tercoSimpson.Checked = true;*/

            //quadGauss.Enabled = false;
        }

        private void MetodoRetanguloEsquerda()
        {
            double h = (b - a) / n;
            ExpressionParser parser = new ExpressionParser(); //Interpretador

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

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

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

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

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

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

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

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

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

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

            if(n > 8)
            {
                MessageBox.Show("O valor de n tem que ser entre 1 e 8","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            double resu = 0;

            if (func.Contains("e"))
            {
                parser.Values.Add("e", Math.E);
            }

            parser.Values.Add("x",0);

            if(n == 1)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b + a));
                resu += 2* ((0.5) * (b - a) * parser.Parse(func));
            }

            if (n == 2)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.57735027) + (0.5) * (b + a));
                resu += (0.5) * (b - a) * parser.Parse(func);
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.57735027) + (0.5) * (b + a));
                resu += (0.5) * (b - a) * parser.Parse(func);
            }

            else if (n == 3)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.77459667) + (0.5) * (b + a));
                resu += (0.55555556) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b + a));
                resu += (0.88888889) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.77459667) + (0.5) * (b + a));
                resu += (0.55555556) * ((0.5) * (b - a) * parser.Parse(func));
            }

            else if (n == 4)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.86113631) + (0.5) * (b + a));
                resu += (0.34785484) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.33998104) + (0.5) * (b + a));
                resu += (0.65214516) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.33998104) + (0.5) * (b + a));
                resu += (0.65214516) * ((0.5) * (b - a) * parser.Parse(func));
                //3
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.86113631) + (0.5) * (b + a));
                resu += (0.34785484) * ((0.5) * (b - a) * parser.Parse(func));
            }

            else if (n == 5)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.90617985) + (0.5) * (b + a));
                resu += (0.23692688) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.53846931) + (0.5) * (b + a));
                resu += (0.47862868) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b + a));
                resu += (0.56888889) * ((0.5) * (b - a) * parser.Parse(func));
                //3
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.53846931) + (0.5) * (b + a));
                resu += (0.47862868) * ((0.5) * (b - a) * parser.Parse(func));
                //4
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.90617985) + (0.5) * (b + a));
                resu += (0.23692688) * ((0.5) * (b - a) * parser.Parse(func));
            }

            else if (n == 6)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.93246951) + (0.5) * (b + a));
                resu += (0.17132450) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.66120939) + (0.5) * (b + a));
                resu += (0.36076158) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.23861919) + (0.5) * (b + a));
                resu += (0.46791394) * ((0.5) * (b - a) * parser.Parse(func));
                //3
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.23861919) + (0.5) * (b + a));
                resu += (0.46791394) * ((0.5) * (b - a) * parser.Parse(func));
                //4
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.66120939) + (0.5) * (b + a));
                resu += (0.36076158) * ((0.5) * (b - a) * parser.Parse(func));
                //5
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.93246951) + (0.5) * (b + a));
                resu += (0.17132450) * ((0.5) * (b - a) * parser.Parse(func));
            }

            else if (n == 7)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.94910791) + (0.5) * (b + a));
                resu += (0.12948496) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.74153119) + (0.5) * (b + a));
                resu += (0.27970540) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.40584515) + (0.5) * (b + a));
                resu += (0.38183006) * ((0.5) * (b - a) * parser.Parse(func));
                //3
                parser.Values["x"].SetValue((0.5) * (b + a));
                resu += (0.41795918) * ((0.5) * (b - a) * parser.Parse(func));
                //4
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.40584515) + (0.5) * (b + a));
                resu += (0.38183006) * ((0.5) * (b - a) * parser.Parse(func));
                //5
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.74153119) + (0.5) * (b + a));
                resu += (0.27970540) * ((0.5) * (b - a) * parser.Parse(func));
                //6
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.94910791) + (0.5) * (b + a));
                resu += (0.12948496) * ((0.5) * (b - a) * parser.Parse(func));
            }

            else if (n == 8)
            {
                //0
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.96028986) + (0.5) * (b + a));
                resu += (0.10122854) * ((0.5) * (b - a) * parser.Parse(func));
                //1
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.79666648) + (0.5) * (b + a));
                resu += (0.22238104) * ((0.5) * (b - a) * parser.Parse(func));
                //2
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.52553242) + (0.5) * (b + a));
                resu += (0.31370664) * ((0.5) * (b - a) * parser.Parse(func));
                //3
                parser.Values["x"].SetValue((0.5) * (b - a) * (0.18343464) + (0.5) * (b + a));
                resu += (0.36268378) * ((0.5) * (b - a) * parser.Parse(func));
                //4
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.18343464) + (0.5) * (b + a));
                resu += (0.36268378) * ((0.5) * (b - a) * parser.Parse(func));
                //5
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.52553242) + (0.5) * (b + a));
                resu += (0.31370664) * ((0.5) * (b - a) * parser.Parse(func));
                //6
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.79666648) + (0.5) * (b + a));
                resu += (0.22238104) * ((0.5) * (b - a) * parser.Parse(func));
                //7
                parser.Values["x"].SetValue((0.5) * (b - a) * (-0.96028986) + (0.5) * (b + a));
                resu += (0.10122854) * ((0.5) * (b - a) * parser.Parse(func));
            }

            solucao.Text = resu.ToString();
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
                if (n < 0)
                {
                    MessageBox.Show("O valor de n tem que ser positivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

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
            if (quadGauss.Checked)
            {
                QuadraturaGaussiana();
            }

        }
    }
}
