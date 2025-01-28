using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services.MaterielService;
namespace WebApplication8.Services.AffectationService
{
    public class affectationService : IAffectation
    {
        private readonly AsteelDBcontext _context;
        private readonly Imateriel _materielService;

        public affectationService(AsteelDBcontext context, Imateriel materielService)
        {
            _context = context;
            _materielService = materielService;
        }
        public void Create(Affectation affectation)
        {
            var materiel = _materielService.GetMateriel(affectation.IdMat);
            if (materiel.disponibilite == 1)
            {
                _context.Affectations.Add(affectation);
                materiel.disponibilite = 0;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Le matériel est déjà affecté et n'est pas disponible.");
            }
        }

        public void DeleteAffectation(string idMat, DateTime dateAffectation)
        {
            var materiel = _materielService.GetMateriel(idMat);
            materiel.disponibilite = 1;
            var affectation = GetAffectation(idMat, dateAffectation);
            _context.Affectations.Remove(affectation);
            _context.SaveChanges();
        }

        public Affectation GetAffectation(string idMat, DateTime dateAffectation)
        {
            return _context.Affectations.FirstOrDefault(a => a.IdMat == idMat && a.DateAffectation == dateAffectation);
        }

        public async Task<Affectation> GetAffectationAsync(string idMat, DateTime dateAffectation)
        {
            var affectation = await _context.Affectations
                .Include(a => a.UserAffecting)
                .Include(a => a.EmpAffected)
                .Include(a => a.Materiel)
                .FirstOrDefaultAsync(a => a.IdMat == idMat && a.DateAffectation == dateAffectation);
            return affectation;
        }

        public List<Affectation> GetAffectations()
        {
            return _context.Affectations
                  .Include(a => a.UserAffecting)
                  .Include(a => a.EmpAffected)
                  .Include(a => a.Materiel)
                  .ToList();
        }
        public async Task<Affectation> UpdateAffectationAsync(Affectation affectation)
        {
            var existingAffectation = await _context.Affectations
                .FirstOrDefaultAsync(a => a.IdMat == affectation.IdMat);

            if (existingAffectation != null)
            {
                _context.Affectations.Remove(existingAffectation);
                await _context.SaveChangesAsync(); // Save changes to remove the existing entity

                // Add the new entity with updated properties
                _context.Affectations.Add(affectation);
                await _context.SaveChangesAsync();

                return affectation;
            }

            return null;
        }
        public List<Affectation> SearchAffectations(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAffectations();
            }

            return _context.Affectations
                .Include(a => a.UserAffecting)
                .Include(a => a.EmpAffected)
                .Include(a => a.Materiel)
                .Where(a => a.UserAffecting.nom.Contains(searchTerm) ||
                            a.EmpAffected.Email.Contains(searchTerm)||
                            a.Materiel.Description.Contains(searchTerm)).ToList();
        }
    }
}
 
