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
        List<string> tickerList = new List<string>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadTickers();
            //GetPrice();
        }

        // method that reads all tickers from text file into list view and ticker list
        private void ReadTickers()
        {
            // prompt user if file is not found
            if (!File.Exists(TICKERPATH))
            {
                MessageBox.Show("File not found");
                return;
            }

            // open the file and read each line (ticker) into List<string> tickerList
            var fileStream = new FileStream(TICKERPATH, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {             
                    tickerList.Add(line);
                }
            }

            UpdateTickerListBox();
        }

        private void tosbtnAdd_Click(object sender, EventArgs e)
        {       
            // opens up the add form when user clicks add button
            frmAddEdit addForm = new frmAddEdit(tickerList, true, 0, lstTickers);
            addForm.ShowDialog();
            UpdateTickerListBox();
            WriteToTextFile();

            lstTickers.SelectedIndex = lstTickers.Items.Count - 1;
            ChangeStatusLabel(stslblStauts, "Listbox have been updated");
        }

        private void tosbtnDelete_Click(object sender, EventArgs e)
        {
            if (lstTickers.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a ticker(s) to delete");
                return;
            }

            List<string> removeList = new List<string>();

            // deletes the selected ticker(s), add the deleted ones onto a
            // temperary remove list
            foreach (var index in lstTickers.SelectedIndices)
            {
                tickerList.Remove((string)lstTickers.Items[(int)index]);
                removeList.Add((string)lstTickers.Items[(int)index]);
            }                

            UpdateTickerListBox();
            WriteToTextFile();

            // make the message and display it for 5 seconds
            string tickers = removeList.Count <= 4 ? string.Join(" ", removeList) : 
                string.Join(" ", removeList.ToArray(), 0, 4) + "...";

            string singularOrPlural = removeList.Count == 1 ? "ticker" : "tickers";
            string message = tickers + " " + singularOrPlural + " have been removed from list.";

            ChangeStatusLabel(toslblStatus, message);
        }

        private void tosbtnEdit_Click(object sender, EventArgs e)
        {
            if (lstTickers.SelectedIndices.Count != 1)
            {
                MessageBox.Show("You must select only one ticker to edit");
                return;
            }

            // opens up the edit form and let user edits the stock ticker
            int sIndex = lstTickers.SelectedIndex;
            string oldTicker = tickerList[sIndex];
            frmAddEdit newEditForm = new frmAddEdit(tickerList, false, sIndex, lstTickers);
            newEditForm.ShowDialog();

            // update Ticker Listbox and write to the text file
            UpdateTickerListBox();
            WriteToTextFile();

            // display which ticker was updated to user
            string newTicker = tickerList[sIndex];
            string msg = oldTicker + " has been updated to " + newTicker;
            ChangeStatusLabel(stslblStauts, msg);
        }

        private void btn50Day_Click(object sender, EventArgs e)
        {
            frm50MA new50MA = new frm50MA(tickerList);
            new50MA.ShowDialog();


        }


        private void UpdateTickerListBox()
        {
            // unlink and then link the datasource to listbox
            lstTickers.DataSource = null;
            lstTickers.DataSource = tickerList;
        }

        private void WriteToTextFile()
        {
            // writes whats in tickerList into text file
            File.WriteAllText(TICKERPATH, string.Empty);

            using (StreamWriter wr = new StreamWriter(TICKERPATH))
            {
                for (int i = 0; i < tickerList.Count; i++)
                {
                    wr.WriteLine(tickerList[i]);
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


        private async void GetPrice()
        {
            //string ticker = "AAPL";
            //var stock = await Yahoo.Symbols(ticker).Fields(Field.FiftyDayAverage).QueryAsync();
            //var stockTic = stock[ticker];
            //double x = Convert.ToDouble(stockTic[Field.FiftyDayAverage]);

            Stock sts = new Stock("QQQ");

            DateTime start = new DateTime(2021, 5, 1);
            DateTime end = new DateTime(2021, 5, 25);

            await sts.GetHistoricalPrices(start, end);

            var test = sts.PriceHistory;





            MessageBox.Show(test.ToString());            

        }


    }
}
