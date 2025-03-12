using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhanSu2025.Models
{
    public class ChamCong
    {
        [Key]
        public int MaChamCong { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public NhanVien? NhanVien { get; set; }

        [Required]
        public DateTime Ngay { get; set; }

        public DateTime? ThoiGianVao { get; set; }

        public DateTime? ThoiGianRa { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? SoGioLam { get; set; }

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}