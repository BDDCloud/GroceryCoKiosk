﻿using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class CartSteps: BaseSteps
    {
        [Given("my cart is empty")]
        public void MyCartIsEmpty()
        {
            base.Cart = new Cart();
        }
    }
}
