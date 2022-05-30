using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class Bestelling {
        public Bestelling(ProductType product, double prijs, int aantal, string adres) {
            Product = product;
            Prijs = prijs;
            Aantal = aantal;
            Adres = adres;
        }

        public ProductType Product { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public string Adres { get; set; }

        public override string ToString() {
            return $"{Product}, {Prijs}, {Aantal}, {Adres}";
        }
    }
}
