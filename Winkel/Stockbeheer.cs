using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class Stockbeheer {
        private Dictionary<ProductType, int> _stock = new Dictionary<ProductType, int>();
        private int _stockgrootte;
        private int _minimumstock;
        public event EventHandler<StockbeheerEventArgs> StockBestelling;

        public Stockbeheer(int stockgrootte, int minimumstock) {
            _stockgrootte = stockgrootte;
            _minimumstock = minimumstock;
            
            InitStock();
        }

        private void InitStock() {
            // Dictionary<ProductType, int> stock = new Dictionary<ProductType, int>();
            _stock.Add(ProductType.Dubbel, _stockgrootte);
            _stock.Add(ProductType.Tripel, _stockgrootte);
            _stock.Add(ProductType.Kriek, _stockgrootte);
            _stock.Add(ProductType.Pils, _stockgrootte);

            // _stock = stock;
        }


        public void VulStockAan() {
            foreach (var x in _stock.Keys) {
                _stock[x] = _stockgrootte;
            }
        }

        public void OnWinkelVerkoop(object source, WinkelEventArgs args) {
            Console.WriteLine("stockbeheer - onwinkelverkoop");
            _stock[args.Bestelling.Product] -= args.Bestelling.Aantal;
            if(_stock[args.Bestelling.Product] < _minimumstock) {
                maakGroothandelaarsBestelling();
            }
        }

        private void maakGroothandelaarsBestelling() {
            Dictionary<ProductType, int> ghb = new Dictionary<ProductType, int>();
            foreach(var x in _stock) {
                if(x.Value<_stockgrootte) {
                    ghb.Add(x.Key, _stockgrootte - x.Value);
                }
            }
            OnStockBestelling(ghb);
        }

        protected virtual void OnStockBestelling(Dictionary<ProductType, int> grhb) {
            StockBestelling?.Invoke(this, new StockbeheerEventArgs() { GHB = grhb });
        }

        public void ToonStock() {
            foreach (var x in _stock) {
                Console.WriteLine($"{x.Key},{x.Value}");
            }
        }
    }
}
