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
                vetB[i].Enabled = false;
                vetBPanel.Controls.Add(vetB[i], i, 0);
                vetX[i] = new TextBox();
                vetX[i].Enabled = false;             
                vetXPanel.Controls.Add(vetX[i], i, 0);
                for (j = 0; j < 10; j++)
                {
                    matA[i, j] = new TextBox();
                    matA[i, j].Enabled = false;
                    matAPanel.Controls.Add(matA[i, j], j, i);
                   // matA[i, j].Text = i.ToString() + j.ToString();
                }
            }

            gaussPT.Enabled = false;
            //gaussSeidel.Enabled = false;
            inversa.Enabled = false;

            ShowBoxesPanel(3);


        }

        //FUNÇÕES DE CALCULO
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
//-----------------------------------------------------------------------------
        private void metGauss()
        {
            int i, j, k;
            double multiplicador, soma;
            int n = (int)ordemSist.Value;
            double[,] aOrig = new double[10, 10];

            passaTextDouble();

            /*if (inversa.Checked)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        aOrig[i, j] = a[i, j];
                    }
                }
            }*/

            for (j = 0; j < n - 1; j++)
            {
                if (j != 0)
                {
                    if (!verificaDiagonalPrincipal(ref a, ref b, n))
                    {
                        MessageBox.Show("Ocorreu zero na diagonal principal e não foi possivel efetuar a troca!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (i = j + 1; i < n; i++)
                {
                    multiplicador = a[i, j] / a[j, j];
                    for (k = j; k < n; k++)
                    {
                        //MessageBox.Show(a[i, k].ToString() + "-" + multiplicador.ToString() + "*" + a[j, k].ToString());
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
                for (j = i + 1; j < n; j++)
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

           /* if (inversa.Checked)
            {
                double[] vetId = new double[10];
                double[] vetSol = new double[10];
                double[,] c = new double[10, 10];
                double[,] mat = new double[10,10];

                for (i = 0; i < n; i++)
                {

                    for (j = 0; j < n; j++)
                    {
                        for (k = 0; k < n; k++)
                        {
                            mat[i, j] = aOrig[i, j];
                        }
                    }

                    for (j = 0; j < n; j++)//preenche vetor auxiliar de identidade
                    {
                        if (j == i)
                        {
                            vetId[j] = 1;
                        }
                        else
                        {
                            vetId[j] = 0;
                        }
                        vetSol[i] = 0;
                    }

                    gauss(n, mat, vetId, ref vetSol);


                    for (j = 0; j < n; j++)
                    {
                        c[j, i] = vetSol[j];
                    }


                }

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        matA[i, j].Text = c[i, j].ToString();
                    }
                }

            }*/
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
            for (i = 1; i < n; i++)
            {
                soma = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    soma += L[i, j] * y[j];
                }
                y[i] = (b[i] - soma) / L[i, i];
            }

            x[n - 1] = y[n - 1] / U[n - 1, n - 1];
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + 1; j < n; j++)
                {
                    soma += U[i, j] * x[j];
                }
                x[i] = (y[i] - soma) / U[i, i];
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
        private void metGaussCompacto()
        {
            double[,] LU = new double[20, 20];
            int i,j,k;
            int n = (int)ordemSist.Value;

            passaTextDouble();

            for (i = 0; i < n; i++) //Preenche as matrizes LU
            {
                for (j = i; j < n; j++)
                {
                    LU[i, j] = a[i, j];
                    for (k = 0; k < i; k++)
                    {
                        LU[i, j] -= LU[i, k] * LU[k, j];
                    }
                }
                for (j = i + 1; j < n; j++)
                {
                    LU[j, i] = a[j, i];
                    for (k = 0; k < i; k++)
                    {
                        LU[j, i] -= LU[j, k] * LU[k, i];
                    }
                    if (LU[i, i] != 0)
                        LU[j, i] /= LU[i, i];
                    else
                    {
                        MessageBox.Show("Ocorreu divisão por zero!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            for (i = 0; i < n; i++) //Efetua mudanças no vetor B
            {
                for (j = 0; j < n; j++)
                {
                    b[i] -= b[j] * LU[i, j];
                }
            }

            double soma = 0; 
            x[n - 1] = b[n - 1] / LU[n - 1, n - 1];
            for (i = n - 2; i >= 0; i--)
            {
                soma = 0;
                for (j = i + 1; j < n; j++)
                {
                    soma += LU[i, j] * x[j];
                }
                x[i] = (b[i] - soma) / LU[i, i];
            }

            for (i = 0; i < n; i++)
            {
                vetX[i].Text = x[i].ToString();
            }

        }
//------------------------------------------------------------------------------
        private void metJacobi(int iteracoes,double[] xini,double epsilon)
        {
            double max;
            int i, j, k;
            int n = (int)ordemSist.Value;
            bool cLinhas = false, cColunas = false;

            passaTextDouble();

            #region Critério das linhas e das colunas
              //Critério das linhas
              max = 0;
              for (i = 0; i < n; i++)
              {
                  double aux = 0;
                  for (j = 0; j < n; j++)
                  {
                      if (i != j)
                      {
                          aux += Math.Abs(a[i, j]);
                      }
                  }
                  aux /= a[i, i];
                  if(max < aux)
                  {
                      max = aux;
                  }
              }

              if (max < 1)
              {
                  cLinhas = true;
              }

              //Critério das colunas
              max = 0;
              for (j = 0; j < n; j++)
              {
                  double aux = 0;
                  for (i = 0; i < n; i++)
                  {
                      if (i != j)
                      {
                          aux += Math.Abs(a[i, j]);
                      }
                  }
                  aux /= a[i, i];
                  if (max < aux)
                  {
                      max = aux;
                  }
              }

              if (max < 1)
              {
                  cColunas = true;
              }

              if(!cLinhas && !cColunas) //Se não atende aos critérios, interrompe e informa
              {
                  MessageBox.Show("Os valores não atendem ao critério das linhas e o das colunas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }
            #endregion


            int cont = 0;
            bool achou = false;
            while(!achou && cont < iteracoes)
            {
                for (i = 0; i < n; i++)
                {
                    double aux = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            aux += a[i, j] * xini[j];
                        }
                    }
                    x[i] = (b[i] - aux) / a[i, i];
                }

                //calcula vetor de diferenças
                double[] vetdif = new double[10];
                for (i = 0; i < n; i++)
                {
                    vetdif[i] = Math.Abs(xini[i] - x[i]);
                }

                if(vetdif.Max() < epsilon) //Se for menor que epsilon, achou
                {
                    achou = true;
                }

                for (i = 0; i < n; i++) //Passa o vetor encontrado para xini para usar no seguinte cálculo
                {
                    xini[i] = x[i];
                }

                cont++;
            }

            if (achou == true)
            {
                for (i = 0; i < n; i++)
                {
                    vetX[i].Text = x[i].ToString();
                }
            }
            else
            {
                MessageBox.Show("O método não convergiu para o dado número de iterações", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

          }
//------------------------------------------------------------------------------
        private void metGaussSeidel(int iteracoes, double[] xini, double epsilon)
        {
            double max;
            int i, j, k;
            int n = (int)ordemSist.Value;
            bool cLinhas = false, cSassenfeld = false;

            passaTextDouble();

            #region Critério das linhas e Sassenfeld
            //Critério das linhas
            max = 0;
            for (i = 0; i < n; i++)
            {
                double aux = 0;
                for (j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        aux += Math.Abs(a[i, j]);
                    }
                }
                aux /= a[i, i];
                if (max < aux)
                {
                    max = aux;
                }
            }

            if (max < 1)
            {
                cLinhas = true;
            }

            //Critério de Sassenfeld
            max = 0;
            double[] beta = new double[10];
            for (i = 0; i < n; i++)
            {
                beta[i] = 0;
                for (j = 0; j < n; j++)
                {
                    if (j > i)
                    {
                        beta[i] += a[i, j];
                    }
                    else if (i > j)
                    {
                        beta[i] += a[i, j] * beta[j];
                    }
                }
                beta[i] /= a[i, i];
                if (max < beta[i])
                {
                    max = beta[i];
                }
            }

            if (max < 1)
            {
                cSassenfeld = true;
            }

            if (!cLinhas && !cSassenfeld) //Se não atende aos critérios, interrompe e informa
            {
                MessageBox.Show("Os valores não atendem ao critério das linhas e o das colunas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion


            int cont = 0;
            bool achou = false;
            while (!achou && cont < iteracoes)
            {
                for (i = 0; i < n; i++)
                {
                    double aux = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            aux += a[i, j] * x[j];
                        }
                    }
                    x[i] = (b[i] - aux) / a[i, i];
                }

                //calcula vetor de diferenças
                double[] vetdif = new double[10];
                for (i = 0; i < n; i++)
                {
                    vetdif[i] = Math.Abs(xini[i] - x[i]);
                }

                if (vetdif.Max() < epsilon) //Se for menor que epsilon, achou
                {
                    achou = true;
                }

                for (i = 0; i < n; i++) //Passa o vetor encontrado para xini para usar no seguinte cálculo
                {
                    xini[i] = x[i];
                }

                cont++;
            }

            if (achou == true)
            {
                for (i = 0; i < n; i++)
                {
                    vetX[i].Text = x[i].ToString();
                }
            }
            else
            {
                MessageBox.Show("O método não convergiu para o dado número de iterações", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                vetB[i].Enabled = true;
                vetX[i].Enabled = true;
                for (int j = 0; j < n; j++)
                {
                    matA[i, j].Enabled = true;
                }
            }

            
        }
//-----------------------------------------------------------------------------
        private void ordemSist_ValueChanged(object sender, EventArgs e)
        {
            for (int i = (int)ordemSist.Value; i < 10; i++)
            {
                vetB[i].Enabled = false;
                vetX[i].Enabled = false;
                for (int j = 0; j < 10; j++)
                {
                    matA[i, j].Enabled = false;
                    matA[j, i].Enabled = false;
                }
            }

            ShowBoxesPanel((int)ordemSist.Value);
        }
//-----------------------------------------------------------------------------
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
            if (jacobi.Checked)
            {
                if(tolerancia.Text == "")
                {
                    MessageBox.Show("Preencha o valor da tolerância!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double eps = Double.Parse(tolerancia.Text);
                if(eps<0.00001 || eps> 0.001)
                {
                    MessageBox.Show("Coloque um valor válido para a tolerância!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double[] xini = new double[10];

                for(int i = 0; i < (int)ordemSist.Value; i++)
                {
                    if(vetX[i].Text== "")
                    {
                        MessageBox.Show("Preencha todo o vetor X", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    xini[i] = Double.Parse(vetX[i].Text);
                }


                metJacobi(int.Parse(numItera.Text), xini, eps);
            }
            if (gaussSeidel.Checked)
            {
                if (tolerancia.Text == "")
                {
                    MessageBox.Show("Preencha o valor da tolerância!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double eps = Double.Parse(tolerancia.Text);
                if (eps < 0.00001 || eps > 0.001)
                {
                    MessageBox.Show("Coloque um valor válido para a tolerância!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double[] xini = new double[10];

                for (int i = 0; i < (int)ordemSist.Value; i++)
                {
                    if (vetX[i].Text == "")
                    {
                        MessageBox.Show("Preencha todo o vetor X", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    xini[i] = Double.Parse(vetX[i].Text);
                }

                metGaussSeidel(int.Parse(numItera.Text), xini, eps);
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
//------------------------------------------------------------------------------
        private void gaussComp_CheckedChanged(object sender, EventArgs e)
        {
            if (gaussComp.Checked)
            {
                det.Enabled = false;
            }
            else
            {
                det.Enabled = true;
            }
        }
//------------------------------------------------------------------------------
        private void jacobi_CheckedChanged(object sender, EventArgs e)
        {
            if (jacobi.Checked)
            {
                det.Enabled = false;
                MessageBox.Show("Digite o vetor aproximado no espaço de solução do vetor x!", "Atençao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                det.Enabled = true;
            }
        }
//------------------------------------------------------------------------------
        private void gaussSeidel_CheckedChanged(object sender, EventArgs e)
        {
            if (gaussSeidel.Checked)
            {
                det.Enabled = false;
                MessageBox.Show("Digite o vetor aproximado no espaço de solução do vetor x!", "Atençao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                det.Enabled = true;
            }
        }
//------------------------------------------------------------------------------
        private void gaussSimples_CheckedChanged(object sender, EventArgs e)
        {
            /*if (gaussSimples.Checked)
            {
                inversa.Enabled = true;
                inversa.Checked = false;
            }
            else
            {
                inversa.Enabled = false;
            }*/
        }
    }
}
