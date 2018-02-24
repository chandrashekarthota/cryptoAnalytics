using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  CryptoModels
{
    public class History
    {
        public string Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
        public string MarketCap { get; set; }
        public string Difference { get; set; }
    }
}