﻿using System;
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

        private void ddlTickers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check which type of graph and drop down list index to create chart
            if (this.typeGraph == 1 && ddlTickers.SelectedIndex != -1)
            {

            }
            else if (this.typeGraph == 2 && ddlTickers.SelectedIndex != -1)
            {         
                CreateChart(tickerList[ddlTickers.SelectedIndex]);
            }
        }       

        private void frmCharts_Load(object sender, EventArgs e)
        {
            // add all tickers onto drop down list`
            for (int i = 0; i < tickerList.Count; i++)
                ddlTickers.Items.Add(tickerList[i]);

            // determines which type of graph it is
            if (this.typeGraph == 1)
            {
                // if there is a selection passed in, then graph it
                if (selIndex != -1)
                {
                    ddlTickers.SelectedIndex = selIndex;
                    CreateMAChart(tickerList[selIndex]);
                }
            }
            else if (this.typeGraph == 2)
            {
                // if there is a selection passed in, then graph it
                if (selIndex != -1)
                {
                    ddlTickers.SelectedIndex = selIndex;
                    CreateChart(tickerList[selIndex]);
                }
            }          
        }

        private async void CreateMAChart(string ticker)
        {
            Stock stks = new Stock(ticker);

            // clear the existing charts and set it to line chart and customize it
            chtTrends.Series.Clear();
            chtTrends.Titles.Clear();
            chtTrends.Series.Add("Price");
            chtTrends.Series.Add("50 MA");
            chtTrends.Series.Add("200 MA");
            chtTrends.Series["Price"].BorderWidth = 5;
            chtTrends.Series["50 MA"].BorderWidth = 5;
            chtTrends.Series["200 MA"].BorderWidth = 5;
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
