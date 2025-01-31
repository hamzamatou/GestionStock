using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.FournisseurService
{
    public interface IFournisseur
    { 
     public List<Fournisseur> GetFournisseurs();
    public void Create(Fournisseur fournisseur);
    public void DeleteFournisseur(string idMat);
    public Task<Fournisseur> UpdateFournisseurAsync(Fournisseur fournisseur);
    public Task<Fournisseur> GetFournisseurAsync(string id);
    public Fournisseur GetFournisseur(string id);
     public List<Fournisseur> SearchBySupplier(string searchTerm);
}
}
