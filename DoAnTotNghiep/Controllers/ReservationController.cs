using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // Lấy danh sách tất cả đặt bàn
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservation();
            return Ok(reservations);
        }

        // Lấy thông tin đặt bàn theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(string id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        // Tạo đặt bàn mới
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _reservationService.CreateReservation(reservationDto);
            return CreatedAtAction(nameof(GetReservationById), new { id = created.id }, created);
        }

        // Cập nhật đặt bàn
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(string id, [FromBody] ReservationDto reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _reservationService.UpdateReservation(id, reservationDto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // Xoá đặt bàn
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var result = await _reservationService.DeleteReservation(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
