using System;
using System.Collections.Generic;
using System.Linq;

namespace VoyagerPos
{
    public class PointOfSaleTerminal
    {
        private readonly ProductDataSource dataSource;
        private readonly List<IArticle> cart;

        public PointOfSaleTerminal(ProductDataSource dataSource)
        {
            this.dataSource = dataSource;
            this.cart = new List<IArticle>();
        }

        /**
         * <remarks>
         *      This method supports chaining
         * </remarks>
         *  
         * <exception cref="ProductNotFoundException">
         *      Thrown when productCode does not exist in data source
         * </exception>
         */
        public PointOfSaleTerminal ScanProduct(string productCode)
        {
            var product = dataSource.FindProduct(productCode: productCode);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product {productCode} does not exist");
            }

            cart.Add(product);
            return this;
        }

        public decimal CalculateTotal()
        {
            return cart.GroupBy(article => article.productCode)
                .Select(articles => articles.First().CalculatePrice(articles.Count()))
                .Sum();              
        }
    }

    public interface ProductDataSource
    {
        public IArticle FindProduct(string productCode);
    }

    public class ProductNotFoundException : ArgumentException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
