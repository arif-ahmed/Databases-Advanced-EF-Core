using System;

namespace TeamBuilder.Models
{
    public class Invitation : Entity
    {
        public Invitation()
        {
            IsActive = true;
        }

        public Guid InvitedUserId { get; set; }

        public Guid TeamId { get; set; }

        public bool IsActive { get; set; }
    }
}