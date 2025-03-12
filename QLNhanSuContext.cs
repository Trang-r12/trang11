using Microsoft.EntityFrameworkCore;

namespace QLNhanSu2025.Models // Hoặc namespace phù hợp với dự án của bạn
{
    public class QLNhanSuContext : DbContext
    {
        public QLNhanSuContext(DbContextOptions<QLNhanSuContext> options) : base(options)
        {
        }

        public DbSet<Luong> Salaries { get; set; } // Thêm dòng này. Lưu ý <Luong> là tên model của bạn
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<NgayNghi> Leaves { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongBan> Departments { get; set; }
        public DbSet<ViTri> Positions { get; set; }
    }
}