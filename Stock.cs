using System;
using System.Collections.Generic;
using System.Globalization;
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
        public DateTime EarningsDate { get; set; }
        public DateTime DividendDate { get; set; }
        public Dictionary<int, decimal> PriceHistory  { get; set; }
        public Dictionary<DateTime, decimal> PriceHistoryDates { get; set; }
        public Dictionary<DateTime, decimal> VolumeHistory { get; set; }


        public Stock(string ticSymbol)
        {
            this.ticker = ticSymbol;
        }


        public async Task<List<string>> CheckVolumeTrend(int totalDays, int volDays)
        {
            List<string> volData = new List<string>();
            await GetStockData();
            await GetHistoricalVolumes(DateTime.Today.AddDays(-100), DateTime.Today.AddDays(1));

            // get the starting index, average 3 month volume, and match count
            int startIndex = this.VolumeHistory.Count - totalDays;
            int numMatches = 0;
            double avg3MonVol = this.Avg3MonthVol;        
            
            if (VolumeHistory.Count > totalDays)
            {
                // loop through volume and see how many days above 3 month average
                for (int i = startIndex; i < this.VolumeHistory.Count; i++)
                {
                    double vol = Convert.ToDouble(VolumeHistory.ElementAt(i).Value);

                    // compare volume and add it to counter
                    if (vol >= avg3MonVol)
                        numMatches++;
                }

                // determine if number of matches passes or fails
                string passFail = numMatches >= volDays ? "P" : "F";

                // get the start and end dates in string format 
                DateTime start = VolumeHistory.ElementAt(startIndex).Key;
                DateTime end = VolumeHistory.ElementAt(VolumeHistory.Count - 1).Key;
                string dateRange = start.Month + "/" + start.Day + " - " + end.Month + "/" + end.Day;
                string percent = ((double)numMatches / totalDays).ToString();
                string matchResult = numMatches.ToString() + " / " + totalDays.ToString() + " days";

                // add everything needed to volData list
                volData.Add(passFail);
                volData.Add(ticker);
                volData.Add(dateRange);
                volData.Add(percent);
                volData.Add(matchResult);
            }
            else
            {
                volData.Add("F");
                volData.Add("N/A");
                volData.Add("N/A");
                volData.Add("N/A");
                volData.Add("N/A");
            }           

            return volData;
        }

        public async Task<Dictionary<string, double>> GetVolumeChartLabels(int fIndex, int sIndex)
        {
            Dictionary<string, double> volumeDic = new Dictionary<string, double>();
            await GetHistoricalVolumes(DateTime.Today.AddDays(-20), DateTime.Today.AddDays(1));
            int first = this.VolumeHistory.Count - fIndex - sIndex - 1;

            for (int i = first; i < this.VolumeHistory.Count; i++)
            {
                DateTime tDate = this.VolumeHistory.ElementAt(i).Key;
                double tVolume = Convert.ToDouble(this.VolumeHistory.ElementAt(i).Value);
                string sDate = tDate.Month + "/" + tDate.Day;
                volumeDic.Add(sDate, tVolume);
            }

            return volumeDic;
        }

        public async Task<Dictionary<string, double>> GetChartLabels(int fIndex, int sIndex)
        {
            // returns a dictionary with historical volumes ex. [5/28, 55544345]
            Dictionary<string, double> priceDic = new Dictionary<string, double>();
            await GetHistoricalPricesDates(DateTime.Today.AddDays(-20), DateTime.Today.AddDays(1));
            int first = this.PriceHistoryDates.Count - fIndex - sIndex - 1;        

            for (int i = first; i < this.PriceHistoryDates.Count; i++)
            {
                DateTime tDate = this.PriceHistoryDates.ElementAt(i).Key;
                double tPrice = Convert.ToDouble(this.PriceHistoryDates.ElementAt(i).Value);
                string sDate = tDate.Month + "/" + tDate.Day;          
                priceDic.Add(sDate, tPrice);
            }

            return priceDic;
        }

        public async Task<List<string>> GetPriceLabels(int fIndex, int sIndex)
        {   
            // calculates and returns two prices and percent as strings in list ex. [$123.33, $125.45, 1.72%]
            List<string> priceList = new List<string>();
            await GetHistoricalPrices(DateTime.Today.AddDays(-20), DateTime.Today.AddDays(1));
            int first = this.PriceHistory.Count - fIndex - sIndex - 1;
            int second = this.PriceHistory.Count - sIndex - 1;
            decimal price1 = this.PriceHistory.ElementAt(first).Value;
            decimal price2 = this.PriceHistory.ElementAt(second).Value;
            decimal rawPercent = (price2 - price1) / price1;
            string finalPercent = rawPercent.ToString("P", CultureInfo.InvariantCulture);
            string strPrice1 = "$" + Math.Round(price1, 2).ToString();
            string strPrice2 = "$" + Math.Round(price2, 2).ToString();
            priceList.Add(this.ticker);
            priceList.Add(strPrice1);
            priceList.Add(strPrice2);
            priceList.Add(finalPercent);
            priceList.Add(rawPercent.ToString());
            return priceList;
        }

        public async Task<List<string>> GetDateLabels(int fIndex, int sIndex)
        {
            // calculates and returns two dates as strings in a list ex. [5/28, 5/30]
            List<string> dateList = new List<string>();        
            await GetHistoricalPricesDates(DateTime.Today.AddDays(-20), DateTime.Today.AddDays(1));
            int first = this.PriceHistoryDates.Count - fIndex - sIndex - 1;
            int second = this.PriceHistoryDates.Count - sIndex - 1;
            DateTime firstDate = this.PriceHistoryDates.ElementAt(first).Key;
            DateTime secondDate = this.PriceHistoryDates.ElementAt(second).Key;
            string strFirstDate = firstDate.Month + "/" + firstDate.Day;
            string strSecondDate = secondDate.Month + "/" + secondDate.Day;
            dateList.Add(strFirstDate);
            dateList.Add(strSecondDate);
            return dateList;
        }

        public async Task<bool> StockConform(int uIndex, int dIndex)
        {
            // test and see if stock qualifies for number of up days and number of down days
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
            // gets the historical dates/prices and insert it into dictionary
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

        public async Task GetHistoricalVolumes(DateTime start, DateTime end)
        {
            // method that gets the historical volumes to graph
            var history = await Yahoo.GetHistoricalAsync(ticker, start, end);
            this.VolumeHistory = new Dictionary<DateTime, decimal>();

            foreach (var point in history)
                this.VolumeHistory.Add(point.DateTime, point.Volume);
        }

        public async Task GetDividendDate()
        {
            // gets the UNIX dividend date and convert to local time
            var stock = await Yahoo.Symbols(ticker).Fields(Field.DividendDate).QueryAsync();
            var stockTic = stock[ticker];
            double dateInSeconds;

            // try to get the dividend date if there is one, or else set it to 01/01/1900
            try
            {
                dateInSeconds = stockTic[Field.DividendDate];
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dt = dt.AddSeconds(dateInSeconds).ToLocalTime();
                this.DividendDate = dt;
            }
            catch (Exception)
            {
                this.DividendDate = new DateTime(1900, 1, 1);  
            }
        }

        public async Task GetEarningsDate()
        {
            // gets the UNIX earnings date and covert it to local time
            var stock = await Yahoo.Symbols(ticker).Fields(Field.EarningsTimestampStart).QueryAsync();
            var stockTic = stock[ticker];
            double dateInSeconds;

            // try to get earnings date if there is one, or else set it to 01/01/1900
            try
            {
                dateInSeconds = stockTic[Field.EarningsTimestampStart];
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dt = dt.AddSeconds(dateInSeconds).ToLocalTime();
                this.EarningsDate = dt;
            }
            catch (Exception)
            {
                this.EarningsDate = new DateTime(1900, 1, 1); 
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
