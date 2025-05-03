using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class UserService : IUserService
    {

        private readonly RestaurantContext _context;
        public UserService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
                return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        

        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = new User
            {
                //id = await IdGeneratorHelper.GenerateNextIdAsync<Customer>(_context, "USER"),
                fullName = userDto.fullName,
                email = userDto.email,
                phoneNumber = userDto.phoneNumber,
                // Thêm các thuộc tính khác nếu có
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(string id, UserDto userDto)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return null;

            existing.fullName = userDto.fullName;
            existing.email = userDto.email;
            existing.phoneNumber = userDto.phoneNumber;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return false;

            _context.Users.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CreateAccount(AccountDto accountDto)
        {
            // Kiểm tra userId có tồn tại không
            var user = await _context.Users.FindAsync(accountDto.userId);
            if (user == null)
                return false;

            // Kiểm tra trùng username
            var existingAccount = await _context.Accounts
                .AnyAsync(a => a.userName == accountDto.userName);
            if (existingAccount)
                return false;

            var newAccount = new Account
            {
                userId = accountDto.userId,
                userName = accountDto.userName,
                password = accountDto.password, // Có thể mã hóa sau
                role = accountDto.role,
                isActive = true
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
