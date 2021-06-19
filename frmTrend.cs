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
    public partial class frmTrend : Form
    {
        List<string> tickerList = new List<string>();
        List<string> qualifyTicList = new List<string>();

        public frmTrend()
        {
            InitializeComponent();
        }

        public frmTrend(List<string> sList)
        {
            InitializeComponent();
            this.tickerList = sList;
        }

        private void frmTrend_Load(object sender, EventArgs e)
        {
            // populate the drop down lists
            for (int i = 0; i <= 5; i++)
            {
                ddlDown.Items.Add(i);
                ddlUp.Items.Add(i);
            }
        }

        private async void tosbtnSearch_Click(object sender, EventArgs e)
        {
            // clear listbox items and qualified ticker list
            lstResults.Items.Clear();
            qualifyTicList.Clear();

            // prompt user if no up or down number of days is selected
            if (ddlDown.SelectedIndex == -1 && ddlUp.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a up or down number of days.");
                return;
            }

            // setup the up and down indexes and which ones to display first
            int upIndex = ddlUp.SelectedIndex == -1 ? 0 : ddlUp.SelectedIndex;
            int downIndex = ddlDown.SelectedIndex == -1 ? 0 : ddlDown.SelectedIndex;

            // get first and second label based on which one is bigger
            int firstIndex = upIndex >= downIndex ? upIndex : downIndex;
            int secondIndex = upIndex >= downIndex ? downIndex : upIndex;            

            // turn the labels into strings with up and down arrows
            string strFIndex = upIndex > downIndex ? "\u2191" + upIndex : "\u2193" + downIndex;
            string strSIndex = upIndex > downIndex ? "\u2193" + downIndex : "\u2191" + upIndex;

            if (upIndex == downIndex)
            {
                strFIndex = "\u2191" + "\u2193" + upIndex;
                strSIndex = "\u2191" + "\u2193" + downIndex;
            }

            // add dates next to each label
            Stock sts = new Stock("SPY");
            var dateLabels = await sts.GetDateLabels(firstIndex, secondIndex);
            string finalLabel1 = strFIndex + " " + dateLabels[0];
            string finalLabel2 = strSIndex + " " + dateLabels[1];
            string finalLabel3 = "% " + "\u25B2" + "    ";

            // add the final label to the listbox
            lstResults.Items.Add("Tickers".PadRight(11) + finalLabel1.PadRight(11) + finalLabel2.PadRight(11)
                + finalLabel3);
            lstResults.Items.Add("-------".PadRight(11) + new string('-', finalLabel1.Length).PadRight(11) +
                new string('-', finalLabel2.Length).PadRight(11) + new string('-', finalLabel3.Length));       

            // loop thru all tickers in ticker list
            foreach (string ticker in tickerList)
            {
                // create stock object and see if it conforms
                Stock stks = new Stock(ticker);
                bool qualify = await stks.StockConform(upIndex, downIndex);

                // if conform, then add its ticker and prices to listbox
                if (qualify)
                {
                    qualifyTicList.Add(ticker);
                    var priceList = await stks.GetPriceLabels(firstIndex, secondIndex);
                    lstResults.Items.Add(stks.ticker.PadRight(11) + priceList[0].PadRight(11) +
                        priceList[1].PadRight(11) + priceList[2]);
                }
            }

            // display number of matches on status label
            int numMatches = lstResults.Items.Count - 2;
            string msg = numMatches.ToString() + " records matched the criteria";
            ChangeStatusLabel(stslblStatus, msg);       
        }


        private void ChangeStatusLabel(ToolStripLabel status, string msg)
        {
            // displays the message, then erase it after 5 seconds
            status.Text = msg;

            var timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += (s, e) =>
            {
                status.Text = "";
                timer.Stop();
            };
            timer.Start();
        }

        private void tosbtnClear_Click(object sender, EventArgs e)
        {
            // clear results listbox and qualified ticker list
            lstResults.Items.Clear();
            qualifyTicList.Clear();
        }

        private void tosbtnChart_Click(object sender, EventArgs e)
        {
            if (qualifyTicList.Count == 0)
            {
                MessageBox.Show("You must have qualified stocks in orders to graph");
                return;
            } 

            // setup the up and down indexes and which ones to display first
            int upIndex = ddlUp.SelectedIndex == -1 ? 0 : ddlUp.SelectedIndex;
            int downIndex = ddlDown.SelectedIndex == -1 ? 0 : ddlDown.SelectedIndex;

            // get first and second label based on which one is bigger
            int firstIndex = upIndex > downIndex ? upIndex : downIndex;
            int secondIndex = upIndex > downIndex ? downIndex : upIndex;
            int selTickerIndex = lstResults.SelectedIndex == -1 ? -1 : lstResults.SelectedIndex - 2;

            frmCharts chartForm = new frmCharts(qualifyTicList, firstIndex, secondIndex, selTickerIndex);
            chartForm.ShowDialog();
            

            MessageBox.Show("HI");
        }
    }
}
