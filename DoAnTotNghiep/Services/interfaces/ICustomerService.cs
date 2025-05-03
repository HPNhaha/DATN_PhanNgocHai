using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(string id);
        Task<Customer> CreateCustomer(CustomerDto customerDto);
        Task<Customer> UpdateCustomer(string id,CustomerDto customerDto);
        Task<bool> DeleteCustomer(string id);
    }
}
