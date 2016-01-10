using System.Collections.Generic;
using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class PromotionsSteps : BaseSteps
    {
        [Given("I have no promotions in the system")]
        public void NoPromotionsInTheSystem()
        {
            base.QuantityPromotions = new List<QuantityPromotion>();
            base.AdditionalItemPromotions = new List<AdditionalItemPromotion>();
        }
    }
}
