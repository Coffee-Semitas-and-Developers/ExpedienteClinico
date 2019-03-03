using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medEvolution.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Interfaz que define el método guardar para
        /// la unidad de trabajo que se instacíe al correr la aplicación
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
