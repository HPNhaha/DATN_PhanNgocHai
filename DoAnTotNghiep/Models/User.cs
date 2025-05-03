using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoAnTotNghiep.Models.BaseEntities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DoAnTotNghiep.Models
{
    public class User : BaseEntity
    {

        //[Key]
        //public int userID { get; set; }                // Mã người dùng

        [Required, StringLength(100)]
        public string fullName { get; set; }           // Họ và tên

        [Required, EmailAddress, StringLength(100)]
        public string email { get; set; }              // Email

        [Required, Phone, StringLength(15)]
        public string phoneNumber { get; set; }        // Số điện thoại
    }
}
