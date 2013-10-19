namespace VendingAccountant
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dgvServiceVisits = new System.Windows.Forms.DataGridView();
            this.bwDataLoader = new System.ComponentModel.BackgroundWorker();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.lbPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceVisits)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.btnNext,
            this.lbPage,
            this.btnPrev,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(893, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton2.Text = "Obnovit";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dgvServiceVisits
            // 
            this.dgvServiceVisits.AllowUserToAddRows = false;
            this.dgvServiceVisits.AllowUserToDeleteRows = false;
            this.dgvServiceVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiceVisits.Location = new System.Drawing.Point(0, 25);
            this.dgvServiceVisits.MultiSelect = false;
            this.dgvServiceVisits.Name = "dgvServiceVisits";
            this.dgvServiceVisits.ReadOnly = true;
            this.dgvServiceVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceVisits.Size = new System.Drawing.Size(893, 531);
            this.dgvServiceVisits.TabIndex = 8;
            this.dgvServiceVisits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiceVisits_CellDoubleClick);
            // 
            // bwDataLoader
            // 
            this.bwDataLoader.WorkerReportsProgress = true;
            this.bwDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDataLoader_DoWork);
            // 
            // btnNext
            // 
            this.btnNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(23, 22);
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lbPage
            // 
            this.lbPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(30, 22);
            this.lbPage.Text = "1 / 1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(192, 22);
            this.toolStripButton1.Text = "Zadat hotovost a stav počítadla";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 556);
            this.Controls.Add(this.dgvServiceVisits);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Návštěvy techniků";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceVisits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dgvServiceVisits;
        private System.ComponentModel.BackgroundWorker bwDataLoader;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripLabel lbPage;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

    }
}