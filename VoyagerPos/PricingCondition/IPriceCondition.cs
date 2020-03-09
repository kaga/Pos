namespace VoyagerPos
{
    public interface IPricingCondition
    {
        CalculatePriceResult CalculatePrice(decimal quantity);
    }

    public struct CalculatePriceResult
    {
        public CalculatePriceResult(decimal subtotal, decimal remainingQuantity)
        {
            this.subtotal = subtotal;
            this.remainingQuantity = remainingQuantity;
        }

        public decimal subtotal;
        public decimal remainingQuantity;
    }
}
