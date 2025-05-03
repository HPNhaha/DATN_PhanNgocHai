namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    public class Reservation:BaseEntity
    {
        //[Key]
        //public int reservationID { get; set; }

        [ForeignKey("Customer")]
        public string customerId { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("Table")]
        public string tableId { get; set; }
        public Table table { get; set; }

        [Required]
        public DateTime reservationTime { get; set; }        // Thời gian đặt

        [Required]
        public ReservationStatus status { get; set; }        // Trạng thái
    }

    public enum ReservationStatus
    {
        [EnumMember(Value = "Chờ xác nhận")]
        pending,

        [EnumMember(Value = "Đã xác nhận")]
        confirmed,

        [EnumMember(Value = "Đã hủy")]
        canceled
    }
}
