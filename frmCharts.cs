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

        public frmCharts()
        {
            InitializeComponent();
        }

        public frmCharts(List<string> tList, int first, int second, int selected)
        {
            InitializeComponent();
            this.tickerList = tList;
            this.fIndex = first;
            this.sIndex = second;
            this.selIndex = selected;
        }

        private void ddlTickers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // create new chart when new ticker is selected
            if (ddlTickers.SelectedIndex != -1)
            {         
                CreateChart(tickerList[ddlTickers.SelectedIndex]);
            }
        }       

        private void frmCharts_Load(object sender, EventArgs e)
        {
            // add all tickers onto drop down list`
            for (int i = 0; i < tickerList.Count; i++)
                ddlTickers.Items.Add(tickerList[i]);

            // if there is a selection
            if (selIndex != -1)
            {
                ddlTickers.SelectedIndex = selIndex;
                CreateChart(tickerList[selIndex]);
            }           
        }

        private async void CreateChart(string ticker)
        {
            Stock stks = new Stock(ticker);
            var datePrices = await stks.GetChartLabels(fIndex, sIndex);

            // clear the existing charts and set it to line chart and customize it
            chtTrends.Series.Clear();
            chtTrends.Titles.Clear();
            chtTrends.Series.Add("Price");
            chtTrends.Series["Price"].ChartType = SeriesChartType.Line;
            chtTrends.Series["Price"].BorderWidth = 5;

            // format title and set it
            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = ticker;
            chtTrends.Titles.Add(title);

            // customize the chart to look good
            var objChart = chtTrends.ChartAreas[0];
            objChart.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            objChart.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            double yMax = datePrices.ElementAt(0).Value;
            double yMin = datePrices.ElementAt(0).Value;
            double lastPrice = datePrices.ElementAt(datePrices.Count - 1).Value;

            // set line color based on whether stock went up or down
            chtTrends.Series["Price"].Color = yMax > lastPrice ? Color.Red : Color.Green;

            // plot all the x-axis and y-axis
            foreach (var point in datePrices)
            {
                chtTrends.Series["Price"].Points.AddXY(point.Key, point.Value);

                if (point.Value > yMax)
                    yMax = point.Value;

                if (point.Value < yMin)
                    yMin = point.Value;
            }

            objChart.AxisY.Maximum = Math.Round(yMax + (yMax - yMin) * 0.2, 0);
            objChart.AxisY.Minimum = Math.Round(yMin - (yMax - yMin) * 0.2, 0);

            CreateStatusLabels();
        }

        private async void CreateStatusLabels()
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

    }
}
