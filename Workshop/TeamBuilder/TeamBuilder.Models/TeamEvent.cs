using System;

namespace TeamBuilder.Models
{
    public class TeamEvent : Entity
    {
        public Guid TeamId { get; set; }
        public Guid EventId { get; set; }
    }
}