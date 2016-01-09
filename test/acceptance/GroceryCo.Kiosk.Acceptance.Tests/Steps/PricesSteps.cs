using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class PricesSteps
    {
        [Given("I have no prices in the system")]
        public void HaveNoPricesInTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
