using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest.Article
{
    public class ArticleBuilderTest
    {
        [Test]
        public void testMissingProductCode()
        {            
            Assert.Throws<InvalidOperationException>(() =>
            {
                var builder = new ArticleBuilder();
                builder.SetUnitPrice(unitPrice: 1.25M);
                builder.BuildArticle();
            });
        }

        [Test]
        public void testMissingBaseUnitPrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var builder = new ArticleBuilder();
                builder.SetProductCode(productCode: "A");
                builder.BuildArticle();
            });
        }

        [Test]
        public void testBaseUnitPriceArticle()
        {
            var builder = new ArticleBuilder();
            builder.SetProductCode(productCode: "A");
            builder.SetUnitPrice(unitPrice: 1.25M);
            var article = builder.BuildArticle();

            Assert.AreEqual("A", article.productCode);
            Assert.AreEqual(1.25M, article.CalculatePrice(1));
        }

        [Test]
        public void testBulkPricingArticle()
        {
            var builder = new ArticleBuilder();
            builder.SetProductCode(productCode: "A");
            builder.SetUnitPrice(unitPrice: 1.25M);
            builder.SetBulkPriceCondition(quantity: 3, price: 3.00M);
            var article = builder.BuildArticle();

            Assert.AreEqual("A", article.productCode);
            Assert.AreEqual(3.0M, article.CalculatePrice(3));
        }

        [Test]
        public void testOutOfRangeBulkPricingArticle()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var builder = new ArticleBuilder();
                builder.SetProductCode(productCode: "A");
                builder.SetUnitPrice(unitPrice: 1.25M);
                builder.SetBulkPriceCondition(quantity: 1, price: 3.00M);
                builder.BuildArticle();
            }, "Bulk quantity should be > 1");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var builder = new ArticleBuilder();
                builder.SetProductCode(productCode: "A");
                builder.SetUnitPrice(unitPrice: 1.25M);
                builder.SetBulkPriceCondition(quantity: 2, price: 0.00M);
                builder.BuildArticle();
            }, "Bulk price should be > 0");
        }
    }
}
