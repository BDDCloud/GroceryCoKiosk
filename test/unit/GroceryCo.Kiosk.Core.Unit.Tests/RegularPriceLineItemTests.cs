using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class RegularPriceLineItemTests
    {
        [Test]
        public void When_constructed()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var sut = new RegularPriceLineItem("apple", 2, productCatalog);

            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.Quantity, Is.EqualTo(2));
            Assert.That(sut.Price, Is.EqualTo(0.75m));
            Assert.That(sut.SubTotal, Is.EqualTo(1.50m));
            Assert.That(sut.Note, Is.EqualTo(""));
        }

        [Test]
        public void When_constructed_with_additional_item_discount()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddAdditionalItemDiscount("apple", 1, 1, 100);
            var sut = new RegularPriceLineItem("apple", 5, productCatalog);

            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.Quantity, Is.EqualTo(5));
            Assert.That(sut.Price, Is.EqualTo(0.75m));
            Assert.That(sut.SubTotal, Is.EqualTo(3.75m));
            Assert.That(sut.DiscountedSubTotal, Is.EqualTo(2.25m));
            Assert.That(sut.Note, Is.EqualTo("***Discount on apple: Buy 1 apple get 1 at $0.00, New Price $2.25, Savings $1.50"));
        }

        [Test]
        public void When_constructed_with_quantity_discount()
        {
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddQuantityDiscount("apple", 3, 2.00m);
            var sut = new RegularPriceLineItem("apple", 7, productCatalog);

            Assert.That(sut.Barcode, Is.EqualTo("apple"));
            Assert.That(sut.Quantity, Is.EqualTo(7));
            Assert.That(sut.Price, Is.EqualTo(0.75m));
            Assert.That(sut.SubTotal, Is.EqualTo(5.25m));
            Assert.That(sut.DiscountedSubTotal, Is.EqualTo(4.75m));
            Assert.That(sut.Note, Is.EqualTo("***Discount on apple: Buy 3 apple for $2.00, New Price $4.75, Savings $0.50"));
        }
    }
}
