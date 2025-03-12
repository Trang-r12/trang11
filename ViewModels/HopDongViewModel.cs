using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using QLNhanSu2025.Command;
using System.Windows.Input;

namespace QLNhanSu2025.ViewModels
{
    public class HopDongViewModel : INotifyPropertyChanged
    {
        private readonly IHopDongService _hopDongService;
        private ObservableCollection<HopDong> _hopDongs;
        private HopDong? _selectedHopDong; // Cho phép null
        private bool _isEditMode;

        public HopDongViewModel(IHopDongService hopDongService)
        {
            _hopDongService = hopDongService;
            _hopDongs = new ObservableCollection<HopDong>();
            LoadHopDongs();

            AddHopDongCommand = new RelayCommand(AddHopDong);
            UpdateHopDongCommand = new RelayCommand(UpdateHopDong, CanUpdateDeleteHopDong);
            DeleteHopDongCommand = new RelayCommand(DeleteHopDong, CanUpdateDeleteHopDong);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<HopDong> HopDongs
        {
            get { return _hopDongs; }
            set
            {
                _hopDongs = value;
                OnPropertyChanged(nameof(HopDongs));
            }
        }

        public HopDong? SelectedHopDong
        {
            get { return _selectedHopDong; }
            set
            {
                _selectedHopDong = value;
                OnPropertyChanged(nameof(SelectedHopDong));
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

        public ICommand AddHopDongCommand { get; }
        public ICommand UpdateHopDongCommand { get; }
        public ICommand DeleteHopDongCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadHopDongs()
        {
            var hopDongs = await _hopDongService.GetAllHopDongs();
            HopDongs = new ObservableCollection<HopDong>(hopDongs);
        }

        private async void AddHopDong(object parameter)
        {
            IsEditMode = true;
            SelectedHopDong = new HopDong(); // Create a new HopDong instance
        }

        private bool CanUpdateDeleteHopDong(object parameter)
        {
            return SelectedHopDong != null;
        }

        private async void UpdateHopDong(object parameter)
        {
            if (SelectedHopDong == null) return;

            await _hopDongService.UpdateHopDong(SelectedHopDong);
            LoadHopDongs();
            IsEditMode = false;
            SelectedHopDong = null;
        }

        private async void DeleteHopDong(object parameter)
        {
            if (SelectedHopDong == null) return;

            await _hopDongService.DeleteHopDong(SelectedHopDong.MaHopDong);
            LoadHopDongs();
            IsEditMode = false;
            SelectedHopDong = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedHopDong = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}