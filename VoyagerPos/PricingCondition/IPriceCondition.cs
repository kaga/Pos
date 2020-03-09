namespace VoyagerPos
{
    public interface IPricingCondition
    {
        CalculatePriceResult CalculatePrice(int quantity);
    }

    public struct CalculatePriceResult
    {
        public CalculatePriceResult(decimal subtotal, int remainingQuantity)
        {
            this.subtotal = subtotal;
            this.remainingQuantity = remainingQuantity;
        }

        public decimal subtotal;
        public int remainingQuantity;
    }
}
