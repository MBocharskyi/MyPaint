namespace MyPaint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pencilButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.circleButton = new System.Windows.Forms.ToolStripButton();
            this.filledCircleButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleButton = new System.Windows.Forms.ToolStripButton();
            this.filledRectangleButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.color1Button = new System.Windows.Forms.ToolStripButton();
            this.color2Button = new System.Windows.Forms.ToolStripButton();
            this.pencilSizeButton = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.negativeFilterButton = new System.Windows.Forms.ToolStripButton();
            this.sepiaFilterButton = new System.Windows.Forms.ToolStripButton();
            this.grayscaleFilterButton = new System.Windows.Forms.ToolStripButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.saveButton,
            this.openButton,
            this.toolStripSeparator1,
            this.pencilButton,
            this.lineButton,
            this.circleButton,
            this.filledCircleButton,
            this.rectangleButton,
            this.filledRectangleButton,
            this.eraserButton,
            this.toolStripSeparator2,
            this.color1Button,
            this.color2Button,
            this.pencilSizeButton,
            this.toolStripSeparator3,
            this.negativeFilterButton,
            this.sepiaFilterButton,
            this.grayscaleFilterButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(23, 22);
            this.newButton.ToolTipText = "Create new file";
            this.newButton.Click += new System.EventHandler(this.newCanvasButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.ToolTipText = "Save image";
            this.saveButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "toolStripButton3";
            this.openButton.ToolTipText = "Open image";
            this.openButton.Click += new System.EventHandler(this.openImageButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pencilButton
            // 
            this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(23, 22);
            this.pencilButton.Text = "toolStripButton4";
            this.pencilButton.ToolTipText = "Select pencil";
            this.pencilButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(23, 22);
            this.lineButton.Text = "toolStripButton5";
            this.lineButton.ToolTipText = "Draw line";
            this.lineButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(23, 22);
            this.circleButton.ToolTipText = "Draaw circle";
            this.circleButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // filledCircleButton
            // 
            this.filledCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filledCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("filledCircleButton.Image")));
            this.filledCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filledCircleButton.Name = "filledCircleButton";
            this.filledCircleButton.Size = new System.Drawing.Size(23, 22);
            this.filledCircleButton.Text = "toolStripButton7";
            this.filledCircleButton.ToolTipText = "Draw filled circle";
            this.filledCircleButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(23, 22);
            this.rectangleButton.Text = "toolStripButton8";
            this.rectangleButton.ToolTipText = "Draw rectangle";
            this.rectangleButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // filledRectangleButton
            // 
            this.filledRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filledRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("filledRectangleButton.Image")));
            this.filledRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filledRectangleButton.Name = "filledRectangleButton";
            this.filledRectangleButton.Size = new System.Drawing.Size(23, 22);
            this.filledRectangleButton.Text = "toolStripButton9";
            this.filledRectangleButton.ToolTipText = "Draw filled rectangle";
            this.filledRectangleButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(23, 22);
            this.eraserButton.ToolTipText = "Eraser button";
            this.eraserButton.Click += new System.EventHandler(this.drawItemButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // color1Button
            // 
            this.color1Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.color1Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.color1Button.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.color1Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color1Button.Margin = new System.Windows.Forms.Padding(2);
            this.color1Button.Name = "color1Button";
            this.color1Button.Padding = new System.Windows.Forms.Padding(2);
            this.color1Button.Size = new System.Drawing.Size(23, 21);
            this.color1Button.ToolTipText = "Color 1";
            this.color1Button.Click += new System.EventHandler(this.color_Click);
            // 
            // color2Button
            // 
            this.color2Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.color2Button.Image = ((System.Drawing.Image)(resources.GetObject("color2Button.Image")));
            this.color2Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color2Button.Margin = new System.Windows.Forms.Padding(2);
            this.color2Button.Name = "color2Button";
            this.color2Button.Padding = new System.Windows.Forms.Padding(2);
            this.color2Button.Size = new System.Drawing.Size(23, 21);
            this.color2Button.Text = "toolStripButton10";
            this.color2Button.ToolTipText = "Color 2";
            this.color2Button.Click += new System.EventHandler(this.color_Click);
            // 
            // pencilSizeButton
            // 
            this.pencilSizeButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pencilSizeButton.Name = "pencilSizeButton";
            this.pencilSizeButton.Size = new System.Drawing.Size(75, 25);
            this.pencilSizeButton.ToolTipText = "Pencil size";
            this.pencilSizeButton.SelectedIndexChanged += new System.EventHandler(this.pencilSizeButton_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // negativeFilterButton
            // 
            this.negativeFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.negativeFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("negativeFilterButton.Image")));
            this.negativeFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.negativeFilterButton.Name = "negativeFilterButton";
            this.negativeFilterButton.Size = new System.Drawing.Size(58, 22);
            this.negativeFilterButton.Text = "Negative";
            this.negativeFilterButton.ToolTipText = "Use negative filter";
            this.negativeFilterButton.Click += new System.EventHandler(this.negativeFilterButton_Click);
            // 
            // sepiaFilterButton
            // 
            this.sepiaFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sepiaFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("sepiaFilterButton.Image")));
            this.sepiaFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sepiaFilterButton.Name = "sepiaFilterButton";
            this.sepiaFilterButton.Size = new System.Drawing.Size(39, 22);
            this.sepiaFilterButton.Text = "Sepia";
            this.sepiaFilterButton.ToolTipText = "Use sepia filter";
            this.sepiaFilterButton.Click += new System.EventHandler(this.sepiaFilterButton_Click);
            // 
            // grayscaleFilterButton
            // 
            this.grayscaleFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.grayscaleFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("grayscaleFilterButton.Image")));
            this.grayscaleFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.grayscaleFilterButton.Name = "grayscaleFilterButton";
            this.grayscaleFilterButton.Size = new System.Drawing.Size(61, 22);
            this.grayscaleFilterButton.Text = "Grayscale";
            this.grayscaleFilterButton.ToolTipText = "Use grayscale filter";
            this.grayscaleFilterButton.Click += new System.EventHandler(this.grayscaleFilterButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(0, 28);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            this.statusStrip1.Resize += new System.EventHandler(this.statusStrip_Resize);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(683, 479);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "My paint";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton pencilButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton circleButton;
        private System.Windows.Forms.ToolStripButton filledCircleButton;
        private System.Windows.Forms.ToolStripButton rectangleButton;
        private System.Windows.Forms.ToolStripButton filledRectangleButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton color1Button;
        private System.Windows.Forms.ToolStripButton color2Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton negativeFilterButton;
        private System.Windows.Forms.ToolStripButton sepiaFilterButton;
        private System.Windows.Forms.ToolStripButton grayscaleFilterButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripComboBox pencilSizeButton;
        private System.Windows.Forms.ToolStripButton eraserButton;
    }
}

