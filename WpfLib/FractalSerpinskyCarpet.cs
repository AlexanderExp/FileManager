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
    /// Class for Serpinsky's Carpet.
    /// </summary>
    public class FractalSerpinskyCarpet : FractalBase
    {
        Grid Canv;
        /// <summary>
        /// Constructor of FractalSerpinskyCarpet object.
        /// </summary>
        /// <param name="Canv">The current drawing place.</param>
        public FractalSerpinskyCarpet(Grid Canv)
        {
            this.Canv = Canv;
        }
        /// <summary>
        /// Draws the Serpinsky Carpet.
        /// </summary>
        /// <param name="depth">The depth of recurcion.</param>
        /// <param name="carpet">Previous iteration of carpet.</param>
        /// <param name="unnecessary">Possible parameters.</param>
        public override void DrawFractal(int depth, Shape carpet, params int[] unnecessary)
        {
            if (depth == 0)
            {
                // Drawing the carpet.
                carpet.Fill = Brushes.LightPink;
                Canv.Children.Add(carpet);
            }
            else
            {
                // Splitting the current piece of carpet into 9 pieces.
                double width = (((Polygon)carpet).Points[1].X - ((Polygon)carpet).Points[0].X) / 3d;
                double height = (((Polygon)carpet).Points[2].Y - ((Polygon)carpet).Points[0].Y) / 3d;
                // (x1, y1) - coordinates of the upper left angle.
                double x1 = ((Polygon)carpet).Points[0].X;
                double x2 = x1 + width;
                double x3 = x1 + 2d * width;
                double x4 = x1 + 3d * width;
                double y1 = ((Polygon)carpet).Points[0].Y;
                double y2 = y1 + height;
                double y3 = y1 + 2d * height;
                double y4 = y1 + 3d * height;
                Polygon UpperLeft = CreatePolygon(new Point(x1, y1), new Point(x2, y1), new Point(x2, y2), new Point(x1, y2));
                Polygon UpperMiddle = CreatePolygon(new Point(x2, y1), new Point(x3, y1), new Point(x3, y2), new Point(x2, y2));
                Polygon UpperRight = CreatePolygon(new Point(x3, y1), new Point(x4, y1), new Point(x4, y2), new Point(x3, y2));
                Polygon MiddleLeft = CreatePolygon(new Point(x1, y2), new Point(x2, y2), new Point(x2, y3), new Point(x1, y3));
                Polygon MiddleRight = CreatePolygon(new Point(x3, y2), new Point(x4, y2), new Point(x4, y3), new Point(x3, y3));
                Polygon LowerLeft = CreatePolygon(new Point(x1, y3), new Point(x2, y3), new Point(x2, y4), new Point(x1, y4));
                Polygon LowerCenter = CreatePolygon(new Point(x2, y3), new Point(x3, y3), new Point(x3, y4), new Point(x2, y4));
                Polygon LowerRight = CreatePolygon(new Point(x3, y3), new Point(x4, y3), new Point(x4, y4), new Point(x3, y4));

                this.DrawFractal(depth - 1, UpperLeft); 
                this.DrawFractal(depth - 1, UpperMiddle); 
                this.DrawFractal(depth - 1, UpperRight); 
                this.DrawFractal(depth - 1, MiddleLeft); 
                this.DrawFractal(depth - 1, MiddleRight); 
                this.DrawFractal(depth - 1, LowerLeft); 
                this.DrawFractal(depth - 1, LowerCenter); 
                this.DrawFractal(depth - 1, LowerRight); 
            }
        }
        /// <summary>
        /// Creates Polygon.
        /// </summary>
        /// <param name="firstPoint">The first point.</param>
        /// <param name="secondPoint">The second point.</param>
        /// <param name="thirdPoint">The third point.</param>
        /// <param name="fourthPoint">The fourth point.</param>
        /// <returns></returns>
        private Polygon CreatePolygon(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourthPoint)
        {
            Polygon poly = new Polygon();
            poly.Points.Add(firstPoint);
            poly.Points.Add(secondPoint);
            poly.Points.Add(thirdPoint);
            poly.Points.Add(fourthPoint);
            return poly;
        }
    }
}
