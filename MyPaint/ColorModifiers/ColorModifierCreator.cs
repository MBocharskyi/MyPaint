namespace MyPaint.ColorModifiers
{
    /// <summary>
    /// Represents color modifier creator
    /// </summary>
    internal static class ColorModifierCreator
    {
        /// <summary>
        /// Create instance of color modifier
        /// </summary>
        /// <param name="colorModifier">Enumeration <see cref="ColorModifier"/>
        /// specify color modifier</param>
        /// <returns>Color modifier</returns>
        public static IColorModifier Create(ColorModifier colorModifier)
        {
            IColorModifier modifier = null;
            switch (colorModifier)
            {
                case ColorModifier.Negative:
                    modifier = new NegativeModifier();
                    break;

                case ColorModifier.Sepia:
                    modifier = new SepiaModifier();
                    break;

                case ColorModifier.GrayScale:
                    modifier = new GrayScaleModifier();
                    break;

                default:
                    break;
            }
            return modifier;
        }
    }
}