namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Account : BaseEntity
    {

        //[Key]
        //public int AccountID { get; set; }             // Mã tài khoản

        [ForeignKey("User")]
        public string userId { get; set; }                // FK → Users
        public User user { get; set; }

        [Required, StringLength(50)]
        public string userName { get; set; }           // Tên đăng nhập

        [Required]
        public string password { get; set; }       // Mật khẩu băm

        [Required]
        public RestaurantRole role { get; set; }       // Vai trò

        [Required]
        public bool isActive { get; set; } = true;     // Trạng thái

        public enum RestaurantRole
        {
            admin,
            [Display(Name = "Nhân viên phục vụ")]
            waiter,
            [Display(Name = "Đầu bếp")]
            chef,
            [Display(Name = "Quản lý cấp cao")]
            manager
        }
    }
}
