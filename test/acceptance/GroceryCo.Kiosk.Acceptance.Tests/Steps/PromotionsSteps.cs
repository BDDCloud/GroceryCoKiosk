using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class PromotionsSteps
    {
        [Given("I have no promotions in the system")]
        public void NoPromotionsInTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
