using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace Stock_YahooFinance
{
    public class Stock
    {
        public string ticker { get; set; }
        public double fiftyMA { get; set; }
        public double RegularMarketPrice { get; set; }

        private double marketPrice;

        public Stock(string ticSymbol)
        {
            this.ticker = ticSymbol;
        }

        public async Task GetStockData()
        {
            var stock = await Yahoo.Symbols(ticker).Fields(Field.FiftyDayAverage, Field.RegularMarketPrice).QueryAsync();
            var stockTic = stock[ticker];


            this.RegularMarketPrice = stockTic[Field.RegularMarketPrice];
     
        }


    }
}
