using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_YahooFinance
{
    public partial class frmEarnings : Form
    {
        List<string> tickerList = new List<string>();
        List<string> selList = new List<string>();
        int selIndex;

        public frmEarnings(List<string> tList, int sIndex)
        {
            InitializeComponent();
            this.tickerList = tList;
            this.selIndex = sIndex;
        }

        private void frmEarnings_Load(object sender, EventArgs e)
        {
            // fill the listbox with tickers and select a ticker
            foreach (string ticker in tickerList)
                lstTickers.Items.Add(ticker);

            lstTickers.SelectedIndex = selIndex;       
        }

        private void tosbtnClear_Click(object sender, EventArgs e)
        {
            // clear results and ticker's selected index
            lstResults.Items.Clear();
            lstTickers.SelectedIndex = -1;
            ChangeStatusLabel();
        }

        private async void tosbtnFilter_Click(object sender, EventArgs e)
        {
            List<List<string>> qualifedDateList = new List<List<string>>();
            selList.Clear();

            // gets the date range from textbox and limit it to 30 days
            int daysRange = txtDaysRange.Text.Length == 0 ? 0 : Convert.ToInt32(txtDaysRange.Text);

            if (daysRange > 30)
            {
                MessageBox.Show("Earnings days range cannot exceed 30 days");
                return;
            }

            // clear results listbox and setup labels
            lstResults.Items.Clear();
            lstResults.Items.Add("Ticker".PadRight(10) + "Earnings".PadRight(12) + "Dividend");
            lstResults.Items.Add("------".PadRight(10) + "--------".PadRight(12) + "--------");        

            // loop thru tickerlist and see which earnings date matches future date chosen
            for (int i = 0; i < tickerList.Count; i++)
            {
                Stock stks = new Stock(tickerList[i]);
                await stks.GetEarningsDate();
                await stks.GetDividendDate();

                // get the earnings and dividend dates if there is one
                DateTime matchDate = DateTime.Today.AddDays(daysRange);
                string eaDate = stks.EarningsDate.Year == 1900 ? "N/A" : stks.EarningsDate.ToString("MM/dd/yy");
                string divDate = stks.DividendDate.Year == 1900 ? "N/A" : stks.DividendDate.ToString("MM/dd/yy");

                if (stks.EarningsDate >= DateTime.Today && stks.EarningsDate <= matchDate)
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(stks.ticker);
                    tempList.Add(eaDate);
                    tempList.Add(divDate);
                    qualifedDateList.Add(tempList);
                }
            }

            // sort based on earliest to latest earnings times
            var sortedEAList = qualifedDateList.OrderBy(x => Convert.ToDateTime(x[1])).ToList();

            // add each result to the results listbox
            foreach (var list in sortedEAList)
            {
                lstResults.Items.Add(list[0].PadRight(10) + list[1].PadRight(12) + list[2]);
                selList.Add(list[0]);
            }

            ChangeStatusLabel();
        }

        private void lstTickers_SelectedIndexChanged(object sender, EventArgs e)
        {        
            if (lstTickers.SelectedIndex != -1)
            {
                // display different dates based on user selection
                string currentTicker = tickerList[lstTickers.SelectedIndex];
                LoadListBox(currentTicker);

                // clear selList add current ticker to selList
                selList.Clear();
                selList.Add(currentTicker);
            }
        }

        private void lstTickers_DoubleClick(object sender, EventArgs e)
        {
            // create chart when user double-clicks on ticker list
            if (lstTickers.SelectedIndex != -1)
            {
                frmCharts newChart = new frmCharts(selList, 6, 6, 0, 0);
                newChart.ShowDialog();
            }
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            // show chart when user double-clicks on a result ticker
            if (lstResults.SelectedIndex > 1)
            {
                int selIndex = lstResults.SelectedIndex - 2;
                frmCharts newChart = new frmCharts(selList, 6, 6, selIndex, 0);
                newChart.ShowDialog();
            }
        }

        private async void LoadListBox(string ticker)
        {
            // clear listbox and re-load the titles 
            lstResults.Items.Clear();
            lstResults.Items.Add("Ticker".PadRight(10) + "Earnings".PadRight(12) + "Dividend");
            lstResults.Items.Add("------".PadRight(10) + "--------".PadRight(12) + "--------");

            // create stock object and call get earnings and dividend date method
            Stock stks = new Stock(ticker);
            await stks.GetEarningsDate();
            await stks.GetDividendDate();

            var eaDate = stks.EarningsDate;
            var divDate = stks.DividendDate;

            // make string earnings N/A if not available or else set it to actual date
            string earningsDate = eaDate.Year == 1900 ? "N/A" : eaDate.ToString("MM/dd/yy");
            string dividendDate = divDate.Year == 1900 ? "N/A" : divDate.ToString("MM/dd/yy");
            lstResults.Items.Add(ticker.PadRight(10) + earningsDate.PadRight(12) + dividendDate);

            ChangeStatusLabel();
        }

        private void txtDaysRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow controls and numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow up to 3 numbers
            if (txtDaysRange.Text.Length == 3 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void ChangeStatusLabel()
        {
            // create a status label based on event
            if (lstResults.Items.Count == 3)
            {
                string ticker = tickerList[lstTickers.SelectedIndex];
                Stock stks = new Stock(ticker);
                await stks.GetStockData();
                double price = Math.Round(stks.RegularMarketPrice, 2);
                string sPrice = "$" + price.ToString();
                stslblStatus.Text = ticker + " - " + sPrice;
            }
            else if (lstResults.Items.Count == 0)
            {
                stslblStatus.Text = "";
            }
            else 
            {
                int matches = lstResults.Items.Count - 2;
                stslblStatus.Text = matches.ToString() + " records matched your criteria";
            }
        }
    }
}
