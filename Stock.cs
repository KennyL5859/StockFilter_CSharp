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
        public double RegPercentChg { get; set; }
        public double MA50_Change { get; set; }
        public double MA50_Change_Percent { get; set; }
        public double MA200_Change { get; set; }
        public double MA200_Change_Percent { get; set; }
        public Dictionary<DateTime, decimal> PriceHistory  { get; set; }


        public Stock(string ticSymbol)
        {
            this.ticker = ticSymbol;
        }

        public async Task GetHistoricalPrices(DateTime start, DateTime end)
        {
            // gets the historica dates/prices and insert it into dictionary
            var history = await Yahoo.GetHistoricalAsync(ticker, start, end);
            this.PriceHistory = new Dictionary<DateTime, decimal>();

            foreach (var point in history)
            {
                this.PriceHistory.Add(point.DateTime, point.Close);
            }
        }

        public async Task GetStockData()
        {
            // gets different data about this particular stock
            var stock = await Yahoo.Symbols(ticker).Fields(Field.FiftyDayAverage, Field.RegularMarketPrice, 
                Field.TwoHundredDayAverage, Field.Symbol, Field.RegularMarketVolume, Field.AverageDailyVolume10Day,
                Field.AverageDailyVolume3Month, Field.RegularMarketChangePercent, 
                Field.FiftyDayAverageChange, Field.FiftyDayAverageChangePercent,
                Field.TwoHundredDayAverageChange, Field.TwoHundredDayAverageChangePercent).QueryAsync();
            var stockTic = stock[ticker];

            this.RegularMarketPrice = stockTic[Field.RegularMarketPrice];
            this.MA50 = stockTic[Field.FiftyDayAverage];
            this.MA200 = stockTic[Field.TwoHundredDayAverage];
            this.RegularVol = stockTic[Field.RegularMarketVolume];
            this.Avg10DayVol = stockTic[Field.AverageDailyVolume10Day];
            this.Avg3MonthVol = stockTic[Field.AverageDailyVolume3Month];
            this.RegPercentChg = stockTic[Field.RegularMarketChangePercent];
            this.MA50_Change = stockTic[Field.FiftyDayAverageChange];
            this.MA50_Change_Percent = stockTic[Field.FiftyDayAverageChangePercent];
            this.MA200_Change = stockTic[Field.TwoHundredDayAverageChange];
            this.MA200_Change_Percent = stockTic[Field.TwoHundredDayAverageChangePercent];

        }

    }
}
