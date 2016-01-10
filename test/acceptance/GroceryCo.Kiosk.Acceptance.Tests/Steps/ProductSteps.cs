using System;
using System.Collections.Generic;
using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class ProductSteps : BaseSteps
    {
        [Given("I have no prices in the system")]
        public void HaveNoPricesInTheSystem()
        {
            Products = new List<Product>();  
        }

        [Given("I have the following products")]
        public void HaveTheFollowingProducts(Table products)
        {
            Products = new List<Product>();
            foreach (var row in products.Rows)
            {
                var product = new Product() { Barcode = row[0], Price = decimal.Parse(row[1]) };
                Products.Add(product);
            }
        }
    }
}
