using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin,manager")] 
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllcustomers()
        {
            var customers = await _customerService.GetAllCustomer();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetcustomerById(string id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Createcustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdcustomer = await _customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetcustomerById), new { id = createdcustomer.id }, createdcustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecustomer(string id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedcustomer = await _customerService.UpdateCustomer(id, customerDto);
            if (updatedcustomer == null)
                return NotFound();
            return Ok(updatedcustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(string id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
