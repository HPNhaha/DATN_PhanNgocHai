namespace DoAnTotNghiep.DTOs
{
    using DoAnTotNghiep.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class ReservationDto
    {
        public string? tableId { get; set; }
        public string? customerId { get; set; }
        public ReservationStatus status { get; set; }
        public DateTime reservationTime { get; set; }
    }
}
