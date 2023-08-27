using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public abstract class PricingRule
    {
        public abstract char Item { get; }
        public abstract int UnitPrice { get; }
        public abstract int Quantity { get; }
        public abstract int SpecialPrice { get; }
        public abstract int CalculatePrice(List<char> items);

    }
}
