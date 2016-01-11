using System.Linq;

namespace GroceryCo.Kiosk.Core.PromotionRules
{
    public class AdditionalItemDiscountRule : IPromotionalDiscountRule
    {
        private readonly ProductCatalog _productCatalog;

        public AdditionalItemDiscountRule(ProductCatalog productCatalog)
        {
            _productCatalog = productCatalog;
        }

        public PromotionalDiscount Calculate(LineItem lineItem)
        {
            var discount = GetCurrentDiscount(lineItem);
            var hasDiscount = discount != null;
            var discountedSubTotal = lineItem.DiscountedSubTotal;
            var note = "";
            if (hasDiscount)
            {
                var discountPriceCount = lineItem.Quantity / (discount.QuantityFullPrice + discount.QuantityDiscounted) * discount.QuantityDiscounted;
                discountedSubTotal = lineItem.Quantity * lineItem.PricePerUnit - discountPriceCount * (decimal)discount.DiscountPercentage / 100m * lineItem.PricePerUnit;
                note = $"***Discount on apple: Buy {discount.QuantityFullPrice} {lineItem.Barcode} get {discount.QuantityDiscounted} at {(lineItem.PricePerUnit * (100m - (decimal)discount.DiscountPercentage) / 100m):C2}, New Price {discountedSubTotal:C2}, Savings {(lineItem.SubTotal - discountedSubTotal):C2}";
            }

            var promotionalDiscount = new PromotionalDiscount(discountedSubTotal, note);
            return promotionalDiscount;
        }

        public bool PromotionApplies(LineItem lineItem)
        {
            var discount = GetCurrentDiscount(lineItem);
            var hasDiscount = discount != null;
            return hasDiscount;       
        }

        private AdditionalItemDiscount GetCurrentDiscount(LineItem lineItem)
        {
            var discount = _productCatalog.AdditionalItemDiscounts.SingleOrDefault(d => d.Barcode == lineItem.Barcode);
            return discount;
        }
    }
}