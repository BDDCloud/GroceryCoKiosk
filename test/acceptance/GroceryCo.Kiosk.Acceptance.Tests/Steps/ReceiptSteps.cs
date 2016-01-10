using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    [Binding]
    public sealed class ReceiptSteps: BaseSteps
    {
        [Then("I should see expected receipt")]
        public void MyCartIsEmpty(Table receipt)
        {
            var expected = "";
            foreach (var row in receipt.Rows)
            {
                expected += $"{row[0]}\n";
            }
            //remove last new line
            expected = expected.Substring(0, expected.Length - 1);
        
            Assert.That(CommandLineResults[0], Is.EqualTo(expected));
        }
    }
}
