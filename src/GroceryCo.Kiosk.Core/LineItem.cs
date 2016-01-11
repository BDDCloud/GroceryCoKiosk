using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core
{
    public class LineItem
    {
        private readonly ProductCatalog _productCatalog;
        private readonly Promotions _promotions;

        public LineItem(string barcode, int quantity, ProductCatalog productCatalog, Promotions promotions)
        {
            _productCatalog = productCatalog;
            _promotions = promotions;
            Barcode = barcode;
            Quantity = quantity;
            DiscountNote = "";
            CalculatePriceAndSubTotal();
        }

        private void CalculatePriceAndSubTotal()
        {
            PricePerUnit = _productCatalog.Products.Single(p => p.Barcode == Barcode).Price;
            SubTotal = PricePerUnit * Quantity;
            var result = _promotions.CalculatePromotionalCost(this);
            DiscountedSubTotal = result.DiscountedSubTotal;
            DiscountNote = result.DiscountNote;
        }

        public string Barcode { get; }
        public string DiscountNote { get; private set; }
        public int Quantity { get; }
        public decimal SubTotal { get; private set; }
        public decimal DiscountedSubTotal { get; private set; }
        public decimal PricePerUnit { get; private set; }
    }
}
