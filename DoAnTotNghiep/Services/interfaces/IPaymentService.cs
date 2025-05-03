using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(string id);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(string id, Payment payment);
        Task<bool> DeletePayment(string id);
    }
}
