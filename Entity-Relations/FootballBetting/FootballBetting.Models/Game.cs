﻿using System;
using System.Collections.Generic;
using FootballBetting.Models.Enums;

namespace FootballBetting.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }
        public Result Result { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public ICollection<Bet> Bets { get; set; }

        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }
    }
}