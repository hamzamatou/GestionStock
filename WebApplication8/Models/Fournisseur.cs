using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Fournisseur
    {
        [Required(ErrorMessage = "Le code fiscal est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le code fiscal ne doit pas dépasser 50 caractères.")]
        public string CodeFiscal { get; set; }

        [Required(ErrorMessage = "Le nom du fournisseur est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom du fournisseur ne doit pas dépasser 50 caractères.")]
        public string NomFor { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le pays est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le pays ne doit pas dépasser 50 caractères.")]
        public string Pays { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide.")]
     
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le numéro de téléphone ne doit pas dépasser 50 caractères.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Le statut principal est obligatoire.")]
        public int Principale { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire.")]
        public int Statut { get; set; }

        public virtual ICollection<Materiel> materiel { get; set; }
    }
}
