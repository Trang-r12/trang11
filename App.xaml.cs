using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using QLNhanSu2025.Services;
using QLNhanSu2025.ViewModels;
using QLNhanSu2025.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QLNhanSu2025
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Cấu hình DbContext
            services.AddDbContext<QLNhanSuContext>(options =>
                options.UseSqlServer("Server=ADMIN-PC;Database=QuanLyNhanSu2025;Trusted_Connection=True;")); // Chuỗi kết nối của bạn

            // Đăng ký các services
            services.AddTransient<IChamCongService, ChamCongService>();
            services.AddTransient<IHopDongService, HopDongService>();
            services.AddTransient<ILuongService, LuongService>();
            services.AddTransient<INgayNghiService, NgayNghiService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddTransient<IPhongBanService, PhongBanService>();
            services.AddTransient<IViTriService, ViTriService>();

            // Đăng ký MainViewModel
            services.AddTransient<MainViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Kiểm tra kết nối cơ sở dữ liệu
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<QLNhanSuContext>();
                    context.Database.EnsureCreated(); // Tự động tạo database nếu chưa có
                    var count = context.NhanViens.Count();
                    MessageBox.Show($"Kết nối thành công! Có {count} nhân viên trong database.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối database: {ex.Message}");
                }
            }

            // Lấy MainViewModel từ ServiceProvider và set nó vào MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
    }
}