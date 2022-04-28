using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Assignment_4.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public string State1 { get; set; }
        public string StateCode { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
