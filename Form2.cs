using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAP12TH10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // =========================================================
        // 1. CÁC HÀM BỔ SUNG (BẮT BUỘC ĐỂ KHÔNG BỊ LỖI)
        // =========================================================

        // Hàm mở Form con không bị lặp lại
        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate(); // Kích hoạt nếu form đã mở
                    return;
                }
            }

            T childForm = new T();
            childForm.MdiParent = this; // Gán Form2 làm cha
            childForm.Show();
        }

        // Hàm cập nhật trạng thái lên StatusStrip của Form2
        public void UpdateStatus(string message)
        {
            // Đảm bảo bạn đã thêm StatusStrip và đặt tên ToolStripStatusLabel là lblThongBao
            if (lblThongBao != null)
            {
                lblThongBao.Text = message;
            }
        }

        // =========================================================
        // 2. CODE SỰ KIỆN CỦA MENU (ĐÃ ĐÚNG THEO CODE CỦA BẠN)
        // =========================================================

        private void mnuHeThong_Click(object sender, EventArgs e)
        {

        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            UpdateStatus("Đã đăng xuất hệ thống.");
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuQLSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm<Form1>(); // FormStudent là tên Form con
            UpdateStatus("Đã mở màn hình Quản lý sinh viên.");
        }

        private void mnuQLSanPham_Click(object sender, EventArgs e)
        {
            // Un-comment dòng dưới khi bạn đã tạo FormProduct
            OpenChildForm<Product>(); 
            UpdateStatus("Đã mở màn hình Quản lý sản phẩm.");
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}