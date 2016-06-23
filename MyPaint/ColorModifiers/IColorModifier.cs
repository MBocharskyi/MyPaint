using System.Drawing;

namespace MyPaint.ColorModifiers
{
    /// <summary>
    /// Interface for color modifying operation
    /// </summary>
    internal interface IColorModifier
    {
        /// <summary>
        /// Modify color
        /// </summary>
        /// <param name="color">color to modify</param>
        /// <returns>modified color</returns>
        Color Modify(Color color);
    }
}