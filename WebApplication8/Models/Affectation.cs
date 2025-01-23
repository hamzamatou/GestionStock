﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Affectation
    {
        public string IdUserAffecting { get; set; }
        public virtual User UserAffecting { get; set; }
        public int IdEmpAffected { get; set; }
        public virtual Employe EmpAffected { get; set; }
        public string IdMat { get; set; }
        public virtual Materiel Materiel { get; set; }
        public DateTime DateAffectation { get; set; }
        public string TypeAffectation { get; set; }
    }
}
