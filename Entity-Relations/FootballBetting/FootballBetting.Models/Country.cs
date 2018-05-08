using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }

        public Country()
        {
            Towns = new HashSet<Town>();
        }
    }
}