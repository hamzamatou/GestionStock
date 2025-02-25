using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.EmployeService
{
    public class employeService : IEmploye
    {
        private readonly AsteelDBcontext _context;

        public employeService(AsteelDBcontext context)
        {
            _context = context;
        }
        public Employe GetEmployeById(int id)
        {
            return _context.Employes.Find(id);
        }

        public Employe GetEmployee(string nom, string prenom, string mail)
        {
            return _context.Employes
                .FirstOrDefault(e => e.Nom == nom && e.Prenom == prenom && e.Email == mail);
        }

        public List<Employe> getEmployees()
        {
            return _context.Employes.ToList();
        }
    }
}
