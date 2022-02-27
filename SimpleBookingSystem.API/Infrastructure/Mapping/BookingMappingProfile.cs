using AutoMapper;
using SimpleBookingSystem.API.Infrastructure.Domain;
using SimpleBookingSystem.API.Models;

namespace SimpleBookingSystem.API.Infrastructure.Mapping
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<CreateBookingRequestModel, Booking>()
             .ForMember(destination => destination.DateFrom, options => options.MapFrom(source => source.DateFrom.ToString("yyyy-MM-dd")))
             .ForMember(destination => destination.DateTo, options => options.MapFrom(source => source.DateTo.ToString("yyyy-MM-dd")));
        }
    }
}