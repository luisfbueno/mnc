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
                    matAPanel.Controls.Add(matA[i, j], i, j);
                }
            }

            gaussComp.Enabled = false;
            gaussPP.Enabled = false;
            gaussPT.Enabled = false;
            gaussSeidel.Enabled = false;
            cholesky.Enabled = false;
            lu.Enabled = false;
            jacobi.Enabled = false;


            ShowBoxesPanel(3);

        }

//----------------------------------------------------------------------------
        private void passaTextDouble()
        {
            int n = (int)ordemSist.Value;
            for (int i= 0; i < n; i++)
            {
                b[i] = Convert.ToDouble(vetB[i].Text);
                for(int j = 0; j < n; j++)
                {
                    a[i, j] = Convert.ToDouble(matA[i, j].Text);
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



        //FUNÇÕES DE CALCULO
        private void gauss()
        {
            int i, j, k;
            double multiplicador, soma;
            int n = (int)ordemSist.Value;

            passaTextDouble();

            for (j = 0; j < n - 1; j++)
            {
                for (i = j + 1; i < n; i++)
                {
                    multiplicador = a[i, j] / a[j, j];
                    for (k = j; k < n; k++)
                    {
                        a[i, k] -= multiplicador * a[j, k];
                    }

                    b[i] -= multiplicador * b[j];
                }

            }

            x[n - 1] = b[n - 1] / a[n - 1, n - 1];
            for (i = n - 1; i >= 0; i--)
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
 //-----------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (gaussSimples.Checked)
            {
                gauss();
            }
        }
    }
}
