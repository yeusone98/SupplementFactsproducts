namespace SupplementFactsproducts
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoiceDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurnover = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuManagement,
            this.mnuInvoice,
            this.mnuFind,
            this.mnuReport,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(135, 22);
            this.mnuExit.Text = "Exit";
            // 
            // mnuManagement
            // 
            this.mnuManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCustomer,
            this.mnuEmployee,
            this.mnuProduct});
            this.mnuManagement.Name = "mnuManagement";
            this.mnuManagement.Size = new System.Drawing.Size(90, 20);
            this.mnuManagement.Text = "&Management";
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mnuCustomer.Size = new System.Drawing.Size(180, 22);
            this.mnuCustomer.Text = "Customer";
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.mnuEmployee.Size = new System.Drawing.Size(180, 22);
            this.mnuEmployee.Text = "Employee";
            // 
            // mnuProduct
            // 
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mnuProduct.Size = new System.Drawing.Size(180, 22);
            this.mnuProduct.Text = "Product";
            // 
            // mnuInvoice
            // 
            this.mnuInvoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvoiceDetail});
            this.mnuInvoice.Name = "mnuInvoice";
            this.mnuInvoice.Size = new System.Drawing.Size(57, 20);
            this.mnuInvoice.Text = "&Invoice";
            // 
            // mnuInvoiceDetail
            // 
            this.mnuInvoiceDetail.Name = "mnuInvoiceDetail";
            this.mnuInvoiceDetail.Size = new System.Drawing.Size(180, 22);
            this.mnuInvoiceDetail.Text = "InvoiceDetail";
            // 
            // mnuFind
            // 
            this.mnuFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindInvoice,
            this.mnuFindProduct,
            this.mnuFindCustomer});
            this.mnuFind.Name = "mnuFind";
            this.mnuFind.Size = new System.Drawing.Size(42, 20);
            this.mnuFind.Text = "&Find";
            // 
            // mnuFindInvoice
            // 
            this.mnuFindInvoice.Name = "mnuFindInvoice";
            this.mnuFindInvoice.Size = new System.Drawing.Size(180, 22);
            this.mnuFindInvoice.Text = "Find_Invoice";
            // 
            // mnuFindProduct
            // 
            this.mnuFindProduct.Name = "mnuFindProduct";
            this.mnuFindProduct.Size = new System.Drawing.Size(180, 22);
            this.mnuFindProduct.Text = "Find_Product";
            // 
            // mnuFindCustomer
            // 
            this.mnuFindCustomer.Name = "mnuFindCustomer";
            this.mnuFindCustomer.Size = new System.Drawing.Size(180, 22);
            this.mnuFindCustomer.Text = "Find_Customer";
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInventory,
            this.mnuTurnover});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(54, 20);
            this.mnuReport.Text = "&Report";
            // 
            // mnuInventory
            // 
            this.mnuInventory.Name = "mnuInventory";
            this.mnuInventory.Size = new System.Drawing.Size(180, 22);
            this.mnuInventory.Text = "Inventory";
            this.mnuInventory.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // mnuTurnover
            // 
            this.mnuTurnover.Name = "mnuTurnover";
            this.mnuTurnover.Size = new System.Drawing.Size(180, 22);
            this.mnuTurnover.Text = "Turnover";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Supplement Facts products";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoice;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoiceDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuFindInvoice;
        private System.Windows.Forms.ToolStripMenuItem mnuFindProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuFindCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuTurnover;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    }
}

