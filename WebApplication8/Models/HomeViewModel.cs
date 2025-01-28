using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class HomeViewModel
    {
        public List<Materiel> Materials { get; set; }
        public List<Fournisseur> Suppliers { get; set; }
        public List<Affectation> Affectations { get; set; }
        public List<User> Users { get; set; }
        }

}
