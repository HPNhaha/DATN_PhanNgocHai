using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(string id);
        Task<Menu> CreateMenu(MenuDto menuDto);
        Task<Menu> UpdateMenu(string id,MenuDto menuDto);
        Task<bool>  DeleteMenu(string id);
    }
}
