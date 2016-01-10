using System.Collections.Generic;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class BillTests
    {
        [Test]
        public void When_no_items()
        {
            var sut = new Bill(new List<string>(), new ProductCatalog());
            Assert.That(sut.Total, Is.EqualTo(0m));
        }

        [Test]
        public void When_some_items()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var sut = new Bill(new List<string>() { "apple", "banana", "apple" }, productCatalog);

            Assert.That(sut.Total, Is.EqualTo(2.50m));
        }
    }
}
