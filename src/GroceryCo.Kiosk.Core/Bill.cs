using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class Bill
    {
        private readonly IList<string> _items;
        private readonly ProductCatalog _productCatalog;
        private IDictionary<string, int> _itemQuantities;
        private List<QuantityDiscountLineItem> _quantityDiscounts;
        private List<RegularPriceLineItem> _regularPricedLineItems;

        public Bill(IList<string> items, ProductCatalog productCatalog)
        {
            _items = items;
            _productCatalog = productCatalog;
            CalculateBill();
        }

        private void CalculateBill()
        {
            SetupItemQuantities();
            ApplyQuantityDiscount();
            ApplyRegularPrice();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = RegularPricedLineItems.Sum(l => l.SubTotal) + QuantityDiscountLineItems.Sum(l => l.SubTotal);
        }

        private void SetupItemQuantities()
        {
            _itemQuantities = new Dictionary<string, int>();
            var itemQuantities = _items.GroupBy(i => i, i => i, (k, j) => new Tuple<string, int>(k, j.Count()));
            foreach (var itemQuantity in itemQuantities)
            {
                _itemQuantities.Add(itemQuantity.Item1, itemQuantity.Item2);
            }
        }

        private void ApplyRegularPrice()
        {
            _regularPricedLineItems = new List<RegularPriceLineItem>();    
            foreach (var itemQuantity in _itemQuantities)
            {
                if (itemQuantity.Value > 0)
                {
                    _regularPricedLineItems.Add(new RegularPriceLineItem(itemQuantity.Key, itemQuantity.Value, _productCatalog));
                }
            }
        }

        private void ApplyQuantityDiscount()
        {
            _quantityDiscounts = new List<QuantityDiscountLineItem>();
            foreach (var quantityDiscount in _productCatalog.QuantityDiscounts.Where(d => _itemQuantities.ContainsKey(d.Barcode)))
            {
                var quantity = _itemQuantities[quantityDiscount.Barcode];
                var applicableDiscounts = quantity / quantityDiscount.DiscountQuantity;
                var applicableQuantity = applicableDiscounts * quantityDiscount.DiscountQuantity;
                _itemQuantities[quantityDiscount.Barcode] = quantity - applicableQuantity;
                if (applicableDiscounts > 0)
                {
                   _quantityDiscounts.Add(new QuantityDiscountLineItem(quantityDiscount.Barcode, applicableQuantity, _productCatalog));
                }
            }
        }

        public IEnumerable<RegularPriceLineItem> RegularPricedLineItems => _regularPricedLineItems;

        public decimal Total { get; private set; }
        public IEnumerable<QuantityDiscountLineItem> QuantityDiscountLineItems => _quantityDiscounts;
    }
}