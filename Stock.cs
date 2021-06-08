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
        public Dictionary<int, decimal> PriceHistory  { get; set; }
        public Dictionary<DateTime, decimal> PriceHistoryDates { get; set; }


        public Stock(string ticSymbol)
        {
            this.ticker = ticSymbol;
        }

        public async Task<bool> StockConform(int uIndex, int dIndex)
        {
            DateTime today = DateTime.Now;
            DateTime priorDate = today.AddDays(-15);
            await GetHistoricalPrices(priorDate, today);
            var history = this.PriceHistory;
            int numRecords = this.PriceHistory.Count;
            
            if (uIndex < dIndex)
            {
                int firstStart = numRecords - uIndex;
                int secondStart = firstStart - dIndex;

                for (int i = firstStart; i < numRecords; i++)
                {
                    if (history[i] < history[i + 1])                    
                        continue;                    
                    else                    
                        return false;                    
                }

                for (int d = secondStart; d < firstStart; d++)
                {
                    if (history[d] > history[d + 1])                    
                        continue;                    
                    else                    
                        return false;                    
                }

                return true;
            }
            else if (uIndex > dIndex)
            {
                int firstStart = numRecords - dIndex;
                int secondStart = firstStart - uIndex;

                for (int i = firstStart; i < numRecords; i++)
                {
                    if (history[i] > history[i + 1])
                        continue;
                    else
                        return false;                    
                }

                for (int i = secondStart; i < firstStart; i++)
                {
                    if (history[i] < history[i + 1])
                        continue;
                    else
                        return false;
                }

                return true;
            }
            else if (uIndex == dIndex)
            {
                int firstStart = numRecords - dIndex;
                int secondStart = firstStart - uIndex;

                int upCount = 0;
                int downCount = 0;
                int upCount2 = 0;
                int downCount2 = 0;

                for (int i = firstStart; i < numRecords; i++)
                {
                    if (history[i] > history[i + 1])
                        downCount++;
                    else
                        upCount++;
                }

                if (downCount < dIndex && upCount < dIndex)
                    return false;


                for (int i = secondStart; i < firstStart; i++)
                {
                    if (history[i] > history[i + 1])
                        downCount2++;
                    else
                        upCount2++;
                }

                if (downCount != upCount2 || upCount != downCount2)
                    return false;

                return true;                
            }


            return false;
        }

        public async Task GetHistoricalPrices(DateTime start, DateTime end)
        {
            // gets the historica dates/prices and insert it into dictionary
            var history = await Yahoo.GetHistoricalAsync(ticker, start, end);
            this.PriceHistory = new Dictionary<int, decimal>();

            int begin = 1;

            foreach (var point in history)
            {
                this.PriceHistory.Add(begin, point.Close);
                begin++;
            }
        }

        public async Task GetHistoricalPricesDates(DateTime start, DateTime end)
        {
            var history = await Yahoo.GetHistoricalAsync(ticker, start, end);
            this.PriceHistoryDates = new Dictionary<DateTime, decimal>();

            foreach (var point in history)
                this.PriceHistoryDates.Add(point.DateTime, point.Close);
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
