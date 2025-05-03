using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrder();
        Task<OrderDto?> GetOrderById(string id);
        Task<Order> CreateOrder(OrderDto order);
        Task<Order> UpdateOrder(string id,OrderDto order);
        Task<bool> DeleteOrder(string id);
        Task<IEnumerable<OrderDetail>> GetOrderDetail(string OrderId);
    }
}
