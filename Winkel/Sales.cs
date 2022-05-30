using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class Sales {
        private Dictionary<string, List<Bestelling>> _rapportData = new Dictionary<string, List<Bestelling>>();
        public void ToonRapport() {
            Console.WriteLine("Sales - rapport");
            foreach(var item in _rapportData) {
                Console.WriteLine(item.Key); // adres uitprinten
                foreach(Bestelling best in item.Value) {
                    Console.WriteLine($"\t{best.Product}, {best.Aantal}"); // product en aantal
                }
            }
        }

        public void OnWinkelVerkoop(object source, WinkelEventArgs args) {
            Console.WriteLine("Sales - OnWinkelVerkoop");
            if (_rapportData.ContainsKey(args.Bestelling.Adres)) { // checken of het adres er al in zit
                _rapportData[args.Bestelling.Adres].Add(args.Bestelling); // if ja, dan gewoon toevoegen
            } else {
                _rapportData.Add(args.Bestelling.Adres, new List<Bestelling>() { args.Bestelling });
            }
        }
    }
}
