using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfLib
{
    /// <summary>
    /// Class for Koch's Curve.
    /// </summary>
    public class FractalKochCurve : FractalBase
    {
        Grid currentCanv;
        /// <summary>
        /// Constructor of FractalKochCurve object.
        /// </summary>
        /// <param name="canv">The current drawing place.</param>
        public FractalKochCurve(Grid canv)
        {
            currentCanv = canv;
        }
        /// <summary>
        /// Draws the Koch's Curve.
        /// </summary>
        /// <param name="depth">Depth of recurcion.</param>
        /// <param name="previousElement">Previous Shape.</param>
        /// <param name="unnecessary">Possible parameters.</param>
        public override void DrawFractal(int depth, Shape previousElement, params int[] unnecessary)
        {
            if (depth == 0)
            {
                previousElement.Stroke = Brushes.Black;
                currentCanv.Children.Add(previousElement);
            }
            else
            {
                double modX, modY;
                double x1, y1, x5, y5, x2, x3, x4, y2, y3, y4;
                x1 = ((Line)previousElement).X1;
                x5 = ((Line)previousElement).X2;
                y1 = ((Line)previousElement).Y1;
                y5 = ((Line)previousElement).Y2;
                modX = x5 - x1;
                modY = y5 - y1;
                x2 = x1 + modX / 3;
                y2 = y1 + modY / 3;
                x3 = x1 + (0.5 * (x5 - x1)) + (Math.Sqrt(3) / 6) * (y1 - y5);
                y3 = y1 + (0.5 * (y5 - y1)) + (Math.Sqrt(3) / 6) * (x5 - x1);
                x4 = x1 + 2 * modX / 3;
                y4 = y1 + 2 * modY / 3;
                Line leftLine = CreateLine(x1, x2, y1, y2);
                Line leftMiddleLine = CreateLine(x2, x3, y2, y3);
                Line rightMiddleLine = CreateLine(x3, x4, y3, y4);
                Line rightLine = CreateLine(x4, x5, y4, y5);

                DrawFractal(depth - 1, leftLine);
                DrawFractal(depth - 1, leftMiddleLine);
                DrawFractal(depth - 1, rightMiddleLine);
                DrawFractal(depth - 1, rightLine);
            }
        }
        /// <summary>
        /// Creates a Line.
        /// </summary>
        /// <param name="x1">The first x coordinate.</param>
        /// <param name="x2">The second x coordinate.</param>
        /// <param name="y1">The first y coordinate.</param>
        /// <param name="y2">The second y coordinate.</param>
        /// <returns></returns>
        public Line CreateLine(double x1, double x2, double y1, double y2)
        {
            Line line = new Line();
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            return line;
        }
    }
}
