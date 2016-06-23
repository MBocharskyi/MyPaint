using System.Drawing;

namespace MyPaint
{
    /// <summary>
    /// Rectangle creator class
    /// </summary>
    internal static class RectangleCreator
    {
        /// <summary>
        /// Creates rectangle
        /// </summary>
        /// <param name="pointA">point</param>
        /// <param name="pointB">point</param>
        /// <returns>instance of <see cref="Rectangle"/></returns>
        public static Rectangle GetRectangle(Point pointA, Point pointB)
        {
            int topLeftX = pointA.X < pointB.X ? pointA.X : pointB.X;
            int topLeftY = pointA.Y < pointB.Y ? pointA.Y : pointB.Y;
            int width = pointA.X < pointB.X ? pointB.X - pointA.X : pointA.X - pointB.X;
            int height = pointA.Y < pointB.Y ? pointB.Y - pointA.Y : pointA.Y - pointB.Y;
            return new Rectangle(topLeftX, topLeftY, width, height);
        }

        /// <summary>
        /// Creates rectangle
        /// </summary>
        /// <param name="point">point</param>
        /// <param name="eraserWidth">width of the eraser tool</param>
        /// <returns>instance of <see cref="Rectangle"/></returns>
        public static Rectangle GetErasingRectangle(Point point, int eraserWidth)
        {
            int topLeftX = (point.X - eraserWidth / 2) > 0 ? (point.X - eraserWidth / 2) : 0;
            int topLeftY = (point.Y - eraserWidth / 2) > 0 ? (point.Y - eraserWidth / 2) : 0;
            int width = eraserWidth;
            int height = eraserWidth;
            return new Rectangle(topLeftX, topLeftY, width, height);
        }
    }
}