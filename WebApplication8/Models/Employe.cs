using System;
using System.Collections.Generic;

namespace WebApplication8.Models
{
    public class Employe
    {
        public int IdEmp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }  
        public string Tel { get; set; }  
        public DateTime DateEmbauche { get; set; }  
        public string Poste { get; set; } 
        public string Service { get; set; }
        public virtual ICollection<Affectation> relations { get; set; }
    }
}
