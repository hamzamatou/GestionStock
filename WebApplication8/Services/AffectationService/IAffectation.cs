using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.AffectationService
{
    public interface IAffectation
    {
        public List<Affectation> GetAffectations();
        public void Create(Affectation affectation);
        public void DeleteAffectation(string idMat, DateTime dateAffectation);
        public Task<Affectation> UpdateAffectationAsync( Affectation affectation);
        public Task<Affectation> GetAffectationAsync(string idMat, DateTime dateAffectation);
        public Affectation GetAffectation(string idMat, DateTime dateAffectation);
        public List<Affectation> SearchAffectations(string searchTerm);
    }
}
