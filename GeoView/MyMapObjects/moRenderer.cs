using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public abstract class moRenderer
    {
        public abstract moRendererTypeConstant RendererType { get; }
        public abstract moRenderer Clone();
    }
}
