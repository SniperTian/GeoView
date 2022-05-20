using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public abstract class moSymbol
    {
        public abstract moSymbolTypeConstant SymbolType { get; }
        public abstract moSymbol Clone();
    }
}
