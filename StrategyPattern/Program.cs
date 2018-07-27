using System;
using StrategyPattern.PurchaseStrategy;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice();
            invoice.AddProduct(new Product(10, true));
            invoice.AddProduct(new Product(15, false));
            
            var total = invoice.GetInvoiceTotal(PurchaseMethod.Online, Province.Quebec);
            Console.WriteLine($"Total si acheté en ligne (sans Strategy): {total}");

            total = invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Quebec);
            Console.WriteLine($"Total si acheté dans un magasin au Québec (sans Strategy): {total}");

            total = invoice.GetInvoiceTotal(PurchaseMethod.InStore, Province.Ontario);
            Console.WriteLine($"Total si acheté dans un magasin en Ontario (sans Strategy): {total}");

            #region With Strategy Pattern

            total = invoice.GetInvoiceTotalWithStrategy(new OnlineInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté en ligne (avec Strategy): {total}");

            total = invoice.GetInvoiceTotalWithStrategy(new QuebecStoreInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté dans un magasin au Québec (avec Strategy): {total}");

            total = invoice.GetInvoiceTotalWithStrategy(new OntarioStoreInvoiceTotalStrategy());
            Console.WriteLine($"Total si acheté dans un magasin en Ontario (avec Strategy): {total}");

            #endregion
            
            Console.ReadKey();
        }
    }
}
