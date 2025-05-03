using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class OrderDto
    {
        public DateTime orderTime { get; set; }
        public string? customerId { get; set; }
        public string? tableId { get; set; }
        public string fullName { get; set; } = string.Empty;
        public int tableNumber { get; set; }
        public OrderStatus status { get; set; }
        public PaymentDto? payment { get; set; }
    }
}
