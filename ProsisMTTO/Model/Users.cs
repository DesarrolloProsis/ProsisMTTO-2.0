using System;
using System.Collections.Generic;

namespace ProsisMTTO.Model
{
    public partial class Users
    {
        public Users()
        {
            Dtctechnical = new HashSet<Dtctechnical>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Dtctechnical> Dtctechnical { get; set; }
    }
}
