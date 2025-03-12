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
    public class LuongViewModel : INotifyPropertyChanged
    {
        private readonly ILuongService _luongService;
        private ObservableCollection<Luong> _luongs;
        private Luong? _selectedLuong; // Cho phép null
        private bool _isEditMode;

        public LuongViewModel(ILuongService luongService)
        {
            _luongService = luongService;
            _luongs = new ObservableCollection<Luong>();
            LoadLuongs();

            AddLuongCommand = new RelayCommand(AddLuong);
            UpdateLuongCommand = new RelayCommand(UpdateLuong, CanUpdateDeleteLuong);
            DeleteLuongCommand = new RelayCommand(DeleteLuong, CanUpdateDeleteLuong);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<Luong> Luongs
        {
            get { return _luongs; }
            set
            {
                _luongs = value;
                OnPropertyChanged(nameof(Luongs));
            }
        }

        public Luong? SelectedLuong
        {
            get { return _selectedLuong; }
            set
            {
                _selectedLuong = value;
                OnPropertyChanged(nameof(SelectedLuong));
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

        public ICommand AddLuongCommand { get; }
        public ICommand UpdateLuongCommand { get; }
        public ICommand DeleteLuongCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadLuongs()
        {
            var luongs = await _luongService.GetAllLuongs();
            Luongs = new ObservableCollection<Luong>(luongs);
        }

        private async void AddLuong(object parameter)
        {
            IsEditMode = true;
            SelectedLuong = new Luong { NgayApDung = DateTime.Now }; // Create a new Luong instance
        }

        private bool CanUpdateDeleteLuong(object parameter)
        {
            return SelectedLuong != null;
        }

        private async void UpdateLuong(object parameter)
        {
            if (SelectedLuong == null) return;

            await _luongService.UpdateLuong(SelectedLuong);
            LoadLuongs();
            IsEditMode = false;
            SelectedLuong = null;
        }

        private async void DeleteLuong(object parameter)
        {
            if (SelectedLuong == null) return;

            await _luongService.DeleteLuong(SelectedLuong.MaLuong);
            LoadLuongs();
            IsEditMode = false;
            SelectedLuong = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedLuong = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}