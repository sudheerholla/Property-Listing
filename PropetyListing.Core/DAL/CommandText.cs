using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyListing.Core.DAL
{
    public interface ICommandText
    {
      
        string AddProperty { get; }

        string GetById { get; }

    }
    public class CommandText : ICommandText
    {
        public string AddProperty => "Insert Into  Property (Id,Address, YearBuilt, ListPrice, MonthlyRent , GrossYield  ) Values (@Id, @Address, @YearBuilt,@ListPrice,@MonthlyRent,@GrossYield)";

        public string GetById => "Select Id,Address, YearBuilt, ListPrice, MonthlyRent , GrossYield from  Property where Id = @Id";
    }
}
