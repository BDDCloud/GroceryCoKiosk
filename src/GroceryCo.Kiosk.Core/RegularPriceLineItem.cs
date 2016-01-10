using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core
{
    public class RegularPriceLineItem
    {
        private readonly ProductCatalog _productCatalog;

        public RegularPriceLineItem(string barcode, int quantity, ProductCatalog productCatalog)
        {
            _productCatalog = productCatalog;
            Barcode = barcode;
            Quantity = quantity;
            Note = "";
            CalculatePriceAndSubTotal();
        }

        private void CalculatePriceAndSubTotal()
        {
            Price = _productCatalog.Products.Single(p => p.Barcode == Barcode).Price;
            SubTotal = Price * Quantity;
            DiscountedSubTotal = SubTotal;
            DiscountedSubTotal = CalculateQuantityDiscount();
            DiscountedSubTotal = CalculateAdditionalItemDiscount();
        }

        private decimal CalculateQuantityDiscount()
        {
            var discount = _productCatalog.QuantityDiscounts.SingleOrDefault(d => d.Barcode == Barcode);
            var hasDiscount = discount != null;
            var price = DiscountedSubTotal;
            if (hasDiscount)
            {
                var applicableQuantity = Quantity/discount.DiscountQuantity;
                price = applicableQuantity*discount.DiscountPrice + (Quantity - applicableQuantity * discount.DiscountQuantity)*Price;
                Note = $"***Discount on {Barcode}: Buy {discount.DiscountQuantity} {Barcode} for {discount.DiscountPrice:C2}, New Price {price:C2}, Savings {(SubTotal - price):C2}";
            }

            return price;
        }

        private decimal CalculateAdditionalItemDiscount()
        {
            var discount = _productCatalog.AdditionalItemDiscounts.SingleOrDefault(d => d.Barcode == Barcode);
            var hasDiscount = discount != null;
            var price = DiscountedSubTotal;
            if (hasDiscount)
            {
                var discountPriceCount = Quantity / (discount.QuantityFullPrice + discount.QuantityDiscounted) * discount.QuantityDiscounted;
                price = Quantity*Price - discountPriceCount*(decimal) discount.DiscountPercentage/100m*Price;
                Note = $"***Discount on apple: Buy {discount.QuantityFullPrice} {Barcode} get {discount.QuantityDiscounted} at {(Price * (100m - (decimal)discount.DiscountPercentage) / 100m):C2}, New Price {price:C2}, Savings {(SubTotal - price):C2}";
            }

            return price;
        }

        public string Barcode { get; }
        public string Note { get; private set; }
        public int Quantity { get; }
        public decimal SubTotal { get; private set; }
        public decimal DiscountedSubTotal { get; private set; }
        public decimal Price { get; private set; }
    }
}
