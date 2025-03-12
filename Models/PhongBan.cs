using System.ComponentModel.DataAnnotations;

namespace QLNhanSu2025.Models
{
    public class PhongBan
    {
        [Key]
        public int MaPhongBan { get; set; }

        [Required]
        [StringLength(100)]
        public string TenPhongBan { get; set; }

        [StringLength(255)]
        public string? MoTa { get; set; }
    }
}