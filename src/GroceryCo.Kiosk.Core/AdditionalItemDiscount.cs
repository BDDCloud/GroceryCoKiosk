namespace GroceryCo.Kiosk.Core
{
    public class AdditionalItemDiscount
    {
        public AdditionalItemDiscount(string barcode, int quantityFullPrice, int quantityDiscounted, double discountPercentage)
        {
            Barcode = barcode;
            QuantityFullPrice = quantityFullPrice;
            QuantityDiscounted = quantityDiscounted;
            DiscountPercentage = discountPercentage;
        }

        public string Barcode { get; }
        public int QuantityFullPrice { get; }
        public int QuantityDiscounted { get; }
        public double DiscountPercentage { get; }
    }
}