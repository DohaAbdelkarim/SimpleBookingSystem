using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController( IResourceService resourceService)
        {
            _resourceService = resourceService ?? throw new ArgumentNullException(nameof(resourceService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResourceModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var resources =await _resourceService.GetResourcesAsync();
            return Ok(resources);
        }
    }
}