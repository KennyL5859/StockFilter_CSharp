
namespace Stock_YahooFinance
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstTickers = new System.Windows.Forms.ListBox();
            this.statusStp = new System.Windows.Forms.StatusStrip();
            this.stslblStauts = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolStp = new System.Windows.Forms.ToolStrip();
            this.tosbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tosbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tosbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStp.SuspendLayout();
            this.tolStp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTickers
            // 
            this.lstTickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTickers.FormattingEnabled = true;
            this.lstTickers.ItemHeight = 25;
            this.lstTickers.Location = new System.Drawing.Point(12, 53);
            this.lstTickers.Name = "lstTickers";
            this.lstTickers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTickers.Size = new System.Drawing.Size(119, 429);
            this.lstTickers.TabIndex = 0;
            // 
            // statusStp
            // 
            this.statusStp.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblStauts,
            this.toslblStatus});
            this.statusStp.Location = new System.Drawing.Point(0, 490);
            this.statusStp.Name = "statusStp";
            this.statusStp.Size = new System.Drawing.Size(529, 28);
            this.statusStp.TabIndex = 1;
            this.statusStp.Text = "statusStrip1";
            // 
            // stslblStauts
            // 
            this.stslblStauts.Name = "stslblStauts";
            this.stslblStauts.Size = new System.Drawing.Size(0, 21);
            // 
            // tolStp
            // 
            this.tolStp.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tolStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnAdd,
            this.tosbtnDelete,
            this.tosbtnEdit,
            this.toolStripSeparator1});
            this.tolStp.Location = new System.Drawing.Point(0, 0);
            this.tolStp.Name = "tolStp";
            this.tolStp.Size = new System.Drawing.Size(529, 38);
            this.tolStp.TabIndex = 2;
            this.tolStp.Text = "toolStrip1";
            // 
            // tosbtnAdd
            // 
            this.tosbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnAdd.Image")));
            this.tosbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnAdd.Name = "tosbtnAdd";
            this.tosbtnAdd.Size = new System.Drawing.Size(34, 33);
            this.tosbtnAdd.Text = "Add Ticker";
            // 
            // tosbtnDelete
            // 
            this.tosbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnDelete.Image")));
            this.tosbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnDelete.Name = "tosbtnDelete";
            this.tosbtnDelete.Size = new System.Drawing.Size(34, 33);
            this.tosbtnDelete.Text = "Delete Ticker";
            this.tosbtnDelete.Click += new System.EventHandler(this.tosbtnDelete_Click);
            // 
            // tosbtnEdit
            // 
            this.tosbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnEdit.Image")));
            this.tosbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnEdit.Name = "tosbtnEdit";
            this.tosbtnEdit.Size = new System.Drawing.Size(34, 33);
            this.tosbtnEdit.Text = "Edit Ticker";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toslblStatus
            // 
            this.toslblStatus.Name = "toslblStatus";
            this.toslblStatus.Size = new System.Drawing.Size(0, 21);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 518);
            this.Controls.Add(this.tolStp);
            this.Controls.Add(this.statusStp);
            this.Controls.Add(this.lstTickers);
            this.Name = "frmMain";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStp.ResumeLayout(false);
            this.statusStp.PerformLayout();
            this.tolStp.ResumeLayout(false);
            this.tolStp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTickers;
        private System.Windows.Forms.StatusStrip statusStp;
        private System.Windows.Forms.ToolStripStatusLabel stslblStauts;
        private System.Windows.Forms.ToolStrip tolStp;
        private System.Windows.Forms.ToolStripButton tosbtnAdd;
        private System.Windows.Forms.ToolStripButton tosbtnDelete;
        private System.Windows.Forms.ToolStripButton tosbtnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toslblStatus;
    }
}

