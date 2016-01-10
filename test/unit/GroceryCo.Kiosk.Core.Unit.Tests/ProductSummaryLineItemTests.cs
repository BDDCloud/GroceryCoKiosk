using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class ProductSummaryLineItemTests
    {
        [Test]
        public void When_constructed()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var sut = new ProductSummaryLineItem("apple", 2, productCatalog);

            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.Quantity, Is.EqualTo(2));
            Assert.That(sut.Price, Is.EqualTo(0.75m));
            Assert.That(sut.SubTotal, Is.EqualTo(1.50m));
        }
    }
}
