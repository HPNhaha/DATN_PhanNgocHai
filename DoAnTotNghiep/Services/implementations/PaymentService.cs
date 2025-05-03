using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;

namespace DoAnTotNghiep.Services.implementations
{
    public class PaymentService : IPaymentService
    {
        public Task<Payment> CreatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePayment(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> UpdatePayment(string id, Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
