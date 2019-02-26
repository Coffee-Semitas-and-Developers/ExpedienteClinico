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

        public void Delete(string Colonia, string Pasaje_Calle, string Casa)
        {
            var dir = GetById(Colonia,Pasaje_Calle,Casa);
            _repository.Delete(dir);
        }

        public IEnumerable<Direccion> GetAll()
        {
           return _repository.GetAll();
        }

        public Direccion GetById(string Colonia, string Pasaje_Calle, string Casa)
        {
            var dir = new Direccion(Colonia, Pasaje_Calle,Casa);
            return _repository.GetById(dir);
            //return _repository.GetbyId(Colonia, Pasaje_Calle, Casa);
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