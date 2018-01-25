using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern.Tests.WithStrategy
{
    [TestFixture]
    public class OntarioStoreInvoiceTotalStrategyTest
    {
        private readonly Product _taxableProduct = new Product(10, true);
        private readonly Product _nonTaxableProduct = new Product(30, false);

        private IInvoiceTotalStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _strategy = new OntarioStoreInvoiceTotalStrategy();
        }

        [Test]
        public void CalculatesTotalWithNoProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>());

            total.Should().Be(0);
        }

        [Test]
        public void CalculatesTotalWithOnlyTaxableProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>
            {
                _taxableProduct
            });

            total.Should().Be(12);
        }

        [Test]
        public void CalculatesTotalWithOnlyNonTaxableProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>
            {
                _nonTaxableProduct
            });

            total.Should().Be(30);
        }

        [Test]
        public void CalculatesTotalWithMixedProducts()
        {
            var total = _strategy.CalculateTotal(new List<Product>
            {
                _taxableProduct,
                _nonTaxableProduct
            });

            total.Should().Be(42);
        }
    }
}