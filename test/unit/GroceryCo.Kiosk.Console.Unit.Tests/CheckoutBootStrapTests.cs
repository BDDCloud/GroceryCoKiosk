using System.Collections.Generic;
using System.Xml;
using Moq;
using NUnit.Framework;


namespace GroceryCo.Kiosk.Console.Unit.Tests
{
    [TestFixture]
    public class CheckoutBootStrapTests
    {
        [Test]
        public void When_no_items_in_cart()
        {
            var consoleWriter = new Mock<IConsoleWriter>();
            var sut = new CheckoutBootStrap(new List<string>(), new List<string>(), consoleWriter.Object);

            sut.Begin();

            consoleWriter.Verify(w => w.WriteLine("Error cart is empty"));
        }

        [Test]
        public void When_items_in_cart_and_product_catalog()
        {
            var consoleWriter = new MockConsoleWriter();
            var cartData = new List<string>() { "apple", "banana", "apple" };
            var productCatalogData = new List<string>() { "PRODUCT, apple, 0.75", "PRODUCT, banana, 1.00"};
            var sut = new CheckoutBootStrap(cartData, productCatalogData, consoleWriter);

            sut.Begin();

            Assert.That(consoleWriter.Output, Is.EqualTo("Receipt:\n2 apple @ $0.75 is $1.50\n1 banana @ $1.00 is $1.00\nTotal is $2.50"));
        }

        [Test]
        public void When_items_in_cart_and_product_catalog_with_quantity_discount()
        {
            var consoleWriter = new MockConsoleWriter();
            var cartData = new List<string>() { "apple", "banana", "apple", "apple", "apple", "apple", "apple", "apple" };
            var productCatalogData = new List<string>() { "PRODUCT, apple, 0.75", "PRODUCT, banana, 1.00", "QUANTITY_DISCOUNT, apple, 3, 2.00"};
            var sut = new CheckoutBootStrap(cartData, productCatalogData, consoleWriter);

            sut.Begin();

            Assert.That(consoleWriter.Output, Is.EqualTo("Receipt:\n6 apple for 3 @ $2.00 is $4.00\n1 apple @ $0.75 is $0.75\n1 banana @ $1.00 is $1.00\nTotal is $5.75"));
        }

        [Test]
        public void When_items_in_cart_and_product_catalog_with_additional_item_discount()
        {
            var consoleWriter = new MockConsoleWriter();
            var cartData = new List<string>() { "apple", "banana", "apple", "apple", "apple", "apple" };
            var productCatalogData = new List<string>() { "PRODUCT, apple, 0.75", "PRODUCT, banana, 1.00", "ADDITIONAL_ITEM_DISCOUNT, apple, 1, 1, 100" };
            var sut = new CheckoutBootStrap(cartData, productCatalogData, consoleWriter);

            sut.Begin();
            Assert.That(consoleWriter.Output, Is.EqualTo("Receipt:\n5 apple @ $0.75 is $3.75\n***Discount on apple: Buy 1 apple get 1 at $0.00, New Price $2.25, Savings $1.50\n1 banana @ $1.00 is $1.00\nTotal is $3.25"));
        }

        public class MockConsoleWriter : IConsoleWriter
        {
            public void WriteLine(string line)
            {
                Output += line;
            }

            public string Output { get; set; }
        }
    }
}
