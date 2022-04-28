using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Assignment_4.Models
{
    public partial class City
    {
        public City()
        {
            FoodEnforcements = new HashSet<FoodEnforcement>();
        }

        public string City1 { get; set; }
        public string StateCode { get; set; }

        public virtual State StateCodeNavigation { get; set; }
        public virtual ICollection<FoodEnforcement> FoodEnforcements { get; set; }
    }
}
