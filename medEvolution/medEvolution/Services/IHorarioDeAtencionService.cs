using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IHorarioDeAtencionService
    {
        IEnumerable<Horario_De_Atencion> GetAll();
        Horario_De_Atencion GetById(int id);
        void Insert(Horario_De_Atencion entity);
        void Update(Horario_De_Atencion entity);
        void Delete(int id);
    }
}
