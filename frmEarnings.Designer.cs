
namespace Stock_YahooFinance
{
    partial class frmEarnings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEarnings));
            this.lstTickers = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tosButtons = new System.Windows.Forms.ToolStrip();
            this.tosbtnFilter = new System.Windows.Forms.ToolStripButton();
            this.tosbtnClear = new System.Windows.Forms.ToolStripButton();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblDaysWithin = new System.Windows.Forms.Label();
            this.txtDaysRange = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tosButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTickers
            // 
            this.lstTickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTickers.FormattingEnabled = true;
            this.lstTickers.ItemHeight = 25;
            this.lstTickers.Location = new System.Drawing.Point(26, 74);
            this.lstTickers.Name = "lstTickers";
            this.lstTickers.Size = new System.Drawing.Size(120, 279);
            this.lstTickers.Sorted = true;
            this.lstTickers.TabIndex = 0;
            this.lstTickers.SelectedIndexChanged += new System.EventHandler(this.lstTickers_SelectedIndexChanged);
            this.lstTickers.DoubleClick += new System.EventHandler(this.lstTickers_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(693, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stslblStatus
            // 
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // tosButtons
            // 
            this.tosButtons.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tosButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnFilter,
            this.tosbtnClear});
            this.tosButtons.Location = new System.Drawing.Point(0, 0);
            this.tosButtons.Name = "tosButtons";
            this.tosButtons.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tosButtons.Size = new System.Drawing.Size(693, 33);
            this.tosButtons.TabIndex = 2;
            this.tosButtons.Text = "toolStrip1";
            // 
            // tosbtnFilter
            // 
            this.tosbtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnFilter.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnFilter.Image")));
            this.tosbtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnFilter.Name = "tosbtnFilter";
            this.tosbtnFilter.Size = new System.Drawing.Size(34, 28);
            this.tosbtnFilter.Text = "Filter ";
            this.tosbtnFilter.Click += new System.EventHandler(this.tosbtnFilter_Click);
            // 
            // tosbtnClear
            // 
            this.tosbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnClear.Image")));
            this.tosbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnClear.Name = "tosbtnClear";
            this.tosbtnClear.Size = new System.Drawing.Size(34, 28);
            this.tosbtnClear.Text = "Clear";
            this.tosbtnClear.Click += new System.EventHandler(this.tosbtnClear_Click);
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 28;
            this.lstResults.Location = new System.Drawing.Point(178, 109);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(442, 256);
            this.lstResults.TabIndex = 3;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            // 
            // lblDaysWithin
            // 
            this.lblDaysWithin.AutoSize = true;
            this.lblDaysWithin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysWithin.Location = new System.Drawing.Point(405, 52);
            this.lblDaysWithin.Name = "lblDaysWithin";
            this.lblDaysWithin.Size = new System.Drawing.Size(136, 25);
            this.lblDaysWithin.TabIndex = 5;
            this.lblDaysWithin.Text = "Days Range:";
            // 
            // txtDaysRange
            // 
            this.txtDaysRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaysRange.Location = new System.Drawing.Point(564, 49);
            this.txtDaysRange.Name = "txtDaysRange";
            this.txtDaysRange.Size = new System.Drawing.Size(56, 30);
            this.txtDaysRange.TabIndex = 6;
            this.txtDaysRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDaysRange_KeyPress);
            // 
            // frmEarnings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 415);
            this.Controls.Add(this.txtDaysRange);
            this.Controls.Add(this.lblDaysWithin);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.tosButtons);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstTickers);
            this.Name = "frmEarnings";
            this.Text = "Earnings Date";
            this.Load += new System.EventHandler(this.frmEarnings_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tosButtons.ResumeLayout(false);
            this.tosButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTickers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStrip tosButtons;
        private System.Windows.Forms.ToolStripButton tosbtnFilter;
        private System.Windows.Forms.ToolStripButton tosbtnClear;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblDaysWithin;
        private System.Windows.Forms.TextBox txtDaysRange;
    }
}