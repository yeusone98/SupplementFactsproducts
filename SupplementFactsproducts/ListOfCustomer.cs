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

namespace SupplementFactsproducts
{
    public partial class ListOfCustomer : DevExpress.XtraEditors.XtraForm
    {
        DataTable Customer;
        public ListOfCustomer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            txtCustomerId.Enabled = false;
            btnSave.Enabled = false;
            LoadDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Customer";
            Customer = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvCustomer.DataSource = Customer; //Hiển thị vào dataGridView
            dgvCustomer.Columns[0].HeaderText = "Customer ID";
            dgvCustomer.Columns[1].HeaderText = "Customer Name";
            dgvCustomer.Columns[2].HeaderText = "Address Customer";
            dgvCustomer.Columns[3].HeaderText = "Telephone Number Customer";
            dgvCustomer.Columns[0].Width = 100;
            dgvCustomer.Columns[1].Width = 150;
            dgvCustomer.Columns[2].Width = 150;
            dgvCustomer.Columns[3].Width = 150;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtCustomerId.Text = "";
            txtNameCustomer.Text = "";
            txtAddressCustomer.Text = "";
            txtPhoneCustomer.Text = "";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            ResetValues();
            txtCustomerId.Enabled = true;
            txtCustomerId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtCustomerId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerId.Focus();
                return;
            }
            if (txtNameCustomer.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameCustomer.Focus();
                return;
            }
            if (txtAddressCustomer.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddressCustomer.Focus();
                return;
            }
            if (txtPhoneCustomer.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhoneCustomer.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT id_Customer FROM Customer WHERE id_Customer=N'" + txtCustomerId.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerId.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO Customer VALUES (N'" + txtCustomerId.Text.Trim() +
                "',N'" + txtNameCustomer.Text.Trim() + "',N'" + txtAddressCustomer.Text.Trim() + "','" + txtPhoneCustomer.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            txtCustomerId.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql;
            if (Customer.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCustomerId.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNameCustomer.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameCustomer.Focus();
                return;
            }
            if (txtAddressCustomer.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddressCustomer.Focus();
                return;
            }
            if (txtPhoneCustomer.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhoneCustomer.Focus();
                return;
            }
            sql = "UPDATE Customer SET name_Customer=N'" + txtNameCustomer.Text.Trim().ToString() + "',address_Customer=N'" +
                txtAddressCustomer.Text.Trim().ToString() + "',phoneNumber_Customer='" + txtPhoneCustomer.Text.ToString() +
                "' WHERE id_Customer=N'" + txtCustomerId.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            if (Customer.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCustomerId.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhach WHERE MaKhach=N'" + txtCustomerId.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCustomerId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtNameCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtAddressCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtPhoneCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}