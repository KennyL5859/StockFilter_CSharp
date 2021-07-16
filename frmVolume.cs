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

        public frmVolume(List<string> tList)
        {
            InitializeComponent();
            this.tickerList = tList;
        }

        private async void tosbtnScan_Click(object sender, EventArgs e)
        {
            // if it doesn't pass the check, return
            if (!CheckMaskedText(mstDaysRange, mstVolRange))
                return;

            // get total days and number of volume days as ints
            int totalDays = mstDaysRange.Text == "" ? 0 : Convert.ToInt32(mstDaysRange.Text);
            int volDays = mstVolRange.Text == "" ? 0 : Convert.ToInt32(mstVolRange.Text);

            Stock stks = new Stock("BA");
            await stks.CheckVolumeTrend(totalDays, volDays);
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
            else if (volDays > 90 || totalDays > 90)
            {
                MessageBox.Show("Total number of days and number of volume days must be less than 90");
                return false;
            }

            return true;
        }
    }
}
