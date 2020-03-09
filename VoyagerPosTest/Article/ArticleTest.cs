using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest.Article
{
    public class ArticleTest
    {
        IArticle article; 

        [SetUp]
        public void setup()
        {
            var builder = new ArticleBuilder();
            builder.SetProductCode(productCode: "A");
            builder.SetUnitPrice(unitPrice: 1.25M);
            builder.SetBulkPriceCondition(quantity: 3, price: 3.00M);
            article = builder.BuildArticle();
        }

        [Test]
        public void testCalculatePrice()
        {
            Assert.AreEqual(1.25M, article.CalculatePrice(quantity: 1), "base unit purchase");
            Assert.AreEqual(3.0M, article.CalculatePrice(quantity: 3), "bulk purchase");
            Assert.AreEqual(4.25M, article.CalculatePrice(quantity: 4), "Should use base unit price for left over bulk purchase");
            Assert.AreEqual(6.0M, article.CalculatePrice(quantity: 6), "Should support multilpe bulk purchase");
        }

        [Test]
        public void testCalculatePriceWithInvalidQuantity()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                article.CalculatePrice(quantity: 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                article.CalculatePrice(quantity: -1);
            });
        }
    }
}
