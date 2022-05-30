using System;
using Winkel;

namespace ConsoleAppWinkel {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Winkelx w = new Winkelx(); // publisher
            Stockbeheer sb = new Stockbeheer(100, 25); // subscriber
            w.WinkelVerkoop += sb.OnWinkelVerkoop;

            Sales s = new Sales();
            w.WinkelVerkoop += s.OnWinkelVerkoop;

            Groothandelaar gh = new Groothandelaar();
            sb.StockBestelling += gh.OnStockBestelling;

            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Dorpstr"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 25, "Dorpstr"));
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Kerkstr"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 35, "Dorpstr"));




            Console.WriteLine("--------");
            sb.ToonStock();
            s.ToonRapport();
            gh.ToonAlleBestellingen();
            sb.VulStockAan();
            sb.ToonStock();
        }
    }
}
