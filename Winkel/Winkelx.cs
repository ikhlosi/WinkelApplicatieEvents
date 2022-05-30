using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class Winkelx {
        // define delegate
        // define event, based on delegate
        // raise/fire event

        /*
        public delegate void WinkelVerkoopEventHandler(object source, EventArgs e);
        public event WinkelVerkoopEventHandler WinkelVerkoop;
        */
        public event EventHandler<WinkelEventArgs> WinkelVerkoop;

        public void VerkoopProduct(Bestelling b) {
            Console.WriteLine($"Verkoopproduct - {b}");
            OnWinkelVerkoop(b);
        }

        protected virtual void OnWinkelVerkoop(Bestelling b) {
            WinkelVerkoop?.Invoke(this, new WinkelEventArgs { Bestelling = b});
        }
    }
}
