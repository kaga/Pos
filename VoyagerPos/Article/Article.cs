using System.Collections.Generic;
using System;

namespace VoyagerPos
{
    struct Article : IArticle
    {
        public string productCode
        {
            get;
        }

        private List<IPricingCondition> pricingConditionChains;

        public Article(string productCode, decimal unitPrice, decimal bulkPrice, int bulkQuantity)
            : this(productCode: productCode)
        {
            this.pricingConditionChains.Add(new BulkPricingCondition(bulkPrice: bulkPrice, bulkQuantity: bulkQuantity));
            this.pricingConditionChains.Add(new BaseUnitPricingCondition(unitPrice: unitPrice));
        }

        public Article(string productCode, decimal unitPrice)
            : this(productCode: productCode)
        {
            this.pricingConditionChains.Add(new BaseUnitPricingCondition(unitPrice: unitPrice));
        }

        private Article(string productCode)
        {
            this.pricingConditionChains = new List<IPricingCondition>();
            this.productCode = productCode;
        }

        public decimal CalculatePrice(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Purchase quantity should be > 0");
            }

            decimal remainingQuantity = quantity;
            decimal total = 0M;

            foreach(var pricingCondition in pricingConditionChains)
            {
                var result = pricingCondition.CalculatePrice(remainingQuantity);

                total += result.subtotal;
                remainingQuantity = result.remainingQuantity;

                if (remainingQuantity == 0)
                {
                    break;
                }
            }

            if (remainingQuantity > 0)
            {
                throw new InvalidOperationException($"Remaining Quantity should be 0, found {remainingQuantity}");
            }

            return Decimal.Round(total, 2, MidpointRounding.AwayFromZero);
        }
    }
}
