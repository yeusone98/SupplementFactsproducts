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

        private void toolStripReceive_Click(object sender, EventArgs e)
        {
            ImportReceipt form= new ImportReceipt();
            form.ShowDialog();
        }
    }
}