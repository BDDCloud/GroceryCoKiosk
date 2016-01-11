namespace GroceryCo.Kiosk.Core
{
    public class PromotionalDiscount
    {
        public PromotionalDiscount(decimal discountedSubTotal, string discountNote)
        {
            DiscountedSubTotal = discountedSubTotal;
            DiscountNote = discountNote;
        }

        public decimal DiscountedSubTotal { get; private set; }
        public string DiscountNote { get; private set; }
    }
}