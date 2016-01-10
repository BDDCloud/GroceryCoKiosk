using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class ProductCatalogTests
    {
        [Test]
        public void When_product_catalog_is_created()
        {
            var sut = new ProductCatalog();

            Assert.That(sut.Products.Count(), Is.EqualTo(0));
        }

        [Test]
        public void When_product_catalog_is_added_to()
        {
            var sut = new ProductCatalog();

            sut.AddProduct("apple", 0.75m);
            sut.AddProduct("banana", 1.00m);

            Assert.That(sut.Products.Count(), Is.EqualTo(2));
            Assert.True(sut.Products.First(p => p.Barcode == "apple").Price == 0.75m);
            Assert.True(sut.Products.First(p => p.Barcode == "banana").Price == 1.00m);
        }
    }
}
