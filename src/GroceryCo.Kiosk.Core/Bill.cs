using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class Bill
    {
        private readonly IList<string> _items;
        private readonly ProductCatalog _productCatalog;
        private readonly Promotions _promotions;
        private List<LineItem> _lineItems;

        public Bill(IList<string> items, ProductCatalog productCatalog, Promotions promotions)
        {
            _items = items;
            _productCatalog = productCatalog;
            _promotions = promotions;
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
            _lineItems = new List<LineItem>();    
            foreach (var itemQuantity in _items.GroupBy(i => i, i => i, (k, j) => new Tuple<string, int>(k, j.Count())))
            {
                _lineItems.Add(new LineItem(itemQuantity.Item1, itemQuantity.Item2, _productCatalog, _promotions));   
            }
        }

        public IEnumerable<LineItem> LineItems => _lineItems;
        public decimal Total { get; private set; }
    }
}