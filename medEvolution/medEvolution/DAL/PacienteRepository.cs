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
    public class PacienteRepository: IPacienteRepository
    {
        private MedEvolutionDbContext _context = new MedEvolutionDbContext();

        public PacienteRepository(MedEvolutionDbContext pacienteContext)
        {
            this._context = pacienteContext;
        }

        public IEnumerable<Paciente> GetPacientes()
        {
            //return _context.Direcciones.ToList();
            return _context.Paciente.Include(p => p.Direccion).Include(p => p.Estado);
        }

        public Paciente GetPacienteByID(int? IdPaciente)
        {
            return _context.Paciente.Find(IdPaciente);
        }

        public void InsertPaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
        }

        public void DeletePaciente(int? IdPaciente)
        {
            Paciente paciente = _context.Paciente.Find(IdPaciente);
            _context.Paciente.Remove(paciente);
        }

        public void UpdatePaciente(Paciente paciente)
        {
            _context.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
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