using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using QLNhanSu2025.Command;
using System.Windows.Input;

namespace QLNhanSu2025.ViewModels
{
    public class PhongBanViewModel : INotifyPropertyChanged
    {
        private readonly IPhongBanService _phongBanService;
        private ObservableCollection<PhongBan> _phongBans;
        private PhongBan? _selectedPhongBan; // Cho phép null
        private bool _isEditMode;

        public PhongBanViewModel(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
            _phongBans = new ObservableCollection<PhongBan>();
            LoadPhongBans();

            AddPhongBanCommand = new RelayCommand(AddPhongBan);
            UpdatePhongBanCommand = new RelayCommand(UpdatePhongBan, CanUpdateDeletePhongBan);
            DeletePhongBanCommand = new RelayCommand(DeletePhongBan, CanUpdateDeletePhongBan);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<PhongBan> PhongBans
        {
            get { return _phongBans; }
            set
            {
                _phongBans = value;
                OnPropertyChanged(nameof(PhongBans));
            }
        }

        public PhongBan? SelectedPhongBan
        {
            get { return _selectedPhongBan; }
            set
            {
                _selectedPhongBan = value;
                OnPropertyChanged(nameof(SelectedPhongBan));
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

        public ICommand AddPhongBanCommand { get; }
        public ICommand UpdatePhongBanCommand { get; }
        public ICommand DeletePhongBanCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadPhongBans()
        {
            var phongBans = await _phongBanService.GetAllPhongBans();
            PhongBans = new ObservableCollection<PhongBan>(phongBans);
        }

        private async void AddPhongBan(object parameter)
        {
            IsEditMode = true;
            SelectedPhongBan = new PhongBan(); // Create a new PhongBan instance
        }

        private bool CanUpdateDeletePhongBan(object parameter)
        {
            return SelectedPhongBan != null;
        }

        private async void UpdatePhongBan(object parameter)
        {
            if (SelectedPhongBan == null) return;

            await _phongBanService.UpdatePhongBan(SelectedPhongBan);
            LoadPhongBans();
            IsEditMode = false;
            SelectedPhongBan = null;
        }

        private async void DeletePhongBan(object parameter)
        {
            if (SelectedPhongBan == null) return;

            await _phongBanService.DeletePhongBan(SelectedPhongBan.MaPhongBan);
            LoadPhongBans();
            IsEditMode = false;
            SelectedPhongBan = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedPhongBan = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}