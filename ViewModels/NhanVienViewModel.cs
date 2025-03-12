using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using QLNhanSu2025.Command;
using System.Windows.Input;

namespace QLNhanSu2025.ViewModels
{
    public class NhanVienViewModel : INotifyPropertyChanged
    {
        private readonly INhanVienService _nhanVienService;
        private ObservableCollection<NhanVien> _nhanViens;
        private NhanVien? _selectedNhanVien; // Cho phép null
        private bool _isEditMode;

        public NhanVienViewModel(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
            _nhanViens = new ObservableCollection<NhanVien>();
            LoadNhanViens();

            AddNhanVienCommand = new RelayCommand(AddNhanVien);
            UpdateNhanVienCommand = new RelayCommand(UpdateNhanVien, CanUpdateDeleteNhanVien);
            DeleteNhanVienCommand = new RelayCommand(DeleteNhanVien, CanUpdateDeleteNhanVien);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<NhanVien> NhanViens
        {
            get { return _nhanViens; }
            set
            {
                _nhanViens = value;
                OnPropertyChanged(nameof(NhanViens));
            }
        }

        public NhanVien? SelectedNhanVien
        {
            get { return _selectedNhanVien; }
            set
            {
                _selectedNhanVien = value;
                OnPropertyChanged(nameof(SelectedNhanVien));
            }
        }

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                OnPropertyChanged(nameof(IsEditMode));
            }
        }

        public ICommand AddNhanVienCommand { get; }
        public ICommand UpdateNhanVienCommand { get; }
        public ICommand DeleteNhanVienCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadNhanViens()
        {
            var nhanViens = await _nhanVienService.GetAllNhanViens();
            NhanViens = new ObservableCollection<NhanVien>(nhanViens);
        }

        private async void AddNhanVien(object parameter)
        {
            IsEditMode = true;
            SelectedNhanVien = new NhanVien(); // Create a new NhanVien instance
        }

        private bool CanUpdateDeleteNhanVien(object parameter)
        {
            return SelectedNhanVien != null;
        }

        private async void UpdateNhanVien(object parameter)
        {
            if (SelectedNhanVien == null) return;

            await _nhanVienService.UpdateNhanVien(SelectedNhanVien);
            LoadNhanViens();
            IsEditMode = false;
            SelectedNhanVien = null;
        }

        private async void DeleteNhanVien(object parameter)
        {
            if (SelectedNhanVien == null) return;

            await _nhanVienService.DeleteNhanVien(SelectedNhanVien.MaNhanVien);
            LoadNhanViens();
            IsEditMode = false;
            SelectedNhanVien = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedNhanVien = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}