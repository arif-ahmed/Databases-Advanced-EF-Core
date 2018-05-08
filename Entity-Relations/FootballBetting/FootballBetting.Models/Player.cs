using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Player
    {
        // PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public Guid TeamId { get; set; }
        public Guid PositionId { get; set; }
        public bool IsInjured { get; set; }

        public Team Team { get; set; }
        public Position Position { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public Player()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }
    }
}