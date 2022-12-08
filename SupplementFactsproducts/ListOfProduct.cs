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
using DevExpress.Drawing;

namespace SupplementFactsproducts
{
    public partial class ListOfProduct : DevExpress.XtraEditors.XtraForm
    {
        DataTable Product;
        public ListOfProduct()
        {
            InitializeComponent();
        }

        private void ListOfProduct_Load(object sender, EventArgs e)
        {
            //string sql;
            //sql = "SELECT * from tblChatLieu";
            txtProductID.Enabled = false;
            btnSave.Enabled = false;
            btnSkip.Enabled = false;
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Product";
            Product = Functions.GetDataToTable(sql);
            dgvProduct.DataSource = Product;
            dgvProduct.Columns[0].HeaderText = "Product ID";
            dgvProduct.Columns[1].HeaderText = "Product Name";
            dgvProduct.Columns[2].HeaderText = "Number of Product";
            dgvProduct.Columns[3].HeaderText = "Import Price";
            dgvProduct.Columns[4].HeaderText = "Selling Price";
            dgvProduct.Columns[5].HeaderText = "Image";
            dgvProduct.Columns[6].HeaderText = "Note";
            dgvProduct.Columns[0].Width = 80;
            dgvProduct.Columns[1].Width = 140;
            dgvProduct.Columns[2].Width = 80;
            dgvProduct.Columns[3].Width = 100;
            dgvProduct.Columns[4].Width = 100;
            dgvProduct.Columns[5].Width = 200;
            dgvProduct.Columns[6].Width = 300;
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtNumberOfProduct.Text = "0";
            txtImportPrice.Text = "0";
            txtSellingPrice.Text = "0";
            txtNumberOfProduct.Enabled = true ;
            txtImportPrice.Enabled = false;
            txtSellingPrice.Enabled = false;
            txtImage.Text = "";
            picAnh.Image = null;
            txtNote.Text = "";
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            if (btnAdd.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductID.Focus();
                return;
            }
            if (Product.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtProductID.Text = dgvProduct.CurrentRow.Cells["id_Product"].Value.ToString();
            txtProductName.Text = dgvProduct.CurrentRow.Cells["name_Product"].Value.ToString();
            txtNumberOfProduct.Text = dgvProduct.CurrentRow.Cells["NumberOf_Product"].Value.ToString();
            txtImportPrice.Text = dgvProduct.CurrentRow.Cells["ImportUnit_Price"].Value.ToString();
            txtSellingPrice.Text = dgvProduct.CurrentRow.Cells["unitSelling_Price"].Value.ToString();
            sql = "SELECT Image FROM product WHERE id_Product=N'" + txtProductID.Text + "'";
            txtImage.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtImage.Text);
            sql = "SELECT Note FROM product WHERE id_Product = N'" + txtProductID.Text + "'";
            txtNote.Text = Functions.GetFieldValues(sql);
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSkip.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSkip.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            ResetValues();
            txtProductID.Enabled = true;
            txtProductID.Focus();
            txtNumberOfProduct.Enabled = true;
            txtImportPrice.Enabled = true;
            txtSellingPrice.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtProductID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductID.Focus();
                return;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName.Focus();
                return;
            }
            if (txtImage.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "SELECT id_Product FROM Product WHERE id_Product=N'" + txtProductID.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductID.Focus();
                return;
            }
            sql = "INSERT INTO Product(id_Product,name_Product,NumberOf_Product,ImportUnit_Price, unitSelling_Price,Image,Note) VALUES(N'"
                + txtProductID.Text.Trim() + "',N'" + txtProductName.Text.Trim() +
                "'," + txtNumberOfProduct.Text.Trim() + "," + txtImportPrice.Text +
                "," + txtSellingPrice.Text + ",'" + txtImage.Text + "',N'" + txtNote.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSkip.Enabled = false;
            btnSave.Enabled = false;
            txtProductID.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtImage.Text = dlgOpen.FileName;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql;
            if (Product.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtProductID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductID.Focus();
                return;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName.Focus();
                return;
            }
            if (txtImage.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImage.Focus();
                return;
            }
            sql = "UPDATE Product SET name_Product=N'" + txtProductName.Text.Trim().ToString() +
                "',NumberOf_Product=" + txtNumberOfProduct.Text +
                ",Image='" + txtImage.Text + "',Note=N'" + txtNote.Text + "' WHERE id_Product=N'" + txtProductID.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSkip.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            if (Product.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtProductID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Product WHERE id_Product=N'" + txtProductID.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnSkip.Enabled = false;
            btnSave.Enabled = false;
            txtProductID.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtProductID.Text == "") && (txtProductName.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Product WHERE 1=1";
            if (txtProductID.Text != "")
                sql += " AND id_Product LIKE N'%" + txtProductID.Text + "%'";
            if (txtProductName.Text != "")
                sql += " AND name_Product LIKE N'%" + txtProductName.Text + "%'";
            if (Product.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + Product.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvProduct.DataSource = Product;
            ResetValues();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT id_Product,name_Product,NumberOf_Product,ImportUnit_Price, unitSelling_Price,Image,Note FROM Product";
            Product = Functions.GetDataToTable(sql);
            dgvProduct.DataSource = Product;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}