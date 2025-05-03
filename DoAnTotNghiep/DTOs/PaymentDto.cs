using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DoAnTotNghiep.Models.Payment;

namespace DoAnTotNghiep.DTOs
{
    public class PaymentDto
    {
        public decimal amount { get; set; }
        public PaymentMethod method { get; set; }
        public string? orderId { get; set; }
        public PaymentStatus status { get; set; }
    }
}
