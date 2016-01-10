using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Kiosk.Core;
using NUnit.Framework;

namespace GroceryCo.Kiosk.Console.Unit.Tests
{
    [TestFixture]
    public class ReceiptGeneratorTests
    {
        [Test]
        public void When_I_generate_a_receipt_with_regular_prices()
        {
            var sut = new ReceiptGenerator();
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            var transaction = new CheckoutTransaction(productCatalog);
            transaction.AddItem("apple");
            transaction.AddItem("banana");
            transaction.AddItem("apple");

            var actual = sut.Generate(transaction);

            Assert.That(actual, Is.EqualTo("Receipt:\n2 apple @ $0.75 is $1.50\n1 banana @ $1.00 is $1.00\nTotal is $2.50"));
        }

        [Test]
        public void When_I_generate_a_receipt_with_quantity_discount()
        {
            var sut = new ReceiptGenerator();
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddQuantityDiscount("apple", 3, 2.00m);
            var transaction = new CheckoutTransaction(productCatalog);
            transaction.AddItem("apple");
            transaction.AddItem("banana");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");

            var actual = sut.Generate(transaction);
            Assert.That(actual, Is.EqualTo("Receipt:\n6 apple for 3 @ $2.00 is $4.00\n1 apple @ $0.75 is $0.75\n1 banana @ $1.00 is $1.00\nTotal is $5.75"));
        }
    }
}
