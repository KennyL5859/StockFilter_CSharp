
namespace Stock_YahooFinance
{
    partial class frmTrend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrend));
            this.lstResults = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.tosbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.tosbtnClear = new System.Windows.Forms.ToolStripButton();
            this.ddlUp = new System.Windows.Forms.ComboBox();
            this.ddlDown = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 23;
            this.lstResults.Location = new System.Drawing.Point(24, 54);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(271, 303);
            this.lstResults.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnSearch,
            this.tosbtnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(612, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 380);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(612, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stslblStatus
            // 
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // picDown
            // 
            this.picDown.Image = global::Stock_YahooFinance.Properties.Resources.Down;
            this.picDown.Location = new System.Drawing.Point(324, 201);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(51, 53);
            this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDown.TabIndex = 4;
            this.picDown.TabStop = false;
            // 
            // picUp
            // 
            this.picUp.Image = global::Stock_YahooFinance.Properties.Resources.Up;
            this.picUp.Location = new System.Drawing.Point(324, 123);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(51, 53);
            this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUp.TabIndex = 3;
            this.picUp.TabStop = false;
            // 
            // tosbtnSearch
            // 
            this.tosbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnSearch.Image")));
            this.tosbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnSearch.Name = "tosbtnSearch";
            this.tosbtnSearch.Size = new System.Drawing.Size(34, 28);
            this.tosbtnSearch.Text = "Search";
            this.tosbtnSearch.Click += new System.EventHandler(this.tosbtnSearch_Click);
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
            // ddlUp
            // 
            this.ddlUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUp.FormattingEnabled = true;
            this.ddlUp.Location = new System.Drawing.Point(406, 143);
            this.ddlUp.Name = "ddlUp";
            this.ddlUp.Size = new System.Drawing.Size(77, 33);
            this.ddlUp.TabIndex = 5;
            // 
            // ddlDown
            // 
            this.ddlDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDown.FormattingEnabled = true;
            this.ddlDown.Location = new System.Drawing.Point(406, 201);
            this.ddlDown.Name = "ddlDown";
            this.ddlDown.Size = new System.Drawing.Size(77, 33);
            this.ddlDown.TabIndex = 6;
            // 
            // frmTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 402);
            this.Controls.Add(this.ddlDown);
            this.Controls.Add(this.ddlUp);
            this.Controls.Add(this.picDown);
            this.Controls.Add(this.picUp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstResults);
            this.Name = "frmTrend";
            this.Text = "Trend Analysis";
            this.Load += new System.EventHandler(this.frmTrend_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStripButton tosbtnSearch;
        private System.Windows.Forms.ToolStripButton tosbtnClear;
        private System.Windows.Forms.PictureBox picUp;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.ComboBox ddlUp;
        private System.Windows.Forms.ComboBox ddlDown;
    }
}