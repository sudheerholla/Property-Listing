using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyListing.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace PropertyListing.Core.DAL
{
    public interface IPropertyRepository
    {
        Task<Property> GetById(int id);
        Task<int> AddProperty(Property property);
      
    }
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ICommandText _commandText;

        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public PropertyRepository(IConfiguration configuration, ICommandText commandText)
        {
            _commandText = commandText;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PropertyDB");

        }

        public async Task<int> AddProperty(Property property)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return await connection.ExecuteAsync(_commandText.AddProperty,
                        new
                        {
                            Id = property.Id,
                            Address = property.Address,
                            YearBuilt = property.YearBuilt,
                            ListPrice = property.ListPrice,
                            MonthlyRent = property.MonthlyRent,
                            GrossYield = property.GrossYield
                        });
                }
            }
            catch (Exception e)
            {
                return -1;
            }
          

        }

        public async Task<Property> GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return await connection.QueryFirstOrDefaultAsync<Property>(_commandText.GetById,
                        new
                        {
                            Id = id,
                           
                        });
                }
            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}
