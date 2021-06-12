﻿using System;
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
            for (int i = 1; i <= 5; i++)
            {
                ddlDown.Items.Add(i);
                ddlUp.Items.Add(i);
            }
        }

        private async void tosbtnSearch_Click(object sender, EventArgs e)
        {
            // clear listbox items
            lstResults.Items.Clear();

            // prompt user if no up or down number of days is selected
            if (ddlDown.SelectedIndex == -1 && ddlUp.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a up or down number of days.");
                return;
            }

            // setup the up and down indexes and which ones to display first
            int upIndex = ddlUp.SelectedIndex == -1 ? 0 : ddlUp.SelectedIndex + 1;
            int downIndex = ddlDown.SelectedIndex == -1 ? 0 : ddlDown.SelectedIndex + 1;

            // get first and second label based on which one is bigger
            int firstIndex = upIndex > downIndex ? upIndex : downIndex;
            int secondIndex = upIndex > downIndex ? downIndex : upIndex;            

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

            // add the final label to the listbox
            lstResults.Items.Add("Tickers".PadRight(11) + finalLabel1.PadRight(11) + finalLabel2);
            lstResults.Items.Add("-------".PadRight(11) + new string('-', finalLabel1.Length).PadRight(11) +
                new string('-', finalLabel2.Length));       


            foreach (string ticker in tickerList)
            {
                Stock stks = new Stock(ticker);
                bool qualify = await stks.StockConform(upIndex, downIndex);

                if (qualify)
                {
                    var priceList = await stks.GetPriceLabels(upIndex, downIndex);
                    lstResults.Items.Add(stks.ticker.PadRight(11) + priceList[0].PadRight(11) +
                        priceList[1]);
                }
            }

            MessageBox.Show("Done");
        }


        private void tosbtnClear_Click(object sender, EventArgs e)
        {
            string test = "\u2193" + "4 days";

            MessageBox.Show(test);
        }
    }
}
