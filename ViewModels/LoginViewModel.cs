using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using QLNhanSu2025.Command;
using QLNhanSu2025.Views;

public class LoginViewModel : INotifyPropertyChanged
{
    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(ExecuteLogin);
    }

    private void ExecuteLogin(object parameter)
    {
        // Kiểm tra tài khoản mặc định
        if (Username == "Admin" && Password == "123")
        {
            MainView mainView = new MainView();
            Application.Current.MainWindow = mainView;
            mainView.Show();

            // Đóng cửa sổ đăng nhập
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginView)
                {
                    window.Close();
                    break;
                }
            }
        }
        else
        {
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
