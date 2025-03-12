using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhanSu2025.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        [Required]
        [StringLength(50)]
        public string Ho { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string? GioiTinh { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        [StringLength(20)]
        public string? SoDienThoai { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public int? MaPhongBan { get; set; }
        [ForeignKey("MaPhongBan")]
        public PhongBan? PhongBan { get; set; }

        public int? MaViTri { get; set; }
        [ForeignKey("MaViTri")]
        public ViTri? ViTri { get; set; }
    }
}