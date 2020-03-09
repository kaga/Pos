using System;

namespace VoyagerPos
{
    public class ArticleBuilder
    {
        private string productCode;
        private decimal unitPrice;

        private int? bulkQuantity = null;
        private decimal? bulkPrice = null;             

        public ArticleBuilder SetProductCode(string productCode)
        {
            this.productCode = productCode;
            return this;
        }

        public ArticleBuilder SetUnitPrice(decimal unitPrice)
        {
            this.unitPrice = unitPrice;
            return this;
        }

        public ArticleBuilder SetBulkPriceCondition(int quantity, decimal price)
        {
            this.bulkPrice = price;
            this.bulkQuantity = quantity;

            return this;
        }

        public IArticle BuildArticle()
        {
            if (productCode == null || string.IsNullOrEmpty(productCode))
            {
                throw new InvalidOperationException("Product code is required");
            }

            if (unitPrice <= 0)
            {
                throw new ArgumentOutOfRangeException("Unit price should be > 0");
            }

            if (bulkPrice is decimal price && bulkQuantity is int quantity)
            {
                if (price <= 0)
                {
                    throw new ArgumentOutOfRangeException("Bulk price should be > 0");
                }

                if (quantity <= 1)
                {
                    throw new ArgumentOutOfRangeException("Bulk quantity should be > 1");
                }

                return new Article(productCode: productCode, unitPrice: unitPrice, bulkPrice: price, bulkQuantity: quantity);
            }
            else
            {
                return new Article(productCode: productCode, unitPrice: unitPrice);
            }
        }
    }
}
