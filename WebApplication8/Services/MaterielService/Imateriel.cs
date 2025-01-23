using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.MaterielService
{
     public interface Imateriel
    {
        public List<Materiel> GetMateriels();
        public void Create(Materiel mat);
        public void DeleteMat(string idMat);
        public Task<Materiel> UpdateMaterielAsync(Materiel materiel);
        public Task<Materiel> GetMaterielAsync(string idMat);
        public Materiel GetMateriel(string id);
    }
}
