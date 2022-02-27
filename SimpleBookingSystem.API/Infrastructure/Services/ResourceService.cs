using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Infrastructure.Services
{
    public class ResourceService : IResourceService
    {
        private readonly SimpleBookingSystemContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ResourceService> _logger;
        public ResourceService(SimpleBookingSystemContext context, IMapper mapper, ILogger<ResourceService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<IEnumerable<ResourceModel>> GetResourcesAsync()
        {
            var resources= await _context.Resource.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ResourceModel>>(resources);
        }
    }
}