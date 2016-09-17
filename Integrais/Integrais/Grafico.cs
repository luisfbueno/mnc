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

namespace Integrais
{
    public partial class Grafico : Form
    {
        public Grafico(string fx,double xzero,double xn)
        {
            InitializeComponent();

            ExpressionParser p = new ExpressionParser();

            double h = (xn - xzero) / 100;
            double[] y = new double[101];
            double aux = xzero;

            p.Values.Add("x", 0);

            for (int i = 0; i <= 100; i++)
            {
                p.Values["x"].SetValue(aux);
                y[i] = p.Parse(fx);
                chart1.Series["Função"].Points.AddXY(aux, y[i]);
                chart1.Series["Area"].Points.AddXY(aux, y[i]);
                aux += h;
            }

            chart1.ChartAreas[0].AxisX.Minimum = xzero;
            chart1.ChartAreas[0].AxisX.Maximum = xn;
            //chart1.ChartAreas[0].AxisY.Minimum = y.Min();
            //chart1.ChartAreas[0].AxisY.Maximum = y.Max();
        }



    }

}

