using System.ComponentModel;
using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Commands;
using System.Windows.Input;

namespace QLNhanSu2025.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage = "Chào mừng Admin!";
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged(nameof(WelcomeMessage));
            }
        }

        private ObservableCollection<NguoiDung> _nguoiDungs;
        public ObservableCollection<NguoiDung> NguoiDungs
        {
            get { return _nguoiDungs; }
            set
            {
                _nguoiDungs = value;
                OnPropertyChanged(nameof(NguoiDungs));
            }
        }

        public ICommand AddNguoiDungCommand { get; }

        public AdminViewModel()
        {
            // Khởi tạo danh sách người dùng (ví dụ)
            NguoiDungs = new ObservableCollection<NguoiDung>
            {
                new NguoiDung { MaNguoiDung = 1, TenDangNhap = "admin", VaiTro = "Admin" },
                new NguoiDung { MaNguoiDung = 2, TenDangNhap = "user1", VaiTro = "Nhân viên" }
            };

            AddNguoiDungCommand = new RelayCommand(AddNguoiDung);
        }

        private void AddNguoiDung(object parameter)
        {
            // Logic thêm người dùng
            // Ví dụ: Tạo một người dùng mới và thêm vào danh sách
            NguoiDung newUser = new NguoiDung { MaNguoiDung = 3, TenDangNhap = "newUser", VaiTro = "Nhân viên" };
            NguoiDungs.Add(newUser);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}