namespace GroceryCo.Kiosk.Core
{
    public class QuantityDiscount
    {
        public QuantityDiscount(string barcode, int discountQuantity, decimal discountPrice)
        {
            Barcode = barcode;
            DiscountQuantity = discountQuantity;
            DiscountPrice = discountPrice;
        }

        public string Barcode { get; }
        public int DiscountQuantity { get; }
        public decimal DiscountPrice { get; }
    }
}