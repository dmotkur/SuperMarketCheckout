using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public class BasePricingRule : PricingRule
    {
        private char _item;
        private int _unitPrice;
        private int _quantity;
        private int _specialPrice;
        public BasePricingRule(char item, int unitPrice, int quantity, int specialPrice)
        {
            _item = item;
            _unitPrice = unitPrice;
            _quantity = quantity;
            _specialPrice = specialPrice;
        }
        public override char Item { get { return _item; } }

        public override int UnitPrice
        {
            get { return _unitPrice; }
        }

        public override int Quantity
        { get { return _quantity; } }

        public override int SpecialPrice
        { get { return _specialPrice; } }

        public override int CalculatePrice(List<char> items)
        {
            int totalPrice = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalPrice += _unitPrice;
            }
            return totalPrice;
        }
    }
}
