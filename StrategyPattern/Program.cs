using System;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var invoice = new Invoice();
            invoice.AddProduct(new Product(10, true));
            invoice.AddProduct(new Product(15, false));
            
            var total = invoice.GetInvoiceTotal(PurchaseMethod.Online, Province.Quebec);
            total = invoice.GetInvoiceTotalWithStrategy(new OnlineInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté en ligne: {total}");
            
            total = invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Quebec);
            total = invoice.GetInvoiceTotalWithStrategy(new QuebecStoreInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté dans un magasin au Québec: {total}");

            total = invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Ontario);
            total = invoice.GetInvoiceTotalWithStrategy(new OntarioStoreInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté dans un magasin en Ontario: {total}");
        }
    }
}
