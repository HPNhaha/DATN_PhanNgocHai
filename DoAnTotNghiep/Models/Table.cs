using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoAnTotNghiep.Models.BaseEntities;
using System.Runtime.Serialization;

namespace DoAnTotNghiep.Models
{
    public class Table :BaseEntity
    {

        //[Key]
        //public int tableID { get; set; }               // Mã bàn

        [Required]
        public int tableNumber { get; set; }           // Số bàn

        [Required]
        public int capacity { get; set; }              // Sức chứa

        [Required]
        public TableStatus status { get; set; }        // Tình trạng

        public string location { get; set; }           // Vị trí

        public ICollection<Reservation> reservations { get; set; }
        public ICollection<Order> orders { get; set; }

        public enum TableStatus
        {
            Available,
            [Display(Name = "Đã đặt")]
            reserved,
            [Display(Name = "Đang phục vụ")]
            occupied
        }
    }
}
