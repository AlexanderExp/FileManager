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
    /// Class for Serpinsky Triangle.
    /// </summary>
    public class FractalSerpinskyTriangle : FractalBase
    {
        Grid currentCanv;
        /// <summary>
        /// Constructor of FractalSerpinskyTriangle object.
        /// </summary>
        /// <param name="canv"></param>
        public FractalSerpinskyTriangle(Grid canv)
        {
            currentCanv = canv;
        }
        /// <summary>
        /// Draws the SerpinskyTriangle.
        /// </summary>
        /// <param name="depth">The depth of recurcion.</param>
        /// <param name="previousElement">Previous Shape.</param>
        /// <param name="unnecessary">Possible parameters.</param>
        public override void DrawFractal(int depth, Shape previousElement, params int[] unnecessary)
        {
            // Check if the drawing is done.
            if (depth == 0)
            {
                previousElement.Fill = Brushes.Pink;
                currentCanv.Children.Add(previousElement);
            }
            else
            {
                Polygon MoreTrianglesLeft = new Polygon();
                Polygon MoreTrianglesRight = new Polygon();
                Polygon MoreTrianglesTop = new Polygon();
                Point Left = new Point((((Polygon)previousElement).Points[0].X + ((Polygon)previousElement).Points[1].X) / 2, (((Polygon)previousElement).Points[1].Y + ((Polygon)previousElement).Points[0].Y) / 2);
                Point Right = new Point((((Polygon)previousElement).Points[0].X + ((Polygon)previousElement).Points[2].X) / 2, (((Polygon)previousElement).Points[2].Y + ((Polygon)previousElement).Points[0].Y) / 2);
                Point Bottom = new Point((((Polygon)previousElement).Points[2].X + ((Polygon)previousElement).Points[1].X) / 2, (((Polygon)previousElement).Points[1].Y + ((Polygon)previousElement).Points[2].Y) / 2);
                MoreTrianglesLeft.Points.Add(Left);
                MoreTrianglesLeft.Points.Add(Bottom);
                MoreTrianglesLeft.Points.Add(((Polygon)previousElement).Points[1]);

                MoreTrianglesRight.Points.Add(Right);
                MoreTrianglesRight.Points.Add(Bottom);
                MoreTrianglesRight.Points.Add(((Polygon)previousElement).Points[2]);

                MoreTrianglesTop.Points.Add(Left);
                MoreTrianglesTop.Points.Add(Right);
                MoreTrianglesTop.Points.Add(((Polygon)previousElement).Points[0]);

                DrawFractal(depth - 1, MoreTrianglesLeft);
                DrawFractal(depth - 1, MoreTrianglesRight);
                DrawFractal(depth - 1, MoreTrianglesTop);
            }
        }
    }
}
