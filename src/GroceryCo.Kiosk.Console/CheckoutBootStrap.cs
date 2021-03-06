﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GroceryCo.Kiosk.Core;
using GroceryCo.Kiosk.Core.PromotionRules;

namespace GroceryCo.Kiosk.Console
{
    public class CheckoutBootStrap
    {
        private readonly IEnumerable<string> _cartData;
        private readonly IEnumerable<string> _productCatalogData;
        private readonly IConsoleWriter _consoleWriter;

        public CheckoutBootStrap(IEnumerable<string> cartData, IEnumerable<string> productCatalogData, IConsoleWriter consoleWriter)
        {
            _cartData = cartData;
            _productCatalogData = productCatalogData;
            _consoleWriter = consoleWriter;
        }

        public void Begin()
        {
            if (!_cartData.Any())
            {
                _consoleWriter.WriteLine("Error cart is empty");
                return;
            }

            var productCatalog = new ProductCatalog();
            foreach (var productCatalogLine in _productCatalogData)
            {
                var parts = productCatalogLine.Split(',');
                if (parts[0] == "PRODUCT")
                {
                    var barcode = parts[1].Trim();
                    var price = Decimal.Parse(parts[2]);
                    productCatalog.AddProduct(barcode, price);
                }
                else if (parts[0] == "QUANTITY_DISCOUNT")
                {
                    var barcode = parts[1].Trim();
                    var quantity = Convert.ToInt32(parts[2]);
                    var discountPrice = Convert.ToDecimal(parts[3]);
                    productCatalog.AddQuantityDiscount(barcode, quantity, discountPrice);
                }
                else if (parts[0] == "ADDITIONAL_ITEM_DISCOUNT")
                {
                    var barcode = parts[1].Trim();
                    var quantity = Convert.ToInt32(parts[2]);
                    var quantityDiscounted = Convert.ToInt32(parts[3]);
                    var dicountPercentage = Convert.ToDouble(parts[4]);
                    productCatalog.AddAdditionalItemDiscount(barcode, quantity, quantityDiscounted, dicountPercentage);
                }
            }

            var promotionalDiscountRules = new List<IPromotionalDiscountRule>() { new AdditionalItemDiscountRule(productCatalog), new QuantityDiscountRule(productCatalog) };
            var transaction = new CheckoutTransaction(productCatalog, new Promotions(promotionalDiscountRules));
            foreach (var cartLine in _cartData)
            {
                transaction.AddItem(cartLine);
            }

            var reportGenerator = new ReceiptGenerator();
            var receipt = reportGenerator.Generate(transaction);
            _consoleWriter.WriteLine(receipt);
        }
    }
}