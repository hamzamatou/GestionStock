using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.BonDentreService
{
    public class BonDentreService : IBonDentre
    {
        private readonly AsteelDBcontext _context;

        public BonDentreService(AsteelDBcontext context)
        {
            _context = context;
        }

        public void Create(BonDentre bonDentre)
        {
            try
            {
                _context.BonDentres.Add(bonDentre);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                throw new Exception($"An error occurred while updating the entries: {innerException}", ex);
            }
        }


        public void DeleteBonDentre(string id)
        {
            var bonDentre = _context.BonDentres.Find(id);
            if (bonDentre != null)
            {
                _context.BonDentres.Remove(bonDentre);
                _context.SaveChanges();
            }
        }

        public async Task<BonDentre> GetBonDentreAsync(string id)
        {
            return await _context.BonDentres.FindAsync(id);
        }

        public BonDentre GetBonDentre(string id)
        {
            return _context.BonDentres.Find(id);
        }

        public List<BonDentre> GetBonDentres()
        {
            return _context.BonDentres.ToList();
        }

        public async Task<BonDentre> UpdateBonDentreAsync(BonDentre bonDentre)
        {
            var existingBonDentre = await _context.BonDentres.FindAsync(bonDentre.idBonDentre);
            if (existingBonDentre != null)
            {
                existingBonDentre.DateEntree = bonDentre.DateEntree;
                existingBonDentre.description = bonDentre.description;
                await _context.SaveChangesAsync();
                return existingBonDentre;
            }
            return null;
        }
    }
}
