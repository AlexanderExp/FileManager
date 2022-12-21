using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLib;

namespace WpfLib
{
    /// <summary>
    /// Class for Pythagorean Tree.
    /// </summary>
    public class FractalPythagoreanTree : FractalBase
    {
        Grid currentCanv;
        double coefficient;
        public static int statAngleLeft;
        public static int statAngleRight;
        /// <summary>
        /// Constructor of FractalPythagoreanTree object.
        /// </summary>
        /// <param name="canv">Coefficient of relation of previous and current lines.</param>
        /// <param name="coef">The c</param>
        /// <param name="leftAngle">Angle for the left line.</param>
        /// <param name="rightAngle">Angle for the right line.</param>
        public FractalPythagoreanTree(Grid canv, double coef, int leftAngle, int rightAngle)
        {
            currentCanv = canv;
            coefficient = coef;
            statAngleRight = rightAngle;
            statAngleLeft = leftAngle;
        }
        /// <summary>
        /// Draws the PythagoreanTree.
        /// </summary>
        /// <param name="depth">The depth of recurcion.</param>
        /// <param name="previousElement">Previous Shape.</param>
        /// <param name="angles">Angles.</param>
        public override void DrawFractal(int depth, Shape previousElement, params int[] angles)
        {
            if (depth == 0)
            {
                ((Line)previousElement).Stroke = Brushes.Black;
                currentCanv.Children.Add(((Line)previousElement));
            }
            else
            {
                Line leftLine = new Line();
                Line rightLine = new Line();
                double len = Math.Sqrt(Math.Pow(((Line)previousElement).Y2 - ((Line)previousElement).Y1, 2) + Math.Pow(((Line)previousElement).X1 - ((Line)previousElement).X2, 2)) * coefficient;

                leftLine.X1 = ((Line)previousElement).X2;
                leftLine.Y1 = ((Line)previousElement).Y2;
                leftLine.X2 = ((Line)previousElement).X2 - len * Math.Cos(angles[0] * Math.PI / 180.0);
                leftLine.Y2 = ((Line)previousElement).Y2 - len * Math.Sin(angles[0] * Math.PI / 180.0);

                rightLine.X1 = ((Line)previousElement).X2;
                rightLine.Y1 = ((Line)previousElement).Y2;
                rightLine.X2 = ((Line)previousElement).X2 + len * Math.Sin(angles[1] * Math.PI / 180.0);
                rightLine.Y2 = ((Line)previousElement).Y2 - len * Math.Cos(angles[1] * Math.PI / 180.0);

                DrawFractal(depth - 1, leftLine, angles[0] - statAngleLeft, angles[1] - statAngleRight);
                DrawFractal(depth - 1, rightLine, angles[0] + statAngleLeft, angles[1] + statAngleRight);
                DrawFractal(depth - 1, ((Line)previousElement), angles[0], angles[1]);
            }
        }
    }
}