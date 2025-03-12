using QLNhanSu2025.Command;
using System.Windows.Input;
using QLNhanSu2025.ViewModels;
using QLNhanSu2025.Services; // Đảm bảo có namespace của các Service

namespace QLNhanSu2025
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IChamCongService _chamCongService;
        private readonly IHopDongService _hopDongService;
        private readonly ILuongService _luongService;
        private readonly INgayNghiService _ngayNghiService;
        private readonly INhanVienService _nhanVienService;
        private readonly IPhongBanService _phongBanService;
        private readonly IViTriService _viTriService;

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateNhanVienCommand { get; }
        public ICommand NavigatePhongBanCommand { get; }
        public ICommand NavigateViTriCommand { get; }
        public ICommand NavigateChamCongCommand { get; }
        public ICommand NavigateHopDongCommand { get; }
        public ICommand NavigateNgayNghiCommand { get; }
        public ICommand NavigateLuongCommand { get; }

        public MainViewModel(IChamCongService chamCongService, IHopDongService hopDongService, ILuongService luongService, INgayNghiService ngayNghiService, INhanVienService nhanVienService, IPhongBanService phongBanService, IViTriService viTriService)
        {
            _chamCongService = chamCongService;
            _hopDongService = hopDongService;
            _luongService = luongService;
            _ngayNghiService = ngayNghiService;
            _nhanVienService = nhanVienService;
            _phongBanService = phongBanService;
            _viTriService = viTriService;

            NavigateNhanVienCommand = new RelayCommand(o => CurrentView = new NhanVienViewModel(_nhanVienService));
            NavigatePhongBanCommand = new RelayCommand(o => CurrentView = new PhongBanViewModel(_phongBanService));
            NavigateViTriCommand = new RelayCommand(o => CurrentView = new ViTriViewModel(_viTriService));
            NavigateChamCongCommand = new RelayCommand(o => CurrentView = new ChamCongViewModel(_chamCongService));
            NavigateHopDongCommand = new RelayCommand(o => CurrentView = new HopDongViewModel(_hopDongService));
            NavigateNgayNghiCommand = new RelayCommand(o => CurrentView = new NgayNghiViewModel(_ngayNghiService));
            NavigateLuongCommand = new RelayCommand(o => CurrentView = new LuongViewModel(_luongService));
        }
    }
}