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

        TextBox[,] matrizA = new TextBox[10, 10];

        public Form1()
        {
            InitializeComponent();

            int i, j;

            for (i = 0; i < 10; i++) //instancia TextBoxes
            {
                for (j = 0; j < 10; j++)
                {
                    matrizA[i, j] = new TextBox();
                    matrizA[i, j].Visible = false;
                    matAPanel.Controls.Add(matrizA[i, j], i, j);
                }
            }


            ShowBoxesPanel(3);

        }


        private void ShowBoxesPanel(int n)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrizA[i, j].Visible = true;
                }
            }
        }
    }
}
