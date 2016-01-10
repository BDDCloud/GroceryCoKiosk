using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class ProductCatalog
    {
        private readonly List<Product> _products;
        private List<QuantityDiscount> _quantityDiscounts;

        public ProductCatalog()
        {
            _products = new List<Product>();
            _quantityDiscounts = new List<QuantityDiscount>();
        }

        public void AddProduct(string barcode, decimal price)
        {
            _products.Add(new Product(barcode, price));
        }

        public IEnumerable<Product> Products => _products;

        public IEnumerable<QuantityDiscount> QuantityDiscounts => _quantityDiscounts;

        public void AddQuantityDiscount(string barcode, int quantity, decimal discountPrice)
        {
            _quantityDiscounts.Add(new QuantityDiscount(barcode, quantity, discountPrice));
        }
    }
}