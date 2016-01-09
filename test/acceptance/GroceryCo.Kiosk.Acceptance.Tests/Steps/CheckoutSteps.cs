using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class CheckoutSteps
    {
        [When("I checkout")]
        public void WhenICheckout()
        {
            ScenarioContext.Current.Pending();
        }

        [Then("I should be told my cart is empty")]
        public void ShouldBeToldMyCartIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
