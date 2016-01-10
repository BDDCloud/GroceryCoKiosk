using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core
{
    public class QuantityDiscountLineItem
    {
        private readonly ProductCatalog _productCatalog;

        public QuantityDiscountLineItem(string barcode, int quantity, ProductCatalog productCatalog)
        {
            _productCatalog = productCatalog;
            Barcode = barcode;
            Quantity = quantity;
            Calculate();
        }

        private void Calculate()
        {
            DiscountPrice = _productCatalog.QuantityDiscounts.Single(p => p.Barcode == Barcode).DiscountPrice;
            DiscountQuantity = _productCatalog.QuantityDiscounts.Single(p => p.Barcode == Barcode).DiscountQuantity;
            SubTotal = Quantity / DiscountQuantity * DiscountPrice;
        }

        public string Barcode { get; }
        public int Quantity { get; }
        public decimal SubTotal { get; private set; }
        public decimal DiscountPrice { get; private set; }
        public int DiscountQuantity { get; private set; }
    }
}
