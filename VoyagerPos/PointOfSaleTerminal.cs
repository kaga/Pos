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

        public decimal CalculateTotal()
        {
            var total = cart.GroupBy(article => article.productCode)
                .Select(articles => articles.First().CalculatePrice(articles.Count()))
                .Sum();

            return total;           
        }

        public PointOfSaleTerminal ScanProduct(string productCode)
        {
            var product = dataSource.FindProduct(productCode: productCode);
            cart.Add(product);
            return this;
        }
    }

    public interface ProductDataSource
    {
        public IArticle FindProduct(string productCode);
    }
}
