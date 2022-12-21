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

namespace PeerGrade_Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Inicialises the main component.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Makes visible certain labels and textboxes.
        /// </summary>
        private void MakeVisible()
        {
            coefTextBox.IsEnabled = true;
            coefTextBox.Visibility = Visibility.Visible;

            leftAngleTextBox.IsEnabled = true;
            leftAngleTextBox.Visibility = Visibility.Visible;

            rightAngleTextBox.IsEnabled = true;
            rightAngleTextBox.Visibility = Visibility.Visible;

            labelCoef.Visibility = Visibility.Visible;
            labelLeftAngle.Visibility = Visibility.Visible;
            labelRightAngle.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Makes visible certain labels and textboxes.
        /// </summary>
        private void MakeInvisible()
        {
            coefTextBox.IsEnabled = false;
            coefTextBox.Visibility = Visibility.Hidden;

            leftAngleTextBox.IsEnabled = false;
            leftAngleTextBox.Visibility = Visibility.Hidden;

            rightAngleTextBox.IsEnabled = false;
            rightAngleTextBox.Visibility = Visibility.Hidden;

            distanceTextBox.IsEnabled = false;
            distanceTextBox.Visibility = Visibility.Hidden;

            labelCoef.Visibility = Visibility.Hidden;
            labelLeftAngle.Visibility = Visibility.Hidden;
            labelRightAngle.Visibility = Visibility.Hidden;
            distanceLabel.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Gets the coefficient and angles to draw a tree.
        /// </summary>
        /// <param name="coef">Coefficient of relation of previous and current lines.</param>
        /// <param name="leftAngle">Angle for the left line.</param>
        /// <param name="rightAngle">Angle for the right line.</param>
        /// <param name="flag">Flag to catch incorrect values.</param>
        private void GetCoefAnglesPythTree(out double coef, out int leftAngle, out int rightAngle, ref bool flag)
        {
            if (double.TryParse(coefTextBox.Text, out coef) && coef >= 0.1 && coef <= 1)
            {
                coefTextBox.Background = Brushes.LightGreen;
            }
            else
            {
                coefTextBox.Background = Brushes.Red;
                MessageBox.Show("Try enterring Real number from 0,1 to 1 (use ',')", "Incorrect");
                flag = false;
            }
            if (int.TryParse(leftAngleTextBox.Text, out leftAngle) && leftAngle > -1 && leftAngle < 91)
            {
                leftAngleTextBox.Background = Brushes.LightGreen;
            }
            else
            {
                leftAngleTextBox.Background = Brushes.Red;
                MessageBox.Show("Try enterring Integer number from 0 to 90", "Incorrect");
                flag = false;
            }
            if (int.TryParse(rightAngleTextBox.Text, out rightAngle) && rightAngle > -1 && rightAngle < 91)
            {
                leftAngleTextBox.Background = Brushes.LightGreen;
            }
            else
            {
                leftAngleTextBox.Background = Brushes.Red;
                MessageBox.Show("Try enterring Integer number from 0 to 90", "Incorrect");
                flag = false;
            }
        }
        /// <summary>
        /// Handles the event of Pythagorean tree button being clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void Pythagorean_tree_Click(object sender, RoutedEventArgs e)
        {
            distanceTextBox.IsEnabled = false;
            distanceLabel.Visibility = Visibility.Hidden;
            distanceTextBox.Visibility = Visibility.Hidden;
            Canv.Children.Clear();
            int depth;
            bool flag = true;
            double coef = 0;
            int leftAngle = 0, rightAngle = 0;
            MakeVisible();
            if (int.TryParse(depthTextBox.Text, out depth) && depth < 9 && depth > -1)
            {
                GetCoefAnglesPythTree(out coef, out leftAngle, out rightAngle, ref flag);
                if (flag == true)
                {
                    Line pythline = new Line();
                    pythline.X1 = Canv.ActualWidth / 2;
                    pythline.X2 = Canv.ActualWidth / 2;
                    pythline.Y2 = Canv.ActualHeight / 1.7;
                    pythline.Y1 = Canv.ActualHeight - 30;
                    FractalPythagoreanTree pythTree = new FractalPythagoreanTree(Canv, coef, leftAngle, rightAngle);
                    pythTree.DrawFractal(depth, pythline, leftAngle, rightAngle);
                }
            }
            else
            {
                MessageBox.Show("Try Enterring integer number from 0 to 8", "Incorrect input");
            }
        }
        /// <summary>
        /// Handles the event of Koch curve button being clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void Koch_curve_Click_1(object sender, RoutedEventArgs e)
        {
            Canv.Children.Clear();
            MakeInvisible();
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth) && depth < 9 && depth > -1)
            {

                Line previousLine = new Line();
                var leftPoint = new Point(WindowMainName.ActualWidth, WindowMainName.ActualHeight / 1.5);
                var rightPoint = new Point(0, WindowMainName.ActualHeight / 1.5);
                previousLine.X1 = WindowMainName.ActualWidth;
                previousLine.Y1 = WindowMainName.ActualHeight / 1.5;
                previousLine.X2 = 0;
                previousLine.Y2 = WindowMainName.ActualHeight / 1.5;
                FractalKochCurve kochCurve = new FractalKochCurve(Canv);
                kochCurve.DrawFractal(depth, previousLine);
            }
            else
            {
                MessageBox.Show("Try Enterring integer number from 0 to 8", "Incorrect input");
            }

        }
        /// <summary>
        /// Handles the event of Serpinsky Carpet button being clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void SerpinskyCarpetButton_Click(object sender, RoutedEventArgs e)
        {
            MakeInvisible();
            Canv.Children.Clear();
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth) && depth < 6 && depth > -1)
            {
                Polygon carpet = new Polygon();
                var UpperLeftPoint = new Point(Canv.ActualWidth / 5, 0);
                var UpperRightPoint = new Point(Canv.ActualWidth / 5 + Canv.ActualHeight, 0);
                var LowerLeftPoint = new Point(Canv.ActualWidth / 5, Canv.ActualHeight);
                var LowerRightPoint = new Point(Canv.ActualWidth / 5 + Canv.ActualHeight, Canv.ActualHeight);

                carpet.Points.Add(UpperLeftPoint);
                carpet.Points.Add(UpperRightPoint);
                carpet.Points.Add(LowerRightPoint);
                carpet.Points.Add(LowerLeftPoint);
                carpet.Fill = Brushes.Black;
                //Canv.Children.Add(carpet);
                FractalSerpinskyCarpet newFractal = new FractalSerpinskyCarpet(Canv);
                newFractal.DrawFractal(depth, carpet);
            }
            else
            {
                MessageBox.Show("Try Enterring integer number from 0 to 5", "Incorrect input");
            }
        }
        /// <summary>
        /// Handles the event of Serpinsky Triangle button being clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void SerpinskyTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            MakeInvisible();
            Canv.Children.Clear();
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth) && depth < 9 && depth > -1)
            {
                Canv.Children.Clear();
                Polygon triangle = new Polygon();
                Point Left = new Point(Canv.ActualWidth / 4, Canv.ActualHeight - 30);
                Point Right = new Point(Canv.ActualWidth - Canv.ActualWidth / 4, Canv.ActualHeight - 30);
                Point Top = new Point((Right.X + Left.X) / 2, Right.Y - Math.Sqrt(3) / 2 * Math.Sqrt(Math.Pow((Right.X - Left.X), 2) + Math.Pow((Right.Y - Left.Y), 2)));
                triangle.Points.Add(Top);
                triangle.Points.Add(Left);
                triangle.Points.Add(Right);
                // Calling drawing function.
                FractalSerpinskyTriangle serpinskyTriangle = new FractalSerpinskyTriangle(Canv);
                serpinskyTriangle.DrawFractal(depth, triangle);
            }
            else
            {
                MessageBox.Show("Try Enterring integer number from 0 to 8", "Incorrect input");
            }
        }
        /// <summary>
        /// Handles the event of Cantor Set button being clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void CantorSetButton_Click(object sender, RoutedEventArgs e)
        {
            MakeInvisible();
            Canv.Children.Clear();
            int depth;
            // In pixels.
            int dist;
            if (int.TryParse(depthTextBox.Text, out depth) && depth < 9 && depth > -1)
            {
                distanceLabel.Visibility = Visibility.Visible;
                distanceTextBox.IsEnabled = true;
                distanceTextBox.Visibility = Visibility.Visible;
                if (int.TryParse(distanceTextBox.Text, out dist) && dist < 101 && dist > 4)
                {
                    Line line = new Line();

                    line.X1 = 15;
                    line.X2 = Canv.ActualWidth - 15;
                    line.Y1 = 15;
                    line.Y2 = 15;

                    FractalCantorsSet cantorsSet = new FractalCantorsSet(Canv, dist);
                    cantorsSet.DrawFractal(depth, line);
                }
                else
                {
                    MessageBox.Show("Try Enterring integer number from 5 to 100", "Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Try Enterring integer number from 0 to 8", "Incorrect input");
            }
        }
    }
}