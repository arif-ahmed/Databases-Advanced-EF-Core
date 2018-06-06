using System;

namespace TeamBuilder.Models
{
    public class Invitation : Entity
    {
        public Guid InvitedUserId { get; set; }

        public Guid TeamId { get; set; }

        public bool IsActivated { get; set; }

        public Invitation()
        {
            IsActivated = true;
        }
    }
}