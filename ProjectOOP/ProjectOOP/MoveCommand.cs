using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class MoveCommand : ICommand
    {
        private Shape shape;
        private Point originalPosition;
        private Point newPosition;

        public MoveCommand(Shape shape, Point originalPosition, Point newPosition)
        {
            this.shape = shape;
            this.originalPosition = originalPosition;
            this.newPosition = newPosition;
        }

        public void Execute()
        {
            shape.MoveTo(newPosition.X, newPosition.Y);
        }

        public void Undo()
        {
            shape.MoveTo(originalPosition.X, originalPosition.Y);
        }
    }
}
