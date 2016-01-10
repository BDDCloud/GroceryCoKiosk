namespace GroceryCo.Kiosk.Core
{
    public class Product
    {
        public Product(string barcode, decimal price)
        {
            Barcode = barcode;
            Price = price;
        }

        public string Barcode { get; private set; }
        public decimal Price { get; private set; }
    }

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