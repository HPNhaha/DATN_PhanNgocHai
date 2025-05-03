using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DoAnTotNghiep.Models
{
    public class Order: BaseEntity
    {

        //[Key]
        //public int orderID { get; set; }

        
        [ForeignKey("customerId")]
        public string customerId { get; set; }
        public Customer? customer { get; set; }
        [ForeignKey("tableId")]
        public string tableId { get; set; }
        public Table? table { get; set; }

        [Required]
        public DateTime orderTime { get; set; } = DateTime.Now; // Thời gian

        [Required]
        public OrderStatus status { get; set; } = OrderStatus.pending; // Trạng thái

        public ICollection<OrderDetail> orderDetails { get; set; }
    }

    public enum OrderStatus
    {
        [EnumMember(Value = "Chờ xử lý")]
        pending,

        [EnumMember(Value = "Đang chế biến")]
        processing,

        [EnumMember(Value = "Hoàn thành")]
        completed
    }
}
