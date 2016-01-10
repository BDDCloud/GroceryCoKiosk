using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core
{
    public class ProductSummaryLineItem
    {
        private readonly ProductCatalog _productCatalog;

        public ProductSummaryLineItem(string barcode, int quantity, ProductCatalog productCatalog)
        {
            _productCatalog = productCatalog;
            Barcode = barcode;
            Quantity = quantity;
            CalculatePriceAndSubTotal();
        }

        private void CalculatePriceAndSubTotal()
        {
            Price = _productCatalog.Products.Single(p => p.Barcode == Barcode).Price;
            SubTotal = Price * Quantity;
        }

        public string Barcode { get; }
        public int Quantity { get; }
        public decimal SubTotal { get; private set; }
        public decimal Price { get; private set; }
    }
}
