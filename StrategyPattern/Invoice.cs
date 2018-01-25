using System.Collections.Generic;
using System.Linq;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern
{
    public class Invoice
    {
        private readonly IList<Product> _products;
        
        public Invoice()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetInvoiceTotal(PurchaseMethod purchaseMethod, Province province)
        {
            var total = 0.0;

            if (purchaseMethod == PurchaseMethod.InStore)
            {
                double taxRate = 1;
                if (province == Province.Quebec)
                {
                    taxRate = 1.5;
                }
                else if (province == Province.Ontario)
                {
                    taxRate = 1.2;
                }

                total += _products.Sum(p => p.Price * (p.Taxable ? taxRate : 1));
            }
            else if(purchaseMethod == PurchaseMethod.Online)
            {
                total += _products.Sum(p => p.Price);
            }

            return total;
        }

        public double GetInvoiceTotalWithStrategy(IInvoiceTotalStrategy totalStrategy)
        {
            return totalStrategy.CalculateTotal(_products);
        }
    }

    public enum PurchaseMethod
    {
        Online,
        InStore
    }

    public enum Province
    {
        Quebec,
        Ontario
    }

    public class Product
    {
        public Product(double price, bool taxable)
        {
            Price = price;
            Taxable = taxable;
        }

        public double Price { get; set; }
        public bool Taxable { get; set; }
    }
}