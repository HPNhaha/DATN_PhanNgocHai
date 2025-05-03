namespace DoAnTotNghiep.DTOs
{
    public class MonthlyCustomerReportDto
    {
        public int month { get; set; }
        public int year { get; set; }
        public int numberOfAdmissions { get; set; }
        public int numberOfDischarges { get; set; }
    }
}
