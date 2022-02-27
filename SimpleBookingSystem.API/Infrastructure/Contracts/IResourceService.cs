using SimpleBookingSystem.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Infrastructure.Contracts
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceModel>> GetResourcesAsync();
    }
}
