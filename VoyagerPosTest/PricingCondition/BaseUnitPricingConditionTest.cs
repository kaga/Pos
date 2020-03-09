using System;
using NUnit.Framework;
using VoyagerPos;

namespace VoyagerPosTest.PricingCondition
{
    public class BaseUnitPricingConditionTest
    {
        BaseUnitPricingCondition condition;

        [SetUp]
        public void Setup()
        {
            condition = new BaseUnitPricingCondition(unitPrice: 1.25M);
        }

        [Test]
        public void testPriceCalculation()
        {
            var result = condition.CalculatePrice(1);
            Assert.AreEqual(1.25M, result.subtotal);
            Assert.AreEqual(0, result.remainingQuantity, message: "remainingQuantity should always return 0");

            result = condition.CalculatePrice(2);
            Assert.AreEqual(2.5M, result.subtotal);
            Assert.AreEqual(0, result.remainingQuantity, message: "remainingQuantity should always return 0");
        }

        [Test]
        public void testInvalidQuantity()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => condition.CalculatePrice(quantity: 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => condition.CalculatePrice(quantity: -1));          
        }
    }
}
