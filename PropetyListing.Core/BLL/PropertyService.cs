using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PropertyListing.Core.DAL;
using PropertyListing.Core.Models;
using Newtonsoft.Json;
using PropertyListing.Core.Helpers;


namespace PropertyListing.Core.BLL
{
    public interface IPropertyService
    {
       Task<Properties> GetProperties(string url);

        Task<int> AddProperty(Property Property);
    }
    public class PropertyService : IPropertyService
    {
        private readonly IHttpClientWrapper<PropertiesJson> _httpClient;

        private readonly IPropertyRepository _productRepository;


        public PropertyService(IHttpClientWrapper<PropertiesJson> httpClient, IPropertyRepository productRepository)
        {
            _httpClient = httpClient;
            _productRepository = productRepository;
        }

        public async Task<Properties> GetProperties(string url)
        {
            var httpResponse = await _httpClient.Get(url);
            return await TransformProperty(httpResponse);
        }

        private async Task<Properties> TransformProperty(PropertiesJson propertiesJson)
        {
            var properties = new Properties(){properties = new List<Property>()};
            foreach (var propertyJson in propertiesJson.properties)
            {
                int year = 0;
                double price = 0.00;
                var property = new Property();
                property.Id = propertyJson.Id;
                property.Address = property.Address ??
                        $"{propertyJson.Address.Address1} {propertyJson.Address.City} {propertyJson.Address.State} {propertyJson.Address.Zip}";
                if (propertyJson.Physical != null)
                {
                    Int32.TryParse(propertyJson.Physical.YearBuilt, out year);
                    property.YearBuilt = year;
                }

                if (propertyJson.Financial != null)
                {
                    double.TryParse(propertyJson.Financial.ListPrice, out price);
                    property.ListPrice = Math.Round(price, 2);
                    double.TryParse(propertyJson.Financial.MonthlyRent, out price);
                    property.MonthlyRent = Math.Round(price, 2);
                    property.GrossYield = (property.MonthlyRent * 12) / property.ListPrice;
                }

              
                properties.properties.Add(property);
            };
            return properties;
        }

        public async Task<int> AddProperty(Property Property)
        {
            var property = await _productRepository.GetById(Property.Id);
            if (property == null)
            {
                return await _productRepository.AddProperty(Property);

            }
            else
            {
                return 0;
            }

        }
    }
}
