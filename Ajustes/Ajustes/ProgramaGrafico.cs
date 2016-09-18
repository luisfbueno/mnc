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

namespace Ajustes
{
    public partial class ProgramaGrafico : Form
    {
        public ProgramaGrafico(string fx,double a,double b,double[] x,int n)
        {
            InitializeComponent();

            ExpressionParser p = new ExpressionParser();

            p.Values.Add("a", a);
            p.Values.Add("b", b);
            p.Values.Add("x", 0);

            if (fx.Contains("e"))
            {
                p.Values.Add("e", Math.E);
            }

            for(int i = 0; i < n; i++)
            {
                p.Values["x"].SetValue(x[i]);
                double py = p.Parse(fx);
                chart1.Series["funcao"].Points.AddXY(x[i], py);
            }

            chart1.ChartAreas[0].AxisX.Minimum = x[0];
            chart1.ChartAreas[0].AxisX.Maximum = x[n-1];



        }

        public ProgramaGrafico(string fx, double[] x, int n)
        {
            InitializeComponent();

            ExpressionParser p = new ExpressionParser();

            p.Values.Add("x", 0);

            if (fx.Contains("e"))
            {
                p.Values.Add("e", Math.E);
            }

            for (int i = 0; i < n; i++)
            {
                p.Values["x"].SetValue(x[i]);
                double py = p.Parse(fx);
                chart1.Series["funcao"].Points.AddXY(x[i], py);
            }

            chart1.ChartAreas[0].AxisX.Minimum = x[0];
            chart1.ChartAreas[0].AxisX.Maximum = x[n - 1];

        }
    }
}
