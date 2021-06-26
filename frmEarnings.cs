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

    }
}
