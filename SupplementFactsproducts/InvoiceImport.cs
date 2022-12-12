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
    public partial class InvoiceImport : DevExpress.XtraEditors.XtraForm
    {
        DataTable Invoice_Import;

        public InvoiceImport()
        {
            InitializeComponent();
        }

        private void InvoiceImport_Load(object sender, EventArgs e)
        {
            {
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                txtVendorName.ReadOnly = true;
                txt_InvoiceId.ReadOnly = true;
                txtProductName.ReadOnly = true;
                txtImportUnitPrice.ReadOnly = true;
                txtIntoMoney.ReadOnly = true;
                txtImportUnitPrice.ReadOnly = true;
                txtImportUnitPrice.Text = "0";
                Functions.FillCombo("SELECT id_vendor, name_vendor FROM vendor", comboVendorId, "id_vendor", "id_vendor");
                comboVendorId.SelectedIndex = -1;
                Functions.FillCombo("SELECT id_Product, name_Product FROM Product", comboProduct, "id_Product", "id_Product");
                comboProduct.SelectedIndex = -1;
                //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
                if (txt_InvoiceId.Text != "")
                {
                    LoadInfoHoaDon();
                    btnDelete.Enabled = true;
                }
                LoadDataGridView();
            }
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.id_Product, b.name_Product, a.NumberOf_Product, b.importUnit_Price,a.intomoney FROM DETAILS_IMPORT AS a, Product AS b WHERE a.id_InvoiceImport = N'" + txt_InvoiceId.Text + "' AND a.id_Product=b.id_Product";
            Invoice_Import = Functions.GetDataToTable(sql);
            dgvInvoiceImport.DataSource = Invoice_Import;
            dgvInvoiceImport.Columns[0].HeaderText = "Product ID";
            dgvInvoiceImport.Columns[1].HeaderText = "Product Name";
            dgvInvoiceImport.Columns[2].HeaderText = "Number of Product";
            dgvInvoiceImport.Columns[3].HeaderText = "Import Unit Price";
            dgvInvoiceImport.Columns[4].HeaderText = "Into Money";
            dgvInvoiceImport.Columns[0].Width = 100;
            dgvInvoiceImport.Columns[1].Width = 130;
            dgvInvoiceImport.Columns[2].Width = 130;
            dgvInvoiceImport.Columns[3].Width = 130;
            dgvInvoiceImport.Columns[4].Width = 130;
            dgvInvoiceImport.AllowUserToAddRows = false;
            dgvInvoiceImport.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT dateOfImport FROM Invoice_Import WHERE id_InvoiceImport = N'" + txt_InvoiceId.Text + "'";
            txtDateTime.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT id_vendor FROM Invoice_Import WHERE id_InvoiceImport = N'" + txt_InvoiceId.Text + "'";
            comboVendorId.Text = Functions.GetFieldValues(str);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            ResetValues();
            txt_InvoiceId.Text = Functions.CreateKey("RI");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txt_InvoiceId.Text = "";
            txtDateTime.Text = DateTime.Now.ToShortDateString();
            comboVendorId.Text = "";
            comboProduct.Text = "";
            txtTotalMoney.Text = "0";
            txtNumberOfProduct.Text = "";
            txtIntoMoney.Text = "0";
            txtImportUnitPrice.Text = "0";
            txtProductName.Text = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT id_InvoiceImport FROM Invoice_Import WHERE id_InvoiceImport=N'" + txt_InvoiceId.Text + "'";
            if (Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (comboVendorId.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboVendorId.Focus();
                    return;
                }
                sql = "INSERT INTO Invoice_Import(id_InvoiceImport, id_vendor, dateofImport, total) VALUES (N'" + txt_InvoiceId.Text.Trim() + "','" +
                        txtDateTime.Value + "',N'" + comboVendorId.SelectedValue + "',N'" + txtTotalMoney.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (comboProduct.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboProduct.Focus();
                return;
            }
            if ((txtNumberOfProduct.Text.Trim().Length == 0) || (txtNumberOfProduct.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumberOfProduct.Text = "";
                txtNumberOfProduct.Focus();
                return;
            }
            sql = "SELECT id_Product FROM DETAILS_IMPORT WHERE id_Product=N'" + comboProduct.SelectedValue + "' AND id_InvoiceImport = N'" + txt_InvoiceId.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesProduct();
                comboProduct.Focus();
                return;
            }
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT numberOf_Product FROM Product WHERE id_Product = N'" + comboProduct.SelectedValue + "'"));
            sql = "INSERT INTO DETAILS_IMPORT(id_InvoiceImport,id_Product,numberOf_Product,intomoney, importUnit_Price) VALUES(N'" 
                + txt_InvoiceId.Text.Trim() + "',N'" + comboProduct.SelectedValue + "'," + txtNumberOfProduct.Text + "," 
                + txtIntoMoney.Text  + "," + txtImportUnitPrice.Text  + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl + Convert.ToDouble(txtNumberOfProduct.Text);
            sql = "UPDATE Product SET numberOf_Product =" + SLcon + " WHERE id_Product= N'" + comboProduct.SelectedValue + "'";
            Functions.RunSQL(sql);

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble((Functions.GetFieldValues("SELECT intomoney FROM Details_Import WHERE id_InvoiceImport = N'" + txt_InvoiceId.Text + "'")));
            Tongmoi = tong + Convert.ToDouble(txtTotalMoney.Text);
            sql = "UPDATE Invoice_Import SET total =" + Tongmoi + " WHERE id_InvoiceImport = N'" + txt_InvoiceId.Text + "'";
            Functions.RunSQL(sql);
            txtTotalMoney.Text = Tongmoi.ToString();
            btnDelete.Enabled = true;
            ResetValuesProduct();
            btnAdd.Enabled = true;
        }
        private void ResetValuesProduct()
        {
            comboProduct.Text = "";
            txtNumberOfProduct.Text = "";
            txtTotalMoney.Text = "0";
        }

        private void txt_InvoiceId_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboProduct.Text == "")
            {
                txtProductName.Text = "";
                txtImportUnitPrice.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT name_Product FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            txtProductName.Text = Functions.GetFieldValues(str);
            str = "SELECT importUnit_Price FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            txtImportUnitPrice.Text = Functions.GetFieldValues(str);
        }

        private void comboVendorId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboVendorId.Text == "")
            {
                txtVendorName.Text = "";
            }
            str = "Select name_vendor from vendor where id_vendor = N'" + comboVendorId.SelectedValue + "'";
            txtVendorName.Text = Functions.GetFieldValues(str);
        }

        private void txtNumberOfProduct_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtNumberOfProduct.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtNumberOfProduct.Text);
            if (txtImportUnitPrice.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtImportUnitPrice.Text);
            tt = sl * dg;
            txtIntoMoney.Text = tt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}