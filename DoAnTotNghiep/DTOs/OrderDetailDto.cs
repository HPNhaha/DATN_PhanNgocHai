using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class OrderDetailDto
    {
        public string? orderId { get; set; }
        public string? menuItemId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        //public List<MenuItemDto> menuItems { get; set; }
        public MenuDto? menuItem { get; set; }
    }
}
