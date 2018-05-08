using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}