using System;

namespace FootballBetting.Models
{
    public class PlayerStatistic
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
    }
}