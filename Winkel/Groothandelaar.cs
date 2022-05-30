using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class Groothandelaar {
        private List<Dictionary<ProductType, int>> _voorraadbestelling = new List<Dictionary<ProductType, int>>();
        public void ToonAlleBestellingen() {
            foreach (var x in _voorraadbestelling) {
                foreach (var y in x) {
                    Console.WriteLine($"voorraadbesteling {y.Key}, {y.Value}");
                }
            }
        }

        public Dictionary<ProductType,int> GeefLaatsteBestelling() {
            return _voorraadbestelling[_voorraadbestelling.Count - 1];
        }

        public void OnStockBestelling(object source, StockbeheerEventArgs args) {
            Console.WriteLine("Groothandelaar - OnStockBestelling");
            _voorraadbestelling.Add(args.GHB);
        }
    }
}
