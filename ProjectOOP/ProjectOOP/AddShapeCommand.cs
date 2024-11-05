using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class AddShapeCommand:ICommand
    {
        private List<Shape> shapes;
        private Shape shapeToAdd;

        public AddShapeCommand(List<Shape> shapes, Shape shapeToAdd)
        {
            this.shapes = shapes;
            this.shapeToAdd = shapeToAdd;
        }

        public void Execute()
        {
            shapes.Add(shapeToAdd);
        }

        public void Undo()
        {
            shapes.Remove(shapeToAdd);
        }
    }
}
