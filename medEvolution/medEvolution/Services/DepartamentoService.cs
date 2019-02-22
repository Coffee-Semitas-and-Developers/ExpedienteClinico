using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medEvolution.Data;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    public class DepartamentoService: IDepartamentoService
    {
        private IRepository<Departamento> _repository;

        public DepartamentoService(IRepository<Departamento> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Departamento> GetDepartamentos()
        {
                return _repository.GetAll();
        }
    }
}