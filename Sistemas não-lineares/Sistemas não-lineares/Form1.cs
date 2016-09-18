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

namespace Sistemas_não_lineares
{
    public partial class Form1 : Form
    {
        TextBox[] xi = new TextBox[10];
        TextBox[] fxi = new TextBox[10];
        TextBox[] xifinal = new TextBox[10];
        TextBox[] fxifinal = new TextBox[10];
        double[] vetX = new double[10];
        string[] vetFx = new string[10];
        double eps;
        double it;
        ExpressionParser parser = new ExpressionParser();

        public Form1()
        {
            InitializeComponent();

            //Adiciona labels
            Label[] nums = new Label[10];
            for (int i =1; i <= 10; i++)
            {
                nums[i - 1] = new Label();
                nums[i-1].Text = i.ToString();
                nums[i - 1].AutoSize = false;
                nums[i - 1].Dock = DockStyle.Fill;
                nums[i - 1].TextAlign = ContentAlignment.MiddleCenter;
                tabelaPontos.Controls.Add(nums[i - 1],0,i);
                parser.Values.Add("x" + i, 0);
            }

            for (int i = 1; i <= 10; i++)
            {
                xi[i-1] = new TextBox();
                xi[i - 1].Dock = DockStyle.Fill;
                fxi[i - 1] = new TextBox();
                fxi[i-1].Dock = DockStyle.Fill;
                xifinal[i - 1] = new TextBox();
                xifinal[i - 1].Dock = DockStyle.Fill;
                fxifinal[i - 1] = new TextBox();
                fxifinal[i - 1].Dock = DockStyle.Fill;

                tabelaPontos.Controls.Add(xi[i-1], 1, i);
                tabelaPontos.Controls.Add(fxi[i-1], 2, i);
                tabelaPontos.Controls.Add(xifinal[i-1], 3, i);
                tabelaPontos.Controls.Add(fxifinal[i-1], 4, i);
            }

            ordemSist.Value = 2;

            fxi[0].Text = "(x1)^2 + (x2)^2 - 1";
            fxi[1].Text = "(x1)*(x2)";
            xi[0].Text = "0,5";
            xi[1].Text = "0,1";
            epsilon.Text = "0,01";

        }


        private void gauss(int n, double[,] a, double[] b, ref double[] x)
        {
            int i, j, k;
            double multiplicador, soma;

            for (j = 0; j < n - 1; j++)
            {
                for (i = j + 1; i < n; i++)
                {
                    multiplicador = a[i, j] / a[j, j];
                    for (k = j; k < n; k++)
                    {
                        a[i, k] -= multiplicador * a[j, k];
                        MessageBox.Show("a[" + i.ToString() + "," + k.ToString() + "] = " + a[i, k]);
                    }

                    b[i] -= multiplicador * b[j];
                    MessageBox.Show("b[" + i.ToString() + "] = " + b[i]);
                }

            }

            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + i; j < n; j++)
                {
                    soma += a[i, j] * x[j];
                }
                x[i] = (b[i] - soma) / a[i, i];
            }

        }
//---------------------------------------------------------------------------------------------
        double f(string f,double val,int ind)
        {
            parser.Values["x" + ind].SetValue(val);
            return parser.Parse(f);
        }
//---------------------------------------------------------------------------------
        double DerivadaParcial(string func,double[] x,int ind) //ind é o indice do vetor, tem q somar 1 quando usar no interpretador
        {
            double d = 0;
            double h = 1000*0.001;
            bool achou = false;
            double p = 0, q;
            double f1, f2, xaux;
            int i;

            xaux = x[ind];
            x[ind] = xaux + h;
            f1 = f(func, x[ind], ind + 1);
            x[ind] = xaux - h;
            f2 = f(func, x[ind], ind + 1);

            p = (f1 - f2) / (2*h);

            for (i = 0; i < 10 && !achou; i++)
            {
                q = p;
                h /= 2;

                x[ind] = xaux + h;
                f1 = f(func, x[ind], ind + 1);
                x[ind] = xaux - h;
                f2 = f(func, x[ind], ind + 1);

                p = (f1 - f2) / (2 * h);

                if (Math.Abs(p - q) < 0.001)
                    achou = true;

            }

            x[ind] = xaux;
            parser.Values["x" + (ind + 1)].SetValue(x[ind]);
            d = p;

            return d;
        }
//---------------------------------------------------------------------------------
        private void Newton(int n)
        {
            double[,] jacobiano = new double[10, 10];
            double[] F = new double[10];
            //double parada = 1;
            //double cont = 1;
            double[] x = new double[10];

            for(int i = 0; i < n; i++)
            {
                x[i] = vetX[i];
            }

           // while(parada>eps && cont <= it)
           // {

                for(int i = 0; i < n; i++) //Calcula vetor F de valores das funções
                {
                    F[i] = parser.Parse(vetFx[i]);
                MessageBox.Show("f[" + i +"] = " + F[i]);
            }

                for(int i = 0; i < n; i++) //Calcula matriz Jacobiana
                {
                    for(int j = 0; j < n; j++)
                    {
                        jacobiano[i, j] = DerivadaParcial(vetFx[i],vetX,j);
                        MessageBox.Show("j[" + i + "," + j + "]=" + jacobiano[i, j]);
                    }
                }

                //gauss(n, jacobiano, F, ref x);



                //cont++;
            //}

        }

        private void ordemSist_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= ordemSist.Value)
                {
                    xi[i - 1].Enabled = true;
                    fxi[i - 1].Enabled = true;
                    xifinal[i - 1].Enabled = true;
                    fxifinal[i - 1].Enabled = true;
                }
                else
                {
                    xi[i - 1].Enabled = false;
                    fxi[i - 1].Enabled = false;
                    xifinal[i - 1].Enabled = false;
                    fxifinal[i - 1].Enabled = false;
                }
            }

            
        }
//----------------------------------------------------------------------------------
        private void calc_Click(object sender, EventArgs e)
        {
            int n = (int)ordemSist.Value;

            for(int i = 0; i < n; i++)
            {
                if(xi[i].Text == "" || fxi[i].Text == "")
                {
                    MessageBox.Show("Preencha todos os espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vetX[i] = Double.Parse(xi[i].Text);
                parser.Values["x" + (i + 1)].SetValue(vetX[i]);
                vetFx[i] = fxi[i].Text;
            }

            eps = Double.Parse(epsilon.Text);
            if(eps<0.0001 || eps > 0.01)
            {
                MessageBox.Show("Coloque um valor válido para epsilon!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            it = (int)iteracoes.Value;

            Newton(n);
        }



    }
}
