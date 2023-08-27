using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public class Checkout
    {
        private readonly Dictionary<char, PricingRuleDecorator> _pricingRules;

        public Checkout(Dictionary<char, PricingRuleDecorator> pricingRules)
        {
            _pricingRules = pricingRules;
        }

        public int CalculatePrice(List<char> items)
        {
            int totalPrice = 0;
            var groupedItems = items.GroupBy(x => x);

            foreach (var group in groupedItems)
            {
                if (_pricingRules.TryGetValue(group.Key, out var pricingRule))
                {
                    totalPrice += pricingRule.CalculatePrice(group.ToList());
                }
            }

            return totalPrice;
        }
    }
}
