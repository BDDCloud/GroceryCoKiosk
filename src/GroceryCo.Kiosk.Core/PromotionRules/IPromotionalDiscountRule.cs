namespace GroceryCo.Kiosk.Core.PromotionRules
{
    public interface IPromotionalDiscountRule
    {
        PromotionalDiscount Calculate(LineItem lineItem);
        bool PromotionApplies(LineItem lineItem);
    }
}