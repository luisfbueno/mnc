﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistemas
{
    public partial class Form1 : Form
    {

        TextBox[,] matA = new TextBox[10, 10];
        TextBox[] vetB = new TextBox[10];
        TextBox[] vetX = new TextBox[10];
        double[,] a = new double[10, 10];
        double[] b = new double[10];
        double[] x = new double[10];

        public Form1()
        {
            InitializeComponent();

            int i, j;

            for (i = 0; i < 10; i++) //instancia TextBoxes nos Panels e os deixa invisiveis

            {
                vetB[i] = new TextBox();
                vetB[i].Visible = false;
                vetBPanel.Controls.Add(vetB[i], i, 0);
                vetX[i] = new TextBox();
                vetX[i].Visible = false;             
                vetXPanel.Controls.Add(vetX[i], i, 0);
                for (j = 0; j < 10; j++)
                {
                    matA[i, j] = new TextBox();
                    matA[i, j].Visible = false;
                    matAPanel.Controls.Add(matA[i, j], j, i);
                   // matA[i, j].Text = i.ToString() + j.ToString();
                }
            }

            gaussComp.Enabled = false;
            gaussPP.Enabled = false;
            gaussPT.Enabled = false;
            gaussSeidel.Enabled = false;
            lu.Enabled = false;
            jacobi.Enabled = false;

            ShowBoxesPanel(3);

        }

        //FUNÇÕES DE CALCULO
        private void metGauss()
        {
            int i, j, k;
            double multiplicador, soma;
            int n = (int)ordemSist.Value;

            passaTextDouble();

            for (j = 0; j < n - 1; j++)
            {
                if (!verificaDiagonalPrincipal(ref a, ref b, n))
                {
                    MessageBox.Show("Ocorreu zero na diagonal principal e não foi possivel efetuar a troca!");
                    return;
                }
                for (i = j + 1; i < n; i++)
                {
                    multiplicador = a[i, j] / a[j, j];
                    for (k = j; k < n; k++)
                    {
                        //MessageBox.Show(a[i, k].ToString() + "-" + multiplicador.ToString() +"*"+ a[j, k].ToString());
                        a[i, k] -= multiplicador * a[j, k];
                    }
                    b[i] -= multiplicador * b[j];
                }
            }

            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            vetX[n - 1].Text = x[n - 1].ToString();
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + i; j < n; j++)
                {
                    soma += a[i, j] * x[j];
                }
                x[i] = (b[i] - soma) / a[i, i];
                vetX[i].Text = x[i].ToString();
            }



        }
//-----------------------------------------------------------------------------
        private void metCholesky()
        {

            int i, j, k;
            int n = (int)ordemSist.Value;
            double[,] g = new double[20, 20];
            double soma;
            double[] y = new double[20];

            passaTextDouble();
            
            for (i = 0; i < n; i++) //Verificar se a matriz é simetrica
            {
                for (j = i+1; j < n; j++)
                {
                    if (a[i, j] != a[j, i])
                    {
                        MessageBox.Show("A matriz dada nao é simétrica! Não é possivel resolver por Cholesky");
                        return;
                    }
                }
            }

            for (k = 0; k < n; k++) //Decompor A em G*Gt
            {
                soma = 0;
                for (j = 0; j <= k - 1; j++)
                {
                    soma += Math.Pow(g[k, j], 2);
                }
                g[k, k] = Math.Sqrt(a[k, k] - soma);
                for (i = k + 1; i < n; i++)
                {
                    soma = 0;
                    for (j = 0; j < k - 1; j++)
                    {
                        soma += g[i, j] * g[k, j];
                    }
                    g[i, k] = (a[i, k] - soma) / g[k, k];
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    g[i, j] = g[j, i];
                }
            }

            y[0] = b[0] / g[0, 0];
            for (i = 1; i < n; i++)
            {
                soma = 0;
                for (j = i-1; j >= 0; j--)
                {
                    soma += g[i, j] * y[j];
                }
                y[i] = (b[i] - soma) / g[i, i];
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
                //vetX[i].Text = Math.Round(x[i]).ToString();
            }

            for (i = 0; i < n; i++)
            {
                vetX[i].Text = x[i].ToString();
            }

        }
//-----------------------------------------------------------------------------
        private bool verificaDiagonalPrincipal(ref double[,] mat,ref double[] vet,int n) //Função que verifica se tem 0 na diagonal principal e efetua trocas
        {
            int linha, coluna,i,j,k;
            bool achou=false,zero=false;
            double aux;

            for (i = 0; i < n; i++)
            {
                if (a[i,i] == 0) //caso haja 0 na diagonal principal, procura
                {
                    zero = true; //bool para achou zero (caso nao seja possivel a troca, o algoritmo retornará que nao é possivel resolver)
                    linha = i + 1;
                    coluna = i;

                    for (k = linha; k < n && !achou; k++)
                    {
                        if (mat[k, coluna] != 0) //procura numero diferente de 0 na coluna
                        {
                            achou = true;
                            linha = k;
                        }
                    }

                    if (achou) //se achou, efetua troca
                    {
                        MessageBox.Show("Troca linha com zero " + i.ToString() + "com linha" + linha.ToString());
                        for (j = 0; j < n; j++)
                        {
                            //MessageBox.Show(a[i, j].ToString() + "<->" + a[linha, j].ToString());
                            aux = mat[i, j];
                            a[i, j] = a[linha, j];
                            a[linha, j] = aux;
                            
                        }
                        //MessageBox.Show(b[i].ToString() + "<->" + b[linha].ToString());
                        aux = vet[i];
                        vet[i] = vet[linha];
                        vet[linha] = aux;
                    }
                }                    

            }
            if (zero && !achou)
                return false;
            else
                return true;
        }


        //FUNÇÕES DE INTERFACE
        private void passaTextDouble()
        {
            int n = (int)ordemSist.Value;
            for (int i= 0; i < n; i++)
            {
                b[i] = double.Parse(vetB[i].Text);
                for(int j = 0; j < n; j++)
                {
                    a[i, j] = double.Parse(matA[i, j].Text);
                }
            }
        }
//-----------------------------------------------------------------------------  
        private void ShowBoxesPanel(int n)
        {
            for(int i = 0; i < n; i++)
            {
                vetB[i].Visible = true;
                vetX[i].Visible = true;
                for (int j = 0; j < n; j++)
                {
                    matA[i, j].Visible = true;
                }
            }

            
        }
//-----------------------------------------------------------------------------
        private void ordemSist_ValueChanged(object sender, EventArgs e)
        {
            for (int i = (int)ordemSist.Value; i < 10; i++)
            {
                vetB[i].Visible = false;
                vetX[i].Visible = false;
                for (int j = 0; j < 10; j++)
                {
                    matA[i, j].Visible = false;
                    matA[j, i].Visible = false;
                }
            }

            ShowBoxesPanel((int)ordemSist.Value);
        }
//-----------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (gaussSimples.Checked)
            {
                metGauss();
            }
            if (cholesky.Checked)
            {
                metCholesky();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                vetB[i].Text = "";
                vetX[i].Text = "";
                for(int j = 0; j < 10; j++)
                {
                    matA[i, j].Text = "";
                }
            }
        }
    }
}
