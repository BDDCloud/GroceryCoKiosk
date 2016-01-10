using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class ProductCatalog
    {
        private readonly List<Product> _products;

        public ProductCatalog()
        {
            _products = new List<Product>();
        }

        public void AddProduct(string barcode, decimal price)
        {
            _products.Add(new Product(barcode, price));
        }

        public IEnumerable<Product> Products => _products;
    }
}