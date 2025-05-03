namespace DoAnTotNghiep.DTOs
{
    using DoAnTotNghiep.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class CustomerDto
    {
        public string? fullName { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public int loyaltyPoints { get; set; } = 0;
    }
}
