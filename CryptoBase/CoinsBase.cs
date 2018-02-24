using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoModels;

namespace CryptoBase
{
    public class CoinsBase
    {
        public static List<Currency> GetCurrencies()
        {
            var url = "https://coinmarketcap.com/coins/";
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = htmlweb.Load(url);
            var currencies = htmlDocument.DocumentNode.SelectNodes("//*[contains(@id,'currencies')]");

            var currenciesData = currencies[0].ChildNodes[3].ChildNodes;
            List<Currency> list = new List<Currency>();
            for (int i = 1; i < currenciesData.Count; i++)
            {
                if (currenciesData[i].Name != "#text")
                {
                    var id = currenciesData[i].ChildNodes[1].InnerText;
                    var name = currenciesData[i].ChildNodes[3].InnerText;
                    var marketCap = currenciesData[i].ChildNodes[5].InnerText;
                    var price = currenciesData[i].ChildNodes[7].InnerText;
                    var volume = currenciesData[i].ChildNodes[9].InnerText;
                    var circulatingSupply = currenciesData[i].ChildNodes[11].InnerText;
                    var change = currenciesData[i].ChildNodes[13].InnerText;

                    Currency currency = new Currency();

                    currency.Id = id;
                    currency.Name = name;
                    currency.Change = change;
                    currency.CirculatingSupply = circulatingSupply;
                    currency.MarketCap = marketCap;
                    currency.Price = price;
                    currency.Volume = volume;
                    //Get Coin History
                    currency.Name = "Bitcoin";
                    var getCoinHistory = GetCoinHistory(currency.Name);
                    currency.CoinHisotry = getCoinHistory;
                    list.Add(currency);
                }
            }
            return list;
        }
        public static List<History> GetCoinHistory(string coinName)
        {
            string historyUrl = "https://coinmarketcap.com/currencies/" + coinName + "/historical-data/";
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = htmlweb.Load(historyUrl);
            var historicalData = htmlDocument.DocumentNode.SelectNodes("//*[contains(@class,'table-responsive')]");
            List<History> historyList = new List<History>();
            int rowCount = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes.Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].Name != "#text")
                {
                    History history = new History();
                    history.Date = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[1].InnerText;
                    history.Open = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[3].InnerText;
                    history.High = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[5].InnerText;
                    history.Low = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[7].InnerText;
                    history.Close = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[9].InnerText;
                    history.Volume = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[11].InnerText;
                    history.MarketCap = historicalData[0].ChildNodes[1].ChildNodes[3].ChildNodes[i].ChildNodes[13].InnerText;
                    historyList.Add(history);
                }
            }

            return historyList;
        }
    }
}
