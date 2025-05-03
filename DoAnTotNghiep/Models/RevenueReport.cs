using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoAnTotNghiep.Models.BaseEntities;
using System.Runtime.Serialization;

namespace DoAnTotNghiep.Models
{
    public class RevenueReport :BaseEntity
    {

        //[Key]
        //public int reportID { get; set; }              // Mã báo cáo


        [Required]
        [EnumDataType(typeof(reportTypeEnum))]
        public reportTypeEnum reportType { get; set; }

        [Required]
        public string reportContent { get; set; }

        [Required]
        public DateTime generatedDate { get; set; } = DateTime.Now;
    }

    public enum reportTypeEnum
    {
        Daily,
        Weekly,
        Monthly,
        Annual,
        Summary
    }
}
