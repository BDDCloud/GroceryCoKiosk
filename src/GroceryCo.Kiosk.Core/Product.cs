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
}