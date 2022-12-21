using System;
using System.Windows;
using System.Windows.Shapes;

namespace WpfLib
{
    /// <summary>
    /// Base class for Fractals.
    /// </summary>
    public class FractalBase
    {
        int limiterDepth = 9;

        int Depth { get { return limiterDepth; } }
        public virtual void DrawFractal(int depth, Shape previousElement, params int[] angles)
        {
            if (depth > limiterDepth)
            {
                MessageBox.Show("Everything is sweet and clean");
            }
            MessageBox.Show("fix");
        }
    }
}
