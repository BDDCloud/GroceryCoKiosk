using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Kiosk.Core.PromotionRules;

namespace GroceryCo.Kiosk.Core
{
    public class Promotions
    {
        private readonly IEnumerable<IPromotionalDiscountRule> _promotionalDiscountRules;

        public Promotions(IEnumerable<IPromotionalDiscountRule> promotionalDiscountRules)
        {
            _promotionalDiscountRules = promotionalDiscountRules;
        }

        public PromotionalDiscount CalculatePromotionalCost(LineItem lineItem)
        {
            var applicableDiscountRule = _promotionalDiscountRules.SingleOrDefault(r => r.PromotionApplies(lineItem));
            if (applicableDiscountRule == null)
            {
                return new PromotionalDiscount(lineItem.SubTotal, "");
            }

            return applicableDiscountRule.Calculate(lineItem);
        }
    }
}
