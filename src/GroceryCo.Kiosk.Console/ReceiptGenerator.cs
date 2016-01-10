using System;
using GroceryCo.Kiosk.Core;

namespace GroceryCo.Kiosk.Console
{
    public class ReceiptGenerator
    {
        public string Generate(CheckoutTransaction transaction)
        {
            var receipt = "Receipt:\n";

            foreach (var lineItem in transaction.Bill.LineItems)
            {
                receipt += $"{lineItem.Quantity} {lineItem.Barcode} @ {lineItem.Price:C2} is {lineItem.SubTotal:C2}\n";
            }

            receipt += $"Total is {transaction.Bill.Total:C2}";

            return receipt;
        }
    }
}