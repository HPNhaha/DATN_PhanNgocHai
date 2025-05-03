namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetail : BaseEntity
    {


        //[Key]
        //public int orderDetailID { get; set; }         // Mã chi tiết

        [ForeignKey("orderId")]
        public string orderId { get; set; }               // FK → Orders
        public Order order { get; set; }

        [ForeignKey("menuItemId")]
        public string menuItemId { get; set; }                // FK → MenuItem
        public Menu menuItem { get; set; }

        [Required]
        public int quantity { get; set; }              // Số lượng

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; } //đơn giá
    } 
}
