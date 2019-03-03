using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using medEvolution.Models.App;
using medEvolution.Data;
using medEvolution.Services;

namespace medEvolution.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly IRepository<Direccion> _repository;

        public DireccionService(IRepository<Direccion> repository)
        {
            this._repository = repository;
        }

        public void Delete(int id)
        {
            Direccion dir = _repository.GetById(id);
            _repository.Delete(dir);
        }

        public void Delete(Direccion dir)
        {
            _repository.Delete(dir);
        }

        public IEnumerable<Direccion> GetAll()
        {
           return _repository.GetAll();
        }

        public Direccion GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Direccion entity)
        {
            _repository.Insert(entity);
        }

        public void Update(Direccion entity)
        {
            _repository.Update(entity);
        }
    }
}