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

        TextBox[] x, y;
        double[] valX = new double[20];
        double[,] valY = new double[20, 20];

        public Form1()
        {
            InitializeComponent();

            x = new TextBox[20];
            y = new TextBox[20];
            panelX.AutoScroll = true;
            panelY.AutoScroll = true;

            for (int i = 0; i < 20; i++)
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

        }


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
