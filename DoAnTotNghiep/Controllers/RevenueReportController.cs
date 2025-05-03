using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueReportController : ControllerBase
    {
        private readonly IRevenueReportServicecs _reportService;

        public RevenueReportController(IRevenueReportServicecs reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("monthly-report/{year}")]
        //public async Task<ActionResult<List<MonthlyCustomerReportDto>>> GetMonthlyReport(int year)
        //{
        //    var report = await _reportService.GetMonthlyReportAsync(year);
        //    return Ok(report);
        //}
        [HttpGet("AllReport")]
        public async Task<ActionResult<List<int>>> GetAllInfoReport()
        {
            List<int> info = await _reportService.GenerateSummaryReport();
            return Ok(info);
        }
    }
}
