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

namespace Interpolação
{
    public partial class Grafico : Form
    {
        public Grafico(double[] pontosX,double[,] pontosY,double n)
        {
            InitializeComponent();

            ExpressionParser p = new ExpressionParser();

            p.Values.Add("x", 0);
            double[] y = new double[(int)n];

            for(int i = 0; i < n; i++) //Adiciona os pontos dados no grafico
            {
                chart1.Series["Pontos Dados"].Points.AddXY(pontosX[i], pontosY[i,0]);
                chart1.Series["Polinômio"].Points.AddXY(pontosX[i], pontosY[i,0]);

                y[i] = pontosY[i, 0];
            }

            chart1.ChartAreas[0].AxisX.Minimum = pontosX[0];
            chart1.ChartAreas[0].AxisX.Maximum = pontosX[(int)n-1];
            chart1.ChartAreas[0].AxisY.Minimum = y.Min() - 0.2;
            chart1.ChartAreas[0].AxisY.Maximum = y.Max() + 0.2;
        
    

    }
    }
}
