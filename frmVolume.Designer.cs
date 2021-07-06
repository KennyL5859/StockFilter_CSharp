
namespace Stock_YahooFinance
{
    partial class frmVolume
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVolume));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tosbtnScan = new System.Windows.Forms.ToolStripButton();
            this.tosbtnClear = new System.Windows.Forms.ToolStripButton();
            this.tosbtnChart = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblSearchRange = new System.Windows.Forms.Label();
            this.mstDaysRange = new System.Windows.Forms.MaskedTextBox();
            this.mstVolRange = new System.Windows.Forms.MaskedTextBox();
            this.lblDaysRange = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnScan,
            this.tosbtnClear,
            this.tosbtnChart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(761, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tosbtnScan
            // 
            this.tosbtnScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnScan.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnScan.Image")));
            this.tosbtnScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnScan.Name = "tosbtnScan";
            this.tosbtnScan.Size = new System.Drawing.Size(34, 28);
            this.tosbtnScan.Text = "Scan";
            this.tosbtnScan.Click += new System.EventHandler(this.tosbtnScan_Click);
            // 
            // tosbtnClear
            // 
            this.tosbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnClear.Image")));
            this.tosbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnClear.Name = "tosbtnClear";
            this.tosbtnClear.Size = new System.Drawing.Size(34, 28);
            this.tosbtnClear.Text = "Clear";
            // 
            // tosbtnChart
            // 
            this.tosbtnChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnChart.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnChart.Image")));
            this.tosbtnChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnChart.Name = "tosbtnChart";
            this.tosbtnChart.Size = new System.Drawing.Size(34, 28);
            this.tosbtnChart.Text = "Chart";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(761, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stslblStatus
            // 
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 28;
            this.lstResults.Location = new System.Drawing.Point(24, 121);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(713, 284);
            this.lstResults.TabIndex = 2;
            // 
            // lblSearchRange
            // 
            this.lblSearchRange.AutoSize = true;
            this.lblSearchRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchRange.Location = new System.Drawing.Point(20, 64);
            this.lblSearchRange.Name = "lblSearchRange";
            this.lblSearchRange.Size = new System.Drawing.Size(125, 25);
            this.lblSearchRange.TabIndex = 3;
            this.lblSearchRange.Text = "Days Range:";
            // 
            // mstDaysRange
            // 
            this.mstDaysRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstDaysRange.Location = new System.Drawing.Point(151, 61);
            this.mstDaysRange.Mask = "000";
            this.mstDaysRange.Name = "mstDaysRange";
            this.mstDaysRange.Size = new System.Drawing.Size(50, 30);
            this.mstDaysRange.TabIndex = 4;
            this.mstDaysRange.ValidatingType = typeof(int);
            // 
            // mstVolRange
            // 
            this.mstVolRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstVolRange.Location = new System.Drawing.Point(506, 61);
            this.mstVolRange.Mask = "000";
            this.mstVolRange.Name = "mstVolRange";
            this.mstVolRange.Size = new System.Drawing.Size(54, 30);
            this.mstVolRange.TabIndex = 6;
            this.mstVolRange.ValidatingType = typeof(int);
            // 
            // lblDaysRange
            // 
            this.lblDaysRange.AutoSize = true;
            this.lblDaysRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysRange.Location = new System.Drawing.Point(252, 64);
            this.lblDaysRange.Name = "lblDaysRange";
            this.lblDaysRange.Size = new System.Drawing.Size(235, 25);
            this.lblDaysRange.TabIndex = 5;
            this.lblDaysRange.Text = "Days Above 3 Month Avg";
            // 
            // frmVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 447);
            this.Controls.Add(this.mstVolRange);
            this.Controls.Add(this.lblDaysRange);
            this.Controls.Add(this.mstDaysRange);
            this.Controls.Add(this.lblSearchRange);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmVolume";
            this.Text = "Volume Scan";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tosbtnScan;
        private System.Windows.Forms.ToolStripButton tosbtnClear;
        private System.Windows.Forms.ToolStripButton tosbtnChart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblSearchRange;
        private System.Windows.Forms.MaskedTextBox mstDaysRange;
        private System.Windows.Forms.MaskedTextBox mstVolRange;
        private System.Windows.Forms.Label lblDaysRange;
    }
}