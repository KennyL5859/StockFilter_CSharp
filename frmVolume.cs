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
    public partial class frmVolume : Form
    {
        List<string> tickerList = new List<string>();
        List<string> selList = new List<string>();

        public frmVolume(List<string> tList)
        {
            InitializeComponent();
            this.tickerList = tList;
        }

        private async void tosbtnScan_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            selList.Clear();

            // if it doesn't pass the check, return
            if (!CheckMaskedText(mstDaysRange, mstVolRange))
                return;

            List<List<string>> masterList = new List<List<string>>();      

            // get total days and number of volume days as ints
            int totalDays = mstDaysRange.Text == "" ? 0 : Convert.ToInt32(mstDaysRange.Text);
            int volDays = mstVolRange.Text == "" ? 0 : Convert.ToInt32(mstVolRange.Text);

            // loop thru all the tickers and add the ones that passes inspection
            foreach (string tic in tickerList)
            {
                Stock stks = new Stock(tic);
                List<string> tempList = await stks.CheckVolumeTrend(totalDays, volDays);

                if (tempList[0] == "P")
                    masterList.Add(tempList);
            }

            // add the labels
            string percentLabel = "% " + "\u25B2" + "    ";
            string dateRange = masterList[0][2];
            lstResults.Items.Add("Tickers".PadRight(12) + dateRange.PadRight(17) + percentLabel);
            lstResults.Items.Add("------".PadRight(12) + new string('-', dateRange.Length).PadRight(17) +
                new string('-', percentLabel.Length));

            // sort the master list by descending order
            List<List<string>> sortMasterList = masterList.OrderByDescending(x => Convert.ToDouble(x[3])).ToList();

            // add results to listbox
            foreach (List<string> list in sortMasterList)
            {
                selList.Add(list[1]);
                string percent = Math.Round(Convert.ToDouble(list[3]) * 100, 2).ToString() + "%";
                lstResults.Items.Add(list[1].PadRight(12) + list[4].PadRight(17) + percent);
            }

            // add the status label after results            
            string msg = selList.Count + " records matched the criteria";
            ChangeStatusLabel(stslblStatus, msg);            
        }

        private void tosbtnClear_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
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

        private bool CheckMaskedText(MaskedTextBox m1, MaskedTextBox m2)
        {
            // defensive guarding code to make both maskedtextboxes logical
            int totalDays = mstDaysRange.Text == "" ? 0 : Convert.ToInt32(m1.Text);
            int volDays = mstVolRange.Text == "" ? 0 : Convert.ToInt32(m2.Text);

            if (m1.Text == "" && m2.Text == "")
            {
                MessageBox.Show("Both total days and days above 3 month volume must be filled");
                return false;
            }
            else if (m2.Text == "")
            {
                MessageBox.Show("Days above 3 month volume must be filled");
                return false;
            }
            else if (m1.Text == "")
            {
                MessageBox.Show("Total days range must be filled");
                return false;
            }
            else if (totalDays <= 0)
            {
                MessageBox.Show("Total days must be greater than 0");
                return false;
            }
            else if (volDays > totalDays)
            {
                MessageBox.Show("Number of volume days must be less than total days");
                return false;
            }
            else if (volDays > 60 || totalDays > 60)
            {
                MessageBox.Show("Total number of days and number of volume days must be less than 60");
                return false;
            }

            return true;
        }

    }
}
