using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class AdditionalItemDiscountTests
    {
        [Test]
        public void When_constructed()
        {
            var sut = new AdditionalItemDiscount("apple", 3, 2, 100);
            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.QuantityFullPrice, Is.EqualTo(3));
            Assert.That(sut.QuantityDiscounted, Is.EqualTo(2.00));
            Assert.That(sut.DiscountPercentage, Is.EqualTo(100));
        }
    }
}
