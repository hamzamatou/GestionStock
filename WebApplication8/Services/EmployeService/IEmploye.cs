using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
namespace WebApplication8.Services.EmployeService
{
    public interface IEmploye
    {
        public List<Employe> getEmployees();
        public Employe GetEmployee(string nom, string prenom, string mail);
        public Employe GetEmployeById(int id);
    }
}
