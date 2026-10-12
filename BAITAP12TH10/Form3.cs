using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAP12TH10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        // 1. Hàm giả lập nạp dữ liệu nặng bất đồng bộ (Task.Run + await + Task.Delay)
        private async Task<List<Student>> LoadDataAsync(IProgress<int> progress)
        {
            List<Student> list = new List<Student>();

            // Giả lập nạp 100 dòng dữ liệu trong tiến trình ngầm
            await Task.Run(async () =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    // Giả lập công việc tốn thời gian (nghỉ 40ms/dòng)
                    await Task.Delay(40);

                    // Tạo đối tượng Student và gán giá trị cụ thể
                    Student st = new Student();

                    // Gán dữ liệu vào thuộc tính (bỏ dấu //)
                    st.StudentId = "SV" + i.ToString("D3");
                    st.FullName = "Sinh viên " + i;
                    st.Age = 20;
                    st.Gender = (i % 2 == 0) ? "Nam" : "Nữ";

                    list.Add(st);

                    // Báo cáo tiến trình % về UI Thread
                    if (progress != null)
                    {
                        progress.Report(i);
                    }
                }
            });

            return list;
        }

        // 2. Sự kiện Click nút Nạp Dữ Liệu
        private async void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            // Quản lý trạng thái: Khóa nút bấm tránh kích hoạt trùng lặp
            btnNapDuLieu.Enabled = false;
            progressBar1.Value = 0;
            lblPhanTram.Text = "0%";

            try
            {
                // Khởi tạo đối tượng Progress<int> để cập nhật giao diện theo thời gian thực
                var progress = new Progress<int>(percent =>
                {
                    // Cập nhật ProgressBar và Label phần trăm trên Form3
                    progressBar1.Value = percent;
                    lblPhanTram.Text = percent + "%";

                    // Cập nhật phần trăm tiến trình lên StatusStrip của Form2 (Form cha MDI)
                    if (this.MdiParent is Form2 parentForm)
                    {
                        parentForm.UpdateStatus($"Đang nạp dữ liệu... {percent}%");
                    }
                });

                // Thực thi tác vụ bất đồng bộ await
                List<Student> result = await LoadDataAsync(progress);

                // Reset và gán dữ liệu vào DataGridView
                if (dgvData != null)
                {
                    dgvData.DataSource = null; // Clears old bindings
                    dgvData.DataSource = result;
                }

                // Thông báo hoàn tất
                if (this.MdiParent is Form2 parent)
                {
                    parent.UpdateStatus("Nạp dữ liệu hoàn tất 100%!");
                }
                MessageBox.Show("Nạp dữ liệu bất đồng bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở lại nút bấm khi tiến trình kết thúc hoặc gặp lỗi
                btnNapDuLieu.Enabled = true;
            }
        }
    }
}