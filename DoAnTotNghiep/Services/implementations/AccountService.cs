using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantContext _context;

        public AccountService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccount(AccountDto accountDto)
        {
            var account = new Account
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Customer>(_context, "ACT"),
                userName = accountDto.userName,
                password = accountDto.password,
                role = accountDto.role,
                isActive = accountDto.isActive,
                userId= accountDto.userId
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }
        public async Task<bool> DeleteAccount(string id)
        {
            var existing = await _context.Accounts.FindAsync(id);
            if (existing == null) return false;

            _context.Accounts.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Account?> GetAccountById(string id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> RegisterAccount(AccountDto accountDto)
        {
            var newAccount = new Account
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Account>(_context, "ACNT"),
                userName = accountDto.userName,
                password = accountDto.password,
                role = accountDto.role,
                isActive = accountDto.isActive,
                userId = accountDto.userId,

            };
            await _context.Accounts.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }
        public async Task<Account?> UpdateAccount(string id, AccountDto accountDto)
        {
            var existingAccount = await _context.Accounts.FindAsync(id);
            if (existingAccount == null)
            {
                return null;
            }
            existingAccount.userName = accountDto.userName;
            existingAccount.role = accountDto.role;
            existingAccount.isActive = accountDto.isActive;
            existingAccount.password = accountDto.password;
            existingAccount.userId = accountDto.userId;


            await _context.SaveChangesAsync();
            return existingAccount;
        }
    }
}
