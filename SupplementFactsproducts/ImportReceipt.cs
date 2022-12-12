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
using System.Data.SqlClient;
using SupplementFactsproducts.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace SupplementFactsproducts
{
    
    public partial class ImportReceipt : DevExpress.XtraEditors.XtraForm
    {
        DataTable Invoice_Import;
        public ImportReceipt()
        {
            InitializeComponent();
        }

        private void ImportReceipt_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            totalMoney.ReadOnly = true;
            totalMoney.Text = "0";
            string str = "SELECT id_vendor, name_vendor FROM vendor";
            Functions.FillCombo(str, comboVendor, "id_vendor", "name_vendor");
            comboVendor.SelectedIndex = -1;
            string str2 = "SELECT id_Product, name_Product FROM Product";
            Functions.FillCombo(str2, comboProduct, "id_Product", "name_Product");
            comboProduct.SelectedIndex = -1;
            if (id_receipt.Text != "")
            {
                LoadInfoHoaDon();
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
            }
            LoadDataGridView();
        }

        //Load dât lên grid
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.id_Product, b.name_Product, a.numberOf_Product, b.unitSelling_Price,a.intomoney FROM Details_Import AS a, Product AS b WHERE a.id_InvoiceImport = N'" + id_receipt.Text + "' AND a.id_Product = b.id_Product";
            Invoice_Import = Functions.GetDataToTable(sql);
            dgvImportReceipt.DataSource = Invoice_Import;
            dgvImportReceipt.Columns[0].HeaderText = "ID Product";
            dgvImportReceipt.Columns[1].HeaderText = "Product Name";
            dgvImportReceipt.Columns[2].HeaderText = "Number Of Product";
            dgvImportReceipt.Columns[3].HeaderText = "Unit Cost";    
            dgvImportReceipt.Columns[4].HeaderText = "Into Money";
            dgvImportReceipt.Columns[0].Width = 100;
            dgvImportReceipt.Columns[1].Width = 160;
            dgvImportReceipt.Columns[2].Width = 130;
            dgvImportReceipt.Columns[3].Width = 130;
            dgvImportReceipt.Columns[4].Width = 130;
            dgvImportReceipt.AllowUserToAddRows = false;
            dgvImportReceipt.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT dateofImport FROM Invoice_Import WHERE id_InvoiceImport = N'" + id_receipt.Text + "'";
            dateImport.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT id_vendor FROM Invoice_Import WHERE id_InvoiceImport = N'" + id_receipt.Text + "'";
            comboVendor.Text = Functions.GetFieldValues(str);
            str = "SELECT total FROM Invoice_Import WHERE id_InvoiceImport = N'" + id_receipt.Text + "'";
            totalMoney.Text = Functions.GetFieldValues(str);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
            btnAdd.Enabled = false;
            ResetValues();
            id_receipt.Text = Functions.CreateKey("RI");
            LoadDataGridView();
        }

        private void ResetValues()
        {
            id_receipt.Text = "";
            dateImport.Value = DateTime.Now;
            comboVendor.Text = "";
            totalMoney.Text = "0";
            comboProduct.Text = "";
            numberOfProduct.Text = "";
        }

        private void ResetValuesProduct()
        {
            comboProduct.Text = "";
            numberOfProduct.Text = "";
            intomoney.Text = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT id_InvoiceImport FROM Invoice_Import WHERE id_InvoiceImport=N'" + id_receipt.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (comboVendor.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboVendor.Focus();
                    return;
                }
                sql = "INSERT INTO Invoice_Import(id_InvoiceImport, id_vendor, dateofImport, total) VALUES (N'" + id_receipt.Text.Trim() + "',N'" + comboVendor.SelectedValue + "','" +
                        dateImport.Value + "'," + totalMoney.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (comboProduct.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboProduct.Focus();
                return;
            }
            if ((numberOfProduct.Text.Trim().Length == 0) || (numberOfProduct.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numberOfProduct.Text = "";
                numberOfProduct.Focus();
                return;
            }
           
            sql = "SELECT id_Product FROM Details_Import WHERE id_Product=N'" + comboProduct.SelectedValue + "' AND id_InvoiceImport = N'" + id_receipt.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesProduct();
                comboProduct.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT numberOf_Product FROM Product WHERE id_Product = N'" + comboProduct.SelectedValue + "'").ToString());
            //if (Convert.ToDouble(numberOfProduct.Text) > sl)
            //{
            //    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    numberOfProduct.Text = "";
            //    numberOfProduct.Focus();
            //    return;
            //}
            sql = "INSERT INTO Details_Import(id_InvoiceImport,id_Product,numberOf_Product,unitSelling_Price,intomoney) VALUES(N'" + id_receipt.Text.Trim() + "',N'" + comboProduct.SelectedValue + "'," + numberOfProduct.Text + "," + unitCost.Text  + "," + intomoney.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl + Convert.ToDouble(numberOfProduct.Text);
            sql = "UPDATE Product SET numberOf_Product =" + SLcon + " WHERE id_Product= N'" + comboProduct.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT total FROM Invoice_Import WHERE id_InvoiceImport = N'" + id_receipt.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(intomoney.Text);
            sql = "UPDATE Invoice_Import SET total =" + Tongmoi + " WHERE id_InvoiceImport = N'" + id_receipt.Text + "'";
            Functions.RunSQL(sql);
            totalMoney.Text = Tongmoi.ToString();
            ResetValuesProduct();
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnPrint.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT id_Product,numberOf_Product FROM Details_Import WHERE id_InvoiceImport = N'" + id_receipt.Text + "'";
                DataTable Product = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= Product.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT numberOf_Product FROM Product WHERE id_Product = N'" + Product.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(Product.Rows[hang][1].ToString());
                    slcon = sl - slxoa;
                    sql = "UPDATE Product SET numberOf_Product =" + slcon + " WHERE id_Product= N'" + Product.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE Details_Import WHERE id_InvoiceImport=N'" + id_receipt.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE Invoice_Import WHERE id_InvoiceImport=N'" + id_receipt.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnDelete.Enabled = false;
                btnPrint.Enabled = false;
            }
        }
      
        private void comboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboVendor.Text == "")
            {
                vendorName.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select name_vendor from vendor where id_vendor = N'" + comboVendor.SelectedValue + "'";
            vendorName.Text = Functions.GetFieldValues(str);
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboProduct.Text == "")
            {
                productName.Text = "";
                unitCost.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT name_Product FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            productName.Text = Functions.GetFieldValues(str);
            str = "SELECT unitSelling_Price FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            unitCost.Text = Functions.GetFieldValues(str);
        }

        private void numberOfProduct_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg;
            if (numberOfProduct.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(numberOfProduct.Text.ToString());
           
            if (unitCost.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(unitCost.Text);
            tt = sl * dg - sl * dg  / 100;
            intomoney.Text = tt.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}