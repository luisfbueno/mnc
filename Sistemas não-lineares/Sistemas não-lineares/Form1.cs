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

            ordemSist.Value = 3;

            fxi[0].Text = "sin(x1) + x2^2 + ln(x3) - 7";
            fxi[1].Text = "3*x1 + 2^x2 - x3^3 + 1";
            fxi[2].Text = "x1 + x2 + x3 - 5";
            xi[0].Text = "1";
            xi[1].Text = "1";
            xi[2].Text = "1";
            epsilon.Text = "0,01";

            newton.Checked = true;

            MessageBox.Show("Versão 3: \n-Correção de problemas com resolução de sistemas");
        }

        //FUNÇÕES DE CÁLCULO
        private void metGaussPP(int n, double[,] a, double[] b, ref double[] x)
        {
            int i, j, k;
            double multiplicador, soma;

            for (j = 0; j < n - 1; j++)
            {
                int linhaMaximo = j;
                for (int linha = j + 1; linha < n; linha++) //Verifica o maximo na coluna j
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
//--------------------------------------------------------------------------------
        private void decomposicaoLU(ref double[,] L,ref double[,] U,int n,double[,] a)
        {
            int i, j, k;

            for (k = 0; k < n; k++) //Preenche diagonal com 1
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
                    if (U[i, i] != 0)
                        L[j, i] /= U[i, i];
                    else
                    {
                        MessageBox.Show("Ocorreu divisão por zero!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
//--------------------------------------------------------------------------------
        private void resolveSistemasLU(double[,] L,double[,] U,int n,ref double[] x,double[] b)
        {
            double[] y = new double[10];
            double soma;
            int i, j;

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
        }
//--------------------------------------------------------------------------------
        private void gauss(int n, double[,] a, double[] b, ref double[] x)
        {
            int i, j, k;
            double multiplicador, soma;

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
                    //multiplicador = Math.Round(multiplicador, 5);
                    for (k = j; k < n; k++)
                    {
                       // MessageBox.Show(a[i, k].ToString() + "-" + multiplicador.ToString() + "*" + a[j, k].ToString());
                        a[i, k] -= multiplicador * a[j, k];
                        // a[i, k] = Math.Round(a[i, k], 5);
                        
                    }

                    b[i] -= multiplicador * b[j];
                    //b[i] = Math.Round(b[i], 5);
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
                //soma = Math.Round(soma, 5);
                x[i] = (b[i] - soma) / a[i, i];
            }

        }
//--------------------------------------------------------------------------------
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
        private bool verificaDiagonalPrincipal(ref double[,] mat, ref double[] vet, int n) //Função que verifica se tem 0 na diagonal principal e efetua trocas
        {
            int linha, coluna, i, j, k;
            bool achou = false, zero = false;
            double aux;

            for (i = 0; i < n; i++)
            {
                if (mat[i, i] == 0) //caso haja 0 na diagonal principal, procura
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
                            mat[i, j] = mat[linha, j];
                            mat[linha, j] = aux;

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
//---------------------------------------------------------------------------------
        private void Newton(int n)
        {
            double[,] jacobiano = new double[10, 10];
            double[] F = new double[10];
            double parada = 1;
            double cont = 0;
            double[] h = new double[10];
            double[] x = new double[10];
            double[] xk = new double[10];
            double[] dif = new double[10];
            double[] moduloxk = new double[10];

            for (int i = 0; i < n; i++)
            {
                x[i] = vetX[i];
            }

           while(Math.Abs(parada)>eps && cont < it)
           {

                for (int i= 0;i< n; i++) //Zerar vetor h para nao ocorrerem erros de calculo
                {
                    h[i] = 0;
                }

                for(int i = 0; i < n; i++) //Calcula vetor F de valores das funções
                {
                    F[i] = - parser.Parse(vetFx[i]);
                    F[i] = Math.Round(F[i], 5);
                   // MessageBox.Show("f" + i +" = " + F[i]);
                }

                for(int i = 0; i < n; i++) //Calcula matriz Jacobiana
                {
                    for(int j = 0; j < n; j++)
                    {
                        jacobiano[i, j] = DerivadaParcial(vetFx[i],x,j);
                        jacobiano[i, j] = Math.Round(jacobiano[i, j], 5);
                       // MessageBox.Show("j" + i + j + " = " + jacobiano[i, j]);
                    }
                }

                metGaussPP(n, jacobiano, F, ref h); //Resolve o sistema

                for(int i = 0; i < n; i++)
                {
                    h[i] = Math.Round(h[i], 5);
                    //MessageBox.Show("h+" + i + "= " + h[i]);
                    xk[i] = x[i] + h[i];
                    moduloxk[i] = Math.Abs(x[i] + h[i]);
                    dif[i] = Math.Abs(xk[i] - x[i]);
                }

                parada = dif.Max();

              
                for (int i = 0; i < n; i++) //salva vetor calculado em x para comparação posterior
                {
                    x[i] = xk[i];
                    parser.Values["x" + (i + 1)].SetValue(x[i]);
                }

                cont++;
            }

            for(int i = 0; i < n; i++)
            {
                parser.Values["x" + (i + 1)].SetValue(x[i]);  
                
                if(Double.IsInfinity(x[i]) || Double.IsNaN(x[i])) {

                    MessageBox.Show("Ocorreu indeterminação ou overflow durante os cálculos, tente alterar os valores ou trocar o método utilizado!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                } 
            }

            if (cont < it)
            {
                for (int i = 0; i < n; i++)
                {
                    xifinal[i].Text = x[i].ToString();
                    double resu = parser.Parse(vetFx[i]);
                    fxifinal[i].Text = resu.ToString();                 
                }
                MessageBox.Show("Iterações = " + cont.ToString());
            }
            else
                MessageBox.Show("O método não convergiu para este número de iterações!");

        }
//---------------------------------------------------------------------------------
        private void NewtonModificado(int n)
        {
            double[,] jacobiano = new double[10, 10];
            double[] F = new double[10];
            double parada = 1;
            double cont = 0;
            double[] h = new double[10];
            double[] x = new double[10];
            double[] xk = new double[10];
            double[] dif = new double[10];
            double[] moduloxk = new double[10];
            double[,] l = new double[10, 10];
            double[,] u = new double[10, 10];

            for (int i = 0; i < n; i++)
            {
                x[i] = vetX[i];
            }

 
            for (int i = 0; i < n; i++) //Calcula matriz Jacobiana a ser usada em todos os métodos, até k
            {
                for (int j = 0; j < n; j++)
                {
                    jacobiano[i, j] = DerivadaParcial(vetFx[i], x, j);
                    jacobiano[i, j] = Math.Round(jacobiano[i, j], 5);
                    // MessageBox.Show("j" + i + j + " = " + jacobiano[i, j]);
                }
            }

            decomposicaoLU(ref l, ref u, n, jacobiano);

            while (Math.Abs(parada) > eps && cont < it)
            {

                if(cont%5 == 0)
                {
                    for (int i = 0; i < n; i++) //Calcula matriz Jacobiana a ser usada em todos os métodos, até k
                    {
                        for (int j = 0; j < n; j++)
                        {
                            jacobiano[i, j] = DerivadaParcial(vetFx[i], x, j);
                            jacobiano[i, j] = Math.Round(jacobiano[i, j], 5);
                            // MessageBox.Show("j" + i + j + " = " + jacobiano[i, j]);
                        }   
                    }
                    decomposicaoLU(ref l, ref u, n, jacobiano);
                }

                for (int i = 0; i < n; i++) //Zerar vetor h para nao ocorrerem erros de calculo
                {
                    h[i] = 0;
                }

                for (int i = 0; i < n; i++) //Calcula vetor F de valores das funções
                {
                    F[i] = -parser.Parse(vetFx[i]);
                    F[i] = Math.Round(F[i], 5);
                    // MessageBox.Show("f" + i +" = " + F[i]);
                }

                resolveSistemasLU(l, u, n, ref h, F); //Resolve o sistema

                for (int i = 0; i < n; i++)
                {
                    h[i] = Math.Round(h[i], 5);
                    //MessageBox.Show("h+" + i + "= " + h[i]);
                    xk[i] = x[i] + h[i];
                    moduloxk[i] = Math.Abs(x[i] + h[i]);
                    dif[i] = Math.Abs(xk[i] - x[i]);
                }

                parada = dif.Max();

                for (int i = 0; i < n; i++) //salva vetor calculado em x para comparação posterior
                {
                    x[i] = xk[i];
                    parser.Values["x" + (i + 1)].SetValue(x[i]);
                }

                cont++;
            }

            for (int i = 0; i < n; i++)
            {
                parser.Values["x" + (i + 1)].SetValue(x[i]);

                if (Double.IsInfinity(x[i]) || Double.IsNaN(x[i]))
                {
                    MessageBox.Show("Ocorreu indeterminação ou overflow durante os cálculos, tente alterar os valores ou trocar o método utilizado!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            if (cont < it)
            {
                for (int i = 0; i < n; i++)
                {
                    xifinal[i].Text = x[i].ToString();
                    double resu = parser.Parse(vetFx[i]);
                    fxifinal[i].Text = resu.ToString();
                }
                MessageBox.Show("Iterações = " + cont.ToString());
            }
            else
                MessageBox.Show("O método não convergiu para este número de iterações!");

        }

//FUNÇÕES DE INTERFACE
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
            if(eps<0.0001 || eps > 0.1)
            {
                MessageBox.Show("Coloque um valor válido para epsilon!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            it = (int)iteracoes.Value;

            if (newton.Checked)
                Newton(n);
            else
                NewtonModificado(n);


        }



    }
}
