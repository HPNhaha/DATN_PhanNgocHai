using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllReservation();
        Task<ReservationDto?> GetReservationById(string id);
        Task<Reservation> CreateReservation(ReservationDto reservationDto);
        Task<Reservation> UpdateReservation(string id, ReservationDto reservationDto);
        Task<bool> DeleteReservation(string id);
    }
}
