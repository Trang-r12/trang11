using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using QLNhanSu2025.Command;
using System.Windows.Input;
using System;

namespace QLNhanSu2025.ViewModels
{
    public class NgayNghiViewModel : INotifyPropertyChanged
    {
        private readonly INgayNghiService _ngayNghiService;
        private ObservableCollection<NgayNghi> _ngayNghis;
        private NgayNghi? _selectedNgayNghi; // Cho phép null
        private bool _isEditMode;

        public NgayNghiViewModel(INgayNghiService ngayNghiService)
        {
            _ngayNghiService = ngayNghiService;
            _ngayNghis = new ObservableCollection<NgayNghi>();
            LoadNgayNghis();

            AddNgayNghiCommand = new RelayCommand(AddNgayNghi);
            UpdateNgayNghiCommand = new RelayCommand(UpdateNgayNghi, CanUpdateDeleteNgayNghi);
            DeleteNgayNghiCommand = new RelayCommand(DeleteNgayNghi, CanUpdateDeleteNgayNghi);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<NgayNghi> NgayNghis
        {
            get { return _ngayNghis; }
            set
            {
                _ngayNghis = value;
                OnPropertyChanged(nameof(NgayNghis));
            }
        }

        public NgayNghi? SelectedNgayNghi
        {
            get { return _selectedNgayNghi; }
            set
            {
                _selectedNgayNghi = value;
                OnPropertyChanged(nameof(SelectedNgayNghi));
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

        public ICommand AddNgayNghiCommand { get; }
        public ICommand UpdateNgayNghiCommand { get; }
        public ICommand DeleteNgayNghiCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadNgayNghis()
        {
            var ngayNghis = await _ngayNghiService.GetAllNgayNghis();
            NgayNghis = new ObservableCollection<NgayNghi>(ngayNghis);
        }

        private async void AddNgayNghi(object parameter)
        {
            IsEditMode = true;
            SelectedNgayNghi = new NgayNghi(); // Create a new NgayNghi instance
        }

        private bool CanUpdateDeleteNgayNghi(object parameter)
        {
            return SelectedNgayNghi != null;
        }

        private async void UpdateNgayNghi(object parameter)
        {
            if (SelectedNgayNghi == null) return;

            await _ngayNghiService.UpdateNgayNghi(SelectedNgayNghi);
            LoadNgayNghis();
            IsEditMode = false;
            SelectedNgayNghi = null;
        }

        private async void DeleteNgayNghi(object parameter)
        {
            if (SelectedNgayNghi == null) return;

            await _ngayNghiService.DeleteNgayNghi(SelectedNgayNghi.MaNgayNghi);
            LoadNgayNghis();
            IsEditMode = false;
            SelectedNgayNghi = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedNgayNghi = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}