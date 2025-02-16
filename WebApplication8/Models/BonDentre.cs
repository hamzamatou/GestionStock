using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class BonDentre
    {
        public string idBonDentre { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEntree { get; set; }
        public string description { get; set; }
        public virtual ICollection<Materiel> Materiels { get; set; }
    }
}
