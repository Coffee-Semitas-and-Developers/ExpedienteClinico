using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace medEvolution.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Esta clase implementa la interfaz para poder definir el método
        /// que nos permitirá aplicar una única Unidad De Trabajo (conexión con EF)
        /// en lugar de multiples por cada entidad instanciada
        /// ref.: https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
        /// https://www.c-sharpcorner.com/article/repository-and-unity-of-work-pattern-in-mvc/
        /// </summary>

        public readonly MedEvolutionDbContext _context; //Public dado que necesito acceder desde el Repository para conocer la Entity que usa la clase
        
        public UnitOfWork(MedEvolutionDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}