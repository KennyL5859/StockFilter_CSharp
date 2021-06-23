
namespace Stock_YahooFinance
{
    partial class frmCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtTrends = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ddlTickers = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkMA50 = new System.Windows.Forms.CheckBox();
            this.chkMA200 = new System.Windows.Forms.CheckBox();
            this.chkVolume = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chtTrends)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chtTrends
            // 
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BorderWidth = 5;
            chartArea1.Name = "ChartArea1";
            this.chtTrends.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtTrends.Legends.Add(legend1);
            this.chtTrends.Location = new System.Drawing.Point(35, 109);
            this.chtTrends.Name = "chtTrends";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Price";
            this.chtTrends.Series.Add(series1);
            this.chtTrends.Size = new System.Drawing.Size(708, 330);
            this.chtTrends.TabIndex = 0;
            this.chtTrends.Text = "  ";
            // 
            // ddlTickers
            // 
            this.ddlTickers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTickers.FormattingEnabled = true;
            this.ddlTickers.Location = new System.Drawing.Point(35, 41);
            this.ddlTickers.Name = "ddlTickers";
            this.ddlTickers.Size = new System.Drawing.Size(108, 33);
            this.ddlTickers.TabIndex = 1;
            this.ddlTickers.SelectedIndexChanged += new System.EventHandler(this.ddlTickers_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stslblStatus
            // 
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // chkMA50
            // 
            this.chkMA50.AutoSize = true;
            this.chkMA50.Location = new System.Drawing.Point(187, 50);
            this.chkMA50.Name = "chkMA50";
            this.chkMA50.Size = new System.Drawing.Size(81, 24);
            this.chkMA50.TabIndex = 3;
            this.chkMA50.Text = "MA 50";
            this.chkMA50.UseVisualStyleBackColor = true;
            this.chkMA50.CheckedChanged += new System.EventHandler(this.chkMA50_CheckedChanged);
            // 
            // chkMA200
            // 
            this.chkMA200.AutoSize = true;
            this.chkMA200.Location = new System.Drawing.Point(306, 50);
            this.chkMA200.Name = "chkMA200";
            this.chkMA200.Size = new System.Drawing.Size(90, 24);
            this.chkMA200.TabIndex = 4;
            this.chkMA200.Text = "MA 200";
            this.chkMA200.UseVisualStyleBackColor = true;
            this.chkMA200.CheckedChanged += new System.EventHandler(this.chkMA200_CheckedChanged);
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Location = new System.Drawing.Point(425, 50);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(89, 24);
            this.chkVolume.TabIndex = 5;
            this.chkVolume.Text = "Volume";
            this.chkVolume.UseVisualStyleBackColor = true;
            // 
            // frmCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 486);
            this.Controls.Add(this.chkVolume);
            this.Controls.Add(this.chkMA200);
            this.Controls.Add(this.chkMA50);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ddlTickers);
            this.Controls.Add(this.chtTrends);
            this.Name = "frmCharts";
            this.Text = "Trend Charts";
            this.Load += new System.EventHandler(this.frmCharts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtTrends)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtTrends;
        private System.Windows.Forms.ComboBox ddlTickers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.CheckBox chkMA50;
        private System.Windows.Forms.CheckBox chkMA200;
        private System.Windows.Forms.CheckBox chkVolume;
    }
}