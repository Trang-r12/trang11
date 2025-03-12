using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhanSu2025.Models;

namespace QLNhanSu2025.Models
{
    public class QuanLyNhanSuContext : DbContext
    {
        public QuanLyNhanSuContext(DbContextOptions<QuanLyNhanSuContext> options) : base(options) { }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<ViTri> ViTris { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<NgayNghi> NgayNghis { get; set; }
    }
}
