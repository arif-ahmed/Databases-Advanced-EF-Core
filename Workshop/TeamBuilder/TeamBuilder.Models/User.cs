using System.Collections.Generic;
using TeamBuilder.Models.Enums;

namespace TeamBuilder.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int Aget { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation Properties
        public ICollection<Event> CreatedEvents { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }
        public ICollection<UserTeam> CreatedUserTeams { get; set; }
        public ICollection<Invitation> ReceivedInvitations { get; set; }

        public User()
        {
            CreatedUserTeams = new List<UserTeam>();
        }
    }
}