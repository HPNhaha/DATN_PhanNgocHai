using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.Models.BaseEntities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }  // Khóa chính

        [Required]
        public DateTime createdAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public string? createdBy { get; set; } //  người tạo

        public DateTime? updatedAt { get; set; } // Ngày cập nhật

        public string? updatedBy { get; set; } //  người cập nhật

        public DateTime? deletedAt { get; set; } // Ngày xóa (nếu có)

        [Required]
        public bool isDeleted { get; set; } = false; // Soft delete
    }

}
