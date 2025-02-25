using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class BonDentre
    {
        [Required(ErrorMessage = "L'ID du bon d'entrée est indispensable.")]
        public string idBonDentre { get; set; }

        [Required(ErrorMessage = "La date d'entrée est indispensable.")]
        [DataType(DataType.Date)]
        public DateTime DateEntree { get; set; }

        [StringLength(255, ErrorMessage = "La description ne peut pas dépasser 255 caractères.")]
        public string description { get; set; }

        public virtual ICollection<Materiel> Materiels { get; set; }
    }
}
