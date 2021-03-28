using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyListing.Core.Models
{
    public class Property
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int YearBuilt { get; set; }

        [Required]
        public double ListPrice { get; set; }

        [Required]
        public double MonthlyRent { get; set; }

        [Required]
        public double GrossYield  { get; set; }
    }

    public class Properties
    {
        public List<Property> properties { get; set; }
    }
}
