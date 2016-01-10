using System;
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

        [Given("I have no additional item promotions in the system")]
        public void NoAdditionalItemPromotionsInTheSystem()
        {
            base.AdditionalItemPromotions = new List<AdditionalItemPromotion>();
        }

        [Given("I have quantity discounts")]
        public void HaveQuantityDiscounts(Table discounts)
        {
            base.QuantityPromotions = new List<QuantityPromotion>();
            foreach (var row in discounts.Rows)
            {
                QuantityPromotions.Add(new QuantityPromotion() { Barcode = row[0], DiscountQuantity = int.Parse(row[1]), DiscountPrice = Decimal.Parse(row[2]) });
            }
        }
    }
}
