using System.Drawing;

namespace MyPaint.ColorModifiers
{
    /// <summary>
    /// Negative color modifier
    /// </summary>
    internal class NegativeModifier : IColorModifier
    {
        /// <summary>
        /// Implementation of <see cref="IColorModifier"/>
        /// </summary>
        /// <param name="color">color to modify</param>
        /// <returns>Color modified with negative filter</returns>
        public Color Modify(Color color)
        {
            return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
        }
    }
}