    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ProjectOOP
    {
        class DeleteCommand : ICommand
        {
            private Shape shape;
            private List<Shape> shapes;

            public DeleteCommand(List<Shape> shapes, Shape shape)
            {
                this.shapes = shapes;
                this.shape = shape;
            }

            public void Execute()
            {
                shapes.Remove(shape);
            }

            public void Undo()
            {
                shapes.Add(shape);
            }
        }
    }
