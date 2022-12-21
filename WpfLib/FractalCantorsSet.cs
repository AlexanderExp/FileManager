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
    /// Class for Cantor's Set.
    /// </summary>
    public class FractalCantorsSet : FractalBase
    {
        Grid currentCanv;
        // Distance between 2 lines.
        int distance;
        /// <summary>
        /// Constructor of FractalCantorsSet object.
        /// </summary>
        /// <param name="canv">Current drawing place.</param>
        /// <param name="dist">Distance between two horizontal lines.</param>
        public FractalCantorsSet(Grid canv, int dist)
        {
            currentCanv = canv;
            distance = dist;
        }
        /// <summary>
        /// Draws the Cantor's Set.
        /// </summary>
        /// <param name="depth">Depth of recurcion.</param>
        /// <param name="previousElement">Previous Shape.</param>
        /// <param name="unnecessary">Possible parameters.</param>
        public override void DrawFractal(int depth, Shape previousElement, params int[] unnecessary)
        {
            if (depth == 0)
            {
                ((Line)previousElement).Stroke = Brushes.Black;
                currentCanv.Children.Add(((Line)previousElement));
            }
            else
            {
                Line lineLeft = new Line();
                Line lineRight = new Line();
                lineLeft.X1 = ((Line)previousElement).X1;
                lineLeft.Y1 = ((Line)previousElement).Y1 + distance;
                lineLeft.Y2 = lineLeft.Y1;
                lineLeft.X2 = ((Line)previousElement).X1 + (((Line)previousElement).X2 - ((Line)previousElement).X1) / 3.0;

                lineRight.X1 = ((Line)previousElement).X1 * 1.0 + (((Line)previousElement).X2 - ((Line)previousElement).X1) * 1.0 * (2.0 / 3.0);
                lineRight.Y1 = ((Line)previousElement).Y1 + distance;
                lineRight.X2 = ((Line)previousElement).X2;
                lineRight.Y2 = lineRight.Y1;

                DrawFractal(depth - 1, ((Line)previousElement));
                DrawFractal(depth - 1, lineLeft);
                DrawFractal(depth - 1, lineRight);
            }

        }
    }
}
