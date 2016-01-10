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
