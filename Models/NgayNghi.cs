using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhanSu2025.Models
{
    public class NgayNghi
    {
        [Key]
        public int MaNgayNghi { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public NhanVien? NhanVien { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }

        [Required]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(50)]
        public string? LoaiNghi { get; set; }

        [StringLength(255)]
        public string? LyDo { get; set; }

        [StringLength(50)]
        public string? TrangThai { get; set; }
    }
}