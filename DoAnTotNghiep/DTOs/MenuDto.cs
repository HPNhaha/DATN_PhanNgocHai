using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DoAnTotNghiep.Models.Menu;

namespace DoAnTotNghiep.DTOs
{
    public class MenuDto
    {
        public string? name { get; set; }
        public menuCategory category {  get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public string? imageURL {  get; set; }
    }
}
