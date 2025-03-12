using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhanSu2025.Models
{
    public class HopDong
    {
        [Key]
        public int MaHopDong { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public NhanVien? NhanVien { get; set; }

        [StringLength(50)]
        public string? LoaiHopDong { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Luong { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PhuCap { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Thuong { get; set; }

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}