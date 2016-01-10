using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class QuantityDiscountTests
    {
        [Test]
        public void When_constructed()
        {
            var sut = new QuantityDiscount("apple", 3, 2.00m);
            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.DiscountQuantity, Is.EqualTo(3));
            Assert.That(sut.DiscountPrice, Is.EqualTo(2.00m));
        }
    }
}
