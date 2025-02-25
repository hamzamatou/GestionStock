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
        [Required(ErrorMessage = "La date d'affectation est obligatoire.")]
        public DateTime DateAffectation { get; set; }

        [StringLength(200, ErrorMessage = "La description ne peut pas dépasser 200 caractères.")]
        public string Description { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "L'état est obligatoire.")]
        public int Etat { get; set; }

        [StringLength(100, ErrorMessage = "L'explication du système ne peut pas dépasser 100 caractères.")]
        public string SystemExp { get; set; }

        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range(0, 1, ErrorMessage = "La disponibilité doit être 0 ou 1.")]
        public int disponibilite { get; set; }

        public string marque { get; set; }

        public string idBonDentree { get; set; }

        public virtual BonDentre BonDachat { get; set; }

        public string codefiscale { get; set; }

        public Fournisseur fournisseur { get; set; }

        public ICollection<Affectation> Affectations { get; set; }
    }
}
