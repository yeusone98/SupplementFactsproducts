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
using DevExpress.XtraEditors.Filtering.Templates;

namespace SupplementFactsproducts
{
    public partial class ListOfVendor : DevExpress.XtraEditors.XtraForm
    {
        DataTable Vendor;
        public ListOfVendor()
        {
            InitializeComponent();
        }

        private void ListOfVendor_Load(object sender, EventArgs e)
        {
            txtVendorId.Enabled = false;
            btnSave.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Vendor";
            Vendor = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvVendor.DataSource = Vendor; //Hiển thị vào dataGridView
            dgvVendor.Columns[0].HeaderText = "Vendor ID";
            dgvVendor.Columns[1].HeaderText = "Vendor Name";
            dgvVendor.Columns[2].HeaderText = "Address Vendor";
            dgvVendor.Columns[3].HeaderText = "Telephone Number Vendor";
            dgvVendor.Columns[0].Width = 100;
            dgvVendor.Columns[1].Width = 150;
            dgvVendor.Columns[2].Width = 150;
            dgvVendor.Columns[3].Width = 150;
            dgvVendor.AllowUserToAddRows = false;
            dgvVendor.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtVendorId.Text = "";
            txtNameVendor.Text = "";
            txtAddressVendor.Text = "";
            txtPhoneVendor.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            ResetValues();
            txtVendorId.Enabled = true;
            txtVendorId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtVendorId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVendorId.Focus();
                return;
            }
            if (txtNameVendor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameVendor.Focus();
                return;
            }
            if (txtAddressVendor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddressVendor.Focus();
                return;
            }
            if (txtPhoneVendor.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhoneVendor.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT id_vendor FROM Vendor WHERE id_vendor=N'" + txtVendorId.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVendorId.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO Vendor VALUES (N'" + txtVendorId.Text.Trim() +
                "',N'" + txtNameVendor.Text.Trim() + "',N'" + txtAddressVendor.Text.Trim() + "','" + txtPhoneVendor.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            txtVendorId.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql;
            if (Vendor.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVendorId.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNameVendor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameVendor.Focus();
                return;
            }
            if (txtAddressVendor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddressVendor.Focus();
                return;
            }
            if (txtPhoneVendor.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhoneVendor.Focus();
                return;
            }
            sql = "UPDATE Vendor SET name_vendor=N'" + txtNameVendor.Text.Trim().ToString() + "',address_vendorr=N'" +
                txtAddressVendor.Text.Trim().ToString() + "',phoneNumber_vendor='" + txtPhoneVendor.Text.ToString() +
                "' WHERE id_vendor=N'" + txtVendorId.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            if (Vendor.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVendorId.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Vendor WHERE id_vendor=N'" + txtVendorId.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVendorId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtNameVendor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtAddressVendor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtPhoneVendor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}