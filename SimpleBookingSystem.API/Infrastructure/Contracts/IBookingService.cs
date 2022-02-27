using SimpleBookingSystem.API.Infrastructure.Domain;
using SimpleBookingSystem.API.Models;
using System;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Infrastructure.Contracts
{
    public interface IBookingService
    {
        Task<CreateBookingResponseModel> BookResourceAsync(CreateBookingRequestModel createBookingRequestModel);
        public bool ValidateResourceBookingTimeConflicts(DateTimeOffset dateFrom, DateTimeOffset dateTo, long bookedQuantity, Resource resource);
    }
}
