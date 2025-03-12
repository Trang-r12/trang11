using System.ComponentModel.DataAnnotations;

namespace QLNhanSu2025.Models
{
    public class ViTri
    {
        [Key]
        public int MaViTri { get; set; }

        [Required]
        [StringLength(100)]
        public string TenViTri { get; set; }

        [StringLength(255)]
        public string? MoTa { get; set; }
    }
}