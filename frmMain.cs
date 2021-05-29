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
using System.IO;

namespace Stock_YahooFinance
{
    public partial class frmMain : Form
    {
        // path to the ticker.txt file
        static string filePath = AppDomain.CurrentDomain.BaseDirectory;
        static string TICKERPATH = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\Ticker.txt"));

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            ReadTickers();            
        }

        private void ReadTickers()
        {
            if (!File.Exists(TICKERPATH))
            {
                MessageBox.Show("File not found");
                return;
            }

            var fileStream = new FileStream(TICKERPATH, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lstTickers.Items.Add(line);
                }
            }
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


            MessageBox.Show(TICKERPATH);
        }
    }
}
