using System;
using System.Collections.Generic;

namespace IntroductionToEntityFramework.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
