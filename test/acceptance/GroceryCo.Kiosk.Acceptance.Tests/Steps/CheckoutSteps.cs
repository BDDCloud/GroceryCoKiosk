using System.IO;
using System.Linq;
using System.Security;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class CheckoutSteps : BaseSteps
    {
        [When("I checkout")]
        public void WhenICheckout()
        {
            var cartFile = CreateCartFile();
            var productCatalogFile = CreateProductCatalogFile();
            var results = CommandLineApp.Run(cartFile, productCatalogFile);
            base.CommandLineResults = results;
        }

        [Then("I should be told my cart is empty")]
        public void ShouldBeToldMyCartIsEmpty()
        {
            CollectionAssert.Contains(CommandLineResults, "Error cart is empty");
        }

        private string CreateProductCatalogFile()
        {
            var filename = GenerateRandomFilename();
            CreateProducts(filename);
            CreateQuantityPromotions(filename);
            CreateAdditionItemPromotions(filename);
            return filename;
        }

        private static string GenerateRandomFilename()
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }

        private void CreateAdditionItemPromotions(string filename)
        {
            foreach (var promotion in AdditionalItemPromotions)
            {
                File.WriteAllText(filename, $"ADDITIONAL_ITEM_DISCOUNT, #{promotion.Barcode}, #{promotion.BuyQuantity}, #{promotion.HowManyFree}");
            }
        }

        private void CreateQuantityPromotions(string filename)
        {
            foreach (var promotion in QuantityPromotions)
            {
                File.WriteAllText(filename, $"QUANTITY_DISCOUNT, #{promotion.Barcode}, #{promotion.DiscountQuantity}, #{promotion.DiscountPrice}");
            }
        }

        private void CreateProducts(string filename)
        {
            foreach (var product in Products)
            {
                File.WriteAllText(filename, $"PRODUCT, #{product.Barcode}, #{product.Price}");
            }
        }

        private string CreateCartFile()
        {
            var filename = GenerateRandomFilename();
            File.WriteAllLines(filename, Cart);
            return filename;
        }
    }
}
