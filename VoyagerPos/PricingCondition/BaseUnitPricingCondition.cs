using System;
namespace VoyagerPos
{
    public class BaseUnitPricingCondition : IPricingCondition
    {
        private readonly decimal unitPrice;

        public BaseUnitPricingCondition(decimal unitPrice)
        {
            this.unitPrice = unitPrice;
        }

        public CalculatePriceResult CalculatePrice(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Purchase quantity should be greater than 0");
            }
            return new CalculatePriceResult(quantity * unitPrice, 0);
        }
    }
}
    