using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(string id);
        Task<User> CreateUser(UserDto userDto);
        Task<User> UpdateUser(string id, UserDto userDto);
        Task<bool> DeleteUser(string id);
        Task<bool> CreateAccount(AccountDto accountDto);
    }
}
