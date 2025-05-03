using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // Lấy tất cả món ăn

        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuitems = await _menuService.GetAllMenus();
            return Ok(menuitems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(string id)
        {
            var menuItem = await _menuService.GetMenuById(id);
            if (menuItem == null)
                return NotFound();
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] MenuDto MenuDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdmenu = await _menuService.CreateMenu(MenuDto);
            return CreatedAtAction(nameof(GetMenuById), new { id = createdmenu.id }, createdmenu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatemenu(string id, [FromBody] MenuDto menuDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedmenu = await _menuService.UpdateMenu(id, menuDto);
            if (updatedmenu == null)
                return NotFound();
            return Ok(updatedmenu);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemenu(string id)
        {
            var result = await _menuService.DeleteMenu(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
