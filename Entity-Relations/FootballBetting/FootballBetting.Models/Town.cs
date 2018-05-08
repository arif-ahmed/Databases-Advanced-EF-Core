using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Town
    {
        public Guid TownId { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public ICollection<Team> Teams { get; set; }
        public Country Country { get; set; }

        public Town()
        {
            Teams = new HashSet<Team>();
        }
    }
}