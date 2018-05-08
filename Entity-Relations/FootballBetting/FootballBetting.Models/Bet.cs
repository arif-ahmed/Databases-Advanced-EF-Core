using System;
using System.Collections.Generic;
using FootballBetting.Models.Enums;

namespace FootballBetting.Models
{
    public class Bet
    {
        // BetId, Amount, Prediction, DateTime, UserId, GameId
        public Guid BetId { get; set; }
        public decimal Amount { get; set; }
        public Prediction Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public ICollection<User> Users { get; set; }

        public Bet()
        {
            Users = new HashSet<User>();
        }
    }
}