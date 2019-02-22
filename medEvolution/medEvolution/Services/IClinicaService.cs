using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IClinicaService
    { 
        IEnumerable<Clinica> GetAll();
        Clinica GetById(int id);
        void Insert(Clinica entity);
        void Update(Clinica entity);
        void Delete(int id);
    }
}
