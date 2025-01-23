using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.FournisseurService
{
    public class fournisseurService : IFournisseur
    {
        private readonly AsteelDBcontext _context;

        public fournisseurService(AsteelDBcontext context)
        {
            _context = context;
        }
        public void Create(Fournisseur fournisseur)
        {
            _context.Fournisseurs.Add(fournisseur);
            _context.SaveChanges();
        }

        public void DeleteFournisseur(string id)
        {
            var fournisseur = _context.Fournisseurs.Find(id);
            if (fournisseur != null)
            {
                _context.Fournisseurs.Remove(fournisseur);
                _context.SaveChanges();
            }
        }

        public async Task<Fournisseur> GetFournisseurAsync(string id)
        {
            return await _context.Fournisseurs.FindAsync(id);
        }
        public Fournisseur GetFournisseur(string id)
        {
            return _context.Fournisseurs.Find(id);
        }
        public List<Fournisseur> GetFournisseurs()
        {
            return _context.Fournisseurs.ToList();
        }

        public async Task<Fournisseur> UpdateFournisseurAsync(Fournisseur fournisseur)
        {
            var existingFournisseur = await _context.Fournisseurs.FindAsync(fournisseur.CodeFiscal);
            if (existingFournisseur != null)
            {
                existingFournisseur.NomFor = fournisseur.NomFor;
                existingFournisseur.Adresse = fournisseur.Adresse;
                existingFournisseur.Pays = fournisseur.Pays;
                existingFournisseur.Mail = fournisseur.Mail;
                existingFournisseur.Tel = fournisseur.Tel;
                existingFournisseur.Principale = fournisseur.Principale;
                existingFournisseur.Statut = fournisseur.Statut;
                await _context.SaveChangesAsync();
                return existingFournisseur;
            }
            return null;
        }

    }
}

