using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public interface ICheckout
    {
        int CalculatePrice(List<char> items);
    }
}
