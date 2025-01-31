using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Services
{
    public interface IMail
    {
        public void Envoyer_Click(string htmlMailBody, string comment, string mailto);
    }
}
