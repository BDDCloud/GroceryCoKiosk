using System;
using System.Collections.Generic;
using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class PricesSteps : BaseSteps
    {
        [Given("I have no prices in the system")]
        public void HaveNoPricesInTheSystem()
        {
            Products = new List<Product>();  
        }
    }
}
