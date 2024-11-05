using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class ResizeCommand:ICommand
    {
        private Shape shape;
        private object originalParameters;
        private object newParameters;

        public ResizeCommand(Shape shape, object originalParameters, object newParameters)
        {
            this.shape = shape;
            this.originalParameters = originalParameters;
            this.newParameters = newParameters;
        }

        public void Execute()
        {
            //shape.Resize(newParameters);
        }

        public void Undo()
        {
            //shape.Resize(originalParameters);
        }
    }
}
