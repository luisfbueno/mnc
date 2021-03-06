﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;

namespace Interpolação
{
    public partial class Form1 : Form
    {

        TextBox[] x,y;
        double[] valX = new double[20];
        double[,] valY = new double[20,20];

        public Form1() 
        {
            InitializeComponent();
            //textPontos.ReadOnly = true;
            //textPontos.BackColor = System.Drawing.SystemColors.Window;
            x = new TextBox[20];
            y = new TextBox[20];
            panelX.AutoScroll = true;
            panelY.AutoScroll = true;

            for(int i = 0; i < 20; i++)
            {
                x[i] = new TextBox();
                y[i] = new TextBox();

                x[i].Visible = false;
                y[i].Visible = false;

                panelX.Controls.Add(x[i]);
                panelY.Controls.Add(y[i]);

            }

            for (int i = 0; i < 7; i++)
            {
                x[i].Visible = true;
                y[i].Visible = true;
            }

            ///Testes para Newton
            /*
            x[0].Text = "-2";
            x[1].Text = "-1";
            x[2].Text = "0,5";
            x[3].Text = "2";
            x[4].Text = "3,5";
            x[5].Text = "4";

            y[0].Text = "1";
            y[1].Text = "2,5";
            y[2].Text = "1,5";
            y[3].Text = "1";
            y[4].Text = "-1";
            y[5].Text = "0,5";

            nPontos.Value = 6;*/
            
            

            //Testes para Newton Gregory
            x[0].Text = "-2";
            x[1].Text = "-1";
            x[2].Text = "0";
            x[3].Text = "1";
            x[4].Text = "2";
            x[5].Text = "3";
            x[6].Text = "4";

            y[0].Text = "1";
            y[1].Text = "2,5";
            y[2].Text = "1,6";
            y[3].Text = "1,5";
            y[4].Text = "1";
            y[5].Text = "-0,7";
            y[6].Text = "0,5";

            nPontos.Value = 7;
            

            newton.Checked = true;

            MessageBox.Show("Versão 3: \n-Agora é possível calcular o polinômio para graus menores do que (Pontos - 1)\n-Desenho de gráficos");

        } 
 
//FUNÇÕES DE CALCULO
        
        private void gauss(int n,double[,] a,double[] b,ref double[] x)
        {
            int i, j,k;
            double multiplicador,soma;

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
            for (i = n - 2; i>= 0; i--)
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
        private void sistLin(int n)
        {

            int i, j;
            double[,] matA = new double[20,20]; //Matriz A para 
            double[] vetY = new double[20]; //Vator Y para resolução
            double[] vetX = new double[20]; //Vetor solução X para solucionar Gauss

            for (i = 0; i < n; i++) //monta matriz a
            {
                for (j = 0; j < n; j++)
                {
                    matA[i, j] = Math.Pow(valX[i], j);
                }
                vetY[i] = valY[i, 0]; //monta vetor y 
            }

            gauss(n,matA,vetY,ref vetX);

            String polinomio = "";

            for (i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    polinomio += " + ";
                }
                polinomio += vetX[i].ToString() + "*" + (Math.Pow(valX[i], i)).ToString(); //Ai * Xi^i 
            }

            textEqu.Text = polinomio;
        }
//---------------------------------------------------------------------------------------------
        private double fatorial(double n)
        {
            int i = 1;
            double fat = 1;

            for (i = 2; i <= n; i++)
            {
                fat *= (double)i;
            }

            return fat;
        }
//---------------------------------------------------------------------------------------------
        private bool passaTextValores() //Função que passa os valores dos TextBoxs para vetores de double
        {
            for (int i= 0;i< nPontos.Value; i++)
            {
                if(x[i].Text == "" || y[i].Text == "")
                {
                    MessageBox.Show("Preencha todos os espaços!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }

                valX[i] = Convert.ToDouble(x[i].Text);
                valY[i, 0] = Convert.ToDouble(y[i].Text);
            }
            return true;
        }
//---------------------------------------------------------------------------------------------
        private void metodoNewton(int n)
        {
            int i,j,m;
            m = n;

            for (i = 1; i < n; i++) 
            {
                for (j = 0; j < m; j++) //faz os cálculos para a matriz valY
                {
                    valY[j, i] = (valY[j + 1,i - 1] - valY[j, i - 1]) / (valX[j + i] - valX[j]);
                }
                m--;
            }

            //Monta o Polinômio
            String polinomio = "";
            n = (int)nPontos.Value;

            for (i = 0; i < n-1; i++)
            {
                if (i != 0)
                {
                    polinomio += "*(";
                }

                polinomio += (valY[0, i]).ToString() + " + (x";
                if (valX[i] > 0)
                {
                    polinomio += " - " + valX[i].ToString() + ")";
                }
                else
                {
                    polinomio += " + " + (-valX[i]).ToString() + ")";
                }

            }

            polinomio += "*(" + valY[0, n - 1].ToString();

            for (i = 0; i < n - 1; i++)
            {
                polinomio += ")";
            }
            textEqu.Text = polinomio;

        }
//---------------------------------------------------------------------------------------------
        private void metodoNewtonGregory(int n)
        {
       
            int i, j,m;
            double dif = Math.Abs(valX[1] - valX[0]); //salva valor da diferença para verificar se os pontos são equidistantes 
            m = n-1;

            for (i = 1; i < n - 1; i++) //Verifica se os pontos são equidistantes
            {
                if(Math.Abs(valX[i+1]-valX[i]) != dif)
                {
                    MessageBox.Show("Os pontos não são equidistantes!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            for (i = 1; i < n; i++)
            {
                for (j = 0; j < m; j++) //faz os cálculos para a matriz valY
                {
                    valY[j, i] = valY[j + 1,i-1] - valY[j,i-1];
                }
                m--;
            }

            // Monta o Polinômio
            String polinomio = "";
            n = (int)nPontos.Value;

            for (i = 0; i < n - 1; i++)
            {
                if (i != 0)
                {
                    polinomio += "*(";
                }

                polinomio += (valY[0, i]/(fatorial((double)i) * Math.Pow(dif,i))).ToString() + " + (x";
                if (valX[i] > 0)
                {
                    polinomio += " - " + valX[i].ToString() + ")";
                }
                else
                {
                    polinomio += " + " + (-valX[i]).ToString() + ")";
                }

            }

            polinomio += "*(" + (valY[0, n-1] / (fatorial((double)n-1) * Math.Pow(dif, i))).ToString();
            //polinomio += "{" + (valY[0, n]).ToString() + "/" + (fatorial((double)n - 1) + Math.Pow(dif, i)).ToString();

            for (i = 0; i < n - 1; i++)
            {
                polinomio += ")";
            }
            textEqu.Text = polinomio;
        }
//---------------------------------------------------------------------------------------------
        private double calculaVal(double x)
        {
            double num = 0;
            double multiplicador = 1;

            for(int i = 0; i < nPontos.Value; i++)
            {
                num += multiplicador * valY[0, 1];
                multiplicador *= (x - valX[i]);
            }

            return num;
        }


//FUNÇÕES DE INTERFACE 
        private void calc_Click(object sender, EventArgs e) 
        {
            int n = 0;

            passaTextValores();

            if((int)nPontos.Value == ((int)grauPoli.Value + 1)) //se o grau do polinomio for nPontos -1, n = grau
            {
                n = (int)nPontos.Value;
            }

            else if(nPontos.Value > grauPoli.Value) //Se houver mais pontos do que o grau pedido, diminuir vetor em volta do ponto de referencia dado
            {

                int k = (int)grauPoli.Value;
                n = (int)nPontos.Value;
                double[] vetDif = new double[20];
                if (pRef.Text == "")
                {
                    MessageBox.Show("Preencha o valor do ponto de referência!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double z = double.Parse(pRef.Text);

                for (int i = 0; i < n; i++) //faz vetor de diferenças (x-z)
                {
                    vetDif[i] = Math.Abs(valX[i] - z);
                }

                //ordena vetor de diferenças por bubble sort, trocando também o vetor x e y
                bool troca = true;
                for (int i = 0; i < n - 1 && troca; i++)
                {
                    troca = false;
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (vetDif[j] > vetDif[j + 1])
                        {
                            troca = true;
                            double aux = valX[j];
                            valX[j] = valX[j + 1];
                            valX[j + 1] = aux;

                            aux = valY[j, 0];
                            valY[j, 0] = valY[j + 1, 0];
                            valY[j + 1, 0] = aux;

                            aux = vetDif[j];
                            vetDif[j] = vetDif[j + 1];
                            vetDif[j + 1] = aux;

                        }
                    }
                }

                troca = true;
                //ordena vetor x de menores diferenças por bubble sort
                for (int i = 0; i < k && troca; i++)
                {
                    troca = false;
                    for (int j = 0; j < k - i - 1; j++)
                    {
                        if (valX[j] > valX[j + 1])
                        {
                            troca = true;
                            double aux = valX[j];
                            valX[j] = valX[j + 1];
                            valX[j + 1] = aux;

                            aux = valY[j, 0];
                            valY[j, 0] = valY[j + 1, 0];
                            valY[j + 1, 0] = aux;
                        }
                    }

                }

                n = k; //define o grau do polinomio para k

            }

            else if(grauPoli.Value >= nPontos.Value)
            {
                MessageBox.Show("Número de pontos insuficiente para calcular o polinomio de grau desejado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Executa o método selecionado
            if (sistLinear.Checked)
            {
                sistLin(n);
            }
            else if (newton.Checked)
            {
                metodoNewton(n);
            }
            else if (newtonGregory.Checked)
            {
                metodoNewtonGregory(n);
            }
        }
//----------------------------------------------------------------------------------------------
        private void reset_Click(object sender, EventArgs e)
        {
            for(int i=0; i < nPontos.Value; i++)
            {
                x[i].Text = "";
                y[i].Text = "";
                textEqu.Text = "";
            }
        }
//----------------------------------------------------------------------------------------------
        private void grafico_Click(object sender, EventArgs e)
        {
            if (passaTextValores() && textEqu.Text != "")
            {
                Grafico g = new Grafico(valX, valY, (double)nPontos.Value);
                g.Show();
            }
        }
//----------------------------------------------------------------------------------------------
        private void nPontos_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < nPontos.Value; i++)
            {
                x[i].Visible = true;
                y[i].Visible = true;
            }

            for(int i = (int)nPontos.Value; i< 20; i++)
            {
                x[i].Visible = false;
                y[i].Visible = false;
            }

        }

    }
}
