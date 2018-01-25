using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern.PurchaseStrategy
{
    public interface IInvoiceTotalStrategy
    {
        double CalculateTotal(IList<Product> products);
    }

    public class OnlineInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        public double CalculateTotal(IList<Product> products) => products.Sum(p => p.Price);
    }

    public class QuebecStoreInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        private const double TaxRate = 1.5;
        public double CalculateTotal(IList<Product> products) => products.Sum(p => p.Price * (p.Taxable ? TaxRate : 1));
    }

    public class OntarioStoreInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        private const double TaxRate = 1.2;
        public double CalculateTotal(IList<Product> products) => products.Sum(p => p.Price * (p.Taxable ? TaxRate : 1));
    }
}