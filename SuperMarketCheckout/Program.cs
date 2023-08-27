using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(',').Select(x => x[0]);
            if (items != null)
            {
                var pricingRules = new Dictionary<char, PricingRuleDecorator>
                {
                    { 'A', new SpecialOfferDecorator(new BasePricingRule('A', 50, 3, 130)) },
                    { 'B', new SpecialOfferDecorator(new BasePricingRule('B', 30, 2, 45)) },
                    { 'C', new SpecialOfferDecorator(new BasePricingRule('C', 20, 0, 0)) },
                    { 'D', new SpecialOfferDecorator(new BasePricingRule('D', 15, 0, 0)) }
                };

                var checkout = new Checkout(pricingRules);
                var totalPrice = checkout.CalculatePrice(items.ToList());
                Console.WriteLine($"Price is : {totalPrice}");
            }
        }
    }
          
}
