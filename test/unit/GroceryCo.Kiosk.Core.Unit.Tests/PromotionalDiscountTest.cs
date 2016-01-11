using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class PromotionalDiscountTest
    {
        [Test]
        public void When_constructed()
        {
            var sut = new PromotionalDiscount(5m, "discount note");
            Assert.That(sut.DiscountedSubTotal, Is.EqualTo(5m));
            Assert.That(sut.DiscountNote, Is.EqualTo("discount note"));
        }
    }
}
