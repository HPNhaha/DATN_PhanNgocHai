using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class CustomerService:ICustomerService
    {
        private readonly RestaurantContext _context;

        public CustomerService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(string id) {
            return await _context.Customers.FindAsync(id);
        }
        public async Task<Customer> CreateCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Customer>(_context, "CUS"),
                fullName = customerDto.fullName,
                phoneNumber = customerDto.phoneNumber,
                email = customerDto.email,
                loyaltyPoints = customerDto.loyaltyPoints
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(string id, CustomerDto customerDto)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return null;

            existing.fullName = customerDto.fullName;
            existing.phoneNumber = customerDto.phoneNumber;
            existing.email = customerDto.email;
            existing.loyaltyPoints = customerDto.loyaltyPoints;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return false;

            _context.Customers.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
