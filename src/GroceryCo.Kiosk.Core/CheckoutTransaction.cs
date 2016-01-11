using System.Collections.Generic;

namespace GroceryCo.Kiosk.Core
{
    public class CheckoutTransaction
    {
        private ProductCatalog _productCatalog;
        private readonly Promotions _promotions;
        private IList<string> _items; 

        public CheckoutTransaction(ProductCatalog productCatalog, Promotions promotions)
        {
            this._productCatalog = productCatalog;
            _promotions = promotions;
            _items = new List<string>();
            this.Bill = new Bill(_items, _productCatalog, _promotions);
        }

        public Bill Bill { get; private set; }
        public IEnumerable<string> Items => _items;

        public void AddItem(string barcode)
        {
            _items.Add(barcode);
            Bill = new Bill(_items, _productCatalog, _promotions);
        }
    }
}
