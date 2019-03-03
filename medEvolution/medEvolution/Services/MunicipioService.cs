using medEvolution.Data;
using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Services
{
    public class MunicipioService : IMunicipioService
    {
        private UnitOfWork _unit;
        private readonly IRepository<Municipio> _repository;

        public MunicipioService(UnitOfWork unit, IRepository<Municipio> repository)
        {
            this._unit = unit;
            this._repository = repository;
        }

        public Municipio GetById(int cod)
        {
            return _repository.GetById(cod);
        }
       
        public IEnumerable<SelectListItem> GetMunicipiosEmpty()
        {
            List<SelectListItem> municipios = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return municipios;
        }

        public IEnumerable<Municipio> GetMunicipios()
        {
           return _repository.GetAll();
        }

        public IEnumerable<SelectListItem> GetMunicipiosByDepart(int cod)
        {
            if (cod != 0)
            {
                using (var context = _unit._context)
                {
                    IEnumerable<SelectListItem> municipios = context.Municipio.AsNoTracking()
                           .OrderBy(n => n.CodigoDepartamento)
                           .Where(n => n.CodigoDepartamento == cod)
                           .Select(n =>
                              new SelectListItem
                              {
                                  Value = n.CodigoMunicipio.ToString(),
                                  Text = n.NombreMun
                              }).ToList();
                    return new SelectList(municipios, "Value", "Text");
                }
            }
            return null;
        }
    }
}