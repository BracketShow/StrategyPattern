using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern.Tests.WithStrategy
{
    [TestFixture]
    public class InvoiceTest
    {
        private Invoice _invoice;

        [SetUp]
        public void SetUp()
        {
            _invoice = new Invoice();
        }

        [Test]
        public void CalculatesTotalWithGivenStrategy()
        {
            var strategyMock = new Mock<IInvoiceTotalStrategy>();
            strategyMock.Setup(s => s.CalculateTotal(It.IsAny<IList<Product>>()))
                .Returns(10);

            var total = _invoice.GetInvoiceTotalWithStrategy(strategyMock.Object);

            total.Should().Be(10);
            strategyMock.Verify(s => s.CalculateTotal(It.IsAny<IList<Product>>()));
        }
    }
}