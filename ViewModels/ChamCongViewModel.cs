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
    public class ChamCongViewModel : INotifyPropertyChanged
    {
        private readonly IChamCongService _chamCongService;
        private ObservableCollection<ChamCong> _chamCongs;
        private ChamCong? _selectedChamCong; // Cho phép null
        private bool _isEditMode;

        public ChamCongViewModel(IChamCongService chamCongService)
        {
            _chamCongService = chamCongService;
            _chamCongs = new ObservableCollection<ChamCong>();
            LoadChamCongs();


            AddChamCongCommand = new RelayCommand(AddChamCong);
            UpdateChamCongCommand = new RelayCommand(UpdateChamCong, CanUpdateDeleteChamCong);
            DeleteChamCongCommand = new RelayCommand(DeleteChamCong, CanUpdateDeleteChamCong);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<ChamCong> ChamCongs
        {
            get { return _chamCongs; }
            set
            {
                _chamCongs = value;
                OnPropertyChanged(nameof(ChamCongs));
            }
        }

        public ChamCong? SelectedChamCong
        {
            get { return _selectedChamCong; }
            set
            {
                _selectedChamCong = value;
                OnPropertyChanged(nameof(SelectedChamCong));
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

        public ICommand AddChamCongCommand { get; }
        public ICommand UpdateChamCongCommand { get; }
        public ICommand DeleteChamCongCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadChamCongs()
        {
            var chamCongs = await _chamCongService.GetAllChamCongs();
            ChamCongs = new ObservableCollection<ChamCong>(chamCongs);
        }

        private async void AddChamCong(object parameter)
        {
            IsEditMode = true;
            SelectedChamCong = new ChamCong { Ngay = DateTime.Now }; // Create a new ChamCong instance
        }

        private bool CanUpdateDeleteChamCong(object parameter)
        {
            return SelectedChamCong != null;
        }

        private async void UpdateChamCong(object parameter)
        {
            if (SelectedChamCong == null) return;

            await _chamCongService.UpdateChamCong(SelectedChamCong);
            LoadChamCongs();
            IsEditMode = false;
            SelectedChamCong = null;
        }

        private async void DeleteChamCong(object parameter)
        {
            if (SelectedChamCong == null) return;

            await _chamCongService.DeleteChamCong(SelectedChamCong.MaChamCong);
            LoadChamCongs();
            IsEditMode = false;
            SelectedChamCong = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedChamCong = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}