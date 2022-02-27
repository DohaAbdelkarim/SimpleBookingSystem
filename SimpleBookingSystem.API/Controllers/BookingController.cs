using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Models;
using System;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateBookingResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BookResource(CreateBookingRequestModel createBookingModel)
        {
            var createBookingResponseModel = await _bookingService.BookResourceAsync(createBookingModel);
            if (createBookingResponseModel.BookingId != null)
            {
                return Ok(createBookingResponseModel);
            }
            else
            {
                return BadRequest(createBookingResponseModel);
            }
        }
    }
}