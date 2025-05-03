using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.implementations;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }
        
        // Lấy danh sách tất cả bàn ăn
        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllTables();
            return Ok(tables);
        }

        // Lấy thông tin bàn ăn theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(string id)
        {
            var table = await _tableService.GetTableById(id);
            if (table == null)
                return NotFound();
            return Ok(table);
        }

        // Tạo bàn ăn mới
        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] TableDto tableDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTable = await _tableService.CreateTable(tableDto);
            return CreatedAtAction(nameof(GetTableById), new { id = createdTable.id }, createdTable);
        }

        // Cập nhật thông tin bàn ăn
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(string id, [FromBody] TableDto tableDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTable = await _tableService.UpdateTable(id, tableDto);
            if (updatedTable == null)
                return NotFound();
            return Ok(updatedTable);
        }

        // Xóa bàn ăn
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(string id)
        {
            var result = await _tableService.DeleteTable(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
