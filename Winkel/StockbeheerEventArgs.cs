using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winkel {
    public class StockbeheerEventArgs {
        public Dictionary<ProductType,int> GHB { get; set; }
    }
}
