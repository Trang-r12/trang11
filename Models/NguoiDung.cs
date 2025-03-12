using System.ComponentModel.DataAnnotations;

namespace QLNhanSu2025.Models
{
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = string.Empty; // Giá trị mặc định

        [Required]
        [StringLength(256)]
        public string MatKhauHash { get; set; } = string.Empty; // Giá trị mặc định

        [Required]
        [StringLength(50)]
        public string VaiTro { get; set; } = string.Empty; // Giá trị mặc định
    }
}