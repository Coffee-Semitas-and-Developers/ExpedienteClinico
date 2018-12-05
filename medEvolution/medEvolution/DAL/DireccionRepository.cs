using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace medEvolution.DAL
{
    public class DireccionRepository: IDireccionRepository
    {
        private MedEvolutionDbContext _context = new MedEvolutionDbContext();

        public DireccionRepository(MedEvolutionDbContext direccionContext)
        {
            this._context = direccionContext;
        }

        public IEnumerable<Direccion> GetDirecciones()
        {
            //return _context.Direcciones.ToList();
            return _context.Direccion.Include(d => d.Municipio);
        }

        public Direccion GetDireccionByID(string IdColonia, string IdPasaje, string IdCasa)
        {
            return _context.Direccion.Find(IdColonia, IdPasaje, IdCasa);
        }

        public void InsertDireccion(Direccion direccion)
        {
            _context.Direccion.Add(direccion);
        }

        public void DeleteDireccion(string IdColonia, string IdPasaje, string IdCasa)
        {
            Direccion direccion = _context.Direccion.Find(IdColonia, IdPasaje, IdCasa);
            _context.Direccion.Remove(direccion);
        }

        public void UpdateDireccion(Direccion direccion)
        {
            _context.Entry(direccion).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}