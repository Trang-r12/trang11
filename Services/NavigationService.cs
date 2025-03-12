using System;
using System.Windows;
using QLNhanSu2025.ViewModels;
using QLNhanSu2025.Views;

namespace QLNhanSu2025.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, object> _viewModelFactory;
        private readonly MainViewModel _mainViewModel;

        public NavigationService(Func<Type, object> viewModelFactory, MainViewModel mainViewModel)
        {
            _viewModelFactory = viewModelFactory;
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "AdminView":
                    _mainViewModel.CurrentView = new AdminView { DataContext = _viewModelFactory(typeof(AdminViewModel)) };
                    break;
                case "KeToanView":
                    _mainViewModel.CurrentView = new KeToanView { DataContext = _viewModelFactory(typeof(KeToanViewModel)) };
                    break;
                //Thêm case cho các View khác
                case "MainWindow":
                    Application.Current.MainWindow = new MainWindow { DataContext = _viewModelFactory(typeof(MainViewModel)) };
                    Application.Current.MainWindow.Show();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is LoginView)
                        {
                            window.Close();
                            break;
                        }
                    }
                    break;
                default:
                    //Xử lý khi không tìm thấy View
                    break;
            }
        }
    }
}