using System.Collections.Generic;
using GroceryCo.Kiosk.Acceptance.Tests.Data;
using GroceryCo.Kiosk.Acceptance.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace GroceryCo.Kiosk.Acceptance.Tests.Steps
{
    public class BaseSteps
    {
        public List<Product> Products
        {
            get { return ScenarioContext.Current.Get<List<Product>>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        public List<QuantityPromotion> QuantityPromotions
        {
            get { return ScenarioContext.Current.Get<List<QuantityPromotion>>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        public List<AdditionalItemPromotion> AdditionalItemPromotions
        {
            get { return ScenarioContext.Current.Get<List<AdditionalItemPromotion>>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        public Cart Cart
        {
            get { return ScenarioContext.Current.Get<Cart>(); }
            set { ScenarioContext.Current.Set(value); }
        }

        public CommandLineResults CommandLineResults
        {
            get { return ScenarioContext.Current.Get<CommandLineResults>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}
