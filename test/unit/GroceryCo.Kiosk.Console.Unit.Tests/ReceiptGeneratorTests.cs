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
        public void When_I_generate_a_receipt()
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
    }
}
