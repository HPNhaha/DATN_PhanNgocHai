using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IRevenueReportServicecs
    {
        Task<IEnumerable<RevenueReport>> GetAllReports();
        Task<RevenueReport> GetReportById(string id);
        Task<RevenueReport> AddReport(RevenueReport reportDto);
        Task<RevenueReport> UpdateReport(string id, RevenueReport reportDto);
        Task<bool> DeleteReport(string id);

        Task<int> GetTotalCustomers();
        Task<int> GetTotalReservations();
        Task<int> GetTotalOrders();
        Task<decimal> GetTotalRevenue();
        Task<int> GetAvailableTables();

        Task<List<int>> GenerateSummaryReport();
        //Task<List<MonthlyCustomerReportDto>> GetMonthlyReportAsync(int year);
    }
}
