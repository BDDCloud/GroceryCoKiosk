using System.Collections.Generic;
using System.Linq;
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
        public void When_constructed_with_some_items()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var sut = new Bill(new List<string>() { "apple", "banana", "apple" }, productCatalog);

            Assert.That(sut.Total, Is.EqualTo(2.50m));
            Assert.That(sut.RegularPricedLineItems.Count(), Is.EqualTo(2));
            Assert.That(sut.RegularPricedLineItems.ElementAt(0).Barcode, Is.EqualTo("apple"));
            Assert.That(sut.RegularPricedLineItems.ElementAt(0).SubTotal, Is.EqualTo(1.50m));
            Assert.That(sut.RegularPricedLineItems.ElementAt(1).Barcode, Is.EqualTo("banana"));
            Assert.That(sut.RegularPricedLineItems.ElementAt(1).SubTotal, Is.EqualTo(1.00m));
        }

        [Test]
        public void When_constructed_with_applicable_quantity_discount()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddQuantityDiscount("apple", 2, 2.00m);
            var sut = new Bill(new List<string>() { "apple", "banana", "apple", "apple", "apple", "apple" }, productCatalog);

            Assert.That(sut.Total, Is.EqualTo(5.75m));
            Assert.That(sut.RegularPricedLineItems.Count(), Is.EqualTo(2));
            Assert.That(sut.QuantityDiscountLineItems.Count(), Is.EqualTo(1));
        }

        [Test]
        public void When_constructed_with_applicable_quantity_discount_but_no_matching_items()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddQuantityDiscount("apple", 2, 2.00m);
            var sut = new Bill(new List<string>() { "banana" }, productCatalog);

            Assert.That(sut.Total, Is.EqualTo(1.00m));
            Assert.That(sut.RegularPricedLineItems.Count(), Is.EqualTo(1));
            Assert.That(sut.QuantityDiscountLineItems.Count(), Is.EqualTo(0));
        }

        [Test]
        public void When_constructed_with_applicable_additional_item_discount()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddAdditionalItemDiscount("apple", 1, 1, 100);
            var sut = new Bill(new List<string>() { "apple", "banana", "apple", "apple", "apple", "apple" }, productCatalog);

            Assert.That(sut.Total, Is.EqualTo(3.25m));
            Assert.That(sut.RegularPricedLineItems.Count(), Is.EqualTo(2));
            Assert.That(sut.RegularPricedLineItems.ElementAt(0).Price, Is.EqualTo(0.75m));
            Assert.That(sut.RegularPricedLineItems.ElementAt(0).Note, Is.EqualTo("***Discount on apple: Buy 1 apple get 1 at $0.00, New Price $2.25, Savings $1.50"));
        }
    }
}
