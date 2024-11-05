using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOOP
{
    public partial class Form1 : Form
    {
        private System.Drawing.Rectangle drawingAreaBounds = new System.Drawing.Rectangle(30, 70, 1170, 665);
        private UndoRedoManager undoRedoManager = new UndoRedoManager();
        private List<Shape> shapes = new List<Shape>();
        private bool shapeSelected = false;
        private string shape = "";
        private Color chosenColor = Color.Black;
        private Shape selectedShape = null;
        private Point mouseDownLocation;
        private bool isMovingShape = false;
        private ContextMenuStrip contextMenuStrip;
        private int moveCount;
        private string command = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Draw Shapes On Click";
            this.Size = new Size(1250, 800);
            this.MouseClick += Form1_MouseClick;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            InitializeContextMenu();
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
            ToolStripMenuItem changeColorItem = new ToolStripMenuItem("Change Color");
            ToolStripMenuItem resizeItem = new ToolStripMenuItem("Resize");
            ToolStripMenuItem calculateArea = new ToolStripMenuItem("Calculate Area");

            deleteItem.Click += DeleteItem_Click;
            changeColorItem.Click += ChangeColorItem_Click;
            resizeItem.Click += ResizeItem_Click;
            calculateArea.Click += CalculateArea_Click;

            contextMenuStrip.Items.Add(deleteItem);
            contextMenuStrip.Items.Add(changeColorItem);
            contextMenuStrip.Items.Add(resizeItem);
            contextMenuStrip.Items.Add(calculateArea);
        }

        private void CalculateArea_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                double area;
                if (selectedShape is Circle)
                {
                    area = ((Circle)selectedShape).CalculateArea();
                }
                else if (selectedShape is Triangle)
                {
                    area = ((Triangle)selectedShape).CalculateArea();
                }
                else
                {
                    area = ((Rectangle)selectedShape).CalculateArea();
                }
                MessageBox.Show($"Area: {area} px", "Shape Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No shape selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Shape shapeToAdd = null;
            if (e.Button == MouseButtons.Left && drawingAreaBounds.Contains(e.Location))
            {
                if (!isMovingShape)
                {
                    if (shapeSelected)
                    {
                        if (shape == "circle")
                        {
                            Circle circle = new Circle(e.X, e.Y, 30, chosenColor);
                            shapes.Add(circle);
                            shapeToAdd = circle;
                        }
                        else if (shape == "rectangle")
                        {
                            Rectangle rectangle = new Rectangle(e.X, e.Y, 60, 40, chosenColor);
                            shapes.Add(rectangle);
                            shapeToAdd = rectangle;
                        }
                        else if (shape == "triangle")
                        {
                            Triangle triangle = new Triangle(e.X, e.Y, 60, 80, 70, chosenColor);
                            shapes.Add(triangle);
                            shapeToAdd = triangle;
                        }

                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Please select a shape first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ICommand addShapeCommand = new AddShapeCommand(shapes, shapeToAdd);
                undoRedoManager.listCommand(addShapeCommand);
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (var shape in shapes)
                {
                    if (shape.ContainsPoint(e.Location))
                    {
                        selectedShape = shape;
                        mouseDownLocation = e.Location;
                        isMovingShape = true;
                        contextMenuStrip.Show(this, e.Location);
                        break;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SetClip(drawingAreaBounds);
            e.Graphics.FillRectangle(Brushes.White, drawingAreaBounds);
            e.Graphics.DrawRectangle(Pens.Black, drawingAreaBounds);

            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shapeSelected = true;
            shape = "circle";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shapeSelected = true;
            shape = "triangle";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shapeSelected = true;
            shape = "rectangle";
        }

        private void SelectColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                chosenColor = colorDialog.Color;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            Refresh();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var shape in shapes)
            {
                if (shape.ContainsPoint(e.Location))
                {
                    selectedShape = shape;
                    mouseDownLocation = e.Location;
                    isMovingShape = true;
                    moveCount = 0;
                    break;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMovingShape && selectedShape != null && e.Button == MouseButtons.Left && drawingAreaBounds.Contains(e.Location))
            {
                int newX = e.X - mouseDownLocation.X + selectedShape.X;
                int newY = e.Y - mouseDownLocation.Y + selectedShape.Y;

                selectedShape.MoveTo(newX, newY);

                //ICommand moveCommand = new MoveCommand(selectedShape, mouseDownLocation, e.Location);
                //undoRedoManager.listCommand(moveCommand);

                mouseDownLocation = e.Location;
                Refresh();

                moveCount++;
            }
            //command = "Move";
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMovingShape = false;
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                ICommand deleteCommand = new DeleteCommand(shapes, selectedShape);
                undoRedoManager.listCommand(deleteCommand);

                shapes.Remove(selectedShape);
                selectedShape = null;
                Refresh();
            }
        }

        private void ChangeColorItem_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color oldColor = selectedShape.ShapeColor;
                    selectedShape.ShapeColor = colorDialog.Color;

                    ICommand changeColorCommand = new ChangeColorCommand(selectedShape, oldColor, colorDialog.Color);
                    undoRedoManager.listCommand(changeColorCommand);

                    Refresh();
                }
            }
        }
        private void ResizeItem_Click(object sender, EventArgs e)
        {
            if (selectedShape == null)
            {
                MessageBox.Show("No shape selected to resize.");
                return;
            }

            if (selectedShape is Circle)
            {
                int radius;
                if (int.TryParse(Interaction.InputBox("Enter radius:"), out radius))
                {
                    ((Circle)selectedShape).Resize(radius);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Invalid input for radius.");
                }
            }
            else if (selectedShape is Rectangle)
            {
                int width, height;
                if (int.TryParse(Interaction.InputBox("Enter width:"), out width) &&
                    int.TryParse(Interaction.InputBox("Enter height:"), out height))
                {
                    ((Rectangle)selectedShape).Resize(width, height);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Invalid input for width or height.");
                }
            }
            else if (selectedShape is Triangle)
            {
                int side1, side2, side3;
                if (int.TryParse(Interaction.InputBox("Enter side 1:"), out side1) &&
                    int.TryParse(Interaction.InputBox("Enter side 2:"), out side2) &&
                    int.TryParse(Interaction.InputBox("Enter side 3:"), out side3))
                {
                    ((Triangle)selectedShape).Resize(side1, side2, side3);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Invalid input for sides.");
                }
            }
            else
            {
                MessageBox.Show("Unsupported shape type.");
            }
        }

        private void CalculateAreaButton_Click(object sender, EventArgs e)
        {
            if (shapes.Count == 0)
            {
                MessageBox.Show("No shapes drawn yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double totalArea = shapes.Sum(shape => shape.CalculateArea());
                MessageBox.Show($"Total Area: {totalArea} px", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (command.Equals("Move"))
            {
                for (int i = 0; i < moveCount; i++)
                {
                    undoRedoManager.Undo();
                    Refresh();
                }
            }
            else
            {
                undoRedoManager.Undo();
                Refresh();
            }
            moveCount = 0;
            command = "";
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            undoRedoManager.Redo();
            Refresh();
        }

        private void load_from_file_button_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("Shapes.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string type = values[0];
                    if (type == "Circle")
                    {
                        int x = int.Parse(values[1]);
                        int y = int.Parse(values[2]);
                        int r = int.Parse(values[3]);
                        int colorA = int.Parse(values[4]);
                        int colorR = int.Parse(values[5]);
                        int colorG = int.Parse(values[6]);
                        int colorB = int.Parse(values[7]);
                        Color color = Color.FromArgb(colorA, colorR, colorG, colorB);
                        Circle circle = new Circle(x, y, r, color);
                        shapes.Add(circle);
                    }
                    else if (type == "Rectangle")
                    {
                        int x = int.Parse(values[1]);
                        int y = int.Parse(values[2]);
                        int a = int.Parse(values[3]);
                        int b = int.Parse(values[4]);
                        int colorA = int.Parse(values[5]);
                        int colorR = int.Parse(values[6]);
                        int colorG = int.Parse(values[7]);
                        int colorB = int.Parse(values[8]);
                        Color color = Color.FromArgb(colorA, colorR, colorG, colorB);
                        Rectangle rectangle = new Rectangle(x, y, a, b, color);
                        shapes.Add(rectangle);
                    }
                    else if (type == "Triangle")
                    {
                        int x = int.Parse(values[1]);
                        int y = int.Parse(values[2]);
                        int a = int.Parse(values[3]);
                        int b = int.Parse(values[4]);
                        int c = int.Parse(values[5]);
                        int colorA = int.Parse(values[6]);
                        int colorR = int.Parse(values[7]);
                        int colorG = int.Parse(values[8]);
                        int colorB = int.Parse(values[9]);
                        Color color = Color.FromArgb(colorA, colorR, colorG, colorB);
                        Triangle triangle = new Triangle(x, y, a, b, c, color);
                        shapes.Add(triangle);
                    }
                }
            }
            Refresh();
        }

        private void save_to_file_button_Click(object sender, EventArgs e)
        {
            string fileName = "Shapes.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Shape shape in shapes)
                {
                    if (shape is Circle)
                    {
                        Circle circle = (Circle)shape;
                        writer.WriteLine("Circle-{0},{1},{2},{3},{4},{5},{6}",
                            circle.X, circle.Y, circle.R,
                            circle.ShapeColor.A, circle.ShapeColor.R, circle.ShapeColor.G, circle.ShapeColor.B);
                    }
                    else if (shape is Rectangle)
                    {
                        Rectangle rectangle = (Rectangle)shape;
                        writer.WriteLine("Rectangle-{0},{1},{2},{3},{4},{5},{6},{7}",
                            rectangle.X, rectangle.Y, rectangle.A, rectangle.B,
                            rectangle.ShapeColor.A, rectangle.ShapeColor.R, rectangle.ShapeColor.G, rectangle.ShapeColor.B);
                    }
                    else if (shape is Triangle)
                    {
                        Triangle triangle = (Triangle)shape;
                        writer.WriteLine("Triangle-{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                            triangle.X, triangle.Y, triangle.A, triangle.B, triangle.C,
                            triangle.ShapeColor.A, triangle.ShapeColor.R, triangle.ShapeColor.G, triangle.ShapeColor.B);
                    }
                }
            }
        }

        private void filterShapesButton_Click(object sender, EventArgs e)
        {
            string shapeType = Interaction.InputBox("Enter shape type (Circle, Rectangle, or Triangle):", "Filter Shapes");
            shapeType = char.ToUpper(shapeType[0]) + shapeType.Substring(1).ToLower();

            ClearCanvasInBounds(drawingAreaBounds);

            int shapeCount = 0;

            switch (shapeType)
            {
                case "Circle":
                    DrawFilteredShapes(shapes.OfType<Circle>());
                    shapeCount = shapes.OfType<Circle>().Count();
                    break;
                case "Rectangle":
                    DrawFilteredShapes(shapes.OfType<Rectangle>());
                    shapeCount = shapes.OfType<Rectangle>().Count();
                    break;
                case "Triangle":
                    DrawFilteredShapes(shapes.OfType<Triangle>());
                    shapeCount = shapes.OfType<Triangle>().Count();
                    break;
                default:
                    MessageBox.Show("Invalid shape type entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            MessageBox.Show($"Total {shapeType}s: {shapeCount}", "Shape Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DrawFilteredShapes(IEnumerable<Shape> filteredShapes)
        {
            using (Graphics g = CreateGraphics())
            {
                foreach (var shape in filteredShapes)
                {
                    shape.Draw(g);
                }
            }
        }

        private void ClearCanvasInBounds(System.Drawing.Rectangle bounds)
        {
            using (Graphics g = CreateGraphics())
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, bounds);
                }
            }
        }

        private void filterColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color chosenColor = colorDialog.Color;

                ClearCanvasInBounds(drawingAreaBounds);

                DrawFilteredShapes(shapes.Where(shape => shape.ShapeColor == chosenColor));
            }
        }

        private void filterSizeButton_Click(object sender, EventArgs e)
        {
            double minArea;
            if (!double.TryParse(Interaction.InputBox("Enter minimum area:", "Filter by Size"), out minArea))
            {
                MessageBox.Show("Invalid input for minimum area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredShapes = shapes.Where(shape => shape.CalculateArea() >= minArea);
            ClearCanvasInBounds(drawingAreaBounds);
            DrawFilteredShapes(filteredShapes);
        }

        private void filterPositionButton_Click(object sender, EventArgs e)
        {
            int x, y;
            if (!int.TryParse(Interaction.InputBox("Enter X coordinate:", "Filter by Position"), out x) ||
                !int.TryParse(Interaction.InputBox("Enter Y coordinate:", "Filter by Position"), out y))
            {
                MessageBox.Show("Invalid input for coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filteredShapes = shapes.Where(shape => shape.ContainsPoint(new Point(x, y)));
            ClearCanvasInBounds(drawingAreaBounds);
            DrawFilteredShapes(filteredShapes);
        }
    }
}