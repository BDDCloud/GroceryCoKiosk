using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Kiosk.Core.PromotionRules;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests.PromotionRules
{
    [TestFixture]
    public class QuantityDiscountRuleTests
    {
        [Test]
        public void When_calculating_rule()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddQuantityDiscount("apple", 3, 2);
            productCatalog.AddProduct("apple", 0.75m);
            var sut = new QuantityDiscountRule(productCatalog);
            var promotions = new Promotions(new List<IPromotionalDiscountRule>() { sut });
            var lineItem = new LineItem("apple", 7, productCatalog, promotions);

            var actual = sut.Calculate(lineItem);

            Assert.That(actual.DiscountedSubTotal, Is.EqualTo(4.75m));
            Assert.That(actual.DiscountNote, Is.EqualTo("***Discount on apple: Buy 3 apple for $2.00, New Price $4.75, Savings $0.50"));
        }

        [Test]
        public void When_promotion_applies()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddQuantityDiscount("apple", 3, 2);
            productCatalog.AddProduct("apple", 0.75m);
            var sut = new QuantityDiscountRule(productCatalog);
            var promotions = new Promotions(new List<IPromotionalDiscountRule>() { sut });
            var lineItem = new LineItem("apple", 7, productCatalog, promotions);

            var actual = sut.PromotionApplies(lineItem);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void When_promotion_does_not_apply()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddQuantityDiscount("apple", 3, 2);
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1m);
            var sut = new QuantityDiscountRule(productCatalog);
            var promotions = new Promotions(new List<IPromotionalDiscountRule>() { sut });
            var lineItem = new LineItem("banana", 7, productCatalog, promotions);

            var actual = sut.PromotionApplies(lineItem);

            Assert.That(actual, Is.False);
        }

    }
}
