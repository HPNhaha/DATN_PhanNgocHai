using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<Table>> GetAllTables();
        Task<Table> GetTableById(string id);
        Task<Table> CreateTable(TableDto table);
        Task<Table> UpdateTable(string id,TableDto table);
        Task<bool> DeleteTable(string id);
    }
}
