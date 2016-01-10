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

        [Test]
        public void When_quantity_discount_is_added()
        {
            var sut = new ProductCatalog();

            sut.AddQuantityDiscount("apple", 3, 2.00m);

            Assert.That(sut.QuantityDiscounts.Count(), Is.EqualTo(1));
            Assert.True(sut.QuantityDiscounts.First(p => p.Barcode == "apple").DiscountPrice == 2.00m);
            Assert.True(sut.QuantityDiscounts.First(p => p.Barcode == "apple").DiscountQuantity == 3.00m);
        }

        [Test]
        public void When_additional_item_discount_is_added()
        {
            var sut = new ProductCatalog();

            sut.AddAdditionalItemDiscount("apple", 3, 2, 100);

            Assert.That(sut.QuantityDiscounts.Count(), Is.EqualTo(0));
            Assert.That(sut.AdditionalItemDiscounts.Count(), Is.EqualTo(1));
            Assert.True(sut.AdditionalItemDiscounts.First(p => p.Barcode == "apple").QuantityFullPrice == 3);
            Assert.True(sut.AdditionalItemDiscounts.First(p => p.Barcode == "apple").QuantityDiscounted == 2.00);
        }
    }
}
