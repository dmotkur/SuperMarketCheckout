using SuperMarketCheckout;

namespace SuperMarketCheckoutTests
{
    public class CheckoutTest
    {
        private PricingRuleDecorator _pricingRuleDecorator;
        private Checkout _checkout;
        [SetUp]
        public void Setup()
        {
            var basePricingRuleA = new BasePricingRule('A', 50, 3, 130);
            var basePricingRuleB = new BasePricingRule('B', 30, 2, 45);
            var basePricingRuleC = new BasePricingRule('C', 20, 0, 0);
            var basePricingRuleD = new BasePricingRule('D', 15, 0, 0);
            _pricingRuleDecorator = new SpecialOfferDecorator(basePricingRuleA);
            var pricingRules = new Dictionary<char, PricingRuleDecorator>
            {
                { 'A', _pricingRuleDecorator },
                { 'B', new SpecialOfferDecorator(basePricingRuleB) },
                { 'C', new SpecialOfferDecorator(basePricingRuleC) },
                { 'D', new SpecialOfferDecorator(basePricingRuleD) }
            };

            _checkout = new Checkout(pricingRules);
        }

        [Test]
        public void CalculatePrice_NoItems_ReturnsZero()
        {
            var items = new List<char>();

            int totalPrice = _checkout.CalculatePrice(items);

            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void CalculatePrice_ItemsWithoutSpecialOffer_ReturnsCorrectPrice()
        {
            var items = new List<char> { 'A', 'B', 'C', 'D' };

            int totalPrice = _checkout.CalculatePrice(items);

            Assert.AreEqual(50 + 30 + 20 + 15, totalPrice);
        }

        [Test]
        public void CalculatePrice_ItemsWithSpecialOffer_ReturnsCorrectPrice()
        {
            var items = new List<char> { 'A', 'A', 'A' }; // 3 items of A with special offer

            int totalPrice = _checkout.CalculatePrice(items);

            Assert.AreEqual(130, totalPrice);
        }

        [Test]
        public void CalculatePrice_ItemsWithMixedSpecialOffers_ReturnsCorrectPrice()
        {
            var items = new List<char> { 'A', 'B', 'B', 'A', 'A', 'C', 'D' };

            int totalPrice = _checkout.CalculatePrice(items);

            Assert.AreEqual(130 + 45 + 20 + 15, totalPrice);
        }
    }
}