using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest.Article
{
    public class ArticleTest
    {
        IArticle article; 

        [SetUp]
        public void Setup()
        {
            var builder = new ArticleBuilder();
            builder.SetProductCode(productCode: "A");
            builder.SetUnitPrice(unitPrice: 1.25M);
            builder.SetBulkPriceCondition(quantity: 3, price: 3.00M);
            article = builder.BuildArticle();
        }

        [Test]
        public void TestCalculatePrice()
        {
            Assert.AreEqual(1.25M, article.CalculatePrice(quantity: 1), "base unit purchase");
            Assert.AreEqual(3.0M, article.CalculatePrice(quantity: 3), "bulk purchase");
            Assert.AreEqual(4.25M, article.CalculatePrice(quantity: 4), "Should use base unit price for left over bulk purchase");
            Assert.AreEqual(6.0M, article.CalculatePrice(quantity: 6), "Should support multilpe bulk purchase");
        }

        [Test]
        public void TestCalculatePriceForKgProduct()
        {
            var builder = new ArticleBuilder();
            builder.SetProductCode(productCode: "Banana");
            builder.SetUnitPrice(unitPrice: 2.99M);
            article = builder.BuildArticle();

            Assert.AreEqual(4.57, article.CalculatePrice(quantity: 1.53M), "Rounded to 2dp");
            Assert.AreEqual(3.02, article.CalculatePrice(quantity: 1.01M), "Rounded to 2dp");
        }

        [Test]
        public void TestCalculatePriceWithInvalidQuantity()
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
