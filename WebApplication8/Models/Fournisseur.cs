using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Fournisseur
    {
        public string CodeFiscal { get; set; }
        public string NomFor { get; set; }
        public string Adresse { get; set; }
        public string Pays { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public int Principale { get; set; }
        public int Statut { get; set; }
        public virtual ICollection<BonDachat> FrsMats { get; set; }
    }
}
