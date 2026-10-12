using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BAITAP12TH10
{
    public partial class Form1 : Form
    {
        private BindingList<Student> studentList = new BindingList<Student>();
        private BindingSource bindingSource = new BindingSource();
        private string tempAvatarPath = ""; // Lưu đường dẫn ảnh đang chọn tạm thời

        public Form1()
        {
            InitializeComponent();
            SetupDataBinding();
        }

        private void SetupDataBinding()
        {
            // Kết nối BindingSource với Danh sách và DataGridView
            bindingSource.DataSource = studentList;
            dgvStudents.DataSource = bindingSource;

            // Binding 2 chiều cho các Control nhập liệu (DataSourceUpdateMode.OnValidation)
            txtStudentId.DataBindings.Add("Text", bindingSource, nameof(Student.StudentId), true, DataSourceUpdateMode.OnValidation);
            txtFullName.DataBindings.Add("Text", bindingSource, nameof(Student.FullName), true, DataSourceUpdateMode.OnValidation);
            txtAge.DataBindings.Add("Text", bindingSource, nameof(Student.Age), true, DataSourceUpdateMode.OnValidation);
            cboGender.DataBindings.Add("Text", bindingSource, nameof(Student.Gender), true, DataSourceUpdateMode.OnValidation);

            // Sự kiện khi chọn dòng khác trên DataGridView
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                tempAvatarPath = currentStudent.AvatarPath;
                LoadAvatar(tempAvatarPath);
            }
            else
            {
                tempAvatarPath = "";
                picAvatar.Image = null;
            }
        }

        private void LoadAvatar(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    picAvatar.ImageLocation = path;
                }
                catch
                {
                    picAvatar.Image = null;
                }
            }
            else
            {
                picAvatar.Image = null;
            }
        }

        // 1. Chọn ảnh Avatar
        private void btnBrowseAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tempAvatarPath = openFileDialog.FileName;
                    LoadAvatar(tempAvatarPath);

                    // Nếu đang chọn một sinh viên có sẵn thì cập nhật luôn đường dẫn ảnh
                    if (bindingSource.Current is Student currentStudent)
                    {
                        currentStudent.AvatarPath = tempAvatarPath;
                    }
                }
            }
        }

        // 2. Nút THÊM sinh viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return;
            }

            int.TryParse(txtAge.Text, out int age);

            Student newStudent = new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Age = age,
                Gender = cboGender.Text,
                AvatarPath = tempAvatarPath
            };

            // Thêm vào danh sách
            studentList.Add(newStudent);
            bindingSource.MoveLast(); // Nhảy tới dòng vừa thêm

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút XÓA sinh viên đang chọn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa SV '{currentStudent.FullName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sinh viên nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Nút CẬP NHẬT thông tin
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Student currentStudent)
            {
                int.TryParse(txtAge.Text, out int age);

                // Cập nhật giá trị trực tiếp
                currentStudent.StudentId = txtStudentId.Text.Trim();
                currentStudent.FullName = txtFullName.Text.Trim();
                currentStudent.Age = age;
                currentStudent.Gender = cboGender.Text;
                currentStudent.AvatarPath = tempAvatarPath;

                bindingSource.EndEdit(); // Xác nhận chỉnh sửa trên BindingSource
                bindingSource.ResetCurrentItem(); // Làm mới hiển thị trên DataGridView

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Nút XUẤT FILE CSV
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (studentList.Count == 0)
            {
                MessageBox.Show("Danh sách trống, không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.FileName = "DanhSachSinhVien.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csvContent = new StringBuilder();
                        csvContent.AppendLine("Mã SV,Họ tên,Tuổi,Giới tính,Đường dẫn Avatar");

                        foreach (Student st in studentList)
                        {
                            csvContent.AppendLine($"\"{st.StudentId}\",\"{st.FullName}\",{st.Age},\"{st.Gender}\",\"{st.AvatarPath}\"");
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContent.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}