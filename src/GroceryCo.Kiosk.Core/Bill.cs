using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class Bill
    {
        private readonly IList<string> _items;
        private readonly ProductCatalog _productCatalog;
        private List<RegularPriceLineItem> _lineItems;

        public Bill(IList<string> items, ProductCatalog productCatalog)
        {
            _items = items;
            _productCatalog = productCatalog;
            CalculateBill();
        }

        private void CalculateBill()
        {
            CreateLineItems();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = LineItems.Sum(l => l.DiscountedSubTotal);
        }

        private void CreateLineItems()
        {
            _lineItems = new List<RegularPriceLineItem>();    
            foreach (var itemQuantity in _items.GroupBy(i => i, i => i, (k, j) => new Tuple<string, int>(k, j.Count())))
            {
                _lineItems.Add(new RegularPriceLineItem(itemQuantity.Item1, itemQuantity.Item2, _productCatalog));   
            }
        }

        public IEnumerable<RegularPriceLineItem> LineItems => _lineItems;
        public decimal Total { get; private set; }
    }
}