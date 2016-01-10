using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Core
{
    public class CheckoutTransaction
    {
        private ProductCatalog _productCatalog;
        private IList<string> _items; 

        public CheckoutTransaction(ProductCatalog productCatalog)
        {
            this._productCatalog = productCatalog;
            _items = new List<string>();
            this.Bill = new Bill(_items, _productCatalog);
        }

        public Bill Bill { get; private set; }
        public IEnumerable<string> Items => _items;

        public void AddItem(string barcode)
        {
            _items.Add(barcode);
            Bill = new Bill(_items, _productCatalog);
        }
    }
}
