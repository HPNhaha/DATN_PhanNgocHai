using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IAuthService
    {
        Task<bool> GenerateJwtToken(Account account);
    }
}
