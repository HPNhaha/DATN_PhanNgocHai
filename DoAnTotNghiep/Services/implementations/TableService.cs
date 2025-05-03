using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class TableService: ITableService
    {
        private readonly RestaurantContext _context;

        public TableService(RestaurantContext context)
        {
            _context = context;
        }

        // Lấy tất cả bàn ăn
        public async Task<IEnumerable<Table>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // Lấy bàn ăn theo ID
        public async Task<Table> GetTableById(string id)
        {
            return await _context.Tables.FirstOrDefaultAsync(t => t.id == id);
        }

        // Thêm mới bàn ăn
        public async Task<Table> CreateTable(TableDto tableDto)
        {
            var table = new Table
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Customer>(_context, "TBL"),
                tableNumber = tableDto.tableNumber,
                capacity = tableDto.capacity,
                status = tableDto.status,
                location = tableDto.location
            };
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table;
        }
        

        // Cập nhật thông tin bàn ăn
        public async Task<Table> UpdateTable(string id, TableDto tableDto)
        {
            var existingTable = await _context.Tables.FindAsync(id);
            if (existingTable == null)
                return null;

            existingTable.tableNumber = tableDto.tableNumber;
            existingTable.capacity = tableDto.capacity;
            existingTable.status = tableDto.status;
            existingTable.location = tableDto.location;

            await _context.SaveChangesAsync();
            return existingTable;
        }

        // Xóa bàn ăn
        public async Task<bool> DeleteTable(string id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
                return false;

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        } 
    }
}
