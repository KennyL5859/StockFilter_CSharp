using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_YahooFinance
{
    public partial class frmCharts : Form
    {
        List<string> tickerList = new List<string>();
        int fIndex;
        int sIndex;
        int selIndex;
        int typeGraph;

        public frmCharts()
        {
            InitializeComponent();
        }

        public frmCharts(List<string> tList, int first, int second, int selected, int type)
        {
            InitializeComponent();
            this.tickerList = tList;
            this.fIndex = first;
            this.sIndex = second;
            this.selIndex = selected;
            this.typeGraph = type;
        }    

        private void frmCharts_Load(object sender, EventArgs e)
        {
            // add all tickers onto drop down list`
            for (int i = 0; i < tickerList.Count; i++)
                ddlTickers.Items.Add(tickerList[i]);

            // create the chart
            CreateMAChart(tickerList[selIndex]);

            ddlTickers.SelectedIndex = selIndex;
        }

        private void ddlTickers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // re-create chart when drop down list changes
            CreateMAChart(tickerList[ddlTickers.SelectedIndex]);
        }

        private async void CreateMAChart(string ticker)
        {
            chkMA50.Checked = false;
            chkMA200.Checked = false;
            

            // create stock object, get all data, and get chart labels
            Stock stks = new Stock(ticker);
            await stks.GetStockData();
            var datePrices = await stks.GetChartLabels(fIndex, sIndex);           

            // clear the existing charts and set it to line chart and customize it
            chtTrends.Series.Clear();
            chtTrends.Titles.Clear();
            chtTrends.Series.Add("Price");
            chtTrends.Series["Price"].ChartType = SeriesChartType.Line; 
            chtTrends.Series["Price"].BorderWidth = 5;

            // make title, format it and set it 
            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = ticker;
            title.ForeColor = Color.Blue;
            chtTrends.Titles.Add(title);

            // customize the chart and get prices data
            var objChart = chtTrends.ChartAreas[0];
            objChart.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            objChart.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            objChart.AxisX.IntervalType = DateTimeIntervalType.Auto;
            double MA50 = stks.MA50;
            double MA200 = stks.MA200;

            // get a starting max/min value to start comparing in loop
            double yMax = Math.Max(datePrices.ElementAt(0).Value, Math.Max(MA50, MA200));
            double yMin = Math.Min(datePrices.ElementAt(0).Value, Math.Min(MA50, MA200));

            // if stock is going up, make line green or else make it red
            chtTrends.Series["Price"].Color = datePrices.ElementAt(0).Value > datePrices.ElementAt(datePrices.Count - 1).Value 
                ? Color.Red : Color.Green;

            // draw the 3 lines and find final maxY and minY
            foreach (var point in datePrices)
            {
                chtTrends.Series["Price"].Points.AddXY(point.Key, point.Value); 

                if (point.Value > yMax)
                    yMax = point.Value;

                if (point.Value < yMin)
                    yMin = point.Value;
            }

            // add 20% more cushion to top and bottom of graph and label it
            objChart.AxisY.Maximum = Math.Round(yMax + (yMax - yMin) * 0.2, 0);
            objChart.AxisY.Minimum = Math.Round(yMin - (yMax - yMin) * 0.2, 0);

            if (typeGraph == 2)
                CreatePriceStatusLabels();
            else
                CreateMAStatusLabels();

        }  

        private async void CreateMAStatusLabels()
        {
            // create status label and show 50MA and 200MA prices
            stslblStatus.Text = "";
            string ticker = tickerList[ddlTickers.SelectedIndex];
            Stock stks = new Stock(ticker);
            await stks.GetStockData();
            string MA50 = "MA50: $" + Math.Round(stks.MA50, 2).ToString();
            string MA200 = "MA200: $" + Math.Round(stks.MA200, 2).ToString();
            string statusLabel = stks.MA50 < stks.MA200 ? MA50 + "   " + MA200 + "  " +
                "\u271C" : MA50 + "   " + MA200;
            stslblStatus.Text = statusLabel;
        }

        private async void CreatePriceStatusLabels()
        {
            // create a status label that shows begin price, end price and percentage change
            stslblStatus.Text = "";
            string ticker = tickerList[ddlTickers.SelectedIndex];
            Stock stks = new Stock(ticker);
            var dates = await stks.GetDateLabels(fIndex, sIndex);
            var prices = await stks.GetPriceLabels(fIndex, sIndex);
            string first = dates[0] + "-" + prices[0];
            string second = dates[1] + "-" + prices[1];
            stslblStatus.Text = first + "    " + second + "     " + prices[2];
        }

        private async void chkMA50_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMA50.Checked)
            {
                // create stock object using ticker on drop down list
                string ticker = tickerList[ddlTickers.SelectedIndex];
                Stock stks = new Stock(ticker);
                var datePrices = await stks.GetChartLabels(fIndex, sIndex);
                await stks.GetStockData();

                double MA50 = stks.MA50;

                // create a series and format it
                chtTrends.Series.Add("50 MA");
                chtTrends.Series["50 MA"].ChartType = SeriesChartType.Line;
                chtTrends.Series["50 MA"].BorderWidth = 3;
                chtTrends.Series["50 MA"].LegendText = "50 Day MA";
                chtTrends.Series["50 MA"].LegendToolTip = "50 Day Moving Average Prices";
                
                foreach (var point in datePrices)                
                    chtTrends.Series["50 MA"].Points.AddXY(point.Key, MA50);
            }
            else
            {
                chtTrends.Series.Remove(chtTrends.Series["50 MA"]);
            }
        }

        private async void chkMA200_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMA200.Checked)
            {
                // create stock object using ticker on drop down list
                string ticker = tickerList[ddlTickers.SelectedIndex];
                Stock stks = new Stock(ticker);
                var datePrices = await stks.GetChartLabels(fIndex, sIndex);
                await stks.GetStockData();

                double MA200 = stks.MA200;

                // create a series and format it
                chtTrends.Series.Add("200 MA");
                chtTrends.Series["200 MA"].ChartType = SeriesChartType.Line;
                chtTrends.Series["200 MA"].BorderWidth = 3;
                chtTrends.Series["200 MA"].LegendText = "200 Day MA";
                chtTrends.Series["200 MA"].LegendToolTip = "200 Day Moving Average Prices";

                foreach (var point in datePrices)
                    chtTrends.Series["200 MA"].Points.AddXY(point.Key, MA200);
            }
            else
            {
                chtTrends.Series.Remove(chtTrends.Series["200 MA"]);
            }
        }
    }
}
