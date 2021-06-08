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
            foreach (string ticker in tickerList)
            {
                Stock stks = new Stock(ticker);
                bool qualify = await stks.StockConform(0, 2);

                if (qualify)
                {
                    lstResults.Items.Add(stks.ticker);
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
