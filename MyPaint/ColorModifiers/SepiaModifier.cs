using System.Drawing;

namespace MyPaint.ColorModifiers
{
    /// <summary>
    /// Sepia color modifier
    /// </summary>
    internal class SepiaModifier : IColorModifier
    {
        /// <summary>
        /// Implementation of <see cref="IColorModifier"/>
        /// </summary>
        /// <param name="color">color to modify</param>
        /// <returns>Color modified with sepia filter</returns>
        public Color Modify(Color color)
        {
            double grayColor = ((double)(color.R + color.G + color.B)) / 3.0d;
            return Color.FromArgb((byte)grayColor, (byte)(grayColor * 0.95), (byte)(grayColor * 0.82));
        }
    }
}