
namespace ProjectOOP
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
            this.CircleButton = new System.Windows.Forms.Button();
            this.TriangleButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.SelectColorButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.CalculateAreaButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.save_to_file_button = new System.Windows.Forms.Button();
            this.load_from_file_button = new System.Windows.Forms.Button();
            this.filterShapesButton = new System.Windows.Forms.Button();
            this.filterColorButton = new System.Windows.Forms.Button();
            this.filterSizeButton = new System.Windows.Forms.Button();
            this.filterPositionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CircleButton
            // 
            this.CircleButton.Location = new System.Drawing.Point(12, 14);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(87, 39);
            this.CircleButton.TabIndex = 0;
            this.CircleButton.TabStop = false;
            this.CircleButton.Text = "Circle";
            this.CircleButton.UseVisualStyleBackColor = true;
            this.CircleButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TriangleButton
            // 
            this.TriangleButton.Location = new System.Drawing.Point(105, 14);
            this.TriangleButton.Name = "TriangleButton";
            this.TriangleButton.Size = new System.Drawing.Size(81, 39);
            this.TriangleButton.TabIndex = 1;
            this.TriangleButton.TabStop = false;
            this.TriangleButton.Text = "Triangle";
            this.TriangleButton.UseVisualStyleBackColor = true;
            this.TriangleButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.Location = new System.Drawing.Point(192, 14);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(109, 39);
            this.RectangleButton.TabIndex = 2;
            this.RectangleButton.TabStop = false;
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.UseVisualStyleBackColor = true;
            this.RectangleButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // SelectColorButton
            // 
            this.SelectColorButton.Location = new System.Drawing.Point(308, 14);
            this.SelectColorButton.Name = "SelectColorButton";
            this.SelectColorButton.Size = new System.Drawing.Size(116, 39);
            this.SelectColorButton.TabIndex = 3;
            this.SelectColorButton.TabStop = false;
            this.SelectColorButton.Text = "Select color";
            this.SelectColorButton.UseVisualStyleBackColor = true;
            this.SelectColorButton.Click += new System.EventHandler(this.SelectColorButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(430, 14);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(54, 39);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.TabStop = false;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CalculateAreaButton
            // 
            this.CalculateAreaButton.Location = new System.Drawing.Point(490, 14);
            this.CalculateAreaButton.Name = "CalculateAreaButton";
            this.CalculateAreaButton.Size = new System.Drawing.Size(93, 39);
            this.CalculateAreaButton.TabIndex = 5;
            this.CalculateAreaButton.TabStop = false;
            this.CalculateAreaButton.Text = "Calculate Area";
            this.CalculateAreaButton.UseVisualStyleBackColor = true;
            this.CalculateAreaButton.Click += new System.EventHandler(this.CalculateAreaButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(589, 14);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(73, 39);
            this.undoButton.TabIndex = 6;
            this.undoButton.TabStop = false;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Location = new System.Drawing.Point(668, 14);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(73, 39);
            this.redoButton.TabIndex = 7;
            this.redoButton.TabStop = false;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // save_to_file_button
            // 
            this.save_to_file_button.Location = new System.Drawing.Point(747, 14);
            this.save_to_file_button.Name = "save_to_file_button";
            this.save_to_file_button.Size = new System.Drawing.Size(73, 39);
            this.save_to_file_button.TabIndex = 8;
            this.save_to_file_button.TabStop = false;
            this.save_to_file_button.Text = "Save To File";
            this.save_to_file_button.UseVisualStyleBackColor = true;
            this.save_to_file_button.Click += new System.EventHandler(this.save_to_file_button_Click);
            // 
            // load_from_file_button
            // 
            this.load_from_file_button.Location = new System.Drawing.Point(826, 14);
            this.load_from_file_button.Name = "load_from_file_button";
            this.load_from_file_button.Size = new System.Drawing.Size(73, 39);
            this.load_from_file_button.TabIndex = 9;
            this.load_from_file_button.TabStop = false;
            this.load_from_file_button.Text = "Load From File";
            this.load_from_file_button.UseVisualStyleBackColor = true;
            this.load_from_file_button.Click += new System.EventHandler(this.load_from_file_button_Click);
            // 
            // filterShapesButton
            // 
            this.filterShapesButton.Location = new System.Drawing.Point(905, 14);
            this.filterShapesButton.Name = "filterShapesButton";
            this.filterShapesButton.Size = new System.Drawing.Size(73, 39);
            this.filterShapesButton.TabIndex = 10;
            this.filterShapesButton.TabStop = false;
            this.filterShapesButton.Text = "Filter shapes";
            this.filterShapesButton.UseVisualStyleBackColor = true;
            this.filterShapesButton.Click += new System.EventHandler(this.filterShapesButton_Click);
            // 
            // filterColorButton
            // 
            this.filterColorButton.Location = new System.Drawing.Point(984, 14);
            this.filterColorButton.Name = "filterColorButton";
            this.filterColorButton.Size = new System.Drawing.Size(73, 39);
            this.filterColorButton.TabIndex = 11;
            this.filterColorButton.TabStop = false;
            this.filterColorButton.Text = "Filter Color";
            this.filterColorButton.UseVisualStyleBackColor = true;
            this.filterColorButton.Click += new System.EventHandler(this.filterColorButton_Click);
            // 
            // filterSizeButton
            // 
            this.filterSizeButton.Location = new System.Drawing.Point(1063, 12);
            this.filterSizeButton.Name = "filterSizeButton";
            this.filterSizeButton.Size = new System.Drawing.Size(73, 39);
            this.filterSizeButton.TabIndex = 12;
            this.filterSizeButton.TabStop = false;
            this.filterSizeButton.Text = "Filter size";
            this.filterSizeButton.UseVisualStyleBackColor = true;
            this.filterSizeButton.Click += new System.EventHandler(this.filterSizeButton_Click);
            // 
            // filterPositionButton
            // 
            this.filterPositionButton.Location = new System.Drawing.Point(1142, 12);
            this.filterPositionButton.Name = "filterPositionButton";
            this.filterPositionButton.Size = new System.Drawing.Size(73, 39);
            this.filterPositionButton.TabIndex = 13;
            this.filterPositionButton.TabStop = false;
            this.filterPositionButton.Text = "Filter position";
            this.filterPositionButton.UseVisualStyleBackColor = true;
            this.filterPositionButton.Click += new System.EventHandler(this.filterPositionButton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1222, 544);
            this.Controls.Add(this.filterPositionButton);
            this.Controls.Add(this.filterSizeButton);
            this.Controls.Add(this.filterColorButton);
            this.Controls.Add(this.filterShapesButton);
            this.Controls.Add(this.load_from_file_button);
            this.Controls.Add(this.save_to_file_button);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.CalculateAreaButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SelectColorButton);
            this.Controls.Add(this.RectangleButton);
            this.Controls.Add(this.TriangleButton);
            this.Controls.Add(this.CircleButton);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button TriangleButton;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button SelectColorButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button CalculateAreaButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button save_to_file_button;
        private System.Windows.Forms.Button load_from_file_button;
        private System.Windows.Forms.Button filterShapesButton;
        private System.Windows.Forms.Button filterColorButton;
        private System.Windows.Forms.Button filterSizeButton;
        private System.Windows.Forms.Button filterPositionButton;
    }
}

