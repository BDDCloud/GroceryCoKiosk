using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Kiosk.Core.PromotionRules;
using Moq;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class PromotionsTests
    {
        [Test]
        public void When_no_promotion_applies()
        {
            var rule = new Mock<IPromotionalDiscountRule>();
            rule.Setup(p => p.PromotionApplies(It.IsAny<LineItem>())).Returns(false);
            var sut = new Promotions(new List<IPromotionalDiscountRule>() { rule.Object });
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            var lineItem = new LineItem("apple", 7, productCatalog, sut);

            var actual = sut.CalculatePromotionalCost(lineItem);
            Assert.That(actual.DiscountedSubTotal, Is.EqualTo(lineItem.SubTotal));
            Assert.That(actual.DiscountNote, Is.EqualTo(""));
        }

        [Test]
        public void When_promotion_applies()
        {
            var rule = new Mock<IPromotionalDiscountRule>();
            rule.Setup(p => p.PromotionApplies(It.IsAny<LineItem>())).Returns(true);
            var promotionalDiscount = new PromotionalDiscount(7m, "discount note");
            rule.Setup(p => p.Calculate(It.IsAny<LineItem>())).Returns(promotionalDiscount);
            var sut = new Promotions(new List<IPromotionalDiscountRule>() { rule.Object });
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            var lineItem = new LineItem("apple", 7, productCatalog, sut);

            var actual = sut.CalculatePromotionalCost(lineItem);
            Assert.That(actual.DiscountedSubTotal, Is.EqualTo(7m));
            Assert.That(actual.DiscountNote, Is.EqualTo("discount note"));
        }
    }
}
