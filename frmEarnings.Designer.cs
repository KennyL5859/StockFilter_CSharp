
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
            this.lstTickers = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tosButtons = new System.Windows.Forms.ToolStrip();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpDates = new System.Windows.Forms.TabPage();
            this.tbpFilter = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTickers
            // 
            this.lstTickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTickers.FormattingEnabled = true;
            this.lstTickers.ItemHeight = 25;
            this.lstTickers.Location = new System.Drawing.Point(25, 49);
            this.lstTickers.Name = "lstTickers";
            this.lstTickers.Size = new System.Drawing.Size(120, 329);
            this.lstTickers.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
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
            this.tosButtons.Location = new System.Drawing.Point(0, 0);
            this.tosButtons.Name = "tosButtons";
            this.tosButtons.Size = new System.Drawing.Size(693, 25);
            this.tosButtons.TabIndex = 2;
            this.tosButtons.Text = "toolStrip1";
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpDates);
            this.tbcMain.Controls.Add(this.tbpFilter);
            this.tbcMain.Location = new System.Drawing.Point(192, 49);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(439, 329);
            this.tbcMain.TabIndex = 3;
            // 
            // tbpDates
            // 
            this.tbpDates.Location = new System.Drawing.Point(4, 29);
            this.tbpDates.Name = "tbpDates";
            this.tbpDates.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDates.Size = new System.Drawing.Size(431, 296);
            this.tbpDates.TabIndex = 0;
            this.tbpDates.Text = "Dates";
            this.tbpDates.UseVisualStyleBackColor = true;
            // 
            // tbpFilter
            // 
            this.tbpFilter.Location = new System.Drawing.Point(4, 29);
            this.tbpFilter.Name = "tbpFilter";
            this.tbpFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFilter.Size = new System.Drawing.Size(431, 296);
            this.tbpFilter.TabIndex = 1;
            this.tbpFilter.Text = "Filter";
            this.tbpFilter.UseVisualStyleBackColor = true;
            // 
            // frmEarnings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 416);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.tosButtons);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstTickers);
            this.Name = "frmEarnings";
            this.Text = "Earnings Date";
            this.Load += new System.EventHandler(this.frmEarnings_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTickers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStrip tosButtons;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpDates;
        private System.Windows.Forms.TabPage tbpFilter;
    }
}