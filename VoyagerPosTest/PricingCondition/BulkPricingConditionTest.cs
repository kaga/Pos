using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest.PricingCondition
{
    public class BulkPricingConditionTest
    {
        BulkPricingCondition condition;

        [SetUp]
        public void Setup()
        {
            condition = new BulkPricingCondition(bulkPrice: 3.00M, bulkQuantity: 3);
        }

        [Test]
        public void testPriceCalculation()
        {
            var result = condition.CalculatePrice(1);
            Assert.AreEqual(0M, result.subtotal);
            Assert.AreEqual(1, result.remainingQuantity, message: "Not qualify for bulk prcing");

            result = condition.CalculatePrice(2);
            Assert.AreEqual(0M, result.subtotal);
            Assert.AreEqual(2, result.remainingQuantity);
        }

        [Test]
        public void testInvalidQuantity()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => condition.CalculatePrice(quantity: 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => condition.CalculatePrice(quantity: -1));
        }
    }
}
