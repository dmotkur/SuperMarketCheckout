using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public abstract class PricingRuleDecorator : PricingRule
    {
        protected PricingRule _pricingRule;
        public PricingRuleDecorator(PricingRule pricingRule)
        {
            _pricingRule = pricingRule;
        }

        public override char Item
        {
            get { return _pricingRule.Item; }
        }

        public override int UnitPrice
        {
            get { return _pricingRule.Item; }
        }
        public override int Quantity
        {
            get { return _pricingRule.Quantity; }
        }
        public override int SpecialPrice
        {
            get { return _pricingRule.SpecialPrice; }
        }
        public override int CalculatePrice(List<char> items)
        {
            return _pricingRule.CalculatePrice(items);
        }
    }
}
