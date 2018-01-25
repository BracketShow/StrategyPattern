using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern.Tests.WithStrategy
{
    [TestFixture]
    public class OnlineInvoiceTotalStrategyTest
    {
        private IInvoiceTotalStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new OnlineInvoiceTotalStrategy();
        }

        [Test]
        public void CalculatesTotalWithNoProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>());

            total.Should().Be(0);
        }

        [Test]
        public void CalculatesTotalWithProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>
            {
                new Product(10, true),
                new Product(15, false)
            });

            total.Should().Be(25);
        }
    }
}