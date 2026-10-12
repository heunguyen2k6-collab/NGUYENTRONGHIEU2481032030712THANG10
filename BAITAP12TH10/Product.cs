using System;
using System.Data;
using System.Windows.Forms;

namespace BAITAP12TH10
{
    public partial class Product : Form
    {
        // Bảng chứa danh sách sản phẩm mẫu
        private DataTable dtSanPham = new DataTable();

        public Product()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form Product tải lên
        private void Product_Load(object sender, EventArgs e)
        {
            // Tạo các cột cho bảng dữ liệu
            dtSanPham.Columns.Add("MaSP", typeof(string));
            dtSanPham.Columns.Add("TenSP", typeof(string));
            dtSanPham.Columns.Add("DonGia", typeof(double));

            // Thêm vài dòng dữ liệu mẫu
            dtSanPham.Rows.Add("SP01", "Laptop Dell", 15000000);
            dtSanPham.Rows.Add("SP02", "Chuột Logitech", 350000);
            dtSanPham.Rows.Add("SP03", "Bàn phím Cơ", 850000);

            // Gán dữ liệu vào DataGridView (đảm bảo DataGridView tên là dgvSanPham)
            if (dgvSanPham != null)
            {
                dgvSanPham.DataSource = dtSanPham;
            }
        }

        // Nút Thêm sản phẩm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dòng mới vào DataTable
            dtSanPham.Rows.Add(txtMaSP.Text, txtTenSP.Text, 0);

            // Xóa nội dung trong ô nhập
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtMaSP.Focus();

            // Gửi thông báo cập nhật lên StatusStrip của Form2 (Form chính)
            if (this.MdiParent is Form2 parentForm)
            {
                parentForm.UpdateStatus("Đã thêm sản phẩm mới thành công!");
            }
        }

        // Nút Xóa sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham != null && dgvSanPham.CurrentRow != null && !dgvSanPham.CurrentRow.IsNewRow)
            {
                dgvSanPham.Rows.Remove(dgvSanPham.CurrentRow);

                // Gửi thông báo cập nhật lên StatusStrip của Form2
                if (this.MdiParent is Form2 parentForm)
                {
                    parentForm.UpdateStatus("Đã xóa 1 sản phẩm.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}