using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core.PromotionRules
{
    public class QuantityDiscountRule : IPromotionalDiscountRule
    {
        private readonly ProductCatalog _productCatalog;

        public QuantityDiscountRule(ProductCatalog productCatalog)
        {
            _productCatalog = productCatalog;
        }
        
        public PromotionalDiscount Calculate(LineItem lineItem)
        {
            var discount = GetCurrentDiscount(lineItem);
            var hasDiscount = PromotionApplies(lineItem);
            var discountedSubTotal = lineItem.SubTotal;
            var discountNote = "";
            if (hasDiscount)
            {
                var applicableQuantity = lineItem.Quantity / discount.DiscountQuantity;
                discountedSubTotal = applicableQuantity * discount.DiscountPrice + (lineItem.Quantity - applicableQuantity * discount.DiscountQuantity) * lineItem.PricePerUnit;
                discountNote = $"***Discount on {lineItem.Barcode}: Buy {discount.DiscountQuantity} {lineItem.Barcode} for {discount.DiscountPrice:C2}, New Price {discountedSubTotal:C2}, Savings {(lineItem.SubTotal - discountedSubTotal):C2}";
            }

            var promotionalDiscount = new PromotionalDiscount(discountedSubTotal, discountNote);
            return promotionalDiscount;
        }

        public bool PromotionApplies(LineItem lineItem)
        {
            var discount = GetCurrentDiscount(lineItem);
            var hasDiscount = discount != null;
            return hasDiscount;
        }

        private QuantityDiscount GetCurrentDiscount(LineItem lineItem)
        {
            var discount = _productCatalog.QuantityDiscounts.SingleOrDefault(d => d.Barcode == lineItem.Barcode);
            return discount;
        }
    }
}
