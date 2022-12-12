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
    public partial class InvoiceDelivery : DevExpress.XtraEditors.XtraForm
    {
        DataTable Invoice_Delivery;
        public InvoiceDelivery()
        {
            InitializeComponent();
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void ProductDelivery_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            txtCustomerName.ReadOnly = true;
            txtInvoiceDeliveryId.ReadOnly = true;
            txtProductName.ReadOnly = true;
            txtSellingPrice.ReadOnly = true;
            txtIntoMoney.ReadOnly = true;
            txtSellingPrice.ReadOnly = true;
            txtSellingPrice.Text = "0";
            Functions.FillCombo("SELECT id_Customer, name_Customer FROM Customer", comboCustomerId, "id_Customer", "id_Customer");
            comboCustomerId.SelectedIndex = -1;
            Functions.FillCombo("SELECT id_Product, name_Product FROM Product", comboProduct, "id_Product", "id_Product");
            comboProduct.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtInvoiceDeliveryId.Text != "")
            {
                LoadInfoHoaDon();
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.id_Product, b.name_Product, a.NumberOf_Product, b.unitSelling_Price,a.intomoney FROM DETAILS_Delivery AS a, Product AS b WHERE a.id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "' AND a.id_Product=b.id_Product";
            Invoice_Delivery = Functions.GetDataToTable(sql);
            dgvInvoiceDelivery.DataSource = Invoice_Delivery;
            dgvInvoiceDelivery.Columns[0].HeaderText = "Product ID";
            dgvInvoiceDelivery.Columns[1].HeaderText = "Product Name";
            dgvInvoiceDelivery.Columns[2].HeaderText = "Number of Product";
            dgvInvoiceDelivery.Columns[3].HeaderText = "Selling Price";
            dgvInvoiceDelivery.Columns[4].HeaderText = "Into Money";
            dgvInvoiceDelivery.Columns[0].Width = 100;
            dgvInvoiceDelivery.Columns[1].Width = 130;
            dgvInvoiceDelivery.Columns[2].Width = 130;
            dgvInvoiceDelivery.Columns[3].Width = 130;
            dgvInvoiceDelivery.Columns[4].Width = 130;
            dgvInvoiceDelivery.AllowUserToAddRows = false;
            dgvInvoiceDelivery.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT DateOfInvoiceDelivery FROM Invoice_Delivery WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'";
            DateOfProductDelivery.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT id_Customer FROM Invoice_Delivery WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'";
            comboCustomerId.Text = Functions.GetFieldValues(str);
            str = "SELECT total_delivery FROM Invoice_Delivery WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'";
            txtTotal.Text = Functions.GetFieldValues(str);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        private void ResetValues()
        {
            txtInvoiceDeliveryId.Text = "";
            DateOfProductDelivery.Text = DateTime.Now.ToShortDateString();
            comboCustomerId.Text = "";
            comboProduct.Text = "";
            txtTotal.Text = "0";
            txtNumberOfProduct.Text = "";
            txtIntoMoney.Text = "0";
            txtSellingPrice.Text = "0";
            txtProductName.Text = "0";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        }
        private void ResetValuesProduct()
        {
            comboProduct.Text = "";
            txtNumberOfProduct.Text = "";
            txtTotal.Text = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT id_Product,numberOf_Product FROM DETAILS_Delivery WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'";
                DataTable Product = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= Product.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT numberOf_Product FROM Product WHERE id_Product = N'" + Product.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(Product.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE Product SET numberOf_Product =" + slcon + " WHERE id_Product= N'" + Product.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE DETAILS_Delivery WHERE id_InvoiceDelivery=N'" + txtInvoiceDeliveryId.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE DETAILS_Delivery WHERE id_InvoiceDelivery=N'" + txtInvoiceDeliveryId.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnDelete.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

        private void comboCustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboCustomerId.Text == "")
            {
                txtCustomerName.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select name_Customer from CUSTOMER where id_Customer = N'" + comboCustomerId.SelectedValue + "'";
            txtCustomerName.Text = Functions.GetFieldValues(str);

        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboProduct.Text == "")
            {
                txtProductName.Text = "";
                txtSellingPrice.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT name_Product FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            txtProductName.Text = Functions.GetFieldValues(str);
            str = "SELECT unitSelling_Price FROM Product WHERE id_Product =N'" + comboProduct.SelectedValue + "'";
            txtSellingPrice.Text = Functions.GetFieldValues(str);
        }

        private void txtNumberOfProduct_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtNumberOfProduct.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtNumberOfProduct.Text);
            if (txtSellingPrice.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtSellingPrice.Text);
            tt = sl * dg;
            txtIntoMoney.Text = tt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable Details_Delivery, Product;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop V AND S";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Nhà Bè - Thành Phố Hồ Chí Minh";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Phone Number: 033313131313";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "Invoice Delivery";
            // Biểu diễn thông tin chung của hóa đơn bán
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.name_Product, a.numberOf_Product, b.unitSelling_Price, a.intomoney " +
                  "FROM DETAILS_Delivery AS a , Product AS b WHERE a.id_InvoiceDelivery = N'" +
                  txtInvoiceDeliveryId.Text + "' AND a.id_Product = b.id_Product";
            Product = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Product Name";
            exRange.Range["C11:C11"].Value = "Number of Product";
            exRange.Range["D11:D11"].Value = "Price";
            exRange.Range["E11:E11"].Value = "Into Money";
            for (hang = 0; hang < Product.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < Product.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = Product.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = Product.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Total:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
     
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Invoice Delivery";
            exApp.Visible = true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            ResetValues();
            txtInvoiceDeliveryId.Text = Functions.CreateKey("RD");
            LoadDataGridView();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT id_InvoiceDelivery FROM Invoice_Delivery WHERE id_InvoiceDelivery=N'" + txtInvoiceDeliveryId.Text + "'";
            string sqltest = sql;
            if (Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (comboCustomerId.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboCustomerId.Focus();
                    return;
                }
                sql = "INSERT INTO Invoice_Delivery(id_InvoiceDelivery, id_Customer, dateOfInvoiceDelivery, total_delivery) VALUES (N'" + txtInvoiceDeliveryId.Text.Trim() + "','" +
                        DateOfProductDelivery.Value + "',N'" + comboCustomerId.SelectedValue + "',N'" + txtTotal.Text + ")";
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
            sql = "SELECT id_Product FROM DETAILS_Delivery WHERE id_Product=N'" + comboProduct.SelectedValue + "' AND id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesProduct();
                comboProduct.Focus();
                return;
            }
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT numberOf_Product FROM Product WHERE id_Product = N'" + comboProduct.SelectedValue + "'"));
            sql = "INSERT INTO DETAILS_Delivery(id_InvoiceDelivery,id_Product,numberOf_Product,intomoney, unitSelling_Price) VALUES(N'"
                + txtInvoiceDeliveryId.Text.Trim() + "',N'" + comboProduct.SelectedValue + "'," + txtNumberOfProduct.Text + ","
                + txtIntoMoney.Text + "," + txtSellingPrice.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtNumberOfProduct.Text);
            sql = "UPDATE Product SET numberOf_Product =" + SLcon + " WHERE id_Product= N'" + comboProduct.SelectedValue + "'";
            Functions.RunSQL(sql);

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble((Functions.GetFieldValues("SELECT intomoney FROM Details_Delivery WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'")));
            Tongmoi = tong + Convert.ToDouble(txtTotal.Text);
            sql = "UPDATE Invoice_Delivery SET total_delivery =" + Tongmoi + " WHERE id_InvoiceDelivery = N'" + txtInvoiceDeliveryId.Text + "'";
            Functions.RunSQL(sql);
            txtTotal.Text = Tongmoi.ToString();
            btnDelete.Enabled = true;
            ResetValuesProduct();
            btnAdd.Enabled = true;
            btnPrint.Enabled = true;
        }
    }
}