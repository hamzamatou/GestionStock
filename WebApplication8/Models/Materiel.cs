using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Materiel
    {
        [StringLength(50)]
        public string IdMat { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date d'achat is required.")]
        public DateTime DateAffectation { get; set; }
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }
        public string Type { get; set; }

        [Required(ErrorMessage = "État is required.")]
        public int Etat { get; set; }

        [StringLength(100, ErrorMessage = "System explanation cannot be longer than 100 characters.")]
        public string SystemExp { get; set; }

        [Required(ErrorMessage = "Quantité is required.")]
        [Range(0, 1, ErrorMessage = "La disponibilité doit être 0 ou 1.")]
        public int disponibilite { get; set; }
        public string marque { get; set; }
        public string idBonDachat { get; set; }
        public virtual BonDachat BonDachat { get; set; }
        public ICollection<Affectation> Affectations { get; set; }
        
      
    }
}
