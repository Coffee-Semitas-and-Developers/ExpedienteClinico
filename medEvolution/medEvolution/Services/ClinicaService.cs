﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using medEvolution.Data;
using medEvolution.Services;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    public class ClinicaService : IClinicaService
    {
        private readonly IRepository<Clinica> _repositoryClinica;
        private readonly IRepository<Direccion> _repositoryDireccion;

        public ClinicaService(IRepository<Clinica> repositoryClinica, IRepository<Direccion> repositoryDireccion)
        {
            this._repositoryClinica = repositoryClinica;
            this._repositoryDireccion = repositoryDireccion;
        }

        public void Delete(int id)
        {
            _repositoryClinica.Delete(id);
            
        }

        public IEnumerable<Clinica> GetAll()
        {
            return _repositoryClinica.GetAll();
        }

        public Clinica GetById(int id)
        {
            return _repositoryClinica.GetById(id);
        }

        public void Insert(Clinica entity)
        {
            _repositoryClinica.Insert(entity);
        }

        public void Update(Clinica entity)
        {
            _repositoryClinica.Update(entity);
        }
    }
}