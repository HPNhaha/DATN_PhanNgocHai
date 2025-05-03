using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class OrderService: IOrderService
    {
        private readonly RestaurantContext _context;

        public OrderService(RestaurantContext context)
        {
            _context = context;
        }

        // Lấy tất cả đơn hàng
        public async Task<IEnumerable<OrderDto>> GetAllOrder() // lấy dữ liệu 
        {
            var orders = await _context.Orders
                .Include(o => o.customer)
                .Include(o => o.table)
                .ToListAsync();

            return orders.Select(o => new OrderDto
            {
                orderTime = o.orderTime,
                customerId = o.customerId,
                tableId = o.tableId,
                fullName = o.customer?.fullName ?? string.Empty,
                tableNumber = o.table?.tableNumber ?? 0,
                status = o.status,
            });
        }

        // Lấy đơn hàng theo ID
        public async Task<OrderDto?> GetOrderById(string id)
        {
            var order = await _context.Orders
                .Include(o => o.customer)
                .Include(o => o.table)
                //.Include(o => o.payment)
                .FirstOrDefaultAsync(o => o.id == id);

            if (order == null) return null;

            return new OrderDto
            {
                orderTime = order.orderTime,
                customerId = order.customerId,
                tableId = order.tableId,
                fullName = order.customer?.fullName ?? string.Empty,
                tableNumber = order.table?.tableNumber ?? 0,
                status = order.status
                //payment = order.Payment == null ? null : new PaymentDto
                //{
                //    paymentId = order.Payment.Id,
                //    amount = order.Payment.Amount
                //}
            };
        }

        // Thêm đơn hàng mới
        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Customer>(_context, "ORD"),
                customerId=orderDto.customerId,
                tableId=orderDto.tableId,
                //tableNumber=orderDto.tableNumber,
                //fullName=orderDto.fullName,
                status = orderDto.status
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        // Cập nhật đơn hàng
        public async Task<Order> UpdateOrder(string id, OrderDto orderDto)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
                return null;

            existingOrder.status = orderDto.status;
            
            await _context.SaveChangesAsync();
            return existingOrder;
        }
        
        // Xóa đơn hàng
        public async Task<bool> DeleteOrder(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetail(string OrderId)
        {
            var orderDetails = await _context.OrderDetails
                .Where(od => od.orderId == OrderId)
                .Include(od => od.menuItem)
                .ToListAsync();

            return orderDetails;
        }
    }
}
