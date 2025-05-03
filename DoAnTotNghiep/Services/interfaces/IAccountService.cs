using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IAccountService
    {
        Task<Account> RegisterAccount(AccountDto accountDto);
        Task<Account?> UpdateAccount(string id, AccountDto accountDto);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account?> GetAccountById(string id);
        Task<Account> CreateAccount(AccountDto accountDto);
        Task<bool> DeleteAccount(string id);
    }
}
