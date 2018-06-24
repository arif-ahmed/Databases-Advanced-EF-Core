using System;
using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Event : Entity
    {
        public Event()
        {
            ParticipatedEventTeams = new List<TeamEvent>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid CreatorId { get; set; }

        // Navigational Properties
        public User Creator { get; set; }

        public ICollection<TeamEvent> ParticipatedEventTeams { get;set; }
    }
}