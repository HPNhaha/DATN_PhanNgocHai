using static DoAnTotNghiep.Models.Account;

namespace DoAnTotNghiep.DTOs
{
    public class AccountDto
    {
        public string userName { get; set; }

        public string password { get; set; }

        public RestaurantRole role { get; set; }  // Sử dụng Enum
        public bool isActive { get; set; } = true;
        public string userId { get; set; }
    }
}
