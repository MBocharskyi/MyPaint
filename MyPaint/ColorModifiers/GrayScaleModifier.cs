using System.Drawing;

namespace MyPaint.ColorModifiers
{
    /// <summary>
    /// Gray scale color modifier
    /// </summary>
    internal class GrayScaleModifier : IColorModifier
    {
        /// <summary>
        /// Implementation of <see cref="IColorModifier"/>
        /// </summary>
        /// <param name="color">color to modify</param>
        /// <returns>Color modified with gray scale filter</returns>
        public Color Modify(Color color)
        {
            int grayScale = (int)((color.R * .3) + (color.G * .59) + (color.B * .11));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }
    }
}