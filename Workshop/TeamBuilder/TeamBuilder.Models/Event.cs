using System;

namespace TeamBuilder.Models
{
    public class Event : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid CreatorId { get; set; }

        // Navigational Properties
        public User User { get; set; }
    }
}