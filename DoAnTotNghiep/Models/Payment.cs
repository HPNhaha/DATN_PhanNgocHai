namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Payment : BaseEntity
    {

        //[Key]
        //public int paymentID { get; set; }             // Mã thanh toán

        [ForeignKey("Order")]
        public string orderId { get; set; }               // FK → Orders
        public Order order { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal amount { get; set; }            // Số tiền

        [Required]
        public PaymentMethod method { get; set; }      // Phương thức

        [Required]
        public PaymentStatus status { get; set; }      // Trạng thái

        public enum PaymentMethod
        {
            [Display(Name = "Tiền mặt")]
            cash,
            [Display(Name = "Thẻ")]
            card,
            [Display(Name = "Chuyển khoản")]
            bankTransfer
        }

        public enum PaymentStatus
        {
            [Display(Name = "Chưa thanh toán")]
            unpaid,
            [Display(Name = "Đã thanh toán")]
            paid
        }
    }
}
