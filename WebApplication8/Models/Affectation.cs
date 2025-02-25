using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Affectation
    {
        [Required(ErrorMessage = "L'ID de l'utilisateur affectant est indispensable.")]
        public string IdUserAffecting { get; set; }
        public virtual User UserAffecting { get; set; }

        [Required(ErrorMessage = "L'ID de l'employé affecté est indispensable.")]
        public int IdEmpAffected { get; set; }
        public virtual Employe EmpAffected { get; set; }

        [Required(ErrorMessage = "L'ID du matériel est indispensable.")]
        public string IdMat { get; set; }
        public virtual Materiel Materiel { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date d'affectation est indispensable.")]
        public DateTime DateAffectation { get; set; }

        public string TypeAffectation { get; set; }
    }
}
