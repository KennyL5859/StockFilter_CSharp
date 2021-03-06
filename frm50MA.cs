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
    public partial class frm50MA : Form
    {
        List<string> tickerList = new List<string>();
        List<string> ticList = new List<string>();
        public frm50MA()
        {
            InitializeComponent();
        }

        public frm50MA(List<string> ticList)
        {
            InitializeComponent();
            this.tickerList = ticList;
        }

        private void frm50MA_Load(object sender, EventArgs e)
        {
            ddlRange.Items.Add("1%");
            ddlRange.Items.Add("2%");
            ddlRange.Items.Add("3%");
            ddlRange.Items.Add("4%");
            ddlRange.Items.Add("5%");
        }

        private async void tosbtnScan_Click(object sender, EventArgs e)
        {
            // warn user if there is no range percent selected
            if (ddlRange.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a range");
                return;
            }

            // ternary operator to get the user selected percentage
            double percentRange = ddlRange.SelectedIndex == 0 ? 0.01 :
                ddlRange.SelectedIndex == 1 ? 0.02 : ddlRange.SelectedIndex == 2 ?
                0.03 : ddlRange.SelectedIndex == 3 ? 0.04 : 0.05;

            // call FillListBox Async method
            await FillListBox(percentRange);

            // display number of matches on status bar
            int matches = lstResults.Items.Count - 2;
            string msg = matches + " stocks fit the criteria";
            ChangeStatusLabel(stslblStatus, msg);
        }

        private void tosbtnClear_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
        }

        private void tosbtnChart_Click(object sender, EventArgs e)
        {
            // clear contents of ticList
            ticList.Clear();

            // if there are no tickers to chart, prompt the user
            if (lstResults.Items.Count <= 2)
            {
                MessageBox.Show("There are now stocks to chart");
                return;
            }

            // add tickers to the ticList
            for (int i = 2; i < lstResults.Items.Count; i++)
            {
                string[] splitTics = lstResults.Items[i].ToString().Split(' ');
                ticList.Add(splitTics[0]);
            }

            // create Chart form object and display it and pass in selected index of listbox
            int selIndex = lstResults.SelectedIndex == -1 ? -1 : lstResults.SelectedIndex - 2;
            frmCharts newChart = new frmCharts(ticList, 6, 6, selIndex, 1);
            newChart.ShowDialog();
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 2)
                tosbtnChart_Click(sender, e);
        }

        private async Task FillListBox(double percentRange)
        {
            List<List<string>> qualifiedList = new List<List<string>>();

            // fill in the listbox based on moving average percentages criteria
            lstResults.Items.Clear();
            lstResults.Items.Add("Ticker".PadRight(10) + "% Change");
            lstResults.Items.Add("------".PadRight(10) + "--------");

            // loop through tickerlist and determine whether stock fits percentage criteria
            // if it fits, then add it to the templist which is added to qualifed list
            for (int i = 0; i < tickerList.Count; i++)
            {
                string ticker = tickerList[i];
                Stock stks = new Stock(ticker);
                await stks.GetStockData();

                double MA50Percent = stks.MA50_Change_Percent;
                double MA200Percent = stks.MA200_Change_Percent;

                List<string> tempList = new List<string>();
                

                if (rad50MA.Checked)
                {
                    if (percentRange == 0.01)
                    {
                        if (Math.Abs(MA50Percent) <= 0.015)
                        { 
                            tempList.Add(stks.ticker);
                            tempList.Add(MA50Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.02)
                    {
                        if (Math.Abs(MA50Percent) > 0.015 && Math.Abs(MA50Percent) <= 0.025)
                        {                
                            tempList.Add(stks.ticker);
                            tempList.Add(MA50Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.03)
                    {
                        if (Math.Abs(MA50Percent) > 0.025 && Math.Abs(MA50Percent) <= 0.035)
                        {          
                            tempList.Add(stks.ticker);
                            tempList.Add(MA50Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.04)
                    {
                        if (Math.Abs(MA50Percent) > 0.035 && Math.Abs(MA50Percent) <= 0.045)
                        {           
                            tempList.Add(stks.ticker);
                            tempList.Add(MA50Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.05)
                    {
                        if (Math.Abs(MA50Percent) > 0.045 && Math.Abs(MA50Percent) <= 0.055)
                        {               
                            tempList.Add(stks.ticker);
                            tempList.Add(MA50Percent.ToString());
                        }
                    }                   
                }
                else if (rad200MA.Checked)
                {
                    if (percentRange == 0.01)
                    {
                        if (Math.Abs(MA200Percent) <= 0.015)
                        {
                            tempList.Add(stks.ticker);
                            tempList.Add(MA200Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.02)
                    {
                        if (Math.Abs(MA200Percent) > 0.015 && Math.Abs(MA200Percent) <= 0.025)
                        {
                            tempList.Add(stks.ticker);
                            tempList.Add(MA200Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.03)
                    {
                        if (Math.Abs(MA200Percent) > 0.025 && Math.Abs(MA200Percent) <= 0.035)
                        {
                            tempList.Add(stks.ticker);
                            tempList.Add(MA200Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.04)
                    {
                        if (Math.Abs(MA200Percent) > 0.035 && Math.Abs(MA200Percent) <= 0.045)
                        {
                            tempList.Add(stks.ticker);
                            tempList.Add(MA200Percent.ToString());
                        }
                    }
                    else if (percentRange == 0.05)
                    {
                        if (Math.Abs(MA200Percent) > 0.045 && Math.Abs(MA200Percent) <= 0.055)
                        {
                            tempList.Add(stks.ticker);
                            tempList.Add(MA200Percent.ToString());
                        }
                    }                    
                }

                // if templist is not empty, then add it to the qualified list
                if (tempList.Count > 0)
                    qualifiedList.Add(tempList);
            }

            // sort the list in ascending order
            var sortedList = qualifiedList.OrderBy(x => Convert.ToDouble(x[1])).ToList();

            // display the results in the listbox results view
            foreach (var list in sortedList)
            {
                lstResults.Items.Add(list[0].PadRight(10) +
                    Math.Round(Convert.ToDouble(list[1]) * 100, 2).ToString() + "%");
            }
        }

        private void ChangeStatusLabel(ToolStripLabel status, string msg)
        {
            // displays the message, then erase it after 5 seconds
            status.Text = msg;

            var timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                status.Text = "";
                timer.Stop();
            };
            timer.Start();
        }
    }
}
