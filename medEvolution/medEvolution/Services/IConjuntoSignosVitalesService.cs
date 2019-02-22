using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medEvolution.Services
{
    interface IConjuntoSignosVitalesService
    {
        IEnumerable<ConjuntoSignosVitales> GetAll();
        ConjuntoSignosVitales GetById(int id);
        void Insert(ConjuntoSignosVitales entity);
        void Update(ConjuntoSignosVitales entity);
        void Delete(int id);
    }
}
