using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class MenuService : IMenuService
    {
        private readonly RestaurantContext _context;

        public MenuService(RestaurantContext context)
        {
            _context = context;
        }

        public MenuService()
        {
        }

        // Lấy danh sách tất cả món ăn
        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        // Lấy món ăn theo ID
        public async Task<Menu> GetMenuById(string id)
        {
            return await _context.Menus.FindAsync(id);
        }

        // Tạo món ăn mới
        public async Task<Menu> CreateMenu(MenuDto menuItemDto)
        {
            var menuItem = new Menu
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Menu>(_context, "ITEM"),  // Sinh ID duy nhất
                name = menuItemDto.name,
                description = menuItemDto.description,
                price = menuItemDto.price,
                category = menuItemDto.category,
                imageURL = menuItemDto.imageURL
            };

            _context.Menus.Add(menuItem);  // Thêm món ăn mới vào DbContext
            await _context.SaveChangesAsync();  // Lưu vào cơ sở dữ liệu
            return menuItem;  // Trả về món ăn vừa tạo
        }

        // Cập nhật món ăn
        public async Task<Menu> UpdateMenu(string id, MenuDto menuItemDto)
        {
            var existing = await _context.Menus.FindAsync(id);
            if (existing == null) return null;

            existing.name = menuItemDto.name;
            existing.description = menuItemDto.description;
            existing.price = menuItemDto.price;
            existing.category = menuItemDto.category;
            existing.imageURL = menuItemDto.imageURL;

            await _context.SaveChangesAsync();
            return existing;
        }

        // Xóa món ăn
        public async Task<bool> DeleteMenu(string id)
        {
            var existing = await _context.Menus.FindAsync(id);
            if (existing == null) return false;

            _context.Menus.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
