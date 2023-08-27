using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public class SpecialOfferDecorator : PricingRuleDecorator
    {
        PricingRule _pricingRule;
        public SpecialOfferDecorator(PricingRule pricingRule) : base(pricingRule)
        {
            _pricingRule = pricingRule;
        }

        public override int CalculatePrice(List<char> items)
        {
            int totalPrice = base.CalculatePrice(items);
            int quantity = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == this._pricingRule.Item)
                {
                    quantity++;
                    if (quantity == this._pricingRule.Quantity)
                    {
                        totalPrice -= (this._pricingRule.UnitPrice * quantity);
                        totalPrice += this._pricingRule.SpecialPrice;
                        quantity = 0;
                    }
                }
            }

            return totalPrice;
        }
    }
}
