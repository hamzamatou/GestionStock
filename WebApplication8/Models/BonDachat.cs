using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class BonDachat
    {
        public string idBonDachat { get; set; }
        public string CodeFournisseur { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public DateTime dateAchat { get; set; }
        public virtual ICollection<Materiel> Materiels { get; set; }
    }
}
