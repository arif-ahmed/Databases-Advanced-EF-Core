using System;
using FootballBetting.Models.Enums;

namespace FootballBetting.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public Initials Initials { get; set; }
        public decimal Budget { get; set; }
        public Guid PrimaryKitColorId { get; set; }
        public Guid SecondaryKitColorId { get; set; }
        public Guid TownId { get; set; }

        public Color PrimaryKitColor { get; set; }
        public Color SecondaryKitColor { get; set; }

        public Town Town { get; set; }
    }
}