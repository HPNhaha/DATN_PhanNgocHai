using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using DoAnTotNghiep.Models;
using static DoAnTotNghiep.Models.Table;

namespace DoAnTotNghiep.Services.implementations
{
    public class RevenueReportService : IRevenueReportServicecs
    {
        private readonly RestaurantContext _context;
        public RevenueReportService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RevenueReport>> GetAllReports()
        {
            return await _context.RevenueReports.ToListAsync();
        }

        public async Task<RevenueReport> GetReportById(string id)
        {
            return await _context.RevenueReports.FirstOrDefaultAsync(r => r.id == id);
        }
        //public async Task<List<MonthlyCustomerReportDto>> GetMonthlyReportAsync(int year)
        //{
        //    var report = await Task.Run(() =>
        //        Enumerable.Range(1, 12).Select(month => new MonthlyCustomerReportDto
        //        {
        //            month = month,
        //            year = year,
        //            numberOfAdmissions = _context.Customers
        //                .Count(p => p.DateOfAdmission.Year == year && p.DateOfAdmission.Month == month),
        //            numberOfDischarges = _context.Customers
        //                .Count(p => p.DischagreDate.Year == year && p.DischagreDate.Month == month)
        //        }).ToList()
        //    );

        //    return report;
        //}
        public async Task<RevenueReport> AddReport(RevenueReport report)
        {
            _context.RevenueReports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<RevenueReport> UpdateReport(string id, RevenueReport report)
        {
            var existingReport = await _context.RevenueReports.FindAsync(id);
            if (existingReport == null)
                return null;

            existingReport.reportType = report.reportType;
            existingReport.reportContent = report.reportContent;
            existingReport.generatedDate = report.generatedDate;

            await _context.SaveChangesAsync();
            return existingReport;
        }

        public async Task<bool> DeleteReport(string id)
        {
            var report = await _context.RevenueReports.FindAsync(id);
            if (report == null) return false;

            _context.RevenueReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalCustomers()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<int> GetTotalReservations()
        {
            return await _context.Reservations.CountAsync();
        }

        public async Task<int> GetTotalOrders()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetTotalRevenue()
        {
            return await _context.Payments.SumAsync(p => p.amount);
        }

        public async Task<int> GetAvailableTables()
        {
            return await _context.Tables.CountAsync(t => t.status == TableStatus.Available);
        }

        public async Task<List<int>> GenerateSummaryReport()
        {
            int totalCustomers = await GetTotalCustomers();
            int totalReservations = await GetTotalReservations();
            int totalOrders = await GetTotalOrders();
            int availableTables = await GetAvailableTables();
            decimal totalRevenue = await GetTotalRevenue();

            List<int> result = new List<int>();
            result.Add(await _context.Customers.CountAsync());
            result.Add(await _context.Reservations.CountAsync());
            result.Add(await _context.Orders.CountAsync());
            result.Add(await _context.Tables.CountAsync());
            result.Add(totalCustomers);
            result.Add(totalReservations);
            result.Add(totalOrders);
            result.Add(availableTables);


            var report = new RevenueReport
            {
                reportType = reportTypeEnum.Summary,
                //reportContent = result,
                generatedDate = DateTime.Now
            };
            return result;
        }
    }
}
