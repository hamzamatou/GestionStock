using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.BonDentreService
{
    public interface IBonDentre
    {
        public List<BonDentre> GetBonDentres();
        public void Create(BonDentre bonDentre);
        public void DeleteBonDentre(string id);
        public Task<BonDentre> UpdateBonDentreAsync(BonDentre bonDentre);
        public Task<BonDentre> GetBonDentreAsync(string id);
        public BonDentre GetBonDentre(string id);
       // public List<Fournisseur> SearchBySupplier(string searchTerm);
    }
}
