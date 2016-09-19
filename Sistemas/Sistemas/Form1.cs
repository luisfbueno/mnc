using System;
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
            gaussPT.Enabled = false;
            gaussSeidel.Enabled = false;
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
                if (j != 0)
                {
                    if (!verificaDiagonalPrincipal(ref a, ref b, n))
                    {
                        MessageBox.Show("Ocorreu zero na diagonal principal e não foi possivel efetuar a troca!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                for (i = j + 1; i < n; i++)
                {
                    multiplicador = a[i, j] / a[j, j];
                    for (k = j; k < n; k++)
                    {
                        MessageBox.Show(a[i, k].ToString() + "-" + multiplicador.ToString() +"*"+ a[j, k].ToString());
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

            if (det.Checked)
            {
                double det = 1;
                for (i = 0; i < n; i++)
                {
                    det *= a[i, i];
                }
                MessageBox.Show("Determinante = " + det);
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
            double[,] gUm = new double[20,20]; //Matriz que salva a matriz antes de fazer a inversa

            passaTextDouble();
            
            for (i = 0; i < n; i++) //Verificar se a matriz é simetrica
            {
                for (j = i+1; j < n; j++)
                {
                    if (a[i, j] != a[j, i])
                    {
                        MessageBox.Show("A matriz dada nao é simétrica! Não é possivel resolver por Cholesky","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            for (k = 0; k < n; k++) //Decompor A em G
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

            y[0] = b[0] / g[0, 0]; //Calcula o valor de y com g
            for (i = 1; i < n; i++)
            {
                soma = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    soma += g[i, j] * y[j];
                }
                y[i] = (b[i] - soma) / g[i, i];
            }

            for (i = 0; i < n; i++) //Inverte G para calcular X
            {
                for (j = i + 1; j < n; j++)
                {
                    gUm[i, j] = g[i, j];
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
                //vetX[i].Text = Math.Round(x[i]).ToString();
            }

            for (i = 0; i < n; i++)
            {
                vetX[i].Text = x[i].ToString();
            }

            if (det.Checked)
            {
                double detg = 1, detgi = 1;
                for (i = 0; i < n; i++)
                {
                    detg *= g[i, i];
                    detgi += gUm[i, i];
                }
                MessageBox.Show("Determinante = " + (detg * detgi));
            }

        }
//-----------------------------------------------------------------------------
        private void metGaussPP()
        {
            int i, j, k;
            double multiplicador, soma;
            int n = (int)ordemSist.Value;

            passaTextDouble();

            for (j = 0; j < n - 1; j++)
            {
                int linhaMaximo = j;
                for(int linha = j + 1; linha < n; linha++) //Verifica o maximo na coluna j
                {
                    if (a[linha, j] > a[linhaMaximo, j])
                    {
                        linhaMaximo = linha;
                    }
                }

                if (linhaMaximo != j) //Se a linha do maximo for maior do que j,troca a linha j com a linha do valor maximo da coluna
                {
                    double aux = 0;
                    for (int coluna = j; coluna < n; coluna++)
                    {
                        aux = a[j, coluna];
                        a[j, coluna] = a[linhaMaximo, coluna];
                        a[linhaMaximo, coluna] = aux;
                    }
                    aux = b[j];
                    b[j] = b[linhaMaximo];
                    b[linhaMaximo] = aux;
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

            if (det.Checked)
            {
                double det = 1;
                for (i = 0; i < n; i++)
                {
                    det *= a[i, i];
                }
                MessageBox.Show("Determinante = " + det);
            }

        }
//------------------------------------------------------------------------------
        private void metLU()
        {
            double[,] L = new double[10,10];
            double[,] U = new double[10, 10];
            double[] y = new double[10];
            int i, j=0, k;
            int n = (int)ordemSist.Value;
            double soma = 0;

            passaTextDouble();
            
            for (k = 0;k< n; k++) //Preenche diagonal com 1
            {
                L[k, k] = 1;
            }


            for (i = 0; i < n; i++) //Preenche as matrizes U e L
            {
                for (j = i; j < n; j++)
                {
                    U[i, j] = a[i, j];
                    for (k = 0; k < i; k++)
                    {
                        U[i, j] -= L[i, k] * U[k, j];
                    }   
                }
                for (j = i + 1; j < n; j++)
                {
                    L[j, i] = a[j, i];
                    for (k = 0; k < i; k++)
                    {
                        L[j, i] -= L[j, k] * U[k, i];
                    }
                    if(U[i,i]!=0)
                        L[j, i] /= U[i, i];
                    else
                    {
                        MessageBox.Show("Ocorreu divisão por zero!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            y[0] = b[0] / L[0, 0];
            MessageBox.Show("y0=" + y[0]);
            for (i = 1; i < n; i++)
            {
                soma = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    soma += L[i, j] * y[j];
                }
                y[i] = (b[i] - soma) / L[i, i];
                MessageBox.Show("y"+i+"= " + y[i]);
            }

            x[n - 1] = y[n - 1] / U[n - 1, n - 1];
            MessageBox.Show("xn-1=" + x[n-1]);
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + 1; j < n; j++)
                {
                    soma += U[i, j] * x[j];
                }
                x[i] = (y[i] - soma) / U[i, i];
                MessageBox.Show("x" + i + "= " + x[i]);
            }

            for (i = 0; i < n; i++)
            {
                vetX[i].Text = x[i].ToString();
            }

            if (det.Checked) //Se determinante selecionado, mostra determinante
            {
                double detl = 1, detu = 1;
                for (i = 0; i < n; i++)
                {
                    detl *= L[i, i];
                    detu += U[i, i];
                }
                MessageBox.Show("Determinante = " + (detl * detu));
            }

        }
//------------------------------------------------------------------------------
       
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
                        //MessageBox.Show("Troca linha com zero " + i.ToString() + "com linha" + linha.ToString());
                        for (j = 0; j < n; j++)
                        {
                            aux = mat[i, j];
                            a[i, j] = a[linha, j];
                            a[linha, j] = aux;
                            
                        }
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
                if (vetB[i].Text == "")
                {
                    MessageBox.Show("Preencha todos os espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                b[i] = double.Parse(vetB[i].Text);
                for(int j = 0; j < n; j++)
                {
                    a[i, j] = double.Parse(matA[i, j].Text);

                    if (matA[i, j].Text == "")
                    {
                        MessageBox.Show("Preencha todos os espaços!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                x[i] = 0;
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
            if (gaussPP.Checked)
            {
                metGaussPP();
            }
            if (lu.Checked)
            {
                metLU();
            }
        }
//------------------------------------------------------------------------------
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
