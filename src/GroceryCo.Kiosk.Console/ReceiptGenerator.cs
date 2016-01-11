using System;
using System.Linq;
using GroceryCo.Kiosk.Core;

namespace GroceryCo.Kiosk.Console
{
    public class ReceiptGenerator
    {
        public string Generate(CheckoutTransaction transaction)
        {
            var receipt = "Receipt:\n";

            foreach (var barcode in transaction.Items.GroupBy(i => i, i => i, (k, j) => k))
            {
                receipt += AddRegularPriceLineItem(transaction, barcode);
            }

            receipt += $"Total is {transaction.Bill.Total:C2}";

            return receipt;
        }

        private string AddRegularPriceLineItem(CheckoutTransaction transaction, string barcode)
        {
            var lineItem = transaction.Bill.LineItems.SingleOrDefault(i => i.Barcode == barcode);
            var output = "";
            if (lineItem != null)
            {
                var note = lineItem.DiscountNote + (string.IsNullOrEmpty(lineItem.DiscountNote) ? "" : "\n"); 
                output = $"{lineItem.Quantity} {lineItem.Barcode} @ {lineItem.PricePerUnit:C2} is {lineItem.SubTotal:C2}\n{note}";
            }
            return output;
        }
    }
}