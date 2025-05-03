using DoAnTotNghiep.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Models
{
    public class Menu: BaseEntity
    {

        //[Key]
        //public int itemID { get; set; }                // Mã món

        [Required, StringLength(100)]
        public string name { get; set; }               // Tên món

        [Required]
        public menuCategory category { get; set; }     // Loại món

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }             // Giá

        public string description { get; set; }        // Mô tả

        public string imageURL { get; set; }           // Hình ảnh

        public ICollection<OrderDetail> orderDetails { get; set; }

        public enum menuCategory
        {
            [Display(Name = "Khai vị")]
            appetizer,
            [Display(Name = "Món chính")]
            mainCourse,
            [Display(Name = "Tráng miệng")]
            dessert,
            [Display(Name = "Đồ uống")]
            beverage
        }
    }
}
