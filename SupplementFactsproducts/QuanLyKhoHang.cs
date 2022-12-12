using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupplementFactsproducts.Class;

namespace SupplementFactsproducts
{
    public partial class QuanLyKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public QuanLyKhoHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhoHang_Load(object sender, EventArgs e)
        {
            Functions.Connect();

        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            Application.Exit();
        }

        private void toolStripListOfProduct_Click(object sender, EventArgs e)
        {
            ListOfProduct form = new ListOfProduct();
            form.ShowDialog();
        }


        private void toolStripCustomer_Click(object sender, EventArgs e)
        {
            ListOfCustomer form = new ListOfCustomer();
            form.ShowDialog();
        }

        private void toolStripVendor_Click(object sender, EventArgs e)
        {
            ListOfVendor form= new ListOfVendor();
            form.ShowDialog();
        }

        private void toolStripReceive_Click(object sender, EventArgs e)
        {
            InvoiceImport form = new InvoiceImport();
            form.ShowDialog();
        }

        private void toolStripDelivery_Click(object sender, EventArgs e)
        {
            InvoiceDelivery form = new InvoiceDelivery();
            form.ShowDialog();
        }
    }
}