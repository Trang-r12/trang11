using System.Collections.ObjectModel;
using QLNhanSu2025.Models;
using QLNhanSu2025.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using QLNhanSu2025.Command;
using System.Windows.Input;

namespace QLNhanSu2025.ViewModels
{
    public class ViTriViewModel : INotifyPropertyChanged
    {
        private readonly IViTriService _viTriService;
        private ObservableCollection<ViTri> _viTris;
        private ViTri? _selectedViTri; // Cho phép null
        private bool _isEditMode;

        public ViTriViewModel(IViTriService viTriService)
        {
            _viTriService = viTriService;
            _viTris = new ObservableCollection<ViTri>();
            LoadViTris();

            AddViTriCommand = new RelayCommand(AddViTri);
            UpdateViTriCommand = new RelayCommand(UpdateViTri, CanUpdateDeleteViTri);
            DeleteViTriCommand = new RelayCommand(DeleteViTri, CanUpdateDeleteViTri);
            CancelEditCommand = new RelayCommand(CancelEdit);
        }

        public ObservableCollection<ViTri> ViTris
        {
            get { return _viTris; }
            set
            {
                _viTris = value;
                OnPropertyChanged(nameof(ViTris));
            }
        }

        public ViTri? SelectedViTri
        {
            get { return _selectedViTri; }
            set
            {
                _selectedViTri = value;
                OnPropertyChanged(nameof(SelectedViTri));
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

        public ICommand AddViTriCommand { get; }
        public ICommand UpdateViTriCommand { get; }
        public ICommand DeleteViTriCommand { get; }
        public ICommand CancelEditCommand { get; }

        private async void LoadViTris()
        {
            var viTris = await _viTriService.GetAllViTris();
            ViTris = new ObservableCollection<ViTri>(viTris);
        }

        private async void AddViTri(object parameter)
        {
            IsEditMode = true;
            SelectedViTri = new ViTri(); // Create a new ViTri instance
        }

        private bool CanUpdateDeleteViTri(object parameter)
        {
            return SelectedViTri != null;
        }

        private async void UpdateViTri(object parameter)
        {
            if (SelectedViTri == null) return;

            await _viTriService.UpdateViTri(SelectedViTri);
            LoadViTris();
            IsEditMode = false;
            SelectedViTri = null;
        }

        private async void DeleteViTri(object parameter)
        {
            if (SelectedViTri == null) return;

            await _viTriService.DeleteViTri(SelectedViTri.MaViTri);
            LoadViTris();
            IsEditMode = false;
            SelectedViTri = null;
        }

        private void CancelEdit(object parameter)
        {
            IsEditMode = false;
            SelectedViTri = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}