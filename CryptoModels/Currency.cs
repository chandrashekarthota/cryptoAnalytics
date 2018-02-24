using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoModels
{
    public class Currency
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MarketCap { get; set; }

        public string Price { get; set; }

        public string Volume { get; set; }

        public string CirculatingSupply { get; set; }

        public string Change { get; set; }

        public List<History> CoinHisotry { get; set; }

    }
}