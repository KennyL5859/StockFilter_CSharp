
namespace Stock_YahooFinance
{
    partial class frm50MA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm50MA));
            this.ddlRange = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tosbtnScan = new System.Windows.Forms.ToolStripButton();
            this.tosbtnClear = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.rad200MA = new System.Windows.Forms.RadioButton();
            this.rad50MA = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlRange
            // 
            this.ddlRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRange.FormattingEnabled = true;
            this.ddlRange.Location = new System.Drawing.Point(235, 67);
            this.ddlRange.Name = "ddlRange";
            this.ddlRange.Size = new System.Drawing.Size(78, 33);
            this.ddlRange.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnScan,
            this.tosbtnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(345, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tosbtnScan
            // 
            this.tosbtnScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnScan.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnScan.Image")));
            this.tosbtnScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnScan.Name = "tosbtnScan";
            this.tosbtnScan.Size = new System.Drawing.Size(34, 33);
            this.tosbtnScan.Text = "Scan List";
            this.tosbtnScan.Click += new System.EventHandler(this.tosbtnScan_Click);
            // 
            // tosbtnClear
            // 
            this.tosbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnClear.Image")));
            this.tosbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnClear.Name = "tosbtnClear";
            this.tosbtnClear.Size = new System.Drawing.Size(34, 33);
            this.tosbtnClear.Text = "Clear All";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(345, 22);
            this.statusStrip1.TabIndex = 3;
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
            this.lstResults.Location = new System.Drawing.Point(28, 135);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(285, 340);
            this.lstResults.TabIndex = 4;
            // 
            // rad200MA
            // 
            this.rad200MA.AutoSize = true;
            this.rad200MA.Location = new System.Drawing.Point(130, 76);
            this.rad200MA.Name = "rad200MA";
            this.rad200MA.Size = new System.Drawing.Size(89, 24);
            this.rad200MA.TabIndex = 5;
            this.rad200MA.TabStop = true;
            this.rad200MA.Text = "200 MA";
            this.rad200MA.UseVisualStyleBackColor = true;
            // 
            // rad50MA
            // 
            this.rad50MA.AutoSize = true;
            this.rad50MA.Checked = true;
            this.rad50MA.Location = new System.Drawing.Point(28, 76);
            this.rad50MA.Name = "rad50MA";
            this.rad50MA.Size = new System.Drawing.Size(80, 24);
            this.rad50MA.TabIndex = 6;
            this.rad50MA.TabStop = true;
            this.rad50MA.Text = "50 MA";
            this.rad50MA.UseVisualStyleBackColor = true;
            // 
            // frm50MA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 525);
            this.Controls.Add(this.rad50MA);
            this.Controls.Add(this.rad200MA);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ddlRange);
            this.Name = "frm50MA";
            this.Text = "50 Day Moving Average";
            this.Load += new System.EventHandler(this.frm50MA_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlRange;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tosbtnScan;
        private System.Windows.Forms.ToolStripButton tosbtnClear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.RadioButton rad200MA;
        private System.Windows.Forms.RadioButton rad50MA;
    }
}