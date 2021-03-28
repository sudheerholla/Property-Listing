using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyListing.Core.BLL;
using PropertyListing.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace PropertyListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {

        private IOptions<AppSettings> _settings;

        private IPropertyService _propertyService;

        public PropertiesController(IOptions<AppSettings> settings, IPropertyService propertyService)
        {
            this._settings = settings;
            this._propertyService = propertyService;
        }

        [HttpGet("")]
        public async Task<Properties> GetProperties()
        {
          return await this._propertyService.GetProperties(_settings.Value.PropertyListingUrl);
        }

        [HttpPost("")]
        public async Task<int> AddProperties(Property property)
        {
            return await this._propertyService.AddProperty(property);
        }
    }
}