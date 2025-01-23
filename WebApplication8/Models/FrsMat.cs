using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class FrsMat
    {
        public string IdMateriel { get; set; }
        public virtual Materiel Materiel { get; set; }
        public string CodeFournisseur { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public double PrixU { get; set; }
        public int Quantite { get; set; }
    }
}
