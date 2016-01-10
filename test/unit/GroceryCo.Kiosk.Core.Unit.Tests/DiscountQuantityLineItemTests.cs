using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class DiscountQuantityLineItemTests
    {
        [Test]
        public void When_constructed()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddQuantityDiscount("apple", 2, 2.00m);
            var sut = new QuantityDiscountLineItem("apple", 4, productCatalog);

            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.Quantity, Is.EqualTo(4));
            Assert.That(sut.DiscountQuantity, Is.EqualTo(2));
            Assert.That(sut.DiscountPrice, Is.EqualTo(2.00m));
            Assert.That(sut.SubTotal, Is.EqualTo(4.00m));
        }
    }
}
