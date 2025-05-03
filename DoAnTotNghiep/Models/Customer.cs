namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer : BaseEntity
    {

        //[Key]
        //public int customerID { get; set; }                 // Mã khách hàng

        [Required]
        [StringLength(100)]
        public string fullName { get; set; }                // Họ và tên khách

        [Required]
        [Phone]
        [StringLength(15)]
        public string phoneNumber { get; set; }             // Số điện thoại

        [EmailAddress]
        [StringLength(100)]
        public string? email { get; set; }                  // Email

        [Required]
        public int loyaltyPoints { get; set; } = 0;         // Điểm tích lũy
    }
}
