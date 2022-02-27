using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Infrastructure.Domain;
using SimpleBookingSystem.API.Infrastructure.Extensions;
using SimpleBookingSystem.API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly SimpleBookingSystemContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingService> _logger;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        public BookingService(SimpleBookingSystemContext context, IMailService mailService, IMapper mapper, ILogger<BookingService> logger, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<CreateBookingResponseModel> BookResourceAsync(CreateBookingRequestModel createBookingRequestModel)
        {
            string invalidMessage = await ValidateBooking(createBookingRequestModel);
            if (!string.IsNullOrEmpty(invalidMessage))
            {
                return new CreateBookingResponseModel(invalidMessage);
            }

            var booking = _mapper.Map<Booking>(createBookingRequestModel);
            _context.Add(booking);
            _context.SaveChanges();

            _mailService.SendMail(new MailRequest(_configuration.GetConnectionString("ToEmail"), "Booking", $"CREATED BOOKING WITH ID {booking.Id}"));
            return new CreateBookingResponseModel(booking.Id, $"Booking {booking.Id} is created successfully.");
        }
        private async Task<string> ValidateBooking(CreateBookingRequestModel createBookingRequestModel)
        {
            var resource = await _context.Resource.AsNoTracking().Include(s => s.Booking)
                                   .Where(s => s.Id == createBookingRequestModel.ResourceId).FirstOrDefaultAsync();
            //Make sure the BookedQuantity doesn't exceed the resource quantity in the first place
            if (resource.Quantity < createBookingRequestModel.BookedQuantity)
            {
                _logger.LogInformation($"BookResource BadRequest: BookedQuantity {createBookingRequestModel.BookedQuantity} exceeds the resource quantity {resource.Quantity}.");
                return "There is no available quanity of this resource for this booking.";
            }

            if (!ValidateResourceBookingTimeConflicts(createBookingRequestModel.DateFrom, createBookingRequestModel.DateTo, createBookingRequestModel.BookedQuantity, resource))
            {
                _logger.LogInformation($"BookResource BadRequest:There is no available quanity of this resource for this booking in this time range {createBookingRequestModel.DateFrom.ToString("yyyy-MM-dd")} - {createBookingRequestModel.DateTo.ToString("yyyy-MM-dd")}.");
                return "There is no available quanity of this resource for this booking in this time range.";
            }
            return null;
        }

        public bool ValidateResourceBookingTimeConflicts(DateTimeOffset dateFrom, DateTimeOffset dateTo, long bookedQuantity, Resource resource)
        {
            var existedBookings = resource.Booking.Where(s => (dateFrom >= s.DateFrom.ToDateTimeOffset() && dateTo <= s.DateTo.ToDateTimeOffset()) ||
                (dateTo >= s.DateFrom.ToDateTimeOffset() && dateTo <= s.DateTo.ToDateTimeOffset()))
                .ToList();
            var availableQuantity = resource.Quantity - existedBookings.Sum(s => s.BookedQuantity);
            if (existedBookings.Any() && availableQuantity < bookedQuantity)
            {
                return false; //Invalid
            }
            return true;
        }
    }
}