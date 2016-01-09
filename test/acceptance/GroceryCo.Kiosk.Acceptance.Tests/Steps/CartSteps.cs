using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class CartSteps
    {
        [Given("my cart is empty")]
        public void MyCartIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
