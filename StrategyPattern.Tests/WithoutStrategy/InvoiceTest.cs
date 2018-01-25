using FluentAssertions;
using NUnit.Framework;

namespace StrategyPattern.Tests.WithoutStrategy
{
    [TestFixture]
    public class InvoiceTest
    {
        private readonly Product _taxableProduct = new Product(10, true);
        private readonly Product _nonTaxableProduct = new Product(30, false);

        private Invoice _invoice;

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice();
        }

        [Test]
        public void CalculatesTotalForOnlinePurchase()
        {
            _invoice.AddProduct(_taxableProduct);
            _invoice.AddProduct(_nonTaxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.Online, Province.Quebec);

            total.Should().Be(40);
        }

        [Test]
        public void CalculatesTotalForQuebecStorePurchaseWithOnlyTaxableProducts()
        {
            _invoice.AddProduct(_taxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Quebec);

            total.Should().Be(15);
        }

        [Test]
        public void CalculatesTotalForQuebecStorePurchaseWithOnlyNonTaxableProducts()
        {
            _invoice.AddProduct(_nonTaxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Quebec);

            total.Should().Be(30);
        }

        [Test]
        public void CalculatesTotalForQuebecStorePurchaseWithMixedProducts()
        {
            _invoice.AddProduct(_taxableProduct);
            _invoice.AddProduct(_nonTaxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Quebec);

            total.Should().Be(45);
        }

        [Test]
        public void CalculatesTotalForOntarioStorePurchaseWithOnlyTaxableProducts()
        {
            _invoice.AddProduct(_taxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Ontario);

            total.Should().Be(12);
        }

        [Test]
        public void CalculatesTotalForOntarioStorePurchaseWithOnlyNonTaxableProducts()
        {
            _invoice.AddProduct(_nonTaxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Ontario);

            total.Should().Be(30);
        }

        [Test]
        public void CalculatesTotalForOntarioStorePurchaseWithMixedProducts()
        {
            _invoice.AddProduct(_taxableProduct);
            _invoice.AddProduct(_nonTaxableProduct);

            var total = _invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Ontario);

            total.Should().Be(42);
        }
    }
}
