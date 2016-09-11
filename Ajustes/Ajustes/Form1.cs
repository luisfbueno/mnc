using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajustes
{
    public partial class Form1 : Form
    {

        TextBox[] x, y,a;
        double[] valX = new double[20];
        double[] valY = new double[20];
        private int m, n;
        
        public Form1()
        {
            InitializeComponent();

            x = new TextBox[20];
            y = new TextBox[20];
            a = new TextBox[7];
            panelX.AutoScroll = true;
            panelY.AutoScroll = true;
            panelPoli.AutoScroll = true;
            panelPoli.WrapContents = false;

            for (int i = 0; i < 20; i++)
            {
                x[i] = new TextBox();
                y[i] = new TextBox();

                x[i].Visible = false;
                y[i].Visible = false;

                panelX.Controls.Add(x[i]);
                panelY.Controls.Add(y[i]);

            }

            for(int i = 0; i < 7; i++)
            {
                a[i] = new TextBox();
                if (i > 2)
                {
                    a[i].Visible = false;
                }

                panelPoli.Controls.Add(a[i]);
            }

            for (int i = 0; i < 12; i++)
            {
                x[i].Visible = true;
                y[i].Visible = true;
            }

            /*
            //Valores Simples para teste
            for (int i = 0; i < 4; i++)
            {
                x[i].Text = (i).ToString();
            }
            y[0].Text = "0";
            y[1].Text = "1";
            y[2].Text = "3,8";
            y[3].Text = "9";
            */
            //TESTE AP SACOMAN
            //Valores de x e y para teste
            double aux = 1964;
            for(int i = 0; i < 12; i++)
            {
                x[i].Text = aux.ToString();
                aux++;
            }
            
            y[0].Text = "0,95";
            y[1].Text = "1,15";
            y[2].Text = "1,17";
            y[3].Text = "0,99";
            y[4].Text = "0,91";
            y[5].Text = "1,04";
            y[6].Text = "0,84";
            y[7].Text = "0,80";
            y[8].Text = "0,84";
            y[9].Text = "0,88";
            y[10].Text = "0,57";
            y[11].Text = "0,84";
        }

        private void cholesky(int n,double[,] a,double[] b,ref double[] x)
        {

            int i, j, k;
            double[,] g = new double[20, 20];
            double soma;
            double[] y = new double[20];

            
            for (k = 0; k < n; k++) //Decompor A em G*Gt
            {
                soma = 0;
                for (j = 0; j <= k - 1; j++)
                {
                    soma += Math.Pow(g[k, j], 2);
                }
                g[k, k] = Math.Sqrt(a[k, k] - soma);
                for (i = k; i < n; i++)
                {
                    soma = 0;
                    for (j = 0; j <= k - 1; j++)
                    {
                        soma += g[i, j] * g[k, j];
                    }
                    g[i, k] = (a[i, k] - soma) / g[k, k];
                }
            }

            y[0] = b[0] / g[0, 0];
            for (i = 1; i < n; i++)
            {
                soma = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    soma += g[i, j] * y[j];
                }
                y[i] = (b[i] - soma) / g[i, i];
            }

            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    g[i, j] = g[j, i];
                    g[j, i] = 0;
                }
            }

            x[n - 1] = y[n - 1] / g[n - 1, n - 1];
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + 1; j < n; j++)
                {
                    soma += g[i, j] * x[j];
                }
                x[i] = (y[i] - soma) / g[i, i];
            }

        }
//-------------------------------------------------------------------------------
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
                        //MessageBox.Show("a[" + i.ToString() + "," + k.ToString() + "] = " + a[i, k]);
                    }

                    b[i] -= multiplicador * b[j];
                    //MessageBox.Show("b[" + i.ToString() + "] = " + b[i]);
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
//-------------------------------------------------------------------------------           
        private void minimosQuadrados()
        {
            int i,j;
            double[] somatorioPotX = new double[15]; //Vetor que guarda os somatorios x(primeira posição guarda somatorio x^1)
            double[] somatorioVetB = new double[7];
            double[,] matrizCalc = new double[7, 7];
            double[] vetCalc = new double[7];
            double[] vetSol = new double[7];

            for (i = 0; i < m+m-2; i++) //Calcula somatorios de x (vai até m+1 pois caso o grau seja 2 ele precisa calcular 
            {
                somatorioPotX[i] = 0;
                for (j = 0; j < n; j++)
                {
                    somatorioPotX[i] += Math.Pow(valX[j], i + 1);
                }
                //MessageBox.Show("Somatório x^" + (i+1) + "=" + somatorioPotX[i]);
            }

            double sumY, sumX;

            for (i = 0; i < m; i++) //Calcula Somatorios do vetor b
            {
                sumY = sumX = 0;
                for (j = 0; j < n; j++)
                {
                    sumY = valY[j];
                    sumX = Math.Pow(valX[j], i);
                    somatorioVetB[i] += sumY * sumX;
                }
                //MessageBox.Show("Somatório x^" + (i + 1) + "*yi=" + somatorioVetB[i]);
            }

            for (i = 0; i < m; i++) //Monta a matriz do calculo
            {
                for (j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matrizCalc[i, j] = n;
                    }
                    else
                    {
                        matrizCalc[i, j] = somatorioPotX[i + j - 1];
                    }
                    //MessageBox.Show("Matriz A[" + i + j + "]=" + matrizCalc[i, j].ToString());
                }
            }

            cholesky(m, matrizCalc, somatorioVetB, ref vetSol);
            //gauss(m, matrizCalc, somatorioVetB, ref vetSol);

            for (i = 0; i < m; i++)
            {
                a[i].Text = vetSol[i].ToString();
            }

        }
//-------------------------------------------------------------------------------
        private void minimosQuadradosComR(int curva)
        {
            int i, j;
            double[] somatorioPotX = new double[15]; //Vetor que guarda os somatorios x(primeira posição guarda somatorio x^1)
            double[] somatorioVetB = new double[7];
            double[,] matrizCalc = new double[7, 7];
            double[] vetCalc = new double[7];
            double[] vetSol = new double[7];
            double[] yOriginal = new double[20];

            #region Mudanças de valores de x e y
            if (curva == 1 || curva == 5) //y = a*b^x,y=e^(a+b*x)
            {
                for (i = 0; i < n; i++)
                {
                    yOriginal[i] = valY[i];
                    valY[i] = Math.Log(valY[i]);
                }
            }

            else if (curva == 2) //y=a*x^b
            {
                for (i = 0; i < n; i++)
                {
                    valX[i] = Math.Log(valX[i]);
                }
            }

            else if (curva == 3) //y=a*b^(e*x)
            {
                for (i = 0; i < n; i++)
                {
                    valY[i] = Math.Log(valY[i]);
                    valX[i] = Math.E * valX[i];
                }
            }

            else if (curva == 4) //y=a*b^(e*x)
            {
                for (i = 0; i < n; i++)
                {
                    yOriginal[i] = valY[i];
                    valY[i] = Math.Log(valY[i]);
                }
            }

            else if (curva == 6)//y=1/(a+b*x)
            {
                for (i = 0; i < n; i++)
                {
                    valY[i] = 1 / valY[i];
                }
            }
           
            else if (curva == 7) //y=x/(a+b*x)
            {
                for (i = 0; i < n; i++)
                {
                    valY[i] = 1 / valY[i];
                    valX[i] = 1 / valX[i];
                }
            }

            else if (curva == 8) //y=1/(1+e^(a+b*x))
            {
                for (i = 0; i < n; i++)
                {
                    valY[i] = (1 / valY[i]) - 1;
                }
            }


            #endregion

            for (i = 0; i < m + m - 2; i++) //Calcula somatorios de x (vai até m+1 pois caso o grau seja 2 ele precisa calcular 
            {
                somatorioPotX[i] = 0;
                for (j = 0; j < n; j++)
                {
                    somatorioPotX[i] += Math.Pow(valX[j], i + 1);
                }
                //MessageBox.Show("Somatório x^" + (i+1) + "=" + somatorioPotX[i]);
            }

            double sumY, sumX;

            for (i = 0; i < m; i++) //Calcula Somatorios do vetor b
            {
                sumY = sumX = 0;
                for (j = 0; j < n; j++)
                {
                    sumY = valY[j];
                    sumX = Math.Pow(valX[j], i);
                    somatorioVetB[i] += sumY * sumX;
                }
                //MessageBox.Show("Somatório x^" + (i + 1) + "*yi=" + somatorioVetB[i]);
            }

            for (i = 0; i < m; i++) //Monta a matriz do calculo
            {
                for (j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        matrizCalc[i, j] = n;
                    }
                    else
                    {
                        matrizCalc[i, j] = somatorioPotX[i + j - 1];
                    }
                    //MessageBox.Show("Matriz A[" + i + j + "]=" + matrizCalc[i, j].ToString());
                }
            }

            gauss(m, matrizCalc, somatorioVetB, ref vetSol);

            #region Cálculos de resultado
            if (curva == 0 || curva == 5 || curva==6 || curva==8) //y = a + b*x,y=e^(a+b*x),y=1/(a+b*x),y=1/(1+e^(a+b*x))
            {
                textA.Text = vetSol[0].ToString();
                textB.Text = vetSol[1].ToString();
            }

            else if(curva == 1 || curva == 3) //y = a*b^x, y = a*b^(e*x)
            {
                /*double somaerro = 0,somayq = 0,somay=0;

                for (i = 0; i < n; i++)
                {
                    somaerro += Math.Pow((yOriginal[i]-valY[i]), 2);
                    somayq += Math.Pow(yOriginal[i],2);
                    somay += yOriginal[i];
                }

                double c = 1 - ((n * somaerro) / (n*somayq - Math.Pow(somay, 2)));*/

                vetSol[0] = Math.Pow(Math.E, vetSol[0]);
                vetSol[1] = Math.Pow(Math.E, vetSol[1]);
                textA.Text = vetSol[0].ToString();
                textB.Text = vetSol[1].ToString();
                //textR.Text = c.ToString();
            }

            else if(curva == 2 || curva == 4) //y = a*x^b
            {
                vetSol[0] = Math.Pow(Math.E, vetSol[0]);
                textA.Text = vetSol[0].ToString();
                textB.Text = vetSol[1].ToString();
            }

            else if(curva == 7) //y=x/(a+b*x)
            {
                textB.Text = vetSol[0].ToString();
                textA.Text = vetSol[1].ToString();
            }

            #endregion
        }

        //FUNCÕES DE INTERFACE
        private bool passaTextDouble()
        {
            for(int i = 0; i < n; i++)
            {
                if(x[i].Text == "" || y[i].Text == "")
                {
                    MessageBox.Show("Preencha todos os espaços!");
                    return false;
                }

                valX[i] = Convert.ToDouble(x[i].Text);
                valY[i] = Convert.ToDouble(y[i].Text);

                
            }

            return true;
        }
//-------------------------------------------------------------------------------
        private void curvasCalc_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                m = 2;
                n = (int)nPontos.Value;

                if (!passaTextDouble())
                {
                    return;
                }

                minimosQuadradosComR(comboBox1.SelectedIndex);



            }
        }
//-------------------------------------------------------------------------------
        private void calcPoli_Click(object sender, EventArgs e)
        {
            m = (int)grauPoli.Value+1;
            n = (int)nPontos.Value;

            if (!passaTextDouble())
            {
                return;
            }

            minimosQuadrados();

        }
//-------------------------------------------------------------------------------
        private void grauPoli_ValueChanged(object sender, EventArgs e)
        {
            int n = (int)grauPoli.Value + 1;

            for (int i = 0; i < 6; i++)
            {

                if (i < n)
                {
                    a[i].Visible = true;
                }
                else
                {
                    a[i].Visible = false;
                }
            }

        }
//-----------------------------------------------------------------------------------------
        private void nPontos_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < nPontos.Value; i++)
            {
                x[i].Visible = true;
                y[i].Visible = true;
            }

            for (int i = (int)nPontos.Value; i < 20; i++)
            {
                x[i].Visible = false;
                y[i].Visible = false;
            }


        }

    }
}
