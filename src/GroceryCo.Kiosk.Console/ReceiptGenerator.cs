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
                receipt += AddQuantityDiscountLineItem(transaction, barcode);
                receipt += AddRegularPriceLineItem(transaction, barcode);
            }

            receipt += $"Total is {transaction.Bill.Total:C2}";

            return receipt;
        }

        private string AddRegularPriceLineItem(CheckoutTransaction transaction, string barcode)
        {
            var lineItem = transaction.Bill.RegularPricedLineItems.SingleOrDefault(i => i.Barcode == barcode);
            var output = "";
            if (lineItem != null)
            {
                var note = lineItem.Note + (string.IsNullOrEmpty(lineItem.Note) ? "" : "\n"); 
                output = $"{lineItem.Quantity} {lineItem.Barcode} @ {lineItem.Price:C2} is {lineItem.SubTotal:C2}\n{note}";
            }
            return output;
        }

        private string AddQuantityDiscountLineItem(CheckoutTransaction transaction, string barcode)
        {
            var lineItem = transaction.Bill.QuantityDiscountLineItems.SingleOrDefault(i => i.Barcode == barcode);
            var output = "";
            if (lineItem != null)
            {
                output = $"{lineItem.Quantity} {lineItem.Barcode} for {lineItem.DiscountQuantity} @ {lineItem.DiscountPrice:C2} is {lineItem.SubTotal:C2}\n";
            }
            return output;
        }
    }
}