using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DoAnTotNghiep.DTOs
{
    public class UserDto
    {
        public string? fullName { get; set; }           // Họ và tên
        public string? email { get; set; }              // Email
        public string? phoneNumber { get; set; }        // Số điện thoại        
    }
}
