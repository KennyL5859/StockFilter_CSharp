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
        public double RegularMarketPrice { get; set; }
        public double MA50 { get; set; }
        public double MA200 { get; set; }
        public double RegularVol { get; set; }
        public double Avg10DayVol { get; set; }
        public double Avg3MonthVol { get; set; }


        public Stock(string ticSymbol)
        {
            this.ticker = ticSymbol;
        }

        public async Task GetStockData()
        {
            var stock = await Yahoo.Symbols(ticker).Fields(Field.FiftyDayAverage, Field.RegularMarketPrice, 
                Field.TwoHundredDayAverage, Field.Symbol, Field.RegularMarketVolume, Field.AverageDailyVolume10Day,
                Field.AverageDailyVolume3Month).QueryAsync();
            var stockTic = stock[ticker];

            this.RegularMarketPrice = stockTic[Field.RegularMarketPrice];
            this.MA50 = stockTic[Field.FiftyDayAverage];
            this.MA200 = stockTic[Field.TwoHundredDayAverage];
            this.RegularVol = stockTic[Field.RegularMarketVolume];
            this.Avg10DayVol = stockTic[Field.AverageDailyVolume10Day];
            this.Avg3MonthVol = stockTic[Field.AverageDailyVolume3Month];
     

        }


    }
}
