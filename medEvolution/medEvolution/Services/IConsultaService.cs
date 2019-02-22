using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IConsultaService
    {
        IEnumerable<Consulta> GetAll();
        Consulta GetById(int id);
        void Insert(Consulta entity);
        void Update(Consulta entity);
        void Delete(int id);
    }
}
