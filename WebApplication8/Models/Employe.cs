using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Employe
    {
        public int IdEmp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Affectation> relations { get; set; }
    }
}
