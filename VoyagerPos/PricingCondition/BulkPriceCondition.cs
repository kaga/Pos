using System;
namespace VoyagerPos
{
    public class BulkPricingCondition : IPricingCondition
    {
        private readonly decimal bulkQuantity;
        private readonly decimal bulkPrice;

        public BulkPricingCondition(decimal bulkQuantity, decimal bulkPrice)
        {
            this.bulkQuantity = bulkQuantity;
            this.bulkPrice = bulkPrice;
        }

        public CalculatePriceResult CalculatePrice(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Purchase quantity should be greater than 0");
            }

            decimal bulkPurchaseQuantity = Math.Truncate(quantity / this.bulkQuantity);
            decimal bulkSubtotal = bulkPurchaseQuantity * this.bulkPrice;
            decimal remainingQuantity = quantity % this.bulkQuantity;

            return new CalculatePriceResult(subtotal: bulkSubtotal, remainingQuantity: remainingQuantity);
        }
    }
}
    