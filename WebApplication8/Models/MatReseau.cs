using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class MatReseau:Materiel
    {
        public string AdresseMac { get; set; }
        public int NombrePort { get;set; }
    }
}
