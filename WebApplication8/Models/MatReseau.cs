using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class MatReseau : Materiel
    {
        [Required(ErrorMessage = "L'adresse MAC est obligatoire.")]
        [StringLength(50, ErrorMessage = "L'adresse MAC ne doit pas dépasser 50 caractères.")]
        public string AdresseMac { get; set; }

        [Required(ErrorMessage = "Le nombre de ports est obligatoire.")]
        [Range(2, 96, ErrorMessage = "Le nombre de ports doit être compris entre 2 et 96.")]
        public int NombrePort { get; set; }
    }
}
