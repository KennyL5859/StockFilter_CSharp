using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceApi;

namespace Stock_YahooFinance
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GetPrice();
        }

        private static async void GetPrice()
        {
            var securities = await Yahoo.Symbols("AAPL", "GOOG").Fields(Field.Symbol, Field.RegularMarketPrice, 
                        Field.FiftyTwoWeekHigh, Field.ShortName, Field.FiftyDayAverage).QueryAsync();
            var aapl = securities["AAPL"];
            var price = aapl[Field.FiftyDayAverage];


            var historyData = await Yahoo.GetHistoricalAsync("AAPL", new DateTime(2021, 5, 1),
                new DateTime(2021, 5, 28), Period.Daily);

            var data1 = historyData[0];


            MessageBox.Show("hi");

        }
    }
}
