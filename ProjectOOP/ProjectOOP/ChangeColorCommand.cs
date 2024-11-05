using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class ChangeColorCommand : ICommand
    {
        private Shape shape;
        private Color originalColor;
        private Color newColor;

        public ChangeColorCommand(Shape shape, Color originalColor, Color newColor)
        {
            this.shape = shape;
            this.originalColor = originalColor;
            this.newColor = newColor;
        }
        public void Execute()
        {
            shape.ShapeColor = newColor;
        }

        public void Undo()
        {
            shape.ShapeColor = originalColor;
        }
    }
}
