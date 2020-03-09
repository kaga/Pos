using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest
{
    public class PointOfSaleTerminalTest_TechnicalExercise
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
                .SetUnitPrice(4.25M)
                .BuildArticle();

            var productC = (new ArticleBuilder())
                .SetProductCode("C")
                .SetUnitPrice(1M)
                .SetBulkPriceCondition(quantity: 6, price: 5.00M)
                .BuildArticle();

            var productD = (new ArticleBuilder())
                .SetProductCode("D")
                .SetUnitPrice(0.75M)
                .BuildArticle();

            var dataSource = new SimpleArticleDataSource();
            dataSource.articles.Add(productA);
            dataSource.articles.Add(productB);
            dataSource.articles.Add(productC);
            dataSource.articles.Add(productD);

            terminal = new PointOfSaleTerminal(dataSource: dataSource);
        }

        [TearDown]
        public void TearDown()
        {
            terminal = null;
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(13.25M,
                terminal.ScanProduct("A")
                .ScanProduct("B")
                .ScanProduct("C")
                .ScanProduct("D")
                .ScanProduct("A")
                .ScanProduct("B")
                .ScanProduct("A")
                .CalculateTotal());
        }

        [Test]
        public void Test2()
        {          
            Assert.AreEqual(6M,
                terminal.ScanProduct("C")
                .ScanProduct("C")
                .ScanProduct("C")
                .ScanProduct("C")
                .ScanProduct("C")
                .ScanProduct("C")
                .ScanProduct("C")
                .CalculateTotal());
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(7.25M,
                terminal.ScanProduct("A")
                .ScanProduct("B")
                .ScanProduct("C")
                .ScanProduct("D")
                .CalculateTotal());
        }
    }
}