using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyPaint
{
    /// <summary>
    /// File operation class
    /// </summary>
    internal static class FileOperations
    {
        private const string saveTitle = "Save image";
        private const string openTitle = "Open image";
        private const string filter = "Bitmap Images (*.bmp)|*.bmp|JPEG Images (*.jpg)|*.jpg|GIF Images (*.gif)|*.gif|PNG Images (*.png)|*.png";
        private static readonly string[] extentions = new[] { ".bmp", ".jpg", ".jpeg", ".gif", ".png" };

        /// <summary>
        /// Open image from file
        /// </summary>
        /// <returns>Instance of <see cref="Image"/></returns>
        public static Image OpenImage()
        {
            Image image = null;

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = openTitle;
            openDialog.Filter = filter;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string extention = Path.GetExtension(openDialog.FileName);
                if (extentions.Contains(extention))
                {
                    try
                    {
                        image = Bitmap.FromFile(openDialog.FileName);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return image;
        }

        /// <summary>
        /// Save image to file
        /// </summary>
        /// <param name="image">Image to save</param>
        public static void SaveImage(Image image)
        {
            ImageFormat imageFormat = null;
            string path = null;
            GetPathAndFormatToSave(ref path, ref imageFormat);

            using (var bitmap = new Bitmap(image))
            {
                if (bitmap != null)
                {
                    bitmap.Save(path, imageFormat);
                }
            }
        }

        /// <summary>
        /// Gets path of file to save and file format
        /// </summary>
        /// <param name="path">Path to save file</param>
        /// <param name="imageFormat">Image format of file to save</param>
        private static void GetPathAndFormatToSave(ref string path, ref ImageFormat imageFormat)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = saveTitle;
            saveDialog.Filter = filter;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string extention = Path.GetExtension(saveDialog.FileName);
                switch (extention)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;

                    case ".jpg":
                    case ".jpeg":
                        imageFormat = ImageFormat.Jpeg;
                        break;

                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;

                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;

                    default:
                        break;
                }

                path = saveDialog.FileName;
            }
        }
    }
}