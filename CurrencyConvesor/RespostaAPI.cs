using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvesor {
    internal class RespostaAPI {

        public class ExchangeRateResponse {
            public string Code { get; set; }
            public string Codein { get; set; }
            public string Name { get; set; }
            public decimal High { get; set; }
            public decimal Low { get; set; }
            public decimal VarBid { get; set; }
            public decimal PctChange { get; set; }
            public decimal Bid { get; set; }
            public decimal Ask { get; set; }
            public long Timestamp { get; set; }
            public string CreateDate { get; set; }
        }

    }
}
