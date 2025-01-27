using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.MaterielService
{
    public class materielService : Imateriel
    {
        private readonly AsteelDBcontext _context;

        public materielService(AsteelDBcontext context)
        {
            _context = context;
        }

        public List<Materiel> GetMateriels()
        {
            return _context.Materiels.ToList();
        }

        public void Create(Materiel mat)
        {
            try
            {
                _context.Materiels.Add(mat);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("L'entrée existe déjà. Veuillez vérifier le code du matériel et réessayer.");

            }
        }
        public void DeleteMat(string idMat)
        {
            var affectations = _context.Affectations.Where(a => a.IdMat == idMat).ToList();
            _context.Affectations.RemoveRange(affectations);
            var materiel = _context.Materiels.Find(idMat);
            if (materiel != null)
            {
                _context.Materiels.Remove(materiel);
                _context.SaveChanges();
            }
        }

        public async Task<Materiel> UpdateMaterielAsync(Materiel materiel)
        {
            var existingMateriel = await _context.Materiels.FindAsync(materiel.IdMat);
            if (existingMateriel != null)
            {
                existingMateriel.DateAffectation = materiel.DateAffectation;
                existingMateriel.Description = materiel.Description;
                existingMateriel.Type = materiel.Type;
                existingMateriel.Etat = materiel.Etat;
                existingMateriel.SystemExp = materiel.SystemExp;
                existingMateriel.disponibilite = materiel.disponibilite;
                await _context.SaveChangesAsync();
                return existingMateriel;
            }
            return null;
        }
        public async Task<Materiel> GetMaterielAsync(string idMat)
        {
            var materiel = await _context.Materiels.FindAsync(idMat);
            return materiel;
        }

        public Materiel GetMateriel(string id)
        {
            return _context.Materiels.Find(id);
        }
        public List<Materiel> GetMaterielsByType(string type)
        {
            var materiels = string.IsNullOrEmpty(type)
                ? _context.Materiels.ToList() // Tous les matériels
                : _context.Materiels.Where(m => m.Type == type).ToList(); // Filtrer par type

            return materiels;

        }
    }
}
