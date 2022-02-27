using AutoMapper;
using SimpleBookingSystem.API.Infrastructure.Domain;
using SimpleBookingSystem.API.Models;

namespace SimpleBookingSystem.API.Infrastructure.Mapping
{
    public class ResourceMappingProfile : Profile
    {
        public ResourceMappingProfile()
        {
            CreateMap<Resource, ResourceModel>();
        }
    }
}