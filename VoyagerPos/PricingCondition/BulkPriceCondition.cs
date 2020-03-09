using System;
namespace VoyagerPos
{
    public class BulkPricingCondition : IPricingCondition
    {
        private readonly int bulkQuantity;
        private readonly decimal bulkPrice;

        public BulkPricingCondition(int bulkQuantity, decimal bulkPrice)
        {
            this.bulkQuantity = bulkQuantity;
            this.bulkPrice = bulkPrice;
        }

        public CalculatePriceResult CalculatePrice(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Purchase quantity should be greater than 0");
            }

            int bulkPurchaseQuantity = quantity / this.bulkQuantity;
            decimal bulkSubtotal = bulkPurchaseQuantity * this.bulkPrice;
            int remainingQuantity = quantity % this.bulkQuantity;

            return new CalculatePriceResult(subtotal: bulkSubtotal, remainingQuantity: remainingQuantity);
        }
    }
}
    