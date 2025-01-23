using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class User : IdentityUser
    {
        public string nom {get;set;}
        public string prenom { get; set; }
        public string Address { get; set; }
        public DateTime datecreation   { get; set; }
        public virtual ICollection<Affectation> Affectations { get; set; }
        public string RoleId { get; set; }
        public virtual IdentityRole Role { get; set; }
    }
}
