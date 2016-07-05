using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goblinfactory.Coffee.Shared.Messages
{
    public class MakeCoffee
    {
        public string Coffee { get; private set; }

        public MakeCoffee(string coffee)
        {
            Coffee = coffee;
        }
    }
}
