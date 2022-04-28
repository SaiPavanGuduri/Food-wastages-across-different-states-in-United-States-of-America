using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Assignment_4.Models
{
    public partial class FoodEnforcement
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ProductDescription { get; set; }
        public string ReportDate { get; set; }
        public string Classification { get; set; }
        public string RecallNumber { get; set; }
        public string EventId { get; set; }
        public string PostalCode { get; set; }
        public string Status { get; set; }
        public string CodeInfo { get; set; }

        public virtual City CityNavigation { get; set; }
    }
}
