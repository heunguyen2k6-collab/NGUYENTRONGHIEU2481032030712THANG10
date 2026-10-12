using System.ComponentModel;

namespace BAITAP12TH10
{
    public class Student : INotifyPropertyChanged
    {
        private string studentId;
        private string fullName;
        private int age;
        private string gender;
        private string avatarPath;

        public string StudentId
        {
            get => studentId;
            set { studentId = value; OnPropertyChanged(nameof(StudentId)); }
        }

        public string FullName
        {
            get => fullName;
            set { fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        public int Age
        {
            get => age;
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Gender
        {
            get => gender;
            set { gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        public string AvatarPath
        {
            get => avatarPath;
            set { avatarPath = value; OnPropertyChanged(nameof(AvatarPath)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}