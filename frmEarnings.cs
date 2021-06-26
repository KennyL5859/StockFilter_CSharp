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

            LoadListBox(tickerList[selIndex]);

        }

        private void LoadListBox(string ticker)
        {
            // clear listbox and re-load the titles 
            lstResults.Items.Clear();
            lstResults.Items.Add("Ticker".PadRight(10) + "Earnings".PadRight(12) + "Dividend");
            lstResults.Items.Add("------".PadRight(10) + "--------".PadRight(12) + "--------");


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
    }
}
