using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IDetalleExamenesService
    {
        IEnumerable<DetalleExamenes> GetAll();
        DetalleExamenes GetById(int id);
        void Insert(DetalleExamenes entity);
        void Update(DetalleExamenes entity);
        void Delete(int id);
    }
}
