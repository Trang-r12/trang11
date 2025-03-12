using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QLNhanSu2025.ViewModels // Điều chỉnh namespace cho phù hợp với project của bạn
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}