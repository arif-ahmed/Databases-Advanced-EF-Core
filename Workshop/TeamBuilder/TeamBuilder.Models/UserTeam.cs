﻿using System;

namespace TeamBuilder.Models
{
    public class UserTeam : Entity
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}