using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest
{
    public class PointOfSaleTerminalTest
    {
        PointOfSaleTerminal terminal;

        [SetUp]
        public void Setup()
        {
            var productA = (new ArticleBuilder())
                .SetProductCode("A")
                .SetUnitPrice(1.25M)
                .SetBulkPriceCondition(quantity: 3, price: 3.00M)
                .BuildArticle();

            var productB = (new ArticleBuilder())
                .SetProductCode("B")
                .SetUnitPrice(2.99M)
                .BuildArticle();

            var dataSource = new SimpleArticleDataSource();
            dataSource.articles.Add(productA);
            dataSource.articles.Add(productB);

            terminal = new PointOfSaleTerminal(dataSource: dataSource);
        }

        [TearDown]
        public void TearDown()
        {
            terminal = null;
        }

        [Test]
        public void TestProductNotFound()
        {
            Assert.Throws<ProductNotFoundException>(() =>
            {
                terminal.ScanProduct("A")
                .ScanProduct("B")
                .ScanProduct("C");
            }, "Product C does not exist");
        }
    }
}
