using System;
using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public Guid CreatorId { get; set; }
        
        public virtual User Creator { get; set; }

        public ICollection<User> TeamMembers { get; set; }
        public ICollection<Event> ParticipatedEvents { get; set; }
        public ICollection<Invitation> Invitations { get; set; }

        public Team()
        {
            TeamMembers = new List<User>();
            ParticipatedEvents = new List<Event>();
            Invitations = new List<Invitation>();
        }
    }
}