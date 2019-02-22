using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IRecetaService
    {
        IEnumerable<Receta> GetAll();
        Receta GetById(int id);
        void Insert(Receta entity);
        void Update(Receta entity);
        void Delete(int id);
    }
}
