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
            Assert.That(actual, Is.EqualTo("Receipt:\n7 apple @ $0.75 is $5.25\n***Discount on apple: Buy 3 apple for $2.00, New Price $4.75, Savings $0.50\n1 banana @ $1.00 is $1.00\nTotal is $5.75"));
        }

        [Test]
        public void When_I_generate_a_receipt_with_additional_item_discount()
        {
            var sut = new ReceiptGenerator();
            var productCatalog = new ProductCatalog();
            productCatalog.AddProduct("apple", 0.75m);
            productCatalog.AddProduct("banana", 1.00m);
            productCatalog.AddAdditionalItemDiscount("apple", 1, 1, 100);
            var transaction = new CheckoutTransaction(productCatalog);
            transaction.AddItem("apple");
            transaction.AddItem("banana");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");
            transaction.AddItem("apple");

            var actual = sut.Generate(transaction);
            Assert.That(actual, Is.EqualTo("Receipt:\n5 apple @ $0.75 is $3.75\n***Discount on apple: Buy 1 apple get 1 at $0.00, New Price $2.25, Savings $1.50\n1 banana @ $1.00 is $1.00\nTotal is $3.25"));
        }
    }
}
