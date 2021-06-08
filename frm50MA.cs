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

        private async Task FillListBox(double percentRange)
        {
            lstResults.Items.Clear();
            lstResults.Items.Add("Ticker".PadRight(10) + "% Change");
            lstResults.Items.Add("------".PadRight(10) + "--------");

            for (int i = 0; i < tickerList.Count; i++)
            {
                string ticker = tickerList[i];
                Stock stks = new Stock(ticker);
                await stks.GetStockData();

                double MA50Percent = stks.MA50_Change_Percent;
                double MA200Percent = stks.MA200_Change_Percent;

                if (rad50MA.Checked)
                {
                    if (percentRange == 0.01)
                    {
                        if (Math.Abs(MA50Percent) <= 0.015)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA50_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.02)
                    {
                        if (Math.Abs(MA50Percent) > 0.015 && Math.Abs(MA50Percent) <= 0.025)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA50_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.03)
                    {
                        if (Math.Abs(MA50Percent) > 0.025 && Math.Abs(MA50Percent) <= 0.035)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA50_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.04)
                    {
                        if (Math.Abs(MA50Percent) > 0.035 && Math.Abs(MA50Percent) <= 0.045)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA50_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.05)
                    {
                        if (Math.Abs(MA50Percent) > 0.045 && Math.Abs(MA50Percent) <= 0.055)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA50_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                }
                else if (rad200MA.Checked)
                {
                    if (percentRange == 0.01)
                    {
                        if (Math.Abs(MA200Percent) <= 0.015)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA200_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.02)
                    {
                        if (Math.Abs(MA200Percent) > 0.015 && Math.Abs(MA200Percent) <= 0.025)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA200_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.03)
                    {
                        if (Math.Abs(MA200Percent) > 0.025 && Math.Abs(MA200Percent) <= 0.035)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA200_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.04)
                    {
                        if (Math.Abs(MA200Percent) > 0.035 && Math.Abs(MA200Percent) <= 0.045)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA200_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                    else if (percentRange == 0.05)
                    {
                        if (Math.Abs(MA200Percent) > 0.045 && Math.Abs(MA200Percent) <= 0.055)
                        {
                            lstResults.Items.Add(stks.ticker.PadRight(10) +
                                Math.Round(stks.MA200_Change_Percent * 100, 2).ToString() + "%");
                        }
                    }
                }
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
