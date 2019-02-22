using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IOrdenExamenService
    {
        IEnumerable<OrdenExamen> GetAll();
        OrdenExamen GetById(int id);
        void Insert(OrdenExamen entity);
        void Update(OrdenExamen entity);
        void Delete(int id);
    }
}
