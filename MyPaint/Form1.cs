using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyPaint.ColorModifiers;

namespace MyPaint
{
    /// <summary>
    /// Represents main form of the application
    /// </summary>
    public partial class Form1 : Form
    {
        private const int RIGHT_MARGIN = 20;

        private const int MENUSTRIP_HEIGHT = 28;

        private int Canvas_Height = 400;

        private int Canvas_Width = 400;

        private int ResizeAreaSize = 20;

        private bool IsImageChanged { get; set; }

        private bool IsDraw { get; set; }

        private bool IsResizeCanvas { get; set; }

        private Color LinesColor { get; set; }

        private Color FillColor { get; set; }

        private Color CanvasColor { get; set; }

        private DrawTool DrawTool { get; set; }

        private Point? DrawStartPoint { get; set; }

        private int PencilWidth { get; set; }

        private Graphics CanvasGraphics { get; set; }

        public Cursor PencilCursor;

        public Cursor EraserCursor;

        /// <summary>
        /// Initializes new instance of the <see cref="Form1"/>
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            pencilButton.Checked = true;
            InitPencilSizeControlByValues();
            pencilSizeButton.SelectedIndex = 0;
            PencilWidth = Convert.ToInt32(pencilSizeButton.SelectedItem);

            LinesColor = Color.Black;
            FillColor = Color.White;
            CanvasColor = Color.White;
            color1Button.BackColor = LinesColor;
            color2Button.BackColor = FillColor;

            toolStripProgressBar1.Width = statusStrip1.Width - RIGHT_MARGIN;
            SetCanvas();

            PencilCursor = new Cursor("..\\..\\Cursors\\pencil.cur");
            EraserCursor = new Cursor("..\\..\\Cursors\\eraser.cur");
            SetCursor();
        }

        #region Event Handlers

        /// <summary>
        /// Event handler for mouse left button press down on the Form
        /// </summary>
        /// <param name="sender">Object which sends event</param>
        /// <param name="e">Event arguments send by sender</param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > pictureBox.Width && e.X <= pictureBox.Width + ResizeAreaSize &&
                    e.Y > pictureBox.Height + MENUSTRIP_HEIGHT && e.Y <= pictureBox.Height + ResizeAreaSize + MENUSTRIP_HEIGHT)
                {
                    IsResizeCanvas = true;
                    DrawStartPoint = e.Location;

                    Canvas_Width = e.X;
                    Canvas_Height = e.Y - MENUSTRIP_HEIGHT;

                    DrawReversibleFrame(pictureBox.Location, Canvas_Width, Canvas_Height);
                }
            }
        }

        /// <summary>
        /// Event handler for mouse left button up on the Form
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (IsResizeCanvas)
                {
                    if (Canvas_Width > 0 && Canvas_Height > 0)
                    {
                        DrawReversibleFrame(pictureBox.Location, Canvas_Width, Canvas_Height);
                    }

                    if (Canvas_Width > 0 && Canvas_Height > 0)
                    {

                        Bitmap bitmap = new Bitmap(pictureBox.Image);
                        if (bitmap.Width > Canvas_Width || bitmap.Height > Canvas_Height)
                        {
                            Rectangle sourceRectangle = new Rectangle(0, 0, Canvas_Width, Canvas_Height);
                            bitmap = bitmap.Clone(sourceRectangle, bitmap.PixelFormat);
                        }

                        SetCanvas();
                        CanvasGraphics.DrawImage(bitmap, 0, 0);
                    }

                    IsResizeCanvas = false;
                }
            }
        }

        /// <summary>
        /// Event handler for mouse move on the Form
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsResizeCanvas)
            {
                if (Canvas_Width > 0 && Canvas_Height > 0)
                {
                    DrawReversibleFrame(pictureBox.Location, Canvas_Width, Canvas_Height);
                }

                Canvas_Width = e.X;
                Canvas_Height = e.Y - MENUSTRIP_HEIGHT;

                if (Canvas_Width > 0 && Canvas_Height > 0)
                {
                    DrawReversibleFrame(pictureBox.Location, Canvas_Width, Canvas_Height);
                }
            }
        }

        /// <summary>
        /// Event handler for click on color button in tool strip
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void color_Click(object sender, EventArgs e)
        {
            ToolStripButton menuItem = sender as ToolStripButton;
            if (menuItem != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    menuItem.BackColor = colorDialog.Color;
                    SetColor(menuItem);
                }
            }
        }

        /// <summary>
        /// Event handler for clicks on draw tools in tool strip
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void drawItemButton_Click(object sender, EventArgs e)
        {
            ToolStripButton menuItem = sender as ToolStripButton;
            if (menuItem != null)
            {
                SetAllDrawToolsToUnchecked();
                menuItem.Checked = true;
                DrawTool = GetDrawTool(menuItem);
                SetPencilSizeAccordingToDrawTool();
                SetCursor();
            }
        }

        /// <summary>
        /// Event handler for status strip resize
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void statusStrip_Resize(object sender, EventArgs e)
        {
            toolStripProgressBar1.Width = statusStrip1.Width - RIGHT_MARGIN;
        }

        /// <summary>
        /// Event handler for mouse left button up on the pictureBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDraw = true;
                DrawStartPoint = e.Location;
            }
        }

        /// <summary>
        /// Event handler for mouse left button up on the pictureBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pen pen;
                Brush brush;
                switch (DrawTool)
                {
                    case DrawTool.Line:
                        pen = new Pen(LinesColor, PencilWidth);
                        CanvasGraphics.DrawLine(pen, DrawStartPoint.Value, e.Location);
                        break;
                    case DrawTool.Circle:
                        pen = new Pen(LinesColor, PencilWidth);
                        CanvasGraphics.DrawEllipse(pen, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        break;
                    case DrawTool.FilledCircle:
                        brush = new SolidBrush(FillColor);
                        pen = new Pen(LinesColor, PencilWidth);
                        CanvasGraphics.FillEllipse(brush, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        CanvasGraphics.DrawEllipse(pen, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        break;
                    case DrawTool.Rectangle:
                        brush = new SolidBrush(FillColor);
                        pen = new Pen(LinesColor, PencilWidth);
                        CanvasGraphics.DrawRectangle(pen, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        break;
                    case DrawTool.FilledRectangle:
                        brush = new SolidBrush(FillColor);
                        pen = new Pen(LinesColor, PencilWidth);
                        CanvasGraphics.FillRectangle(brush, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        CanvasGraphics.DrawRectangle(pen, RectangleCreator.GetRectangle(DrawStartPoint.Value, e.Location));
                        break;
                    default:
                        break;
                }
                IsImageChanged = true;
                this.pictureBox.Invalidate();
                IsDraw = false;
                DrawStartPoint = null;
            }
        }

        /// <summary>
        /// Event handler for mouse move on the pictureBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDraw)
            {
                if (DrawTool == DrawTool.Pen)
                {
                    Pen pen = new Pen(LinesColor, PencilWidth);
                    CanvasGraphics.DrawLine(pen, DrawStartPoint.Value, e.Location);
                    DrawStartPoint = e.Location;
                    IsImageChanged = true;
                }
                else if (DrawTool == DrawTool.Eraser)
                {
                    Brush brush = new SolidBrush(CanvasColor);
                    CanvasGraphics.FillEllipse(brush, RectangleCreator.GetErasingRectangle(e.Location, PencilWidth));
                    DrawStartPoint = e.Location;
                    IsImageChanged = true;
                }
                else if (DrawTool == DrawTool.Line)
                {
                    // If call this method one time draw of the line will be strange
                    DrawReversibleLine(new Point(DrawStartPoint.Value.X, DrawStartPoint.Value.Y + MENUSTRIP_HEIGHT), new Point(e.X, e.Y + MENUSTRIP_HEIGHT));
                    DrawReversibleLine(new Point(DrawStartPoint.Value.X, DrawStartPoint.Value.Y + MENUSTRIP_HEIGHT), new Point(e.X, e.Y + MENUSTRIP_HEIGHT));
                }
                else if (DrawTool == DrawTool.Circle ||
                    DrawTool == DrawTool.FilledCircle ||
                    DrawTool == DrawTool.Rectangle ||
                    DrawTool == DrawTool.FilledRectangle)
                {
                    // If call this method one time draw of the rectangle will be strange
                    DrawReversibleFrame(new Point(DrawStartPoint.Value.X, DrawStartPoint.Value.Y + MENUSTRIP_HEIGHT), e.X - DrawStartPoint.Value.X, e.Y - DrawStartPoint.Value.Y);
                    DrawReversibleFrame(new Point(DrawStartPoint.Value.X, DrawStartPoint.Value.Y + MENUSTRIP_HEIGHT), e.X - DrawStartPoint.Value.X, e.Y - DrawStartPoint.Value.Y);
                }

                this.pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// Event handler for click on new canvas button in tool strip
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void newCanvasButton_Click(object sender, EventArgs e)
        {
            if (IsImageChanged)
            {
                if (MessageBox.Show("Save changes?", "Save?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                     == DialogResult.OK)
                {
                    FileOperations.SaveImage(pictureBox.Image);
                }
            }
            SetCanvas();
            IsImageChanged = false;
        }

        /// <summary>
        /// Event handler for click on save image button in tool strip
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void saveImageButton_Click(object sender, EventArgs e)
        {
            FileOperations.SaveImage(pictureBox.Image);
            IsImageChanged = false;
        }

        /// <summary>
        /// Event handler for click on open image button in tool strip
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void openImageButton_Click(object sender, EventArgs e)
        {
            if (IsImageChanged)
            {
                if (MessageBox.Show("Save changes?", "Save?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                     == DialogResult.OK)
                {
                    FileOperations.SaveImage(pictureBox.Image);
                }
            }

            var image = FileOperations.OpenImage();
            if (image != null)
            {
                Canvas_Width = image.Width;
                Canvas_Height = image.Height;
                SetCanvas();
                CanvasGraphics.DrawImage(image, 0, 0);
                IsImageChanged = false;
            }
        }

        /// <summary>
        /// Event handler for click on negative image filter button in tool strip
        /// Filter called in new thread from ThreadPool
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private async void negativeFilterButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ModifyImage(ColorModifier.Negative));
        }

        /// <summary>
        /// Event handler for click on sepia image filter button in tool strip
        /// Filter called in new thread from ThreadPool
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private async void sepiaFilterButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ModifyImage(ColorModifier.Sepia));
        }

        /// <summary>
        /// Event handler for click on gray scale image filter button in tool strip
        /// Filter called in new thread from ThreadPool
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private async void grayscaleFilterButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ModifyImage(ColorModifier.GrayScale));
        }

        /// <summary>
        /// Event handler for selecting value in comboBox of pencil size in tool strip
        /// Filter called in new thread from ThreadPool
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments send by sender</param>
        private void pencilSizeButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            PencilWidth = Convert.ToInt32(pencilSizeButton.SelectedItem);
        }

        #endregion

        /// <summary>
        /// Draw reversible rectangle on pictureBox while draw tool is Rectangle, Circle,
        /// FilledRectangle or FilledCircle and mouse moving over pictureBox
        /// </summary>
        /// <param name="point">Start point of the drawing</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        private void DrawReversibleFrame(Point point, int width, int height)
        {
            point = this.PointToScreen(point);
            var rectangle = new Rectangle(point.X, point.Y, width, height);
            ControlPaint.DrawReversibleFrame(rectangle, this.ForeColor, FrameStyle.Dashed);
        }

        /// <summary>
        /// Draw reversible line on pictureBox while draw tool is Line and mouse moving over pictureBox
        /// </summary>
        /// <param name="point">Start point of the drawing</param>
        /// <param name="point1">End point of the drawing</param>
        private void DrawReversibleLine(Point point, Point point1)
        {
            point = this.PointToScreen(point);
            point1 = this.PointToScreen(point1);
            ControlPaint.DrawReversibleLine(point, point1, this.ForeColor);
        }

        /// <summary>
        /// Gets draw tool
        /// </summary>
        /// <param name="toolStripItem">ToolStrip item which was clicked</param>
        /// <returns>Enumeration which describe draw tool</returns>
        private DrawTool GetDrawTool(ToolStripButton toolStripItem)
        {
            DrawTool draw = DrawTool.None;
            if (toolStripItem == pencilButton)
            {
                draw = DrawTool.Pen;
            }
            else if (toolStripItem == eraserButton)
            {
                draw = DrawTool.Eraser;
            }
            else if (toolStripItem == lineButton)
            {
                draw = DrawTool.Line;
            }
            else if (toolStripItem == circleButton)
            {
                draw = DrawTool.Circle;
            }
            else if (toolStripItem == filledCircleButton)
            {
                draw = DrawTool.FilledCircle;
            }
            else if (toolStripItem == rectangleButton)
            {
                draw = DrawTool.Rectangle;
            }
            else if (toolStripItem == filledRectangleButton)
            {
                draw = DrawTool.FilledRectangle;
            }
            return draw;
        }

        /// <summary>
        /// Items initializer for pencil size comboBox
        /// </summary>
        private void InitPencilSizeControlByValues()
        {
            this.pencilSizeButton.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        }

        /// <summary>
        /// Modify image in pictureBox according to selected filter
        /// </summary>
        /// <param name="modifierType">Color modifier type</param>
        private void ModifyImage(ColorModifier modifierType)
        {
                IColorModifier pixelModifier = ColorModifierCreator.Create(modifierType);

                Bitmap bitmap = new Bitmap(pictureBox.Image);
                int size = bitmap.Width * bitmap.Height;

                this.Invoke(new Action(() =>
                {
                    SetUpProgressBar(size);
                    SetFilterButtons(false);
                }));

                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color color = bitmap.GetPixel(i, j);
                        color = pixelModifier.Modify(color);
                        bitmap.SetPixel(i, j, color);
                        this.Invoke(new Action(() =>
                        {
                            toolStripProgressBar1.PerformStep();
                        }));
                    }
                }

                this.Invoke(new Action(() =>
                {
                    pictureBox.Image = bitmap;
                    toolStripProgressBar1.Value = 0;
                    statusStrip1.Visible = false;
                    CanvasGraphics = Graphics.FromImage(pictureBox.Image);
                    SetFilterButtons(true);
                }));
        }

        /// <summary>
        /// Progress bar properties setter
        /// </summary>
        /// <param name="maxValue">Maximum value for progress bar</param>
        private void SetUpProgressBar(int maxValue)
        {
            statusStrip1.Visible = true;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = maxValue;
            toolStripProgressBar1.Step = 1;
        }

        /// <summary>
        /// Sets all draw tool buttons in tool Strip to unchecked state
        /// </summary>
        private void SetAllDrawToolsToUnchecked()
        {
            pencilButton.Checked = false;
            lineButton.Checked = false;
            circleButton.Checked = false;
            filledCircleButton.Checked = false;
            rectangleButton.Checked = false;
            filledRectangleButton.Checked = false;
            eraserButton.Checked = false;
        }

        /// <summary>
        /// Sets color for lines and fill cover 
        /// </summary>
        /// <param name="toolStripItem">ToolStrip item which was clicked</param>
        private void SetColor(ToolStripButton toolStripItem)
        {
            if (toolStripItem == color1Button)
            {
                LinesColor = toolStripItem.BackColor;
            }
            else if (toolStripItem == color2Button)
            {
                FillColor = toolStripItem.BackColor;
            }
        }

        /// <summary>
        /// Sets canvas state
        /// </summary>
        private void SetCanvas()
        {
            pictureBox.Size = new Size(Canvas_Width, Canvas_Height);
            pictureBox.Image = new Bitmap(Canvas_Width, Canvas_Height);
            CanvasGraphics = Graphics.FromImage(pictureBox.Image);
            CanvasGraphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas_Width, Canvas_Height));
        }

        /// <summary>
        /// Sets cursor for pictureBox according draw tool
        /// </summary>
        private void SetCursor()
        {
            switch (DrawTool)
            {
                case DrawTool.Pen:
                case DrawTool.Line:
                    pictureBox.Cursor = PencilCursor;
                    break;
                case DrawTool.Circle:
                case DrawTool.FilledCircle:
                case DrawTool.Rectangle:
                case DrawTool.FilledRectangle:
                    pictureBox.Cursor = Cursors.Cross;
                    break;
                case DrawTool.Eraser:
                    pictureBox.Cursor = EraserCursor;
                    break;
                case DrawTool.None:
                    pictureBox.Cursor = Cursors.Arrow;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Change filter buttons enable/disable state
        /// </summary>
        /// <param name="flag">Specify state for filter buttons. true - enabled. false - disabled.</param>
        private void SetFilterButtons(bool flag)
        {
            this.negativeFilterButton.Enabled = flag;
            this.sepiaFilterButton.Enabled = flag;
            this.grayscaleFilterButton.Enabled = flag;
        }

        /// <summary>
        /// Sets pencil size according draw tool
        /// </summary>
        private void SetPencilSizeAccordingToDrawTool()
        {
            if (DrawTool == DrawTool.Eraser)
            {
                int index = pencilSizeButton.SelectedIndex;
                pencilSizeButton.Items.RemoveAt(0);
                pencilSizeButton.SelectedIndex = index - 1 >= 0 ? index - 1 : 0;
            }
            else
            {
                if (!pencilSizeButton.Items.Contains(1))
                {
                    pencilSizeButton.Items.Insert(0, 1);
                }
            }
        }
    }
}