namespace SupplementFactsproducts
{
    partial class QuanLyKhoHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyKhoHang));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripReceive = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelivery = new System.Windows.Forms.ToolStripButton();
            this.toolStripReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripListOfProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripVendor = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripReceive,
            this.toolStripDelivery,
            this.toolStripReport,
            this.toolStripListOfProduct,
            this.toolStripCustomer,
            this.toolStripVendor,
            this.toolStripClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1127, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripReceive
            // 
            this.toolStripReceive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripReceive.Image")));
            this.toolStripReceive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReceive.Name = "toolStripReceive";
            this.toolStripReceive.Size = new System.Drawing.Size(125, 24);
            this.toolStripReceive.Text = "Good Receive";
            this.toolStripReceive.Click += new System.EventHandler(this.toolStripReceive_Click);
            // 
            // toolStripDelivery
            // 
            this.toolStripDelivery.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelivery.Image")));
            this.toolStripDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelivery.Name = "toolStripDelivery";
            this.toolStripDelivery.Size = new System.Drawing.Size(126, 24);
            this.toolStripDelivery.Text = "Good delivery";
            // 
            // toolStripReport
            // 
            this.toolStripReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripReport.Image")));
            this.toolStripReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReport.Name = "toolStripReport";
            this.toolStripReport.Size = new System.Drawing.Size(78, 24);
            this.toolStripReport.Text = "Report";
            // 
            // toolStripListOfProduct
            // 
            this.toolStripListOfProduct.Image = ((System.Drawing.Image)(resources.GetObject("toolStripListOfProduct.Image")));
            this.toolStripListOfProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripListOfProduct.Name = "toolStripListOfProduct";
            this.toolStripListOfProduct.Size = new System.Drawing.Size(129, 24);
            this.toolStripListOfProduct.Text = "List of product";
            this.toolStripListOfProduct.Click += new System.EventHandler(this.toolStripListOfProduct_Click);
            // 
            // toolStripCustomer
            // 
            this.toolStripCustomer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCustomer.Image")));
            this.toolStripCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCustomer.Name = "toolStripCustomer";
            this.toolStripCustomer.Size = new System.Drawing.Size(83, 24);
            this.toolStripCustomer.Text = "Customer";
            this.toolStripCustomer.Click += new System.EventHandler(this.toolStripCustomer_Click);
            // 
            // toolStripClose
            // 
            this.toolStripClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClose.Image")));
            this.toolStripClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(57, 24);
            this.toolStripClose.Text = "Exit";
            this.toolStripClose.Click += new System.EventHandler(this.toolStripClose_Click);
            // 
            // toolStripVendor
            // 
            this.toolStripVendor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripVendor.Image")));
            this.toolStripVendor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripVendor.Name = "toolStripVendor";
            this.toolStripVendor.Size = new System.Drawing.Size(68, 24);
            this.toolStripVendor.Text = "Vendor";
            this.toolStripVendor.Click += new System.EventHandler(this.toolStripVendor_Click);
            // 
            // QuanLyKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 572);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("QuanLyKhoHang.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuanLyKhoHang";
            this.Text = "QuanLyKhoHang";
            this.Load += new System.EventHandler(this.QuanLyKhoHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripReceive;
        private System.Windows.Forms.ToolStripButton toolStripDelivery;
        private System.Windows.Forms.ToolStripButton toolStripReport;
        private System.Windows.Forms.ToolStripButton toolStripListOfProduct;
        private System.Windows.Forms.ToolStripButton toolStripClose;
        private System.Windows.Forms.ToolStripButton toolStripCustomer;
        private System.Windows.Forms.ToolStripButton toolStripVendor;
    }
}