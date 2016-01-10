using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Core.Unit.Tests
{
    [TestFixture]
    public class CheckoutTransactionTests
    {
        [Test]
        public void When_checkout_transaction_is_created()
        {
            var productCatalog = new ProductCatalog();
            var sut = new CheckoutTransaction(productCatalog);

            Assert.That(sut.Bill.Total, Is.EqualTo(0));
        }

        [Test]
        public void When_add_some_items()
        {
            var expected = new List<string>() { "apple", "banana", "apple" };
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var sut = new CheckoutTransaction(productCatalog);
            sut.AddItem("apple");
            sut.AddItem("banana");
            sut.AddItem("apple");

            Assert.That(sut.Bill.Total, Is.EqualTo(2.50m));
            CollectionAssert.AreEquivalent(expected, sut.Items);
        }
    }
}
