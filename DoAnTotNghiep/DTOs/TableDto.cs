using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static DoAnTotNghiep.Models.Table;
namespace DoAnTotNghiep.DTOs
{
    public class TableDto
    {
        public int tableNumber { get; set; }
        public int capacity { get; set; }
        public string location {  get; set; }
        public TableStatus status { get; set; } = TableStatus.Available;
        public List<OrderDto> Orders { get; set; }
    }
}
