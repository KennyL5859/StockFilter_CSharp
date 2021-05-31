using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_YahooFinance
{
    public partial class frmAddEdit : Form
    {
        List<string> tickerLists = new List<string>();
        ListBox lstTickers = new ListBox();
        bool isAdd;
        int selIndex;
        public frmAddEdit()
        {
            InitializeComponent();
        }        

        public frmAddEdit(List<string> tList, bool add, int index, ListBox lst)
        {
            InitializeComponent();
            this.tickerLists = tList;
            this.isAdd = add;
            this.selIndex = index;
            this.lstTickers = lst;
        }

        private void frmAddEdit_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                this.Text = "Add New Ticker";
                btnAdd.Text = "Add";
            }
            else
            {
                this.Text = "Edit Ticker";
                btnAdd.Text = "Save";
                txtTicker.Text = tickerLists[selIndex];
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtTicker.BackColor = Color.White;

            if (!CheckTickerRegex(txtTicker, "Ticker symbol must be 1 to 4 letters eg. TSLA, ba"))
                return;

            if (isAdd)
            {
                // add ticker to the tickerlist
                if (!CheckForDuplicate(tickerLists, txtTicker))
                    return;

                string ticker = txtTicker.Text.ToUpper();
                tickerLists.Add(ticker);
                txtTicker.Clear();
                string msg = ticker + " have been added to the list.";
                ChangeStatusLabel(stslblStatus, msg);
            }
            else
            {
                // update the ticker from old to new and close the form
                if (!CheckForEditingDuplicate(tickerLists, txtTicker, selIndex))
                    return;

                string oldTicker = tickerLists[selIndex];
                string newTicker = txtTicker.Text.ToUpper();
                tickerLists[selIndex] = newTicker;
                txtTicker.Clear();
                this.Close();
            }

            // update the grid list as user adds/edits tickers
            lstTickers.DataSource = null;
            lstTickers.DataSource = tickerLists;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTicker.Clear();
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

        private bool CheckForEditingDuplicate(List<string> tickList, TextBox txt, int index)
        {
            // this is a duplication check when user is in edit mode
            List<string> tempList = new List<string>(tickerLists);
            tempList.RemoveAt(index);

            if (tempList.Contains(txt.Text.ToUpper()))
            {
                MessageBox.Show(txt.Text + " is a duplicate ticker");
                txt.BackColor = Color.LightYellow;
                return false;
            }
            else
            {
                return true;
            }         
        }

        private bool CheckForDuplicate(List<string> tickList, TextBox txt)
        {
            // check for duplicate ticker in ticker lists
            if (tickList.Contains(txt.Text.ToUpper()))
            {
                MessageBox.Show(txt.Text + " is a duplicate ticker");
                txt.BackColor = Color.LightYellow;
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckTickerRegex(TextBox txt, string msg)
        {
            // checks the patter of the tickers must be 1 to 4 letters e.g. TSLA
            string pattern = @"^[A-Za-z]{1,4}$";
            Match m = Regex.Match(txt.Text, pattern);

            if (m.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(msg);
                txt.BackColor = Color.LightYellow;
                return false;
            }
        }

        private void txtTicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow backspace to pass through
            if (e.KeyChar == (char)Keys.Back)
                return;

            // if text length is >= 4, then stop letting user enter more
            if (txtTicker.Text.Length >=4)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
