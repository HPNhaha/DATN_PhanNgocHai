using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.implementations
{
    public class ReservationService:IReservationService
    {
        private readonly RestaurantContext _context;

        public ReservationService(RestaurantContext context)
        {
            _context =context;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservation()
        {
            var reservation = await _context.Reservations
                 .Include(o => o.customer)
                 .Include(o => o.table)
                 .ToListAsync();

            return reservation.Select(o => new ReservationDto
            {
                reservationTime = o.reservationTime,
                customerId = o.customerId,
                tableId = o.tableId,
                status = o.status
            });
        }

        public async Task<ReservationDto?> GetReservationById(string id)
        {
            var reservation=await _context.Reservations
                .Include(o => o.customer)
                .Include(o => o.table)
                .FirstOrDefaultAsync(o=>o.id==id);
            if (reservation == null) return null;
            return new ReservationDto
            {
                reservationTime=reservation.reservationTime,
                customerId=reservation.customerId,
                tableId=reservation.tableId,
                status=reservation.status
            };
        }
        // Tạo đặt bàn mới
        public async Task<Reservation> CreateReservation(ReservationDto reservationDto)
        {
            var reservation = new Reservation
            {
                id = await IdGeneratorHelper.GenerateNextIdAsync<Reservation>(_context, "RSV"),
                tableId=reservationDto.tableId,
                status = reservationDto.status,
                customerId=reservationDto.customerId
            };
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<bool> DeleteReservation(string id)
        {
            var existing = await _context.Reservations.FindAsync(id);
            if (existing == null) return false;

            _context.Reservations.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Cập nhật thông tin đặt bàn
        public async Task<Reservation?> UpdateReservation(string id, ReservationDto reservationDto)
        {
            var existingReservation = await _context.Reservations.FindAsync(id);
            if (existingReservation == null)
            {
                return null;
            }
            existingReservation.tableId = reservationDto.tableId;
            existingReservation.status = reservationDto.status;
            existingReservation.customerId = reservationDto.customerId;
 
            await _context.SaveChangesAsync();
            return existingReservation;
        }
    }
}
