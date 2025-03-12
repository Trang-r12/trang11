using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhanSu2025.Models
{
    public class Luong
    {
        [Key]
        public int MaLuong { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public NhanVien? NhanVien { get; set; }

        [Required]
        public DateTime NgayApDung { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LuongCoBan { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TiLeBaoHiem { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TiLeThue { get; set; }
    }
}