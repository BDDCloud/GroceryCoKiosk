using System.Collections.Generic;
using System.Linq;

namespace GroceryCo.Kiosk.Core
{
    public class Bill
    {
        private readonly IList<string> _items;
        private readonly ProductCatalog _productCatalog;

        public Bill(IList<string> items, ProductCatalog productCatalog)
        {
            _items = items;
            _productCatalog = productCatalog;
            CalculateBill();
        }

        private void CalculateBill()
        {
            LineItems = _items.GroupBy(i => i, i => i, (k, j) => new ProductSummaryLineItem(k, j.Count(), _productCatalog));
            Total = LineItems.Sum(l => l.Quantity*_productCatalog.Products.Single(p => p.Barcode == l.Barcode).Price);
        }

        public IEnumerable<ProductSummaryLineItem> LineItems { get; private set; }

        public decimal Total { get; private set; }
    }
}